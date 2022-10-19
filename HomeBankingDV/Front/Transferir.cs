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
    public partial class Transferir : Form
    {
        private int elCBUorigen;
        private int elCBUdestino;
        private int monto;

        private Banco elBanco;

        public Transferir(Banco _elBanco, int _elCBUorigen)
        {
            elBanco = _elBanco;
            elCBUorigen = _elCBUorigen;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int prueba() { return 11; }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aux = " NO ";

            elCBUdestino = Int32.Parse(textBox2.Text);
            //elBanco.TransferirDinero(monto, elCBUorigen, elCBUdestino);
            if (elBanco.TransferirDinero(monto, elCBUorigen, elCBUdestino)) 
            {aux = "";}
            MessageBox.Show("transferencia "+aux+" realizada ");
            Close();
        }

        private void Transferir_Load(object sender, EventArgs e)
        {
            textBox1.Text = elCBUorigen.ToString();
        }
    }
}
