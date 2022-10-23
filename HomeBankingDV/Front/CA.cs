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
    public partial class CA : Form
    {    
        //public DelegadoRegistroStart delegadoRegistroStart;
        public DelegadoCloseCA delegadoCloseCA;
        public DelegadoDepositar delegadoDepositar;
        public DelegadoRetirar delegadoRetirar;
        public DelegadoTransferir delegadoTransferir;
        public DelegadoVerDetalle delegadoVerDetalle;
        public DelegadoBajaCA delegadoBajaCA;
        

        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;
        public int elCBU;

        public CA(Banco elBancoFora, int _elCBU)
        {
            elBanco = elBancoFora;
            elCBU = _elCBU;

            InitializeComponent();
            label5.Text = _elCBU.ToString();

            label6.Text = elBanco.MostrarSaldoDeCAdeUsuarioActual(_elCBU).ToString();

            foreach (Usuario titul in elBanco.usuarioActual.MostrarTitularesCajasDeAhorro(_elCBU))
            {
                listBox1.Items.Add(titul.apellido + ", " + titul.nombre);
            }
        }


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
            delegadoCloseCA();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.delegadoCloseCA();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.delegadoDepositar(elCBU);
            //Form formulario = new Depositar(elBanco, elCBU);
            //formulario.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.delegadoRetirar(elCBU);
            //Form formulario = new Retirar(elBanco, elCBU);
            //formulario.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.delegadoTransferir(elCBU);
            //Form formulario = new Transferir(elBanco, elCBU);
            //formulario.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.delegadoVerDetalle(elCBU);
            //Form formulario = new VerDetalle();
            //formulario.Show();
        }

        private void CA_Load(object sender, EventArgs e)
        {
            
        }

        private void CA_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Dar de baja caja de ahorro
            this.delegadoBajaCA(elCBU);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.delegadoBajaCA(elCBU);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }

    //public delegate void TransfDelegado();
    public delegate void DelegadoCloseCA();

    public delegate void DelegadoDepositar(int elCBU);
    public delegate void DelegadoRetirar(int elCBU);
    public delegate void DelegadoTransferir(int elCBU);
    public delegate void DelegadoVerDetalle(int elCBU);
    public delegate void DelegadoBajaCA(int elCBU);
}

