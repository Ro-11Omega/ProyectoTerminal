using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SystemBiometric
{
    public partial class FormRegister : Form
    {
        private DPFP.Template Template;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            FormManager.CenterForm(this);
            FormManager.OrangeTheme(this);
            LoadDatas();
        }

        private void FunctionTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                btnSave.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("Scaneo completado correctamente.",
                        textBoxHuella.Text = "Presione el botón Guardar");
                }
                else
                {
                    MessageBox.Show("Hubo un problema en el scaneo de huellas, repita el proceso.");
                }
            }));
        }

        #region Data Grid View Datos
        private void LoadDatas()
        {
            dataGridViewDatas.DataSource = FileManager.LoadDatasFingerPMatr();
        }

        #endregion

        #region Botón Cancelar
        private void btnBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            FileManager.ClearFingerPrint();
            main.Show();
            this.Hide();
        }

        #endregion

        #region Botón Capturar

        private void btnCapture_Click(object sender, EventArgs e)
        {
            FormFingerPrintScanner formFingerPrintScanner = new FormFingerPrintScanner();
            formFingerPrintScanner.OnTemplate += this.FunctionTemplate;
            formFingerPrintScanner.Show();
        }

        #endregion

        #region Botón Guardar
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Template == null)
            {
                Console.WriteLine("Scanea tu huella antes de guargar.");
                return;
            }

            string matricula = textBoxMatricula.Text.Trim();
            if (string.IsNullOrWhiteSpace(matricula))
            {
                Console.WriteLine("La matrícula no puede estar vacía.");
                return;
            }

            FileManager.SaveDatasFingerPMatr(matricula, Template.Bytes);

            textBoxMatricula.Text = "";
            Template = null;
            LoadDatas();
            btnSave.Enabled = false;

            Console.WriteLine("Registro guardado correctamente.");
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        #endregion
    }
}
