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
    public partial class Tarjeta : Form
    {    
        public DelegadoCloseTar delegadoCloseTar;
        //public DelegadoDepositar delegadoDepositar;
        public DelegadoModLimite delegadoModLimite;
        //public DelegadoTransferir delegadoTransferir;
        //public DelegadoVerDetalle delegadoVerDetalle;
        //public DelegadoBajaCA delegadoBajaCA;
        //public DelegadoModificar delegadoModificar;


        public Banco elBanco;
        private int idTarjeta;
        private float limite;

        public Tarjeta(Banco elBancoFora, int _elidTar, int _numeroTarjeta, int _codigoTarjeta, float _limiteTarjeta, float _consumoTarjeta)
        {
            elBanco = elBancoFora;
            idTarjeta = _elidTar;

            InitializeComponent();
            label5.Text = _elidTar.ToString();
            label6.Text = _numeroTarjeta.ToString();
            label9.Text = _codigoTarjeta.ToString();
            label10.Text = _limiteTarjeta.ToString();
            label11.Text = _consumoTarjeta.ToString();
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
            delegadoCloseTar();
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
            this.delegadoCloseTar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.delegadoDepositar(elCBU);
            //Form formulario = new Depositar(elBanco, elCBU);
            //formulario.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //this.delegadoRetirar(elCBU);
            //Form formulario = new Retirar(elBanco, elCBU);
            //formulario.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //this.delegadoTransferir(elCBU);
            //Form formulario = new Transferir(elBanco, elCBU);
            //formulario.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //this.delegadoVerDetalle(elCBU);
            //Form formulario = new VerDetalle();
            //formulario.Show();
        }

        private void Tarjeta_Load(object sender, EventArgs e)
        {
            
        }

        private void Tarjeta_Load_1(object sender, EventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e){this.delegadoBajaCA(elCBU);}

        private void button1_Click_1(object sender, EventArgs e)
        {
            string salida = "No fue posible eliminar tarjeta, recuerde que debe tener 0 consumos";
            if (elBanco.BajaTarjetaCredito(idTarjeta)) { salida = "Tarjeta dada de baja correctamente";  };
            MessageBox.Show(salida);
            delegadoCloseTar();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.delegadoModLimite(idTarjeta,limite);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }

    public delegate void DelegadoCloseTar();
    //public delegate void DelegadoDepositar(int elCBU);
    public delegate void DelegadoModLimite(int idTarjeta, float limite);
    //public delegate void DelegadoTransferir(int elCBU);
    //public delegate void DelegadoVerDetalle(int elCBU);
    //public delegate void DelegadoBajaCA(int elCBU);   
    //public delegate void DelegadoModificar(int elCBU);
}