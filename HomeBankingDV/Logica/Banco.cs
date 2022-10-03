using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class Banco
    {
        public List <Usuario> usuarios {get; set;}
        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<TarjetaDeCredito> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }
        public List<Movimiento> movimientos { get; set; }

        public Usuario usuarioActual { get; set; }

        //constructor
        public Banco()
        {
            usuarios= new List<Usuario>();
            cajas= new List<CajaDeAhorro>();
            tarjetas= new List<TarjetaDeCredito>();
            pagos= new List<Pago>();
            movimientos= new List<Movimiento>();
            pfs = new List<PlazoFijo>();
        }

        public bool AltaUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password)
        {
            if (!existeUsuario(DNI))
            {
                try
                {
                    Usuario usuario = new Usuario(DNI,Nombre,Apellido,Mail,Password);
                    usuarios.Add(usuario);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public bool existeUsuario(int DNI)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.dni == DNI)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean IniciarSesion(int DNI, string Contraseña)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.dni == DNI && usuario.password == Contraseña && usuario.bloqueado == false)
                {
                    usuarioActual = usuario;
                    MessageBox.Show("Login correcto");
                    return true;
                }
                if (usuario.dni == DNI && usuario.password != Contraseña && usuario.bloqueado == false)
                {
                    usuario.intentosFallidos++;
                    MessageBox.Show("Password mal. A los 3 intentos fallidos se bloqueara cuenta." +
                        "Intentos Fallidos: " + usuario.intentosFallidos);
                    if (usuario.intentosFallidos == 3)
                    {
                        MessageBox.Show("El usuario " + usuario.nombre + " " + usuario.apellido + " se ha bloqueado." );
                        usuario.bloqueado = true;
                    }
                    return false;
                }
                if (usuario.bloqueado == true)
                {
                    MessageBox.Show("El usuario esta bloqueado");
                    return false;
                }

               
            }

            MessageBox.Show("El usuario no se encuentra en la base de datos");
            return false;
        }
    }

}

