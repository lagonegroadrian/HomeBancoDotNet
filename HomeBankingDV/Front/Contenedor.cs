namespace HomeBankingDV
{
    public partial class Contenedor : Form
    {
        Login hijoLogin;
        Registrar hijoRegistrar;
        public Banco elBanco = new Banco();

        
        public Contenedor()
        {
            elBanco.AltaUsuario(39500600, "Tomas", "Rodriguez", "rodriguezt@banco.com", "123456");

            InitializeComponent();
            hijoLogin = new Login(elBanco);
            hijoLogin.MdiParent = this;
            hijoLogin.transfDelegado += TransfDelegado;
            hijoLogin.Show(); 


        }

        private void TransfDelegado()
        {
            hijoLogin.Close();
            hijoRegistrar = new Registrar(elBanco);   
            hijoRegistrar.MdiParent = this;
            hijoRegistrar.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}