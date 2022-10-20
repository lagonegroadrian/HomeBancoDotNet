namespace HomeBankingDV
{
    public partial class Contenedor : Form
    {
        Login hijoLogin;
        Registrar hijoRegistrar;
        Home hijoHomme;
        CA hijoCA;

        public Banco elBanco = new Banco();

        
        public Contenedor()
        {
            elBanco.AltaUsuario(1, "Tomas", "Rodriguez", "rodriguezt@banco.com", "1",false,false);
            elBanco.AltaUsuario(35147312, "Adrian", "Lagonegro", "Lagonegro@cobanco.com", "123",false,false);
            
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

        private void DelegadoHommeToCA(int _elCBU) 
        {
            hijoHomme.Close();
            ActivoCA(_elCBU);
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