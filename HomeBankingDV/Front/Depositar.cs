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
    public partial class Depositar : Form
    {
        //public DelegadoHommeStart delegadoHommeStart;
        public DelegadoDespositarClose delegadoDespositarClose;

        private int elCBU;
        //private int monto;
        //private Double monto;
        private float monto;

        private Banco elBanco;

        public Depositar(Banco _elBanco, int _elCBU)
        {
            elBanco = _elBanco;
            elCBU = _elCBU;
            InitializeComponent();
        }

        private void Depositar_Load(object sender, EventArgs e)
        {
            textCbuDestino.Text = elCBU.ToString();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_depositar_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (textMonto.Text == "")
                {
                    MessageBox.Show("por favor ingrese monto:");
                }
                else
                {
                    monto = float.Parse(textMonto.Text);
                }
                    
                    if (monto > 0)
                    {
                        elBanco.DepositarDinero(monto, elCBU, "");
                        MessageBox.Show("deposito realizado con exito.");
                        this.delegadoDespositarClose(elCBU);

                    }else
                {
                    MessageBox.Show("verifique monto ingresado.");
                }
                
                }
            catch (Exception)
            {
                MessageBox.Show("error en la operacion.");
                this.delegadoDespositarClose(elCBU);
                throw;
            
            }  
          
           
           
        }

        private void textCuentaOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMonto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textCbuDestino_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
        public delegate void DelegadoDespositarClose(int _elCBU);
}
