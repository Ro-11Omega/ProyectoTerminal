import datetime
import json
import hashlib
from Block import Block
from Transaction import Transaction
from urllib.parse import urlparse
import requests

class Blockchain:
    def __init__(self):
        self.chain = []
        self.transacciones = []
        self.block_genesis()
        self.nodos = set()

    def add_nodo(self, dir):
        parsed_url = urlparse(dir)
        self.nodos.add(parsed_url.netloc)
    
    def is_empty(self):
        return len(self.chain) == 0
    
    def hash_block(self, block):
        try:
            block_string = json.dumps(block.to_dict(), sort_keys=True).encode()
            return hashlib.sha256(block_string).hexdigest()
        except Exception as e:
            print(f"Error al calcular el hash del bloque: {e}")
            return None   
    
    def get_last_block(self):
        return self.chain[-1]
    
    def block_genesis(self):
        print("Creando el bloque génesis...")
        transaction = Transaction("", "", 0, "", "")
        index = 1
        timestamp=str(datetime.datetime.now())
        proof = 1
        hash_previo='0'
        
        block = Block(index,timestamp,proof,hash_previo,transaction.to_dict())
        self.chain.append(block)
        return block

    def create_block(self, proof_previus, hash_block_previus, transactions):
        if self.is_empty():
            return self.block_genesis()

        index = len(self.chain) + 1
        timestamp = str(datetime.datetime.now())
        proof = proof_previus
        hash_previo = hash_block_previus

        transactions_dict = [transaction.to_dict() for transaction in transactions]


        block = Block(index, timestamp, proof, hash_previo, transactions_dict)
        self.chain.append(block)
        return block


    def create_transaction(self, matricula_hash, salt, iteraciones, nonce, dato_biometrico):
        transaction = Transaction(matricula_hash, salt, iteraciones, nonce, dato_biometrico)
        self.transacciones.append(transaction)
        return transaction


    def proof_of_work(self, previous_proof):
        new_proof = 1
        while True:
            if previous_proof % 2 == 0:
                operacion = (new_proof ** 2 + previous_proof ** 2)
            else:
                operacion = (new_proof ** 2 - previous_proof ** 2)

            hash_operacion = hashlib.sha256(str(operacion).encode()).hexdigest()
            if hash_operacion[:4] == '0000':
                return new_proof
            new_proof += 1      


    def new_chain(self):
        network = self.nodos
        mas_larga = None
        longitud_max = len(self.chain)

        for node in network:
            response = requests.get(f'http://{node}/get_chain')
            if response.status_code == 200:
                longitud = response.json()['length']
                chain = response.json()['chain']

                if longitud > longitud_max and self.valid(chain):
                    longitud_max = longitud
                    mas_larga = chain

        if mas_larga:
            self.chain = [Block(**block) if isinstance(block, dict) else block for block in mas_larga]
            return True

        return False
    
    
    def valid(self, chain):
        bloque_previo = chain[0]
        if isinstance(bloque_previo, dict):
            bloque_previo = Block(**bloque_previo)

        index_block = 1

        while index_block < len(chain):
            block = chain[index_block]
            if isinstance(block, dict):
                block = Block(**block)

            if block.hash_previo != self.hash_block(bloque_previo):
                return False

            prueba_previa = bloque_previo.proof
            proof = block.proof

            if prueba_previa % 2 == 0:
                operacion = (proof ** 2 + prueba_previa ** 2)
            else:
                operacion = (proof ** 2 - prueba_previa ** 2)

            hash_operacion = hashlib.sha256(str(operacion).encode()).hexdigest()

            if hash_operacion[:4] != '0000':
                return False

            bloque_previo = block
            index_block += 1

        return True
    
    def buscar_transaccion_por_matricula_hash(self, matricula_hash):
        for block in self.chain:
            transactions = block.transactions if isinstance(block.transactions, list) else [block.transactions]

            for transaccion in transactions:
                if isinstance(transaccion, dict):
                    if transaccion.get("matricula_hash") == matricula_hash:
                        return transaccion
        return None






