using HomeBankingDV.Front;
using HomeBankingDV.Logica;
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
    public partial class Home : Form
    {
        public DelegadoCloseHomme delegadoCloseHomme;
        public DelegadoHommeToCA delegadoHommeToCA;
        public DelegadoPlazoFijo delegadoPlazoFijo;
        public DelegadoHommeToTarjeta delegadoHommeToTarjeta;
        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;

        public Home(Banco elBancoFora)
        {
            elBanco = elBancoFora;
            InitializeComponent();
            llenarDatosDataGrid1();
            llenarDatosDataGrid6();
            llenarDatosDataGrid8();
        }

        private void llenarDatosDataGrid1()
        {
            dataGridView1.Rows.Clear();
            foreach (CajaDeAhorro salida in elBanco.traerUsuario().cajas) { dataGridView1.Rows.Add(salida.idCajaDeAhorro, salida.cbu, salida.saldo); }
        }

        private void llenarDatosDataGrid8()
        {
            dataGridView8.Rows.Clear();
            foreach (TarjetaDeCredito salida in elBanco.traerUsuario().tarjetas)
            {
                dataGridView8.Rows.Add(salida.idTarjetaDeCredito, salida.numero, salida.codigoV, salida.limite, salida.consumos);
            }
        }


        private void llenarDatosDataGrid6() // llenar plazo fijo
        {   dataGridView6.Rows.Clear();
            foreach (PlazoFijo salida in elBanco.traerUsuario().pfs)
            {
                string aux = "EnCurso";
                if (salida.pagado) { aux = "Acobrar"; }

                dataGridView6.Rows.Add(salida.idPlazoFijo, salida.monto, salida.fechaIni.Date + " A " + salida.fechaFin.Date, aux);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            elBanco.AltaCajaAhorro();
            llenarDatosDataGrid1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            object elCBU = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            object elSaldo = dataGridView1.Rows[e.RowIndex].Cells[2].Value;

            if ((elCBU is DBNull) || (elSaldo is DBNull)) { return; } // por si viene nulo que salga del metodo


            int nroCBU = Int32.Parse(elCBU.ToString());

            Double valorSaldo = Double.Parse(elSaldo.ToString());


            this.delegadoHommeToCA(nroCBU);

            //Form formulario = new CA(elBanco, nroCBU, valorSaldo);
            //formulario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delegadoCloseHomme();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void cajasDeAhorroTab_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            delegadoCloseHomme();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string salida = "";
            string message = "Desea eliminar Plazo Fijo?";
            string caption = "*Importante*";

            object auxIdPL = dataGridView6.Rows[e.RowIndex].Cells[0].Value;
            object auxSaldo = dataGridView6.Rows[e.RowIndex].Cells[1].Value;
            object auxEstado = dataGridView6.Rows[e.RowIndex].Cells[3].Value;

            if ((auxIdPL is DBNull) || (auxSaldo is DBNull)) { return; } // por si viene nulo que salga del metodo

            int  idPlazoFijo = Int32.Parse(auxIdPL.ToString());
            int _saldo = Int32.Parse(auxSaldo.ToString());
            string _estado = auxEstado.ToString();

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            if (_estado == "EnCurso")
            {
                salida = "Plazo Fijo se encuentra en curso";
            }
            else
            { 
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (elBanco.BajaPlazoFijo(idPlazoFijo))
                    {
                        salida = "Plazo Fijo eliminado correctamente";
                        this.llenarDatosDataGrid6();
                    }
                    else 
                    { 
                        salida = "Error: Plazo Fijo no se pudo eliminar"; 
                    }
                }
            }
            MessageBox.Show(salida);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // llamar al plazo fijo
            this.delegadoPlazoFijo();
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // cuandoDoble click sobre dataGrid8

            object elid = dataGridView8.Rows[e.RowIndex].Cells[0].Value;
            object elnumero = dataGridView8.Rows[e.RowIndex].Cells[1].Value;
            object elcodigo = dataGridView8.Rows[e.RowIndex].Cells[2].Value;
            object ellimite = dataGridView8.Rows[e.RowIndex].Cells[3].Value;
            object elconsumo = dataGridView8.Rows[e.RowIndex].Cells[4].Value;

            if ((elid is DBNull) ||(elnumero is DBNull) ||(elcodigo is DBNull) ||(ellimite is DBNull) ||(elconsumo is DBNull)){ return; } // por si viene nulo que salga del metodo

            int idTarjeta = Int32.Parse(elid.ToString());
            int numeroTarjeta = Int32.Parse(elnumero.ToString());
            int codigoTarjeta = Int32.Parse(elcodigo.ToString());
            float limiteTarjeta = float.Parse(ellimite.ToString());
            float consumoTarjeta = float.Parse(elconsumo.ToString());

            this.delegadoHommeToTarjeta(idTarjeta, numeroTarjeta, codigoTarjeta,limiteTarjeta,consumoTarjeta);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //aca dar de baja
            //elBanco.DarDeBajaTarjeta();
            //llenarDatosDataGrid8();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string salida="Error al crear Tarjeta de credito";
            if (elBanco.AltaTarjetaCredito()) 
            { 
                salida = "Tarjeta de Credito Creada";
                llenarDatosDataGrid8();
            }
            MessageBox.Show(salida);
        }
    }

    //public delegate void TransfDelegado();
    public delegate void DelegadoCloseHomme();
    public delegate void DelegadoHommeToCA(int nroCBU);
    public delegate void DelegadoPlazoFijo();
    public delegate void DelegadoHommeToTarjeta(int idTarjeta, int numeroTarjeta, int codigoTarjeta, float limiteTarjeta, float consumoTarjeta);
}