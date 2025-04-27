using System;
using System.Data;
using System.IO;
using System.Text;

namespace SystemBiometric
{
    internal class FileManager
    {
        public static string MatriculaFile { get; } = "Matricula.txt";
        public static string FingerPrintFile { get; } = "FingerPrint.txt";

        #region Guardar Fingerprint y Matricula
        public static void SaveDatasFingerPMatr(string matricula, byte[] huellaBytes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FingerPrintFile, true, Encoding.UTF8))
                {
                    sw.WriteLine(matricula);
                    sw.WriteLine(BitConverter.ToString(huellaBytes));
                    sw.WriteLine("*****");  // Separador entre registros
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar los datos en el archivo: " + ex.Message);
            }
        }

        #endregion

        #region Guardar Matricula
        public static void SaveDataMatricula(string matricula)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(MatriculaFile, true, Encoding.UTF8))
                {
                    sw.WriteLine(matricula);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar la matricula en el archivo: " + ex.Message);
            }
        }
        #endregion

        #region Cargar Fingerprint y Matricula
        public static DataTable LoadDatasFingerPMatr()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Matrícula", typeof(string));
            dt.Columns.Add("Huella", typeof(string));

            try
            {
                if (!File.Exists(FingerPrintFile))
                    return dt;

                using (StreamReader sr = new StreamReader(FingerPrintFile))
                {
                    string matricula = null;
                    string huella = null;
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;

                        if (matricula == null)
                        {
                            matricula = linea.Trim();
                        }
                        else if (huella == null)
                        {
                            huella = linea.Trim();
                        }
                        else if (linea.StartsWith("*****"))
                        {
                            dt.Rows.Add(matricula, huella);
                            matricula = null;
                            huella = null;
                        }
                    }

                    if (matricula != null && huella != null)
                    {
                        dt.Rows.Add(matricula, huella);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar las huellas: " + ex.Message);
            }

            return dt;
        }

        #endregion

        #region Cargar Matricula
        public static DataTable LoadMatriculas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Matricula", typeof(string));

            try
            {
                if (!File.Exists(MatriculaFile))
                    return dt;

                using (StreamReader sr = new StreamReader(MatriculaFile))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        dt.Rows.Add(linea);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Eliminar Fingerprint y Matricula
        public static void ClearFingerPrint()
        {
            try
            {
                File.WriteAllText(FingerPrintFile, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar los archivos: " + ex.Message);
            }
        }

        #endregion

        #region Eliminar Matricula
        public static void ClearMatricula()
        {
            try
            {
                File.WriteAllText(MatriculaFile, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar los archivos: " + ex.Message);
            }
        }

        #endregion

        #region Eliminar el contenido de ambos archivos
        public static void ClearFiles()
        {
            try
            {
                File.WriteAllText(MatriculaFile, string.Empty);
                File.WriteAllText(FingerPrintFile, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al borrar los archivos:" + ex.Message);
            }
        }
        #endregion
    }
}
