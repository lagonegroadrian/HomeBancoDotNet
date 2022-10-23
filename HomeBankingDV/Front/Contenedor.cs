namespace HomeBankingDV
{
    using Front;
    public partial class Contenedor : Form
    {
        Login hijoLogin;
        Registrar hijoRegistrar;
        Home hijoHomme;
        CA hijoCA;
        Depositar hijoDepositar;
        Retirar hijoRetirar;
        Transferir hijoTransferir;
        VerDetalle hijoDetalle;
        TitularesAdd hijoModificarCA;

        public Banco elBanco = new Banco();


        public Contenedor()
        {
            elBanco.AltaUsuario(1, "Tomas", "Rodriguez", "rodriguezt@banco.com", "1", false, false);
            elBanco.AltaUsuario(35147312, "Adrian", "Lagonegro", "Lagonegro@cobanco.com", "123", false, false);

            ActivoLogin();
        }

        public void ActivoLogin() {
            InitializeComponent();
            hijoLogin = new Login(elBanco);
            hijoLogin.MdiParent = this;
            hijoLogin.delegadoRegistroStart += DelegadoRegistroStart;
            hijoLogin.delegadoCloseLogin += DelegadoCloseLogin;
            hijoLogin.delegadoHommeStart += DelegadoHommeStart;
            hijoLogin.Show();
        }

        public void ActivoCA(int _elCBU)
        {
            InitializeComponent();
            hijoCA = new CA(elBanco, _elCBU);

            hijoCA.MdiParent = this;
            hijoCA.delegadoCloseCA += DelegadoCloseCA;
            hijoCA.delegadoDepositar += DelegadoDepositar;
            hijoCA.delegadoRetirar += DelegadoRetirar;
            hijoCA.delegadoTransferir += DelegadoTransferir;
            hijoCA.delegadoVerDetalle += DelegadoVerDetalle;
            hijoCA.delegadoBajaCA += DelegadoBajaCA;
            hijoCA.delegadoModificar += DelegadoModificar;
            

            hijoCA.Show();
        }

        public void ActivoVerDetalle(int _elCBU)
        {
            InitializeComponent();
            hijoDetalle = new VerDetalle(elBanco, _elCBU);

            hijoDetalle.MdiParent = this;
            hijoDetalle.Show();
        }

        public void ActivoRegistro()
        {
            hijoRegistrar = new Registrar(elBanco);
            hijoRegistrar.MdiParent = this;
            hijoRegistrar.delegadoCloseRegistro += DelegadoCloseRegistro;
            hijoRegistrar.Show();
        }


        public void ActivoHomme()
        {
            hijoHomme = new Home(elBanco);
            hijoHomme.MdiParent = this;
            hijoHomme.delegadoCloseHomme += DelegadoCloseHomme;
            hijoHomme.delegadoHommeToCA += DelegadoHommeToCA;
            hijoHomme.Show();
        }

        public void ActivoDepositar(int _elCBU)
        {
            hijoDepositar = new Depositar(elBanco, _elCBU);
            hijoDepositar.MdiParent = this;
            hijoDepositar.delegadoDespositarClose += DelegadoDespositarClose;
            hijoDepositar.Show();
        }


        public void ActivoRetirar(int _elCBU)
        {
            hijoRetirar = new Retirar(elBanco, _elCBU);
            hijoRetirar.MdiParent = this;
            hijoRetirar.delegadoRetirarClose += DelegadoRetirarClose;


            hijoRetirar.Show();
        }


        public void ActivoTransferir(int _elCBU)
        {
            hijoTransferir = new Transferir(elBanco, _elCBU);
            hijoTransferir.MdiParent = this;
            hijoTransferir.delegadoTransferirClose  += DelegadoTransferirClose;
            hijoTransferir.Show();
        }

        public void ActivoModificar(int _elCBU)
        {
            hijoModificarCA = new TitularesAdd(elBanco, _elCBU);
            hijoModificarCA.MdiParent = this;
            hijoModificarCA.delegadoCArecargar += DelegadoCArecargar;
            hijoModificarCA.Show();
        }

        private void DelegadoHommeToCA(int _elCBU) 
        {
            hijoHomme.Close();
            ActivoCA(_elCBU);
        }


        private void DelegadoCArecargar(int _elCBU)
        {
            hijoModificarCA.Close();
            hijoCA.Close();
            ActivoCA(_elCBU);
        }

        private void DelegadoModificar(int _elCBU)
        {
            hijoHomme.Close();
            ActivoModificar(_elCBU);
        }
        

        private void DelegadoBajaCA(int _elCBU)
        {
            string salida="Operacion no Exitosa, CA posee saldo";

            //INICIO
            // Checks the value of the text.
            
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Desea dar de baja la cuenta?";
                string caption = "*Importante*";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                // Closes the parent form.
                if (elBanco.BajaCajaAhorro(_elCBU)) 
                {
                    salida = "Cuenta dada de baja correctamente";
                }
                MessageBox.Show(salida);
                hijoCA.Close();
                ActivoHomme();
                //this.Close();
            }
            
            //FIN

        }


        


        private void DelegadoDespositarClose(int _elCBU)
        {
            hijoDepositar.Close();
            hijoCA.Close();
            //ActivoCA(_elCBU);
            ActivoCA(_elCBU);
        }

        private void DelegadoRetirarClose(int _elCBU)
        {
            hijoRetirar.Close();
            hijoCA.Close();
            //ActivoCA(_elCBU);
            ActivoCA(_elCBU);
        }

        private void DelegadoTransferirClose(int _elCBU)
        {
            hijoTransferir.Close();
            hijoCA.Close();
            //ActivoCA(_elCBU);
            ActivoCA(_elCBU);
        }

        private void DelegadoTransferir(int _elCBU)
        {
            hijoHomme.Close();
            ActivoTransferir(_elCBU);
        }

        private void DelegadoVerDetalle(int _elCBU)
        {
            hijoHomme.Close();
            ActivoVerDetalle(_elCBU);
        }


        private void DelegadoDepositar(int _elCBU)
        {
            hijoHomme.Close();
            ActivoDepositar(_elCBU);
        }

        private void DelegadoRetirar(int _elCBU)
        {
            hijoHomme.Close();
            ActivoRetirar(_elCBU);
        }

        private void DelegadoRegistroStart()
        {
            hijoLogin.Close();
            ActivoRegistro();
        }

        private void DelegadoCloseCA()
        {
            hijoCA.Close();
            ActivoHomme();
        }
        

        private void DelegadoHommeStart()
        {
            hijoLogin.Close();
            ActivoHomme();
        }

        private void DelegadoCloseRegistro()
        {
            hijoRegistrar.Close();
            ActivoLogin();
        }

        private void DelegadoCloseLogin()
        {
            hijoLogin.Close();
            this.Dispose();
        }

        private void DelegadoCloseHomme()
        {
            hijoHomme.Close();
            elBanco.usuarioActual = null;
            ActivoLogin();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}