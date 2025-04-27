from flask import Flask
from uuid import uuid4
import sys

from Blockchain import Blockchain
from SistemaBiometrico import SistemaBiometrico
from routes import registrar_rutas

app = Flask(__name__)
node_address = str(uuid4()).replace('-', '')

blockchain = Blockchain()
sistemaBiometrico = SistemaBiometrico()

registrar_rutas(app, blockchain, sistemaBiometrico)

@app.route('/')
def home():
    return ""

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Uso: python node.py <puerto>")
        sys.exit(1)

    try:
        port = int(sys.argv[1])
        if not (5000 <= port <= 5010):
            raise ValueError("El puerto debe estar entre 5000 y 5010.")
    except ValueError as e:
        print(f"Error: {e}")
        sys.exit(1)

    print(f"Ejecutando servidor en el puerto {port}")
    app.run(host='0.0.0.0', port=port)
