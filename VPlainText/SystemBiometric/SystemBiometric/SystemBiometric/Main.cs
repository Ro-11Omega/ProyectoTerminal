using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemBiometric
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            FormManager.CenterForm(this);
            FormManager.OrangeTheme(this);
        }


        #region Botón iniciar sesión
        private void btnVerify_Click(object sender, EventArgs e)
        {
            FormVerify formVerify = new FormVerify();
            formVerify.Show();
            this.Hide();
        }

        #endregion

        #region Botón Registrarse
        private void labelRegistrar_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
            this.Hide();
        }

        #endregion
    }
}
