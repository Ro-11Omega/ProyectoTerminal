import pyodbc

class Conexion:
    def __init__(self):
        self.DRIVER_NAME = 'SQL SERVER'
        self.SERVER_NAME = 'DESKTOP-OU870J3'
        self.DATABASE_NAME = 'SystemBiometricDB'
        self.connection_string = f"""
            DRIVER={{{self.DRIVER_NAME}}};
            SERVER={self.SERVER_NAME};
            DATABASE={self.DATABASE_NAME};
            Trust_Connection=yes;
        """

    def get_conexion(self):
        try:
            return pyodbc.connect(self.connection_string)
        except pyodbc.Error as e:
            print(f"Error al conectar con la base de datos: {e}")
            return None

    def get_datoBiometrico(self):
        conn = self.get_conexion()
        if conn is None:
            return None, None

        try:
            cursor = conn.cursor()
            query = "SELECT TOP 1 Fingerprint, Matricula, id FROM FingerPrint ORDER BY id ASC"
            cursor.execute(query)
            row = cursor.fetchone()

            if row:
                fingerprint_data = row[0]
                matricula = row[1]
                id_registro = row[2]

                query_delete = "DELETE FROM FingerPrint WHERE id = ?"
                cursor.execute(query_delete, (id_registro,))

                conn.commit()
                return fingerprint_data, matricula
            else:
                print("No se han registrados datos en la Base de Datos")
                return None, None

        except pyodbc.Error as e:
            print(f"Error al consultar la base de datos: {e}")
            return None, None

        finally:
            conn.close()


    def get_matricula(self):
        conn = self.get_conexion()
        if conn is None:
            return None

        try:
            cursor = conn.cursor()
            query = "SELECT TOP 1 Matricula, id FROM Matricula ORDER BY id ASC"
            cursor.execute(query)
            row = cursor.fetchone()

            if row:
                matricula = row[0]
                id_registro = row[1]

                query_delete = "DELETE FROM Matricula WHERE id = ?"
                cursor.execute(query_delete, (id_registro,))

                conn.commit()
                return matricula
            else:
                print("No se encontró matricula para solicitud de verificación en la Base de Datos")
                return None

        except pyodbc.Error as e:
            print(f"Error al consultar la base de datos: {e}")
            return None

        finally:
            conn.close()


    def add_datoBiometrico(self, huella, matricula):
        conn = self.get_conexion()
        if conn is None:
            return
        try:
            cursor = conn.cursor()
            query = """
                INSERT INTO FingerPrint (Fingerprint, Matricula)
                VALUES (?, ?)
            """
            cursor.execute(query, (huella, matricula))
            conn.commit()
            print("Datos insertados correctamente en la base de datos.")

        except pyodbc.Error as e:
            print(f"Error al recuperar los datos: {e}")

        finally:
            conn.close()
