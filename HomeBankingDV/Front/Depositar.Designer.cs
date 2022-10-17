namespace HomeBankingDV.Front
{
    partial class Depositar
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
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textCuentaOrigen = new System.Windows.Forms.TextBox();
            this.textMonto = new System.Windows.Forms.TextBox();
            this.textCbuDestino = new System.Windows.Forms.TextBox();
            this.btn_depositar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_cancelar.Location = new System.Drawing.Point(81, 346);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(124, 50);
            this.btn_cancelar.TabIndex = 0;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nuevo Deposito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cuenta Origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Monto a Depositar:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "CBU destino:";
            // 
            // textCuentaOrigen
            // 
            this.textCuentaOrigen.Location = new System.Drawing.Point(267, 126);
            this.textCuentaOrigen.Name = "textCuentaOrigen";
            this.textCuentaOrigen.Size = new System.Drawing.Size(145, 37);
            this.textCuentaOrigen.TabIndex = 5;
            this.textCuentaOrigen.TextChanged += new System.EventHandler(this.textCuentaOrigen_TextChanged);
            // 
            // textMonto
            // 
            this.textMonto.Location = new System.Drawing.Point(267, 182);
            this.textMonto.Name = "textMonto";
            this.textMonto.Size = new System.Drawing.Size(145, 37);
            this.textMonto.TabIndex = 6;
            this.textMonto.TextChanged += new System.EventHandler(this.textMonto_TextChanged);
            // 
            // textCbuDestino
            // 
            this.textCbuDestino.Location = new System.Drawing.Point(267, 238);
            this.textCbuDestino.Name = "textCbuDestino";
            this.textCbuDestino.Size = new System.Drawing.Size(145, 37);
            this.textCbuDestino.TabIndex = 7;
            this.textCbuDestino.TextChanged += new System.EventHandler(this.textCbuDestino_TextChanged);
            // 
            // btn_depositar
            // 
            this.btn_depositar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_depositar.Location = new System.Drawing.Point(229, 346);
            this.btn_depositar.Name = "btn_depositar";
            this.btn_depositar.Size = new System.Drawing.Size(123, 50);
            this.btn_depositar.TabIndex = 8;
            this.btn_depositar.Text = "Depositar";
            this.btn_depositar.UseVisualStyleBackColor = false;
            this.btn_depositar.Click += new System.EventHandler(this.btn_depositar_Click);
            // 
            // Depositar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.btn_depositar);
            this.Controls.Add(this.textCbuDestino);
            this.Controls.Add(this.textMonto);
            this.Controls.Add(this.textCuentaOrigen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Depositar";
            this.Text = "Depositar";
            this.Load += new System.EventHandler(this.Depositar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_cancelar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textCuentaOrigen;
        private TextBox textMonto;
        private TextBox textCbuDestino;
        private Button btn_depositar;
    }
}