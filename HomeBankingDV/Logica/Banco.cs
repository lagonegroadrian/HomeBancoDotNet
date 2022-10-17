using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class Banco
    {
        public List<Usuario> usuarios {get; set;}
        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<TarjetaDeCredito> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }
        public List<Movimiento> movimientos { get; set; }

        public Usuario usuarioActual { get; set; }

        public Banco()
        {
            usuarios= new List<Usuario>();
            cajas= new List<CajaDeAhorro>();
            tarjetas= new List<TarjetaDeCredito>();
            pagos= new List<Pago>();
            movimientos= new List<Movimiento>();
            pfs = new List<PlazoFijo>();
        }

        public bool AltaUsuario(int dni, string nombre, string apellido, string mail, string password)
        {
            if (!existeUsuario(dni))
            {
                //Buscamos el id que vamos a asignar
                int id = 0;
                if (usuarios.Count > 0)
                {
                    //si hay al menos 1 elemento en la lista previamente
                    var lastItem = usuarios[^1];//accede al ultimo elemento de la lista
                    id = lastItem.id + 1; //aca accedemos a su id y le sumamos 1
                }
                else { 
                    //si la lista esta vacia (count = 0)
                    id = 1;
                }

                //Agregamos el usuario
                try
                {
                    Usuario usuario = new Usuario(id, dni,nombre,apellido,mail,password);
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

        //public bool ModificarUsuario(int dni, string nombre, string apellido, string mail, string password) {usuarioActual.dni = dni;usuarioActual.nombre = nombre;usuarioActual.apellido = apellido;usuarioActual.mail = mail;usuarioActual.password = password;return true;}

        //COMPRUEBA SI EXISTE UN USUARIO EN LA LISTA DE USUARIOS DEL BANCO//
        public bool existeUsuario(int dni)
        {
            foreach (Usuario usuario in usuarios){if (usuario.dni == dni){return true;}}
            return false;
        }

        //INICIA SESION CON UN USUARIO EXISTENTE EN LA LISTA DE USUARIOS DEL BANCO//        
        public bool IniciarSesion(int DNI, string Contraseña)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.dni == DNI && usuario.password == Contraseña && usuario.bloqueado == false)
                {
                    usuarioActual = usuario;
                    MessageBox.Show("Login correcto"); //ESTO TIENE QUE SALIR DE LA VISTA, LO MISMO CON TODOS LOS MESSAGEBOX
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

        //INICIA SESION CON UN USUARIO EXISTENTE EN LA LISTA DE USUARIOS DEL BANCO//    
        public bool AltaCajaAhorro(Usuario usuario)
        {
            List<Usuario> usuarioList = new List<Usuario>();
            usuarioList.Add(usuario);
            List<Movimiento> movimientos = new List<Movimiento>();
            //genera CBU a partir del DNI.
            //int cbu = usuario.dni * 1000;
            //genero un numero CBU random
            int cbu = usuario.dni * 1000;

            Random rd = new Random();
            int rand_num = rd.Next(cbu, cbu * 1109);
            cbu = rand_num;

            int id = usuario.cajas.Count() + 1;

            //CajaDeAhorro caja = new CajaDeAhorro(id, cbu, usuarioList, 0, movimientos);
            CajaDeAhorro caja = new CajaDeAhorro(cbu, usuario);

            cajas.Add(caja);
            usuario.cajas.Add(caja);
            return true;
        }


        //public List<String> MostrarTitularesDeCA(Usuario usuario)
        //{   List<String> datoSalida = new List<String>();
        //  foreach (CajaDeAhorro laCajaDeAhorro in usuario.MostrarCajasDeAhorro()){foreach (Usuario titu in laCajaDeAhorro.titulares){datoSalida.Add(titu.nombre);}}
        //return datoSalida;
        //}


        //public List<String> MostrarTitularesDeCA(Usuario usuario, int CBU)
        //{List<String> datoSalida = new List<String>();
        //  foreach (CajaDeAhorro laCajaDeAhorro in usuario.MostrarCajasDeAhorro())
        //{foreach (Usuario titu in laCajaDeAhorro.titulares){datoSalida.Add(titu.nombre);}}
        //return datoSalida;
        //}



        //INICIA SESION CON UN USUARIO EXISTENTE EN LA LISTA DE USUARIOS DEL BANCO//
        //MISMO CASO CON LOS ID A ALTAUSUARIO//
        //public bool AltaCajaAhorro() {
        //ESTAS LISTAS PASARLAS AL CONSTRUCTOR DE CAJA DE AHORRO//

        //Buscamos el id que vamos a asignar
        //int id = 0;
        //if (cajas.Count > 0){
        //si hay al menos 1 elemento en la lista previamente
        //var lastItem = cajas[^1];//accede al ultimo elemento de la lista
        //id = lastItem.id + 1; //aca accedemos a su id y le sumamos 1
        //}
        //    else { 
        //si la lista esta vacia (count = 0)
        //id = 1;
        //}
        //Genera CBU a partir del DNI.
        //int cbu = usuarioActual.dni*1000;
        //Inicializamos las listas
        //List<Usuario> titulares = null;
        //List<Movimiento> movimientos ;
        //Agregamos la caja
        //CajaDeAhorro caja = new CajaDeAhorro(id, cbu, null , 0, null);
        //cajas.Add(caja);
        //usuarioActual.cajas.Add(caja);
        //return true;
        //}

        //DA DE BAJA UNA CAJA DE AHORRO DE LA LISTA DEL BANCO Y DE LA LISTA DE CADA USUARIO TITULAR DE LA CAJA//   
        //public bool BajaCajaAhorro (int id)
        //{
        //bool result = false;
        //foreach (CajaDeAhorro caja in usuarioActual.cajas)
        //{if (caja.id == id){if (caja.saldo == 0){
        //cajas.Remove(caja);
        //usuarioActual.cajas.Remove(caja);
        //return result = true;}}}
        //return result;
        //}

        //AGREGA O ELIMINA USUARIOS TITULARES DE UNA CAJA DE AHORRO --FLAG DEBE TRAER "Agregar" o "Eliminar"//   
        
        public bool AgregarTitularCajaAhorro (int id, int dni)
        {//REEMPLAZAR POR DATO IDENTIFICABLE DNI O ID, NUNCA PASAR OBJETO DESD LA VISTA

            foreach (CajaDeAhorro cajaU in usuarioActual.cajas)
            {
                if (cajaU.id == id )
                {
                    foreach (Usuario usuario in usuarios)
	                {
                        if(usuario.dni == dni)
                        {
                            cajaU.titulares.Add(usuario);
                            
                            foreach (CajaDeAhorro caja in cajas)
                            {
                                if(caja.id == id)
                                {
                                    caja.titulares.Add(usuario);
                                }
                            }
                            return true;
                        }
	                }  
                    
                }

                //NO EXISTE LA CAJA DE AHORRO//
            }
            return false;
        }

        public bool EliminarTitularCajaAhorro (int id, int dni, string flag)
        {//REEMPLAZAR POR DATO IDENTIFICABLE DNI O ID, NUNCA PASAR OBJETO DESD LA VISTA
            foreach (CajaDeAhorro cajaU in usuarioActual.cajas)
            {
                if (cajaU.id == id )
                {
                    if (cajaU.titulares.Count >= 2)
                    {
                        foreach (Usuario usuario in usuarios)
	                    {
                            if(usuario.dni == dni)
                            {
                                cajaU.titulares.Add(usuario);
                            
                                foreach (CajaDeAhorro caja in cajas)
                                {
                                    if(caja.id == id) 
                                    {
                                        caja.titulares.Add(usuario);
                                    }
                                }
                            }
	                    }  
                        return true;
                    }
                    return false; //tiene 1 o menos titulares
                }   
                return false; //no se encontro el id de la caja
            }
            return false;
        }


        //AGREGA UN MOVIMIENTO A LA LISTA DE MOVIMIENTOS DEL BANCO Y A LA LISTA DE MOVIMIENTOS DE LA CAJA A LA QUE PERTENECE EL MOVIMIENTO//   
        public bool AltaMovimiento (float monto, int idCaja, string detalle, DateTime fecha) //LA FECHA DATETIME .NOW()
        {
            
            //Buscamos el id que vamos a asignar
            int id = 0;
            if (movimientos.Count > 0)
            {
                //si hay al menos 1 elemento en la lista previamente
                var lastItem = movimientos[^1];//accede al ultimo elemento de la lista
                id = lastItem.id + 1; //aca accedemos a su id y le sumamos 1
            }
            else { 
                //si la lista esta vacia (count = 0)
                id = 1;
            }
            DateTime fechaActual = DateTime.Now; //REVISAR (no toma DateTime)

            CajaDeAhorro cajaInfo = null;

            foreach (CajaDeAhorro caja in usuarioActual.cajas)
	        {
                if(caja.id == idCaja)
                {
                    cajaInfo = caja;
                }
            }
            //Agregamos el movimiento
            Movimiento m = new Movimiento(id, monto, cajaInfo, detalle, fecha);     
            movimientos.Add(m); //guardamos en banco
            
            cajaInfo.movimientos.Add(m);

            return true;
        }

        //NO IMPLEMENTAR//
        public void BajaMovimiento()
        {

        }

        //NO IMPLEMENTAR//
        public void ModificarMovimiento()
        {

        }

        //AGREGA UN PAGO A LA LISTA DE PAGOS DEL BANCO Y A LA LISTA DE PAGOS DE UN USUARIO EN PARTICULAR//
        public bool AltaPago(string nombre, float monto, bool pagado, string metodo)
        {
            //Buscamos el id que vamos a asignar
            int id = 0;
            if (pagos.Count > 0)
            {
                //si hay al menos 1 elemento en la lista previamente
                var lastItem = pagos[^1];//accede al ultimo elemento de la lista
                id = lastItem.id + 1; //aca accedemos a su id y le sumamos 1
            }
            else { 
                //si la lista esta vacia (count = 0)
                id = 1;
            }

            //Agregamos el pago
            Pago p = new Pago (id, usuarioActual, nombre, monto, pagado, metodo);
            usuarioActual.pagos.Add(p); //agregamos al usuario
            pagos.Add(p);
            return true;
        }

        //ELIMINA UN PAGO DE LA LISTA DE PAGOS DEL BANCO Y DE LA LISTA DE PAGOS DE UN USUARIO EN PARTICULAR//
        public bool BajaPago(int id)
        {
            foreach(Pago p in usuarioActual.pagos)
            {
                if(p.id == id)
                {
                    pagos.Remove(p);
                    usuarioActual.pagos.Remove(p);
                    return true;
                }
            }
            return false;
        }

        //MODIFICA UN PAGO DE LA LISTA DE PAGOS DEL BANCO Y DE LA LISTA DE PAGOS DE UN USUARIO EN PARTICULAR//
        public bool ModificarPago(int id, bool pagado, string metodo)
        {
            
            foreach(Pago pU in usuarioActual.pagos)
            {
                if(pU.id == id)
                {
                    pU.pagado = pagado;
                    pU.metodo = metodo;
                    //repetimos esto, porque ya p hace referencia a usuarioActual->Pago
                    //usuarioActual.pagos.pagado = pagado;
                    //usuarioActual.pagos.metodo = metodo;
                    return true;
                }
            }

            foreach (Pago p in pagos) {
                if (p.id == id)
                {
                    p.pagado = pagado;
                    p.metodo = metodo;
                }
            }

            return false;
        }


        //AGREGA UN PLAZO FIJO A LA LISTA DE PFS DEL BANCO Y A LA LISTA DE PFS DE UN USUARIO EN PARTICULAR//
        public bool AltaPlazoFijo(float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
        {   
            //Buscamos el id que vamos a asignar
            int id = 0;
            if (pfs.Count > 0)
            {
                //si hay al menos 1 elemento en la lista previamente
                var lastItem = pfs[^1];//accede al ultimo elemento de la lista
                id = lastItem.id + 1; //aca accedemos a su id y le sumamos 1
            }
            else { 
                //si la lista esta vacia (count = 0)
                id = 1;
            }

            //Agregamos el plazo fijo
            PlazoFijo pf = new PlazoFijo(id, usuarioActual, monto, fechaIni, fechaFin, tasa, pagado);     
            pfs.Add(pf);
            usuarioActual.pfs.Add(pf);
            return true;
        }

        //ELIMINA UN PFS DE LA LISTA DE PFS DEL BANCO Y DE LA LISTA DE PFS DE UN USUARIO EN PARTICULAR//
        public bool BajaPlazoFijo(int id)
        {
            foreach(PlazoFijo pf in usuarioActual.pfs)
            {
                if(pf.id == id)
                {
                    if(pf.pagado == true)
                    {
                        TimeSpan fecha = DateTime.Now - pf.fechaFin;
                        if(fecha.Days >= 30)
                        {
                            pfs.Remove(pf);
                            usuarioActual.pfs.Remove(pf);
                            return true;
                        }
                    }
                    return false;
                }
                return false;
            }
            return false;
        }


        //NO IMPLEMENTAR//
        public void ModificarPlazoFijo(int id)
        {

        }

        //AGREGA UNA TARJETA DE CREDITO A LA LISTA DE PFS DEL BANCO Y A LA LISTA DE TARJETAS DE CREDITO DE UN USUARIO EN PARTICULAR//
        public bool AltaTarjetaCredito(int numero, int codigoV, float limite, float consumos)
        {
            //Buscamos el id que vamos a asignar
            int id = 0;
            if (tarjetas.Count > 0)
            {
                //si hay al menos 1 elemento en la lista previamente
                var lastItem = tarjetas[^1];//accede al ultimo elemento de la lista
                id = lastItem.id + 1; //aca accedemos a su id y le sumamos 1
            }
            else { 
                //si la lista esta vacia (count = 0)
                id = 1;
            }

            //Agregamos la tarjeta
            TarjetaDeCredito tj = new TarjetaDeCredito(id, usuarioActual, numero, codigoV,limite, consumos);
            tarjetas.Add(tj);
            usuarioActual.tarjetas.Add(tj);
            return true;
        }

        //ELIMINA UNA TJ DE LA LISTA DE TJS DEL BANCO Y DE LA LISTA DE TJS DE UN USUARIO EN PARTICULAR//
        public bool BajaTarjetaCredito(int id)
        {
            foreach(TarjetaDeCredito tj in usuarioActual.tarjetas)
            {
                if(tj.id == id)
                {
                    if(tj.consumos == 0)
                    {
                            tarjetas.Remove(tj);
                            usuarioActual.tarjetas.Remove(tj);
                            return true;
                    }
                }
                return false;
            }
            return false;
        }


        //MODIFICA EL LIMITE DE UNA TJ DE LA LISTA DE TJS DEL BANCO Y DE LA LISTA DE TJS DE UN USUARIO EN PARTICULAR//
        public bool ModificarTarjetaCredito(int id, float limite)
        {
            foreach(TarjetaDeCredito tj in usuarioActual.tarjetas)
            {
                if(tj.id == id)
                {
                    tj.limite = limite;

                    foreach (TarjetaDeCredito tarjeta in tarjetas)
                    {
                        if(tarjeta.id == id) {
                            tarjeta.limite = limite;
                        }
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public List<CajaDeAhorro> obtenerCajas()
        {
            return usuarioActual.cajas.ToList();
        }

        public List<Movimiento> obtenerMovimientos(int idCaja)
        {
            List<Movimiento> listaMovimientos = null;
            foreach(CajaDeAhorro caja in usuarioActual.cajas)
            {
                if (caja.id == idCaja)
                {
                    return listaMovimientos = caja.movimientos.ToList();
                }
                return listaMovimientos;
            }
            return listaMovimientos;
        }

        public List<Pago> obtenerPagos()
        {
            return usuarioActual.pagos.ToList();
        }

        public List<PlazoFijo> obtenerPlazosFijos()
        {
            return usuarioActual.pfs.ToList();
        }

        public List<TarjetaDeCredito> obtenerTarjetasDeCredito()
        {
            return usuarioActual.tarjetas.ToList();
        }

        public Usuario traerUsuario()
        {
            return usuarioActual;
        }

        // Operaciones del usuario..
        public bool crearCajaAhorro()
        {
            int id = 0;
            int cbu = 0;
            
            if (usuarioActual.cajas.Count>0)
            {
                var lastItem=usuarioActual.cajas[^1];
                id = lastItem.id + 1;
            }else
            {
                id = 1;
            }
            
            
            try
            {
                
                CajaDeAhorro cajaNew = new CajaDeAhorro(id,cbu, null, 0, null);
                usuarioActual.cajas.Add(cajaNew);
                MessageBox.Show("caja creada con exito.");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error: la operacion no pudo ser realizada.");
                return false;
            }
            }
        public bool TransferirDinero(int MontoTranferido, int CBUOrigen, int CBUDestino)
        {
            foreach (CajaDeAhorro Caja in usuarioActual.cajas)
            {
                if (Caja.cbu == CBUOrigen)
                {
                    Caja.saldo = Caja.saldo - MontoTranferido;
                    foreach (CajaDeAhorro cajaDestino in cajas)
                    {
                        if (cajaDestino.cbu == CBUDestino)
                        {
                            cajaDestino.saldo = cajaDestino.saldo + MontoTranferido;
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public bool DepositarDinero(int montoRetirado, int cbu)
        {
            foreach (CajaDeAhorro Caja in usuarioActual.cajas)
            {
                if (Caja.cbu == cbu)
                {
                    Caja.saldo = Caja.saldo - montoRetirado;
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool RetirarDinero(int montoDepositado, int cbu)
        {
            foreach (CajaDeAhorro Caja in usuarioActual.cajas)
            {
                if (Caja.cbu == cbu)
                {
                    Caja.saldo = Caja.saldo + montoDepositado;
                    return true;
                }
                return false;
            }
            return false;
        }
        
        // metodos BuscarMovimiento con 3,2 y 1 parametros (sobrecarga de metodos)
        public List<Movimiento> BuscarMovimiento(string detalle,DateTime fecha,float monto,int idCaja)
        {
           
          foreach(Movimiento movi in obtenerMovimientos(idCaja))
            {
                if(detalle == movi.detalle || fecha == movi.fecha || monto == movi.monto)
                {
                    return movimientos;
                }else
                {
                    MessageBox.Show("Error: no se encontraron resultados validos");
                }
            }
            return movimientos;
        }
        public List<Movimiento> BuscarMovimientos(string detalle, DateTime fecha, int idCaja)
        {

            foreach (Movimiento movi in obtenerMovimientos(idCaja))
            {
                if (detalle == movi.detalle || fecha == movi.fecha)
                {
                    return movimientos;
                }
                else
                {
                    MessageBox.Show("Error: no se encontraron resultados validos");
                }
            }
            return movimientos;
        }
        public List<Movimiento> BuscarMovimientos(string detalle, int idCaja)
        {

            foreach (Movimiento movi in obtenerMovimientos(idCaja))
            {
                if (detalle == movi.detalle)
                {
                    return movimientos;
                }
                else
                {
                    MessageBox.Show("Error: no se encontraron resultados validos");
                }
            }
            return movimientos;
        }

        public bool PagarTarjeta(int NumeroDeTarjeta, int CBU, String detalle, DateTime fecha)
        {
            foreach (TarjetaDeCredito TarjetaAPagar in usuarioActual.tarjetas)
            {
                if (TarjetaAPagar.numero == NumeroDeTarjeta)
                {
                    float Saldo = TarjetaAPagar.consumos;
                    foreach (CajaDeAhorro CajaDePago in usuarioActual.cajas)
                    {
                        if (CajaDePago.id == CBU)
                        {
                            CajaDePago.saldo = CajaDePago.saldo - Saldo;
                            TarjetaAPagar.consumos = 0;
                            AltaMovimiento(TarjetaAPagar.consumos, CBU, detalle, fecha);
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }


    }
}

