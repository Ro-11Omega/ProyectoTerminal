from flask import jsonify, request
from Conexion import Conexion
import time

def registrar_rutas(app, blockchain, sistemaBiometrico):
    db = Conexion()
	
    @app.route('/simulate_blocks/<int:num_blocks>', methods=['GET'])
    def simulate_blocks(num_blocks):
        tiempos = []
        matricula, fingerprint_data = db.get_datoBiometrico()
        if fingerprint_data is None or matricula is None:
            return jsonify({'message': 'No se pudo obtener el contenido en la base de datos.'}), 404
        for i in range(num_blocks):
            datos_cifrados = sistemaBiometrico.cifrado_AES(fingerprint_data, matricula)
            biometric_data = datos_cifrados['biometric_data']
            nonce = datos_cifrados['nonce']
            salt = datos_cifrados['salt']
            iteraciones = datos_cifrados['iteraciones']

            matricula_hash = sistemaBiometrico.hash_matricula(matricula)

            bloque_previo = blockchain.get_last_block()
            prueba_anterior = bloque_previo.proof
            inicio = time.time()
            new_proof = blockchain.proof_of_work(prueba_anterior)
            fin = time.time()
            tiempos.append(fin - inicio)
            hash_previo = blockchain.hash_block(bloque_previo)
            transaction = blockchain.create_transaction(matricula_hash, salt, iteraciones, nonce, biometric_data)
            blockchain.create_block(new_proof, hash_previo, [transaction])

        promedio = sum(tiempos) / len(tiempos) if tiempos else 0
        return jsonify({
            'message': f'Se simularon {len(tiempos)} bloques correctamente.',
            'tiempo_total': sum(tiempos),
            'tiempo_promedio': promedio
        }), 200


    @app.route('/add_block', methods=['GET'])
    def add_block():
        update()
        fingerprint_data, matricula = db.get_datoBiometrico()
        if fingerprint_data is None or matricula is None:
            return jsonify({'message': 'No se pudo obtener el contenido en la base de datos.'}), 404

        datos_cifrados = sistemaBiometrico.cifrado_AES(fingerprint_data, matricula)
        biometric_data = datos_cifrados['biometric_data']
        nonce = datos_cifrados['nonce']
        salt = datos_cifrados['salt']
        iteraciones = datos_cifrados['iteraciones']
        matricula_hash = sistemaBiometrico.hash_matricula(matricula)

        if blockchain.buscar_transaccion_por_matricula_hash(matricula_hash):
            return jsonify({'message': 'Ya existe un registro con esa matrícula.'}), 409

        bloque_previo = blockchain.get_last_block()
        prueba_anterior = bloque_previo.proof
        new_proof = blockchain.proof_of_work(prueba_anterior)
        hash_previo = blockchain.hash_block(bloque_previo)
        transaction = blockchain.create_transaction(matricula_hash, salt, iteraciones, nonce, biometric_data)
        new_block = blockchain.create_block(new_proof, hash_previo, [transaction])

        contenido = {
            'index': new_block.index,
            'timestamp': new_block.timestamp,
            'proof': new_block.proof,
            'hash_previo': new_block.hash_previo,
            'transactions': new_block.transactions
        }

        return jsonify(contenido), 200


    @app.route('/get_block', methods=['GET'])
    def get_block():
        update()
        matricula = db.get_matricula()
        if not matricula:
            return jsonify({"error": "No se pudo obtener la matrícula desde el sistema"}), 404

        matricula_hash = sistemaBiometrico.hash_matricula(matricula)
        transaccion = blockchain.buscar_transaccion_por_matricula_hash(matricula_hash)
        if not transaccion:
            return jsonify({"error": "Transacción no encontrada para la matrícula proporcionada"}), 404

        dato = {
            "salt": transaccion.get("salt"),
            "nonce": transaccion.get("nonce"),
            "iteraciones": transaccion.get("iteraciones"),
            "biometric_data": transaccion.get("biometric_data")
        }

        if all(dato.values()):
            dato_biometrico = sistemaBiometrico.descifrado_AES(
                dato['biometric_data'], matricula, dato['salt'], dato['nonce'], dato['iteraciones']
            )
            db.add_datoBiometrico(dato_biometrico, matricula)
            return jsonify(dato), 200
        else:
            return jsonify({"error": "Campos faltantes en la transacción"}), 400


    @app.route('/get_chain', methods=['GET'])
    def get_chain():
        response = {
            'chain': [block.to_dict() for block in blockchain.chain],
            'length': len(blockchain.chain)
        }
        return jsonify(response), 200


    @app.route('/is_valid', methods=['GET'])
    def if_valid():
        resultado = blockchain.valid(blockchain.chain)
        response = {'message': 'El Blockchain es válido' if resultado else 'El Blockchain no es válido!'}
        return jsonify(response), 200


    @app.route('/add_transaction', methods=['POST'])
    def add_transaction():
        json = request.get_json()
        transaction_keys = ['matricula_hash', 'salt', 'iteraciones', 'nonce', 'biometric_data']

        if not all(key in json for key in transaction_keys):
            return 'Algun elemento de la transacción está faltando', 400

        index = blockchain.create_transaction(
            json['matricula_hash'], json['salt'], json['iteraciones'], json['nonce'], json['biometric_data']
        )
        response = {'message': f'La transacción será añadida al bloque {index}'}
        return jsonify(response), 201


    @app.route('/connect', methods=['POST'])
    def connect():
        json = request.get_json()
        nodos = json.get('nodes')
        if nodos is None:
            return "No se proporcionaron nodos", 401
        for nodo in nodos:
            blockchain.add_nodo(nodo)
        response = {'message': "Nodos conectados", 'total_nodes': list(blockchain.nodos)}
        return jsonify(response), 201


    @app.route('/update', methods=['GET'])
    def update():
        cadenaNueva = blockchain.new_chain()
        response = {
            'message': 'Los nodos tenían diferentes cadenas.' if cadenaNueva else 'Cadena actualizada.',
            'new_chain': [block.to_dict() for block in blockchain.chain] if cadenaNueva else 'Cadena no reemplazada'
        }
        return jsonify(response), 200
