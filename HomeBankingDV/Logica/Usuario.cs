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
        //Segun diagrama tendriamos que heredar de Banco?,
        //pero no tiene sentido
    {
        public int id { get; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }

        public bool bloqueado { get; set; }

        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<TarjetaDeCredito> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }

        //constructor
        public Usuario(int dni, string nombre, string apellido, string mail, string password)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            intentosFallidos = 0;
            bloqueado = false;
            cajas = new List<CajaDeAhorro>();
            pfs = new List<PlazoFijo>();
            tarjetas = new List<TarjetaDeCredito>();
            pagos = new List<Pago>();
            this.id = dni;
        }

        ////-------------ABM----------------
        /// Hice este metodo en clase banco directamente
        //public string AltaUsuario(List<Usuario> lista, Usuario u) {
        //    //Agrega el usuario u a la lista.

        //    foreach (Usuario usuario in lista)
        //    {
        //        if (usuario.dni == u.dni){
        //            return "No se pudo agregar. El usuario ya existe";
        //        }
        //    }

        //    lista.Add(u);
 
        //    return "Usuario agregado exitosamente";
        //}


        public string ModificarUsuario(List<Usuario> lista, Usuario u) {
            // buscamos el u.id en la lista
            // validar si el id pasado por parametro es igual al del usuario logeado
            foreach (Usuario usuario in lista)
            {
                if (usuario.id == u.id){
                    usuario.dni = u.dni;
                    usuario.nombre = u.nombre;
                    usuario.apellido = u.apellido;
                    usuario.mail = u.mail;
                    usuario.password = u.password;
                    usuario.intentosFallidos = u.intentosFallidos;
                    usuario.bloqueado = u.bloqueado;
                    usuario.cajas = u.cajas;
                    usuario.pfs = u.pfs;
                    usuario.tarjetas = u.tarjetas;
                    usuario.pagos = u.pagos;

                    return "Usuario modificado exitosamente";
                }
            }
            return "El id del usuario no se pudo encontrar";


        }
        public bool EliminarUsuario() {
            //pendiente porque necesitamos tener listos los metodos de
            //baja de caja de ahorro, flazo fijo, y las demas listas

            return true;

        }

        

    }
}
