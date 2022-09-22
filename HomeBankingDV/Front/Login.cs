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
    
        public TransfDelegado transfDelegado;

        public Login()
        {
           InitializeComponent();

        }
        
  

        private void Registrar_Click(object sender, EventArgs e)
        {
            transfDelegado();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    public delegate void TransfDelegado();

    
}

