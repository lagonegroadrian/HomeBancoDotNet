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
    public partial class TitularesAdd : Form
    {
        private int laCAja;
        private Banco elBanco;

        public TitularesAdd(Banco _elBanco, int _laCA)
        {
            InitializeComponent();
            laCAja = _laCA;
            elBanco = _elBanco;
            llenarDatosDataGrid1();
        }

        private void button1_Click(object sender, EventArgs e){Close();}

        private void llenarDatosDataGrid1()
        {
            dataGridView1.Rows.Clear();
            
            //List<Movimiento> detalles = elBanco.BuscarMovimientos(laCAja);
            List<Usuario> detalles = elBanco.usuarios;

            

            foreach (Usuario salida in detalles)
            {
                dataGridView1.Rows.Add(salida.dni, salida.nombre, salida.apellido, "no");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}
    }
}