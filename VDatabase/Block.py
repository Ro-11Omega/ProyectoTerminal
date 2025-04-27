class Block:
    def __init__(self, index, timestamp, proof, hash_previo, transactions):
        self.index = index
        self.timestamp = timestamp
        self.proof = proof
        self.hash_previo = hash_previo
        self.transactions = transactions

    def to_dict(self):
        return {
            'index': self.index,
            'timestamp': self.timestamp,
            'proof': self.proof,
            'hash_previo': self.hash_previo,
            'transactions': self.transactions
        }
