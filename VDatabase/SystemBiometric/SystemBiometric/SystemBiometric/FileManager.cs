using System;
using System.Data;
using System.Linq;

namespace SystemBiometric
{
    internal class FileManager
    {
        private static SystemBiometricDBEntities db = new SystemBiometricDBEntities();

        #region Guardar Fingerprint y Matricula
        public static void SaveDatasFingerPMatr(string matricula, byte[] huellaBytes)
        {
            try
            {
                var nuevaHuella = new FingerPrint
                {
                    Matricula = matricula,
                    Fingerprint1 = huellaBytes
                };

                db.FingerPrints.Add(nuevaHuella);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar en base de datos: " + ex.Message);
            }
        }

        #endregion

        #region Guardar Matricula
        public static void SaveDataMatricula(string matricula)
        {
            try
            {
                var nuevaMatricula = new Matricula
                {
                    Matricula1 = matricula
                };

                db.Matriculas.Add(nuevaMatricula);
                db.SaveChanges();
                LoadDatasFingerPMatr();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar en base de datos: " + ex.Message);
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
                var registros = db.FingerPrints.ToList();

                foreach (var item in registros)
                {
                    string fingerprintHex = BitConverter.ToString(item.Fingerprint1);
                    dt.Rows.Add(item.Matricula, fingerprintHex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al mostrar el dato biométrico almacenado: " + ex.Message);
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
                var registros = db.Matriculas.ToList();
                foreach (var m in registros)
                {
                    dt.Rows.Add(m.Matricula1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar matrículas: " + ex.Message);
            }

            return dt;
        }

        #endregion

        #region Eliminar Fingerprint y Matricula
        public static void ClearFingerPrint()
        {
            try
            {
                db.FingerPrints.RemoveRange(db.FingerPrints);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar huellas: " + ex.Message);
            }
        }

        #endregion

        #region Eliminar Matricula
        public static void ClearMatricula()
        {
            try
            {
                db.Matriculas.RemoveRange(db.Matriculas);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar matrículas: " + ex.Message);
            }
        }

        #endregion

        #region Eliminar el contenido de ambas tablas
        public static void ClearFiles()
        {
            ClearFingerPrint();
            ClearMatricula();
        }

        #endregion
    }
}
