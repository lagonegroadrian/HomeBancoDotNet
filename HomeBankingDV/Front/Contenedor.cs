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
            hijoCA.Show();
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


        private void DelegadoHommeToCA(int _elCBU) 
        {
            hijoHomme.Close();
            ActivoCA(_elCBU);
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