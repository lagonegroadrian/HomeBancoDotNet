using HomeBankingDV.Front;
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
        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;
        

        public Home(Banco elBancoFora)
        {
            //elBanco = new Banco();
            elBanco = elBancoFora;
            //seteoElBanco(elBanco);            
            InitializeComponent();
            List <string> cajasDeAhorro = new List<string>();
            List<CajaDeAhorro> cajaDeAhorroList = new List<CajaDeAhorro>();
            cajaDeAhorroList.Add(new CajaDeAhorro(123, 2323, null, 213322, null));
            cajaDeAhorroList.Add(new CajaDeAhorro(12243, 2132323, null, 2163322, null));
            llenarDatosDataGrid1();
        }

        private void llenarDatosDataGrid1()
        {
            dataGridView1.Rows.Clear();
            foreach (CajaDeAhorro salida in elBanco.usuarioActual.MostrarCajasDeAhorro()) { dataGridView1.Rows.Add(salida.id, salida.cbu, salida.saldo); }
        }

        //private void seteoElBanco(Banco eBanco) {elBanco = eBanco;}



        private void Registrar_Click(object sender, EventArgs e)
        {
            //transfDelegado();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dniIngresado = int.Parse(textUsuario.Text);
            //contraseniaIngresada = textContrasenia.Text;

            //elBanco.IniciarSesion(dniIngresado,contraseniaIngresada);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            delegadoCloseHomme();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            //Form crearCaja = new CrearNuevaCaja();
            //crearCaja.Show();
            elBanco.AltaCajaAhorro(elBanco.usuarioActual);
            llenarDatosDataGrid1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form formulario = new Depositar();
            formulario.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //aca
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int nroCBU = 0;
            int valorSaldo = 0;

            object elCBU = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            object elSaldo = dataGridView1.Rows[e.RowIndex].Cells[2].Value;

            if ((elCBU is DBNull) || (elSaldo is DBNull)) { return; } // por si viene nulo que salga del metodo


            nroCBU = Int32.Parse(elCBU.ToString());
            valorSaldo = Int32.Parse(elSaldo.ToString());

            Form formulario = new CA(elBanco, nroCBU, valorSaldo);
            formulario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delegadoCloseHomme();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form formulario = new Retirar();
            formulario.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form formulario = new Transferir();
            formulario.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form formulario = new VerDetalle();
            formulario.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }

    //public delegate void TransfDelegado();
    public delegate void DelegadoCloseHomme();

    

}

