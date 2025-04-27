namespace SystemBiometric
{
    partial class FormRegister
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
            this.btnSave = new System.Windows.Forms.Button();
            this.labelMatricula = new System.Windows.Forms.Label();
            this.labelFingerPrint = new System.Windows.Forms.Label();
            this.textBoxHuella = new System.Windows.Forms.TextBox();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.dataGridViewDatas = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(71, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelMatricula
            // 
            this.labelMatricula.AutoSize = true;
            this.labelMatricula.Location = new System.Drawing.Point(68, 52);
            this.labelMatricula.Name = "labelMatricula";
            this.labelMatricula.Size = new System.Drawing.Size(50, 13);
            this.labelMatricula.TabIndex = 1;
            this.labelMatricula.Text = "Matricula";
            // 
            // labelFingerPrint
            // 
            this.labelFingerPrint.AutoSize = true;
            this.labelFingerPrint.Location = new System.Drawing.Point(68, 86);
            this.labelFingerPrint.Name = "labelFingerPrint";
            this.labelFingerPrint.Size = new System.Drawing.Size(37, 13);
            this.labelFingerPrint.TabIndex = 2;
            this.labelFingerPrint.Text = "Huella";
            // 
            // textBoxHuella
            // 
            this.textBoxHuella.Location = new System.Drawing.Point(163, 83);
            this.textBoxHuella.Name = "textBoxHuella";
            this.textBoxHuella.Size = new System.Drawing.Size(236, 20);
            this.textBoxHuella.TabIndex = 3;
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(163, 45);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(236, 20);
            this.textBoxMatricula.TabIndex = 4;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(425, 83);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 5;
            this.btnCapture.Text = "Capturar";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // dataGridViewDatas
            // 
            this.dataGridViewDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatas.Location = new System.Drawing.Point(163, 130);
            this.dataGridViewDatas.Name = "dataGridViewDatas";
            this.dataGridViewDatas.Size = new System.Drawing.Size(337, 89);
            this.dataGridViewDatas.TabIndex = 6;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(22, 239);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Cancelar";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 293);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewDatas);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.textBoxMatricula);
            this.Controls.Add(this.textBoxHuella);
            this.Controls.Add(this.labelFingerPrint);
            this.Controls.Add(this.labelMatricula);
            this.Controls.Add(this.btnSave);
            this.Name = "FormRegister";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelMatricula;
        private System.Windows.Forms.Label labelFingerPrint;
        private System.Windows.Forms.TextBox textBoxHuella;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.DataGridView dataGridViewDatas;
        private System.Windows.Forms.Button btnBack;
    }
}