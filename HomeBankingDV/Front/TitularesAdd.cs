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
        public DelegadoCArecargar delegadoCArecargar;

        private int elCBU;
        private Banco elBanco;

        public TitularesAdd(Banco _elBanco, int _laCA)
        {
            InitializeComponent();
            elCBU = _laCA;
            elBanco = _elBanco;
            llenarDatosDataGrid1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.delegadoCArecargar(elCBU);
        }

        private void llenarDatosDataGrid1()
        {
            dataGridView1.Rows.Clear();
            List<Usuario> allUser = elBanco.usuarios;

            foreach (Usuario salida in allUser)
            {
                string aux_ = "No";
                //INI
                elBanco.usuarioActual.MostrarTitularesCajasDeAhorro(elCBU);

                foreach (Usuario titul in elBanco.usuarioActual.MostrarTitularesCajasDeAhorro(elCBU))
                {
                    if(salida.dni == titul.dni) { aux_ = "Si"; }
                }
                //FIN

                dataGridView1.Rows.Add(salida.dni, salida.nombre, salida.apellido, aux_);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   //CUANDO LE SELECCIONAS
            int nroDoc = 0;

            object dni = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            object esTitu = dataGridView1.Rows[e.RowIndex].Cells[3].Value;

            if ((dni is DBNull) || (esTitu is DBNull)) { return; } // por si viene nulo que salga del metodo

            nroDoc = Int32.Parse(dni.ToString());

            string message = "Designar titular?";
            string caption = "Mensaje";
            string salida = "Operacion fallida";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            if (esTitu == "Si") { message = "Sacar Titular"; }

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (esTitu == "Si") {
                    if (elBanco.EliminarTitularCajaAhorro(elCBU, nroDoc)) { salida = "Operacion exitosa"; }
                }
                else {
                    if (elBanco.AgregarTitularCajaAhorro(elCBU, nroDoc)) { salida = "Operacion exitosa"; }
                }
                MessageBox.Show(salida);
            }

            // recargar...
            llenarDatosDataGrid1();
        }
    }
    public delegate void DelegadoCArecargar(int elCBU);
}