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
    public partial class Retirar : Form
    {
        public DelegadoRetirarClose delegadoRetirarClose;

        private int elCBU;
        //private int monto;
        private float monto;
        private Banco elBanco;

        public Retirar(Banco _elBanco, int _elCBU)
        {
            elBanco = _elBanco;
            elCBU = _elCBU;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            //retirar monto
            monto = float.Parse(textBox2.Text);
            elBanco.RetirarDinero(monto, elCBU);
            this.delegadoRetirarClose(elCBU);
        }

        private void Retirar_Load(object sender, EventArgs e)
        {
            textBox1.Text = elCBU.ToString();
        }
    }
    public delegate void DelegadoRetirarClose(int _elCBU);
}
