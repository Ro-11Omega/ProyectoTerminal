using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemBiometric
{
    internal class FormManager
    {
        #region Centrar Form
        public static void CenterForm(Form form)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int formWidth = form.Width;
            int formHeight = form.Height;

            int x = (screenWidth - formWidth) / 2;
            int y = (screenHeight - formHeight) / 2;

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(x, y);
        }

        #endregion

        #region Editar tema del Form
        public static void OrangeTheme(Form form)
        {
            Color backgroundColor = Color.FromArgb(255, 165, 0);
            Color textColor = Color.FromArgb(35, 35, 35);
            Color buttonColor = Color.FromArgb(255, 140, 0);
            Color textBoxBackground = Color.FromArgb(255, 205, 135);

            form.BackColor = backgroundColor;
            form.ForeColor = textColor;

            foreach (Control control in form.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = buttonColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                }
                else if (control is Label label)
                {
                    label.ForeColor = textColor;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = textBoxBackground;
                    textBox.ForeColor = textColor;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.BackgroundColor = Color.FromArgb(255, 190, 120);
                    dataGridView.DefaultCellStyle.ForeColor = textColor;
                }
            }
        }

        #endregion
    }
}
