using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemBiometric
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void labelContinuar_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            FormManager.CenterForm(this);
            FormManager.OrangeTheme(this);
        }
    }
}
