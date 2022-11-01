using HomeBankingDV.Front;
using HomeBankingDV.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HomeBankingDV
{
    public partial class Home : Form
    {
    
        //public DelegadoRegistroStart delegadoRegistroStart;
        public DelegadoCloseHomme delegadoCloseHomme;
        public DelegadoHommeToCA delegadoHommeToCA;
        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;

        public Home(Banco elBancoFora)
        {
            elBanco = elBancoFora;
            InitializeComponent();
            List <string> cajasDeAhorro = new List<string>();
            List<CajaDeAhorro> cajaDeAhorroList = new List<CajaDeAhorro>();
            llenarDatosDataGrid1();
        }

        private void llenarDatosDataGrid1()
        {
            dataGridView1.Rows.Clear();
            elBanco.usuarioActual.cajas.Clear();

            //foreach (CajaDeAhorro salida in elBanco.usuarioActual.MostrarCajasDeAhorro()) { dataGridView1.Rows.Add(salida.id, salida.cbu, salida.saldo); }

            foreach (TitularesRel osTitulares in elBanco.obtenerTitulares()) // Le traigo los titulares
            {
                if (elBanco.usuarioActual.id == (osTitulares.idUs)) // filtro esos titulares por el usuario logueado
                {
                    foreach (CajaDeAhorro asCaixas in elBanco.obtenerCajas()) // Traigo las Caixas de ahorro
                    {
                        if ((osTitulares.idCa)==(asCaixas.id)) 
                        {
                            dataGridView1.Rows.Add(asCaixas.id, asCaixas.cbu, asCaixas.saldo);
                            elBanco.usuarioActual.cajas.Add(asCaixas);
                        }
                    }
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //Form crearCaja = new CrearNuevaCaja();
            //crearCaja.Show();
            //elBanco.AltaCajaAhorro();
            elBanco.AltaCajaAhorro_v2();
            llenarDatosDataGrid1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Form formulario = new Depositar();
            //formulario.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //aca
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int nroCBU = 0;
            //int valorSaldo = 0;
            Double valorSaldo = 0;

            object elCBU = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            object elSaldo = dataGridView1.Rows[e.RowIndex].Cells[2].Value;

            if ((elCBU is DBNull) || (elSaldo is DBNull)) { return; } // por si viene nulo que salga del metodo


            nroCBU = Int32.Parse(elCBU.ToString());
            
            //valorSaldo = Int32.Parse(elSaldo.ToString());
            valorSaldo = Double.Parse(elSaldo.ToString());


            this.delegadoHommeToCA(nroCBU);

            //Form formulario = new CA(elBanco, nroCBU, valorSaldo);
            //formulario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delegadoCloseHomme();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void cajasDeAhorroTab_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            delegadoCloseHomme();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    //public delegate void TransfDelegado();
    public delegate void DelegadoCloseHomme();
    public delegate void DelegadoHommeToCA(int nroCBU);
}