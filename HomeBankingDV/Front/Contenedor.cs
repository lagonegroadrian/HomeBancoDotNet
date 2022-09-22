namespace HomeBankingDV
{
    public partial class Contenedor : Form
    {
        Login hijoLogin;
        Registrar hijoRegistrar;


        public Contenedor()
        {
            InitializeComponent();
            hijoLogin = new Login();
            hijoLogin.MdiParent = this;
            hijoLogin.transfDelegado += TransfDelegado;
            hijoLogin.Show(); 


        }

        private void TransfDelegado()
        {
            hijoLogin.Close();
            hijoRegistrar = new Registrar();   
            hijoRegistrar.MdiParent = this;
            hijoRegistrar.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}