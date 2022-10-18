using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HomeBankingDV.Front
{
    public partial class CrearNuevaCaja : Form
    {
        public delegadonuevaCaja delegadonuevaCaja;
        public Banco elBanco;
        public CrearNuevaCaja()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

          //  elBanco.crearCajaAhorro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    public delegate void delegadonuevaCaja();
}
