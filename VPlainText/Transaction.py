class Transaction:
    def __init__(self, matricula_hash, salt, iteraciones, nonce, dato_biometrico):
        self.matricula_hash = matricula_hash
        self.salt = salt
        self.iteraciones = iteraciones
        self.nonce = nonce
        self.dato_biometrico = dato_biometrico

    def to_dict(self):
        return {
            'matricula_hash': self.matricula_hash,
            'salt': self.salt,
            'iteraciones': self.iteraciones,
            'nonce': self.nonce,
            'biometric_data': self.dato_biometrico
        }

