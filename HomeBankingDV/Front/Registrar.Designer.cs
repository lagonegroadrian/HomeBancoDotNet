namespace HomeBankingDV
{
    partial class Registrar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Confirmar = new System.Windows.Forms.Button();
            this.textBoxContraseniaRepetida = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxContrasenia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMensajes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(137, 374);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(187, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(242, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "REGISTRARSE";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(279, 368);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(307, 37);
            this.textBoxDNI.TabIndex = 2;
            this.textBoxDNI.Leave += new System.EventHandler(this.onBlurDNI);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(279, 468);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(307, 37);
            this.textBoxNombre.TabIndex = 4;
            this.textBoxNombre.Leave += new System.EventHandler(this.onBlurNombre);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(65, 474);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "NOMBRE";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(279, 566);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(307, 37);
            this.textBoxApellido.TabIndex = 6;
            this.textBoxApellido.Leave += new System.EventHandler(this.onBlurApellido);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(50, 572);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "APELLIDO";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(279, 670);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(307, 37);
            this.textBoxMail.TabIndex = 8;
            this.textBoxMail.TextChanged += new System.EventHandler(this.textBoxMail_TextChanged);
            this.textBoxMail.Leave += new System.EventHandler(this.onBlurMail);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(120, 676);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "MAIL";
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Cancelar.Location = new System.Drawing.Point(82, 1080);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(207, 66);
            this.Cancelar.TabIndex = 12;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Confirmar
            // 
            this.Confirmar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Confirmar.Location = new System.Drawing.Point(382, 1080);
            this.Confirmar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(207, 66);
            this.Confirmar.TabIndex = 11;
            this.Confirmar.Text = "Confirmar";
            this.Confirmar.UseVisualStyleBackColor = false;
            this.Confirmar.Click += new System.EventHandler(this.Confirmar_Click);
            // 
            // textBoxContraseniaRepetida
            // 
            this.textBoxContraseniaRepetida.Location = new System.Drawing.Point(279, 866);
            this.textBoxContraseniaRepetida.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxContraseniaRepetida.Name = "textBoxContraseniaRepetida";
            this.textBoxContraseniaRepetida.PasswordChar = '*';
            this.textBoxContraseniaRepetida.Size = new System.Drawing.Size(307, 37);
            this.textBoxContraseniaRepetida.TabIndex = 10;
            this.textBoxContraseniaRepetida.Leave += new System.EventHandler(this.onBlurPassVerification);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(5, 872);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "REPITA PASS";
            // 
            // textBoxContrasenia
            // 
            this.textBoxContrasenia.Location = new System.Drawing.Point(279, 776);
            this.textBoxContrasenia.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxContrasenia.Name = "textBoxContrasenia";
            this.textBoxContrasenia.PasswordChar = '*';
            this.textBoxContrasenia.Size = new System.Drawing.Size(307, 37);
            this.textBoxContrasenia.TabIndex = 9;
            this.textBoxContrasenia.Leave += new System.EventHandler(this.onBlurPass);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(111, 782);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "PASS";
            // 
            // labelMensajes
            // 
            this.labelMensajes.AutoSize = true;
            this.labelMensajes.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMensajes.ForeColor = System.Drawing.Color.Red;
            this.labelMensajes.Location = new System.Drawing.Point(82, 942);
            this.labelMensajes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelMensajes.Name = "labelMensajes";
            this.labelMensajes.Size = new System.Drawing.Size(0, 27);
            this.labelMensajes.TabIndex = 14;
            // 
            // Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(711, 1102);
            this.Controls.Add(this.labelMensajes);
            this.Controls.Add(this.textBoxContraseniaRepetida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxContrasenia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Confirmar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Registrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar";
            this.Load += new System.EventHandler(this.cargaDeForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Confirmar;
        private System.Windows.Forms.TextBox textBoxContraseniaRepetida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxContrasenia;
        private System.Windows.Forms.Label label7;
        private Label labelMensajes;
    }
}