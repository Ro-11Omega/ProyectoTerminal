import hashlib
import random
from Crypto.Cipher import AES
from Crypto.Random import get_random_bytes


class SistemaBiometrico:
    def __init__(self):
        self.salt_size = 16 

    def generar_salt(self):
        return get_random_bytes(self.salt_size)
    
    def repeticiones(self):
        return random.randint(100000, 500000)

    def key_AES(self, matricula, salt, iteraciones):
        if not isinstance(matricula, str):
            matricula = str(matricula)
        return hashlib.pbkdf2_hmac('sha256', matricula.encode('utf-8'), salt, iteraciones, dklen=16)

    def cifrado_AES(self, biometric_data: str, matricula: str):
        salt = self.generar_salt()
        iteraciones = self.repeticiones()
        derived_key = self.key_AES(matricula, salt, iteraciones)

        cipher = AES.new(derived_key, AES.MODE_EAX)
        nonce = cipher.nonce

        if isinstance(biometric_data, str):
            biometric_data = biometric_data.encode('utf-8')

        ciphertext, tag = cipher.encrypt_and_digest(biometric_data)

        return {
            'biometric_data': ciphertext.hex(),
            'nonce': nonce.hex(),
            'salt': salt.hex(),
            'iteraciones': iteraciones
        }

    def descifrado_AES(self, encrypted_data, matricula, salt, nonce, iteraciones):
        try:
            salt = bytes.fromhex(salt) if isinstance(salt, str) else salt
            nonce = bytes.fromhex(nonce) if isinstance(nonce, str) else nonce
            ciphertext = bytes.fromhex(encrypted_data) if isinstance(encrypted_data, str) else encrypted_data

            derived_key = self.key_AES(matricula, salt, iteraciones)
            cipher = AES.new(derived_key, AES.MODE_EAX, nonce=nonce)
            decrypted_data = cipher.decrypt(ciphertext)

            try:
                return decrypted_data.decode('utf-8')
            except UnicodeDecodeError:
                return decrypted_data

        except (ValueError, KeyError, Exception) as e:
            print(f"Error al descifrar: {e}")
            return None

    def hash_matricula(self, matricula):
        return hashlib.sha256(matricula.encode('utf-8')).hexdigest()
