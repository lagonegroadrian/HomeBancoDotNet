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
    public partial class Login : Form
    {
    
        public DelegadoRegistroStart delegadoRegistroStart;
        public DelegadoCloseLogin delegadoCloseLogin;
        public DelegadoHommeStart delegadoHommeStart;

        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;

        // prueba
        public Login(Banco elBancoFora)
        {
            elBanco = elBancoFora;
            InitializeComponent();
        }

        //private void seteoElBanco(Banco eBanco) {elBanco = eBanco;}
        
  

        private void Registrar_Click(object sender, EventArgs e)
        {
            delegadoRegistroStart();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   try {   dniIngresado = int.Parse(textUsuario.Text);
                    contraseniaIngresada = textContrasenia.Text;
                    if (elBanco.IniciarSesion(dniIngresado, contraseniaIngresada)){delegadoHommeStart();}else { MessageBox.Show("Password Erronea"); }
                } catch (Exception){MessageBox.Show("Error en el ingreso de datos.");}
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            delegadoCloseLogin();
        }
    }

    public delegate void DelegadoRegistroStart();
    public delegate void DelegadoHommeStart();
    public delegate void DelegadoCloseLogin();
}

