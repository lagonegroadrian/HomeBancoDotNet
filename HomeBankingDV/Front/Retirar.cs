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
    public partial class Retirar : Form
    {
        public DelegadoRetirarClose delegadoRetirarClose;

        private int elCBU;
        //private int monto;
        private float monto;
        private Banco elBanco;

        public Retirar(Banco _elBanco, int _elCBU)
        {
            elBanco = _elBanco;
            elCBU = _elCBU;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //retirar monto


            try
            {
                foreach (CajaDeAhorro cajaU in elBanco.usuarioActual.cajas)
                {
                    if (cajaU.cbu == elCBU)
                    {
                        if (cajaU.saldo > 0)
                        {
                            if (textBox2.Text == "" || float.Parse(textBox2.Text) <= 0)
                            {
                                MessageBox.Show("por favor ingrese monto valido:");

                            }

                            else
                            {
                                monto = float.Parse(textBox2.Text);
                                elBanco.RetirarDinero(monto, elCBU, "");
                                MessageBox.Show("operacion realizada con exito.");
                                this.delegadoRetirarClose(elCBU);
                            }
                        }else
                        {
                            MessageBox.Show("saldo insuficiente.");
                            this.delegadoRetirarClose(elCBU);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error en la operacion !");
                throw;
            }
            
          
        }

        private void Retirar_Load(object sender, EventArgs e)
        {
            textBox1.Text = elCBU.ToString();
        }
    }
    public delegate void DelegadoRetirarClose(int _elCBU);
}
