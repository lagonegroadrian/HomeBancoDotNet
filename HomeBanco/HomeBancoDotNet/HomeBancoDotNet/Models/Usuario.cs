
//using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeBancoDotNet.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
       
        public bool isAdmin { get; set; }

        public int intentos { get; set; }

        public bool bloqueado { get; set; }
        public string Rol { get; set; }

        public ICollection<CajaDeAhorro> cajas { get; } = new List<CajaDeAhorro>();
        public List<TitularesRel> UserCajas { get; set; } = new List<TitularesRel>();

        public List<PlazoFijo> pfs { get; } = new List<PlazoFijo>();
        public ICollection<TarjetaDeCredito> tarjetas { get; } = new List<TarjetaDeCredito>();


        public List<Pago> pagos { get; } = new List<Pago>();
        //public ICollection<Pago> pagos { get;} = new List<Pago>();



        //constructor
        public Usuario() { }
        public Usuario(int dni, string nombre, string apellido, string mail, string password, bool isAdmin, bool bloqueado, int intentos, string Rol)
        {
            this.idUsuario = idUsuario;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            this.isAdmin = isAdmin;
            this.bloqueado = bloqueado;
            cajas = new List<CajaDeAhorro>();
            pfs = new List<PlazoFijo>();
            this.tarjetas = new List<TarjetaDeCredito>();
            this.pagos = new List<Pago>();
            this.intentos = intentos;
            this.Rol = Rol;

        }

        public List<CajaDeAhorro> MostrarCajasDeAhorro() { return cajas.ToList(); }

        public List<Usuario> MostrarTitularesCajasDeAhorro(int _cbu)
        {
            List<Usuario> tituDeCBU = new List<Usuario>();
            foreach (CajaDeAhorro cajase in cajas) { if (cajase.cbu == _cbu) 
                {
                    foreach (Usuario titularAsociadoAlCBU in cajase.titulares) 
                    { tituDeCBU.Add(titularAsociadoAlCBU); } } 
                }
            return tituDeCBU; }
    }
}


