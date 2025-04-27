namespace SystemBiometric
{
    partial class FormBiometrico
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
            this.LabelInstruction = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.PBox = new System.Windows.Forms.PictureBox();
            this.TBoxInstruction = new System.Windows.Forms.TextBox();
            this.TBoxStatus = new System.Windows.Forms.TextBox();
            this.LabelStates = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelInstruction
            // 
            this.LabelInstruction.AutoSize = true;
            this.LabelInstruction.Location = new System.Drawing.Point(12, 22);
            this.LabelInstruction.Name = "LabelInstruction";
            this.LabelInstruction.Size = new System.Drawing.Size(62, 13);
            this.LabelInstruction.TabIndex = 1;
            this.LabelInstruction.Text = "Instrucción:";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(12, 72);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(43, 13);
            this.LabelStatus.TabIndex = 3;
            this.LabelStatus.Text = "Estado:";
            // 
            // PBox
            // 
            this.PBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PBox.BackColor = System.Drawing.SystemColors.Window;
            this.PBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBox.Location = new System.Drawing.Point(354, 9);
            this.PBox.Name = "PBox";
            this.PBox.Size = new System.Drawing.Size(216, 213);
            this.PBox.TabIndex = 0;
            this.PBox.TabStop = false;
            // 
            // TBoxInstruction
            // 
            this.TBoxInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBoxInstruction.Location = new System.Drawing.Point(12, 38);
            this.TBoxInstruction.Name = "TBoxInstruction";
            this.TBoxInstruction.ReadOnly = true;
            this.TBoxInstruction.Size = new System.Drawing.Size(336, 20);
            this.TBoxInstruction.TabIndex = 2;
            // 
            // TBoxStatus
            // 
            this.TBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBoxStatus.BackColor = System.Drawing.SystemColors.Window;
            this.TBoxStatus.Location = new System.Drawing.Point(12, 88);
            this.TBoxStatus.Multiline = true;
            this.TBoxStatus.Name = "TBoxStatus";
            this.TBoxStatus.ReadOnly = true;
            this.TBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBoxStatus.Size = new System.Drawing.Size(336, 134);
            this.TBoxStatus.TabIndex = 4;
            // 
            // LabelStates
            // 
            this.LabelStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelStates.Location = new System.Drawing.Point(9, 225);
            this.LabelStates.Name = "LabelStates";
            this.LabelStates.Size = new System.Drawing.Size(480, 39);
            this.LabelStates.TabIndex = 5;
            this.LabelStates.Text = "[Estados]";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(495, 255);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FormBiometrico
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(582, 293);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.LabelStates);
            this.Controls.Add(this.TBoxStatus);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.TBoxInstruction);
            this.Controls.Add(this.LabelInstruction);
            this.Controls.Add(this.PBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FormBiometrico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biometric Scanner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBiometrico_FormClosed);
            this.Load += new System.EventHandler(this.FormBiometrico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBox;
        private System.Windows.Forms.TextBox TBoxInstruction;
        private System.Windows.Forms.TextBox TBoxStatus;
        private System.Windows.Forms.Label LabelStates;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label LabelInstruction;
        private System.Windows.Forms.Label LabelStatus;
    }
}