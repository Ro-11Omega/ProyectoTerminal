
#Rutas relativas para su uso en Windows
#fingerPrintFile = "SystemBiometric\\SystemBiometric\\SystemBiometric\\bin\\Debug\\Matricula.txt"
#matriculaFile = "SystemBiometric\\SystemBiometric\\SystemBiometric\\bin\\Debug\\Matricula.txt"

#Rutas relativas para su uso en Linux
fingerPrintFile = "SystemBiometric/SystemBiometric/SystemBiometric/bin/Debug/fingerPrint.txt"
matriculaFile = "SystemBiometric/SystemBiometric/SystemBiometric/bin/Debug/Matricula.txt"


def read_fingerprint(archivo):
    try:
        with open(archivo, 'r', encoding='utf-8-sig') as file:
            matricula = file.readline().strip()
            huella = file.readline().strip()
            separador = file.readline().strip()

            lineas_restantes = file.readlines()

            if separador != "*****":
                print("Separador no existente")
            
            if not matricula or not huella:
                raise ValueError("Datos incompletos en el archivo.")
        
        with open(archivo, 'w', encoding='utf-8-sig') as file:
            file.writelines(lineas_restantes)
        return matricula, huella

    except FileNotFoundError:
        print(f"Error: El archivo '{archivo}' no existe")
    except ValueError as e:
        print(f"Error de valor: {e}")
    except Exception as e:
        print(f"Error inesperado: {e}")

    return None, None
    

def write_fingerprint(archivo, matricula, huella):
    try:
        with open(archivo, 'a', encoding='utf-8-sig') as file:
            file.write(f"{matricula}\n")
            file.write(f"{huella}\n")
            file.write("*****\n")

            print("Datos escritos correctamente.")
    except Exception as e:
        print(f"Error al escribir en el archivo: {e}")


def read_matricula(file_path):
    try:
        with open(file_path, 'r', encoding='utf-8-sig') as f:
            matricula = f.readline().strip()
            lineas_restantes = f.readlines()

        with open(file_path, 'w', encoding='utf-8-sig') as f:
            f.writelines(lineas_restantes)

        return matricula
    except FileNotFoundError:
        print(f"El archivo {file_path} no existe.")
        return None
    except Exception as e:
        print(f"Error inesperado: {e}")
        return None

