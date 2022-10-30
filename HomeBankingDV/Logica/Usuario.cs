
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class Usuario
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        
        //public int intentosFallidos { get; set; }

        public bool isAdmin { get; set; }

        public bool bloqueado { get; set; }

        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<TarjetaDeCredito> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }

        private List<Domicilio> misDirecciones;

        static int aux { get; set; }

        //constructor
        public Usuario(int id, int dni, string nombre, string apellido, string mail, string password, bool isAdmin, bool bloqueado)
        {
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
          //  intentosFallidos = 0;
            bloqueado = false;
            cajas = new List<CajaDeAhorro>();
            pfs = new List<PlazoFijo>();
            tarjetas = new List<TarjetaDeCredito>();
            pagos = new List<Pago>();
            misDirecciones = new List<Domicilio>();
            //this.id = aux++;
            this.isAdmin = isAdmin;

        }

        public List<CajaDeAhorro> MostrarCajasDeAhorro() { return cajas; }

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


