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
    public partial class VerDetalle : Form
    {
        private int laCAja;
        private Banco elBanco;

        public VerDetalle(Banco _elBanco, int _laCA)
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

            
            foreach(Movimiento movimiento in elBanco.obtenerTodosLosMovimientos()) 
            {
                if(movimiento.caja.cbu == laCAja)
                {
                    dataGridView1.Rows.Add(movimiento.idMovimiento,movimiento.monto,movimiento.detalle, movimiento.fecha);
                }
            }


            //foreach (Movimiento salida in detalles){dataGridView1.Rows.Add(salida.id, salida.monto, salida.detalle, salida.fecha);}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        private void VerDetalle_Load(object sender, EventArgs e)
        {
            llenarDatosDataGrid1();
        }
    }
}