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
        public DelegadoClosePL delegadoClosePL;

        private float montoCuentaOrigen { get; set; }

        private Banco elBanco;

        public PlazoFijoAdd(Banco _elBanco)
        {
            elBanco = _elBanco;
            InitializeComponent();

            textBox3.Text = "1";

            MostrarCBUs();
        }

        private void MostrarCBUs()
        {
            dataGridView1.Rows.Clear();

            foreach (CajaDeAhorro caixa in elBanco.traerUsuario().cajas)
            {dataGridView1.Rows.Add(caixa.cbu, caixa.saldo);}
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //cuenta

        }

        public int prueba() { return 11; }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //monto
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.delegadoClosePL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // boton crear plazo fijo


            
            int _cuenta = Int32.Parse(textBox1.Text);
            float _monto = float.Parse(textBox2.Text);

            

            float _tasa = float.Parse(textBox3.Text);
            int _dias = Int32.Parse(textBox4.Text);

            
                if (montoCuentaOrigen < _monto && montoCuentaOrigen <1) 
            { 
                MessageBox.Show("Monto Insuficiente.");
            } 
            else 
            {
                elBanco.RetirarDinero(_monto, _cuenta, "[PlazoFijo]");
            
                if (elBanco.AltaPlazoFijo(_monto, _dias))
                {
                    MessageBox.Show("Plazo fijo creado con éxito.");
                    this.MostrarCBUs();
                };
            }
            

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void PlazoFijoAdd_Load(object sender, EventArgs e)
        {
            //textBox1.Text = elCBUorigen.ToString();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroCBU = 0;

            float montoOrigen;

            object elCBU = dataGridView1.Rows[e.RowIndex].Cells[0].Value;            
            object auxMontoO = dataGridView1.Rows[e.RowIndex].Cells[1].Value;

            if ((elCBU is DBNull)) { return; } // por si viene nulo que salga del metodo

            nroCBU = Int32.Parse(elCBU.ToString());

            montoCuentaOrigen = Int32.Parse(auxMontoO.ToString());

            textBox1.Text = elCBU.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public delegate void DelegadoClosePL();
}
