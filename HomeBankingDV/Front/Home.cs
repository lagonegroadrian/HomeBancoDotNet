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
    
        //public DelegadoRegistroStart delegadoRegistroStart;
        public DelegadoCloseHomme delegadoCloseHomme;
        public DelegadoHommeToCA delegadoHommeToCA;
        public DelegadoPlazoFijo delegadoPlazoFijo;
        public Banco elBanco;
        public int dniIngresado;
        public string contraseniaIngresada;

        public Home(Banco elBancoFora)
        {
            elBanco = elBancoFora;
            InitializeComponent();

            llenarDatosDataGrid1();
            llenarDatosDataGrid6();
        }

        private void llenarDatosDataGrid1()
        {
            dataGridView1.Rows.Clear();
          //  elBanco.traerUsuario().cajas.Clear();

            foreach (CajaDeAhorro salida in elBanco.traerUsuario().cajas) { dataGridView1.Rows.Add(salida.idCajaDeAhorro, salida.cbu, salida.saldo); }

         
        }


        private void llenarDatosDataGrid6()
        {
            dataGridView6.Rows.Clear();
          //  elBanco.traerUsuario().pfs.Clear();

            foreach (PlazoFijo oPlazo in elBanco.obtenerPlazosFijos()) 
            {
                if (elBanco.traerUsuario().idUsuario == (oPlazo.titularP.idUsuario))
                {
                    string aux = "EnCurso";

                    if (oPlazo.pagado) { aux = "Acobrar"; }

                    dataGridView6.Rows.Add(oPlazo.idPlazoFijo , oPlazo.monto, oPlazo.fechaIni.Date + " A " + oPlazo.fechaFin.Date , aux);
                    elBanco.traerUsuario().pfs.Add(oPlazo);

                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //Form crearCaja = new CrearNuevaCaja();
            //crearCaja.Show();
            //elBanco.AltaCajaAhorro();
            elBanco.AltaCajaAhorro();
            llenarDatosDataGrid1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Form formulario = new Depositar();
            //formulario.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //aca
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int nroCBU = 0;
            //int valorSaldo = 0;
            Double valorSaldo = 0;

            object elCBU = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            object elSaldo = dataGridView1.Rows[e.RowIndex].Cells[2].Value;

            if ((elCBU is DBNull) || (elSaldo is DBNull)) { return; } // por si viene nulo que salga del metodo


            nroCBU = Int32.Parse(elCBU.ToString());
            
            //valorSaldo = Int32.Parse(elSaldo.ToString());
            valorSaldo = Double.Parse(elSaldo.ToString());


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
            if (_estado == "EnCurso") { 
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (elBanco.BajaPlazoFijo(idPlazoFijo))
                {
                        salida = "Plazo Fijo eliminado correctamente";
                        this.llenarDatosDataGrid6();

                }
                
            }
            }
            else { salida = "Plazo Fijo se encuentra en curso";  }

            MessageBox.Show(salida);
            //FIN

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // llamar al plazo fijo
            this.delegadoPlazoFijo();
        }
    }

    //public delegate void TransfDelegado();
    public delegate void DelegadoCloseHomme();
    public delegate void DelegadoHommeToCA(int nroCBU);
    public delegate void DelegadoPlazoFijo();

}