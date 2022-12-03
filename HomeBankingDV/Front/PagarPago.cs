using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBankingDV.Front
{
    public partial class PagarPago : Form
    {
        public DelegadoClosePago delegadoClosePago;

        private float montoCuentaOrigen { get; set; }

        private Banco elBanco;
        private int idpago;
        private float _saldoCa;
        private int nroCBU;

        public PagarPago(Banco _elBanco, int _idpago)
        {
            elBanco = _elBanco;
            idpago = _idpago;
            InitializeComponent();

            MostrarCBUs();
        }

        private void MostrarCBUs()
        {
            dataGridView1.Rows.Clear();

            foreach (CajaDeAhorro caixa in elBanco.obtenerUsuarioActualCajasDeAhorro())
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
            this.delegadoClosePago();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (elBanco.ModificarPago(idpago, true, "cajaAhorro", _saldoCa, nroCBU))
            {
                MessageBox.Show("Pago realizado con exito");
            }
            else { MessageBox.Show("No se pudo procesar el Pago - monto insuficiente");  }

            //int _cuenta = Int32.Parse(textBox1.Text);

            this.delegadoClosePago();

        }

        private void PagarPago_Load(object sender, EventArgs e)
        {
            //textBox1.Text = elCBUorigen.ToString();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          

            float montoOrigen;

            object elCBU = dataGridView1.Rows[e.RowIndex].Cells[0].Value;            
            object auxMontoO = dataGridView1.Rows[e.RowIndex].Cells[1].Value;

            if ((elCBU is DBNull)) { return; } // por si viene nulo que salga del metodo

            nroCBU = Int32.Parse(elCBU.ToString());

            //_saldoCa = Int32.Parse(auxMontoO.ToString());
            _saldoCa = Convert.ToSingle(auxMontoO.ToString(), CultureInfo.CreateSpecificCulture("en-US"));

            textBox1.Text = elCBU.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public delegate void DelegadoClosePago();
}
