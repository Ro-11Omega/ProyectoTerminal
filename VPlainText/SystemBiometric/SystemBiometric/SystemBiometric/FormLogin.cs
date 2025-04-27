using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Data;

namespace SystemBiometric
{
    public partial class FormLogin : FormBiometrico
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;

        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        private void UpdateStatus(int FAR)
        {
            SetStatus(string.Format("Probabilidad de falsa aceptación = {0}", FAR));
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Verificación Biométrica";
            Verificator = new DPFP.Verification.Verification();
            UpdateStatus(0);
        }

        private byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 3 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        protected override void CaptureSample(DPFP.Sample Sample)
        {
            base.CaptureSample(Sample);
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            if (features != null)
            {
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                bool datoRegistrado = false;
                string matriculaUsuario = "";

                DataTable registros = FileManager.LoadDatasFingerPMatr();

                foreach (DataRow registro in registros.Rows)
                {
                    byte[] huellaBytes = HexStringToByteArray(registro["Huella"].ToString());
                    using (MemoryStream stream = new MemoryStream(huellaBytes))
                    {
                        DPFP.Template storedTemplate = new DPFP.Template(stream);
                        Verificator.Verify(features, storedTemplate, ref result);

                        if (result.Verified)
                        {
                            datoRegistrado = true;
                            matriculaUsuario = registro["Matrícula"].ToString();
                            break;
                        }
                    }
                }

                if (datoRegistrado)
                {
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show("Usuario Aceptado", "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FileManager.ClearFiles();
                        FormWelcome formWelcome = new FormWelcome();
                        formWelcome.Show();
                        this.Close();
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show("No se encontró coincidencias en los datos proporcionados.", "Acceso Denegado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileManager.ClearFiles();
                        FormVerify formVerify = new FormVerify();
                        formVerify.Show();
                        this.Close();
                    });
                }
            }
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            FormManager.CenterForm(this);
            FormManager.OrangeTheme(this);
        }
    }
}
