# 🔐 Sistema Blockchain para Datos Biométricos
Este proyecto implementa una red blockchain básica enfocada en el almacenamiento seguro de **datos biométricos (huellas dactilares)**. Está construido con Python y Flask, e incorpora técnicas como **cifrado AES**, **hashing con SHA-256** y **estructura de bloques encadenados**, simulando una red de nodos descentralizados que pueden comunicarse entre sí.

## 1. Índice

1. Índice
2. Contenido del Proyecto
3. Requisitos Previos y Preparación del Entorno
4. Scaneao de la huella dactirlar
5. Configuración de nodos.
6. Almacenamiento a la Blockchain


## 2. Contenido del Proyecto
### Archivos `.txt` requeridos
### ❗Importante:
> Si estás utilizando la **versión del sistema basada en base de datos**, **puedes ignorar toda referencia a archivos `.txt`**. Estos solo aplican en la versión sin base de datos (modo archivo plano).

Asegúrate de contar con los siguientes archivos:

- Rutas:
    Directorio Actual/SystemBiometric/SystemBiometric/SystemBiometric/bin/Debug/fingerPrint.txt
    Directorio Actual/SystemBiometric/SystemBiometric/SystemBiometric/bin/Debug/Matricula.txt

El sistema automaticamente crea los archivos `.txt`, en caso de que no esten presentes deberá escanear el dedo que desea para crear el archivo
Este paso debe realizarse desde el formulario en Windows Forms antes de iniciar el servidor Flask:

Abre el sistema Windows Forms: Ejecuta el proyecto en C# que está diseñado para generar los archivos necesarios.

Generación de archivos:

`fingerprint.txt`: Este archivo se genera al escanear el dedo desde el formulario. Si no existe, el sistema te pedirá que lo escanees.
`matricula.txt`:: Deberás ingresar la matrícula correspondiente en el formulario. Si no existe, el sistema lo creará.

### Archivos principales del sistema
`Blockchain.py`        | Lógica principal de la blockchain.
`Block.py`             | Define la estructura de un bloque.
`Transaction.py`       | Modelo de una transacción.
`SistemaBiometrico.py` | Funciones de cifrado AES y hashing SHA-256.
`File_data.py`         | Carga y procesamiento de los archivos `.txt`.
`node.py`              | Script principal para levantar un nodo.
`routes.py`            | Define todas las rutas HTTP del servidor.
`SystemBiometric/`     | Sistema biométrico en Windows Forms C#
`__pycache__/`         | Archivos generados automáticamente por Python.
`README.md`            | Instructivo.

### SDK compatible en Windows 10 y WIndows 11
Este sistema incluye el SDK necesario para el funcionamiento del lector biométrico Digital Persona U.are.U 4500.


## 3. Requisitos Previos y Preparación del Entorno
### En Windows – Instalación del SDK del Lector Biométrico
Antes de ejecutar el sistema biométrico en Windows Forms, es obligatorio instalar el SDK del lector Digital Persona U.are.U 4500.
- Pasos para instalar el SDK:
    1. Descomprime el archivo SDK para Digital Persona.zip.
    2. Ingresa a la carpeta descomprimida llamada SDK.
    3. Ejecuta el archivo Setup.exe.
    4. Sigue los pasos del instalador hasta completar la instalación.

    Asegúrate de que el lector biométrico esté correctamente conectado durante la instalación para que los controladores se configuren adecuadamente.

### Pasos para configurar Windows Forms en Visual Studio 2022:
1. Descargar Visual Studio 2022 desde:
    https://visualstudio.microsoft.com/es/vs/
    Se recomienda descargar la versión Community

2. Instalación de Visual Studio 2022 y .NET Framework
    Durante la instalación, selecciona:
    Desarrollo de escritorio con Windows Forms .NET
    
    Esto incluye el diseñador de formularios y todo lo necesario para compilar aplicaciones de escritorio en C#.

3. Abrir y ejecutar el formulario biométrico
    1. Abre Visual Studio 2022.
    2. Desde el menú, selecciona Archivo > Abrir > Proyecto/Solución.
    3. Navega hasta:
    Directorio Actual/SystemBiometric/SystemBiometric/SystemBiometric.sln
    Selecciona el archivo: SystemBiometric.sln

    ¡Directorio Actual, es la ruta donde está decargado este proyecto bucado en la el directorio de este README.md!


### Instalación de SQL Server Management Studio (SSMS) en Windows Server 2022
1. Instalar SQL Server
    Descarga e instala SQL Server 2022 Developer Edition (gratis y completa) desde:
    https://www.microsoft.com/en-us/sql-server/sql-server-downloads

    Durante la instalación, elige "Instalación básica" o "Personalizada" según tu preferencia.

2. Instalar SQL Server Management Studio (SSMS)
    Descárgalo desde:
    https://aka.ms/ssms

    Ejecuta el instalador (SSMS-Setup.exe) y haz clic en "Install".

    Al finalizar, reinicia si lo pide.

