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
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("por favor ingrese CBU");
                }
                else
                {
                    elCBUdestino = Int32.Parse(textBox2.Text);
                }

                if (textBox3.Text == "" || float.Parse(textBox3.Text)<=0)
                {
                    MessageBox.Show("por favor ingrese un monto valido.");
                }
                else
                {
                    monto = float.Parse(textBox3.Text);
                }
                foreach (CajaDeAhorro cajasU in elBanco.usuarioActual.cajas)
                {
                   if(cajasU.cbu == elCBUorigen)
                    {
                        if (cajasU.saldo > 0 && cajasU.saldo <= monto)
                        {
                            elBanco.TransferirDinero(monto, elCBUorigen, elCBUdestino);
                            MessageBox.Show("transferencia realizada con exito.");
                            this.delegadoTransferirClose(elCBUorigen);

                        }
                        else
                        {
                            MessageBox.Show("saldo insuficiente.");
                            this.delegadoTransferirClose(elCBUorigen);
                        }
                    }
                    
                }
                
               
            }
            catch (Exception)
            {
                MessageBox.Show("error en la operacion.");
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
