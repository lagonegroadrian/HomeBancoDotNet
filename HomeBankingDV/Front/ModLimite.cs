using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBankingDV.Front
{
    public partial class ModLimite : Form
    {
        public DelegadoModLimiteClose delegadoModLimiteClose;

        //private int elCBU;
        private int idTarjeta;
        private Banco elBanco;

        public ModLimite(Banco _elBanco, int _elId)
        {
            elBanco = _elBanco;
            idTarjeta = _elId;
            
            InitializeComponent();
            textBox1.Text = idTarjeta.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string salida = "No se pudo modificar el limite";
            if (elBanco.ModificarTarjetaCredito(idTarjeta, float.Parse(textBox2.Text))) { salida = "Limite modificado con éxito"; };

            MessageBox.Show(salida);
            delegadoModLimiteClose();
        }

        private void Retirar_Load(object sender, EventArgs e)
        {
            //textBox1.Text = elCBU.ToString();
        }
    }
    public delegate void DelegadoModLimiteClose();
}
