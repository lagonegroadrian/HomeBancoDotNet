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

        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;

        public CA(Banco elBancoFora, int _elCBU, int _elSaldo)
        {
            elBanco = elBancoFora;

            InitializeComponent();

            label5.Text = _elCBU.ToString();
            label6.Text = _elSaldo.ToString();

            foreach (Usuario titul in elBanco.usuarioActual.MostrarTitularesCajasDeAhorro(_elCBU)){listBox1.Items.Add(titul.apellido + " * " + titul.nombre);}
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
            this.Close();
        }
    }

    //public delegate void TransfDelegado();
    public delegate void DelegadoCloseCA();

    

}

