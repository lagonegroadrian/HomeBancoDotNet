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
                string aux_ = "No";
                //INI
                elBanco.usuarioActual.MostrarTitularesCajasDeAhorro(laCAja);

                foreach (Usuario titul in elBanco.usuarioActual.MostrarTitularesCajasDeAhorro(laCAja))
                {
                    if(salida.dni == titul.dni) { aux_ = "Si"; }
                }
                //FIN

                dataGridView1.Rows.Add(salida.dni, salida.nombre, salida.apellido, aux_);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroDoc = 0;

            object dni = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            object esTitu = dataGridView1.Rows[e.RowIndex].Cells[3].Value;

            if ((dni is DBNull) || (esTitu is DBNull)) { return; } // por si viene nulo que salga del metodo

            nroDoc = Int32.Parse(dni.ToString());

            if (esTitu == "No") { elBanco.AgregarTitularCajaAhorro(laCAja, nroDoc); }
        }
    }
}