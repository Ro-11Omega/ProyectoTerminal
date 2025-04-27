namespace SystemBiometric
{
    partial class FormWelcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelBienvenido = new System.Windows.Forms.Label();
            this.labelContinuar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelBienvenido
            // 
            this.labelBienvenido.AutoSize = true;
            this.labelBienvenido.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.labelBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelBienvenido.Location = new System.Drawing.Point(188, 29);
            this.labelBienvenido.Name = "labelBienvenido";
            this.labelBienvenido.Size = new System.Drawing.Size(214, 42);
            this.labelBienvenido.TabIndex = 0;
            this.labelBienvenido.Text = "Bienvenido";
            // 
            // labelContinuar
            // 
            this.labelContinuar.AutoSize = true;
            this.labelContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContinuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelContinuar.Location = new System.Drawing.Point(261, 160);
            this.labelContinuar.Name = "labelContinuar";
            this.labelContinuar.Size = new System.Drawing.Size(69, 15);
            this.labelContinuar.TabIndex = 1;
            this.labelContinuar.Text = "Continuar";
            this.labelContinuar.Click += new System.EventHandler(this.labelContinuar_Click);
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 293);
            this.Controls.Add(this.labelContinuar);
            this.Controls.Add(this.labelBienvenido);
            this.Name = "FormWelcome";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.FormWelcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBienvenido;
        private System.Windows.Forms.Label labelContinuar;
    }
}