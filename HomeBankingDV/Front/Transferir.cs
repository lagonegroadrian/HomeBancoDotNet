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
    public partial class Transferir : Form
    {
        public DelegadoTransferirClose delegadoTransferirClose;

        private int elCBUorigen;
        private int elCBUdestino;
        //private int monto;
        private float monto;

        private Banco elBanco;

        public Transferir(Banco _elBanco, int _elCBUorigen)
        {
            elBanco = _elBanco;
            elCBUorigen = _elCBUorigen;
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
            bool saldoCero = true;
            bool noExisteCbu = true;

            try
            {
                if (textBox2.Text == "")
            {
                    MessageBox.Show("ingrese CBU !");
                  
            }
            else
            {
                    elCBUdestino = Int32.Parse(textBox2.Text);
                }

            foreach (CajaDeAhorro cajaBanco in elBanco.obtenerCajas())
            {
                    if(cajaBanco.cbu == elCBUdestino)
                {
                        noExisteCbu = false;
                }
            }
            if (textBox3.Text == "")
                {
                    MessageBox.Show("ingrese MONTO !");
                }
                else
                {
                    monto = float.Parse(textBox3.Text);
                }
                foreach(CajaDeAhorro cajaUsuario in elBanco.traerUsuario().cajas)
                {
                    if(cajaUsuario.cbu == elCBUorigen)
                    {
                       if(cajaUsuario.saldo >0)
                        {
                            saldoCero = false;
                        }
                        
                    }
                }
                if(saldoCero == false && noExisteCbu == false)
                {
                    elBanco.TransferirDinero(monto, elCBUorigen, elCBUdestino);
                    MessageBox.Show("Operacion realizada con Exito.");
                    this.delegadoTransferirClose(elCBUorigen);
              
                }
                if(noExisteCbu == true)
                {
                    MessageBox.Show("ingrese CBU valido !");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error catastrofico.");
               // this.delegadoTransferirClose(elCBUorigen);
                throw;
            }

        }

        private void Transferir_Load(object sender, EventArgs e)
        {
            textBox1.Text = elCBUorigen.ToString();
        }
    }
    
        public delegate void DelegadoTransferirClose(int _elCBU);
}