3. Conectarse y usar en un proyecto
    Abre SSMS y conecta con:
        Server name: localhost o .\SQLEXPRESS
        Ejecuta el siguiente script en una nueva consulta:

        ```sql
        CREATE DATABASE SystemBiometricDB;
        GO

        USE SystemBiometricDB;
        GO

        CREATE TABLE Matricula (
            Id INT PRIMARY KEY,
            Matricula NVARCHAR(50) NOT NULL
        );
        GO

        CREATE TABLE FingerPrint (
            Id INT PRIMARY KEY,
            Matricula NVARCHAR(50) NOT NULL,
            Fingerprint VARBINARY(MAX) NOT NULL
        );
        GO

4. En Visual Studio 2022:
    Agrega nueva conexión a SQL Server

    Ingresa:
        Server name: Nombre que le aparece al abrir SSMS
        Database: SystemBiometricDB
        Autenticación: Windows Authentication
        Agregar las dos tablas creadas: FingerPrint y Matricula.


### Instalación y configuración de Postman
Postman es una herramienta que permite enviar solicitudes HTTP para probar APIs. En este proyecto, se usará para simular la comunicación entre nodos de la red blockchain.
1. Descarga e instalación de Postman
    Ve al sitio oficial de Postman:
    https://www.postman.com/downloads/

    Descarga la versión compatible con tu sistema operativo Windows.
    Instálalo como cualquier otro programa.

### Instalación de Visual Studio Code y Python (si no los tienes)
Antes de ejecutar el proyecto, asegúrate de tener instalados Python y Visual Studio Code en tu sistema:
1. Instalar Python
    Ve al sitio oficial:
    https://www.python.org/downloads/

    Descarga la versión más reciente para Windows (se recomienda Python 3.10 o superior).
    Durante la instalación, marca la opción: ✅ Add Python to PATH.

    Verifica que se instaló correctamente ejecutando en terminal:

    python --version

2. Instalar Visual Studio Code (Opcional, pero recomendado)
    Ve al sitio oficial:
    https://code.visualstudio.com/

    Descarga e instala la versión para Windows.

    Despues de descargarlo:
    Seleccione la opción de "Abrir Folder" y seleccione el proyecto

### Instalación de dependencias y librerias

Para ejecutar correctamente el sistema, es necesario instalar algunas librerías externas. Puedes instalarlas fácilmente con el siguiente comando:
Con el comando ctrl + r, se desplegará una ventana, escriba cmd. por ultimo dale click en la opción Aceptar.

Se abrirá una terminal donde escribirá el siguiente comando:
    pip install flask pycryptodome requests

    Con el anterior comando se incluiran las siguientes librerias:
    flask: Para levantar el servidor web y crear las rutas HTTP.
    pycryptodome: Proporciona cifrado AES y generación segura de claves.
    requests: Permite la comunicación entre nodos mediante 

⚠️ Posibles problemas y soluciones
    🔹 1. ¿No tienes Python o pip instalado?
        Asegúrate de tener Python instalado. Descárgalo desde:
        https://www.python.org/downloads/
        Durante la instalación, marca la opción ✅ Add Python to PATH "para que puedas usar python y pip desde la terminal".

    🔹 2. ¿No reconoce el comando pip?
        Prueba usar:
        python -m pip install flask pycryptodome requests
        Si eso tampoco funciona, puede que necesites reinstalar Python correctamente.
    
    🔹 3. ¿Error de permisos?
        Si aparece un error de permisos, ejecuta la terminal como administrador:
        Cierra la terminal.
        Haz clic derecho sobre "Símbolo del sistema" y selecciona "Ejecutar como administrador".
        Luego vuelve a ejecutar el comando.

## 4. Escaneo de la huella dactilar
Para comenzar a utilizar el sistema de escaneo y registro biométrico, sigue estos pasos:
1. Abrir el Proyecto
    Abre Visual Studio 2022.
    Carga el proyecto SystemBiometric.

2. Ejecutar el Sistema
    Presiona el botón Play (▶) en Visual Studio para ejecutar la aplicación.
    Se abrirá una ventana con dos opciones principales:

        Registrarse

        Iniciar Sesión

3. Registro de Huella
    Selecciona la opción “Registrarse”.
    Sigue las instrucciones que aparecerán en pantalla para capturar la huella dactilar y registrar la matrícula del usuario.

    Al finalizar el proceso, el sistema generará automáticamente un archivo llamado `fingerprint.txt`, que contiene la información biométrica, y asociará dicha huella con la matrícula del usuario ingresada.

4. Verificación de Huella
    Selecciona la opción “Iniciar Sesión”.

    Introduce la matrícula del usuario previamente registrado.

    El sistema creará un archivo temporal llamado `matricula.txt`, que se usará para verificar la correspondencia entre la matrícula ingresada y la huella escaneada en tiempo real.

    Si la huella es verificada correctamente, el sistema confirmará la autenticación del usuario.

⚠️ Nota de seguridad: Una vez completado el proceso de verificación, los datos de los archivos fingerprint.txt y matricula.txt se eliminan automáticamente para proteger la privacidad del usuario y evitar almacenamiento innecesario.

## 5. Configuración de nodos
Una vez que hayas escaneado todas las huellas dactilares que deseas registrar (sin realizar la verificación, ya que esta elimina los archivos), sigue estos pasos para almacenarlas en la blockchain.
1. Verifica que los Archivos Estén Presentes

    Asegúrate de que existan los siguientes archivos generados por el sistema Windows Forms:
        fingerprint.txt
        matricula.txt

    Ubicación esperada:
        SystemBiometric/SystemBiometric/SystemBiometric/bin/Debug/

⚠️ Ambos archivos son esenciales para el registro en la blockchain.

2. Levantar un Nodo del Servidor Flask
    1. Ubicación del script del nodo
        El archivo node.py se encuentra en:
        PTBlockchain/node.py

    2. Asegúrate de tener instaladas las librerías necesarias
        Antes de ejecutar el nodo, asegúrate de haber instalado previamente las dependencias descritas en la sección 3. Requisitos Previos y Preparación del Entorno, tales como:
            pip install flask pycryptodome requests

    3. Iniciar uno o más nodos
        Ejecuta uno o más nodos
        En la terminal de Visual Studio Code en la ubicación donde se encuentra el archivo node.py
        Ejecute el siguiente comando:
            python node.py <puerto>

        Cabe aclarar que <puerto> es en realidad un número.
        Cada vez que ejecutes el anterior comando, estarás creando un nodo independiente de la red, por ejemplo:
            🔹Terminal 1
                python node.py 5000
            🔹Terminal 2
                python node.py 5001
            🔹Terminal 3
                python node.py 5002
            🔹Terminal 4
                python node.py 5003

        Esto levantará nodos locales escuchando en las siguientes direcciones respectivamente (en Postman):

            http://127.0.0.1:5000

            http://127.0.0.1:5001

            http://127.0.0.1:5002

            http://127.0.0.1:5003

⚠️ Importante: El número que colocas en python node.py <puerto> es directamente equivalente a lo que usarás en Postman como http://127.0.0.1:<puerto>.
Por ejemplo: si ejecutas python node.py 5000, ese nodo estará disponible en Postman en la URL http://127.0.0.1:5000.

4. Configurar y Usar Postman
    1. Simulación de nodos en Postman

        Por cada nodo que tengas ejecutándose en visual studio code o en diferentes terminales de tu computadora (por ejemplo 4 nodos en puertos 5000, 5001, 5002, 5003), puedes crear peticiones en Postman apuntando a sus respectivas direcciones:

            Nodo 1 → http://127.0.0.1:5000

            Nodo 2 → http://127.0.0.1:5001

            Nodo 3 → http://127.0.0.1:5002

            Nodo 4 → http://127.0.0.1:5003

        Puedes simular las operaciones de red directamente desde Postman como si fueras un nodo interactuando con otros.
    2. Registro de Nodos desde Postman
        Una vez que tus nodos estén corriendo, puedes registrarlos entre sí usando la siguiente solicitud:

        Seleccione el método: POST

            URL: http://127.0.0.1:5005/connect (reemplaza el puerto si deseas registrar desde otro nodo)

        Encabezados:

        Content-Type: application/json
        Body (Cuerpo JSON):
        Selecciona la opción raw y elige JSON.
        Copia y pega el siguiente contenido:
            {
            "nodes": [
                "http://127.0.0.1:5001",
                "http://127.0.0.1:5002",
                "http://127.0.0.1:5003",
                "http://127.0.0.1:5004"
            ]
            }

            📝 En este ejemplo se usan los puertos: 5001, 5002, 5003, 5004 y 5005.
            El nodo que corre en el puerto 5005 debe reconocer a los demás, por eso se hace la solicitud desde él.

        Esto le permite al nodo que hace la solicitud reconocer a los demás nodos de la red y así compartir bloques y mantener la cadena sincronizada.

## 6. Almacenamiento y Consultas en la Blockchain
Una vez levantado uno o más nodos y con los archivos fingerprint.txt y matricula.txt listos, puedes usar los siguientes endpoints desde Postman para interactuar con la blockchain:
    🔹Endpoint: GET

        URL de ejemplo: http://127.0.0.1:5000/add_block
        Registra una nueva huella en la blockchain: cifra los datos y los almacena como un bloque.

        URL de ejemplo: http://127.0.0.1:5000/get_block
        Recupera una huella previamente registrada en función de la matrícula. Descifra y restaura la huella original en fingerprint.txt.

        URL de ejemplo: http://127.0.0.1:5000/get_chain
        Muestra toda la cadena de bloques del nodo en formato JSON.
        Endpoint: GET /update

        URL de ejemplo: http://127.0.0.1:5000/update
        Actualiza la cadena del nodo usando la más larga entre los nodos conectados.

    🔹Endpoint: POST

        URL de ejemplo: http://127.0.0.1:5000/connect
        Permite registrar otros nodos dentro de la red para que puedan compartir bloques y sincronizarse.

⚠️ Recuerda: Cada operación se realiza sobre el nodo especificado en la URL. Aunque en los ejemplos se utiliza el puerto 5000, puedes reemplazarlo por cualquier otro puerto correspondiente al nodo que desees consultar.
