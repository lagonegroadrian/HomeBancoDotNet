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
    public partial class PlazoFijoAdd : Form
    {
        public DelegadoPlazoFijoAddClose delegadoPlazoFijoAddClose;


        private int elCBUdestino;
        //private int monto;
        private float monto;

        private Banco elBanco;

        public PlazoFijoAdd(Banco _elBanco)
        {
            elBanco = _elBanco;
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
            elCBUdestino = Int32.Parse(textBox2.Text);
            monto= float.Parse(textBox3.Text);

            //elBanco.PlazoFijoAdd(monto, elCBUorigen, elCBUdestino);
            //this.delegadoPlazoFijoAddClose(elCBUorigen);
        }

        private void PlazoFijoAdd_Load(object sender, EventArgs e)
        {
            //textBox1.Text = elCBUorigen.ToString();
        }
    }
    
        public delegate void DelegadoPlazoFijoAddClose(int _elCBU);
}
