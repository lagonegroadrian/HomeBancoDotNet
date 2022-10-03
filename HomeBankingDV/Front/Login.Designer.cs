
namespace HomeBankingDV
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Registrar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.labelIntentos = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textContrasenia = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.Registrar);
            this.panel1.Controls.Add(this.Cancelar);
            this.panel1.Controls.Add(this.labelIntentos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textContrasenia);
            this.panel1.Controls.Add(this.textUsuario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Registrar
            // 
            this.Registrar.BackColor = System.Drawing.Color.Green;
            this.Registrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Registrar, "Registrar");
            this.Registrar.Name = "Registrar";
            this.Registrar.UseVisualStyleBackColor = false;
            this.Registrar.Click += new System.EventHandler(this.Registrar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Cancelar.FlatAppearance.BorderSize = 4;
            this.Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.Cancelar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.Cancelar, "Cancelar");
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            // 
            // labelIntentos
            // 
            resources.ApplyResources(this.labelIntentos, "labelIntentos");
            this.labelIntentos.Name = "labelIntentos";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textContrasenia
            // 
            resources.ApplyResources(this.textContrasenia, "textContrasenia");
            this.textContrasenia.Name = "textContrasenia";
            // 
            // textUsuario
            // 
            resources.ApplyResources(this.textUsuario, "textUsuario");
            this.textUsuario.Name = "textUsuario";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textContrasenia;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label labelIntentos;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Registrar;
    }
}

