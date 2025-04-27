using System;
using System.Windows.Forms;
using System.IO;
using DPFP;

namespace SystemBiometric
{
    public partial class FormVerify : Form
    {
        public FormVerify()
        {
            InitializeComponent();
            textBoxMatricula.TextChanged += (s, e) => buttonStatus();
        }

        private void FormVerify_Load(object sender, EventArgs e)
        {
            FormManager.CenterForm(this);
            FormManager.OrangeTheme(this);
            LoadMatriculas();
        }

        private void buttonStatus()
        {
            btnVerify.Enabled = !string.IsNullOrWhiteSpace(textBoxMatricula.Text);
        }

        #region Botón Verificar
        private void btnVerify_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }
        #endregion

        #region Botón Guardar
        private void btnSave_Click(object sender, EventArgs e)
        {
            string matricula = textBoxMatricula.Text.Trim();

            if (string.IsNullOrWhiteSpace(matricula) || matricula.Contains(" "))
            {
                MessageBox.Show("La matrícula no puede contener espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FileManager.SaveDataMatricula(matricula);
            MessageBox.Show("Solicitud guardada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadMatriculas();
        }


        #endregion

        #region Botón Cancelar
        private void btnBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            FileManager.ClearFiles();
            main.Show();
            this.Hide();
        }
        #endregion

        #region Data Grid View Matrículas
        private void LoadMatriculas()
        {
            dataGridViewMatriculas.DataSource = FileManager.LoadMatriculas();
        }
        #endregion

    }
}
