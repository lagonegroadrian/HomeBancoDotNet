

using HomeBankingDV.Logica;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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

     

        private List<TitularesRel> misTitulares;
        

        private CONNECTION DB; 
  
        //banco

        public bool existeUsuario(int dni)
        {   foreach (Usuario usuario in usuarios){if (usuario.dni == dni){return true;}}
            return false;}



        public float MostrarSaldoDeCAdeUsuarioActual(int _elCBU)
        {
          float saldo_ = 0;

          foreach (CajaDeAhorro laCajaDeAhorro in usuarioActual.cajas)
            {
                if(laCajaDeAhorro.cbu == _elCBU)
                { return saldo_ = laCajaDeAhorro.saldo; }

            }
        return saldo_;
        }


     
        public bool BajaCajaAhorro(int _elCBU)
        {
        bool result = false;
        foreach (CajaDeAhorro caja in usuarioActual.cajas)
        {
            if (caja.cbu == _elCBU)
            {
                    if (caja.saldo == 0)
                    {
                    cajas.Remove(caja);
                    usuarioActual.cajas.Remove(caja);
                        //eliminar de la base de datos (eliminar tambien, los titulares)

                        if (DB.eliminarTitularesDeCajaDeAhorro(caja.id) > 0)
                        {
                            DB.eliminarCajaDeAhorro(caja.id);
                            DB.eliminarMovimientosDeCajaDeAhorro(caja.id);
                        }

                    return result = true; // para que una vez que lo remueva del listado, salga.
                    }
            }
        }
        return result;
        }


        public bool AgregarTitularCajaAhorro (int _cbu, int _dni)
        {
            foreach (CajaDeAhorro cajaU in usuarioActual.cajas)
            {
                if (cajaU.cbu == _cbu)
                {
                    foreach (Usuario usuario in usuarios)
                    {
                        if(usuario.dni == _dni)
                        {
                            cajaU.titulares.Add(usuario);

                            DB.agregaragregaTitular_v2(usuario.id , cajaU.id );

                            //foreach (CajaDeAhorro caja in cajas){if(caja.cbu == _cbu){caja.titulares.Add(usuario);}}
                            return true;
                        }
                    }
                }
                //NO EXISTE LA CAJA DE AHORRO//
            }
            return false;
        }

        //public bool EliminarTitularCajaAhorro (int id, int dni, string flag)

        public bool EliminarTitularCajaAhorro(int _cbu, int _dni)
        {//REEMPLAZAR POR DATO IDENTIFICABLE DNI O ID, NUNCA PASAR OBJETO DESD LA VISTA
            foreach (CajaDeAhorro cajaU in usuarioActual.cajas)
            {
                if (cajaU.cbu == _cbu )
                {
                    if (cajaU.titulares.Count >= 2)
                    {
                        foreach (Usuario usuario in usuarios)
	                    {
                            if(usuario.dni == _dni)
                            {
                                cajaU.titulares.Remove(usuario);
                                DB.eliminarTitular_v2(usuario.id,cajaU.id);
                                return true;
                            }
                        }  
                        
                    }
                    return false; //tiene 1 o menos titulares
                }   
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
            //Movimiento m = new Movimiento(id, monto, cajaInfo, detalle, fecha);
            Movimiento m = new Movimiento(id, monto, cajaInfo, detalle);
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

        public List<CajaDeAhorro> obtenerCajas(){return cajas.ToList().ToList(); }

        public List<TitularesRel> obtenerTitulares(){return misTitulares.ToList().ToList();}

        public List<Usuario> obtenerTitularesXcaja(int _cbu) 
        { 
        
            return usuarios; 
        }

        public List<Movimiento> obtenerMovimientos(int idCaja) // revisar returns
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

        //public List<Pago> obtenerPagos(){return usuarioActual.pagos.ToList();}

        //public List<PlazoFijo> obtenerPlazosFijos(){return usuarioActual.pfs.ToList();}

        //public List<TarjetaDeCredito> obtenerTarjetasDeCredito(){return usuarioActual.tarjetas.ToList();}

        //public Usuario traerUsuario(){return usuarioActual;}

        public bool TransferirDinero(float MontoTranferido, int CBUOrigen, int CBUDestino)
        {
            bool salida = false;
            string _mensaje = "(x) transferencia ";
            if (this.RetirarDinero(MontoTranferido, CBUOrigen, _mensaje))
            {
                this.DepositarDinero(MontoTranferido, CBUDestino, _mensaje);

                salida = true;
            }
            inicializarMovs();

            return salida;
        }


        public bool DepositarDinero(float _monto, int cbu, string _adicional)
        {   bool resultado = false;

            string _accion = "(+) Deposito de $" + _monto + " en cbu: " + cbu;

            if (_adicional != "") { _accion = "(+) transf. de $" + _monto + " en cbu: " + cbu; }

            foreach (CajaDeAhorro Caja in usuarioActual.cajas)
            {   if (Caja.cbu == cbu)
                {   Caja.saldo = Caja.saldo + _monto;
                    try
                    {
                        DB.cambiarMontoEnCajaDeAhorro(Caja.id, Caja.saldo);
                        DB.insertarMovimiento(Caja.id, _monto, _accion);
                        //Caja.movimientos.Add(new Movimiento(DB.insertarMovimiento(Caja.id, _monto, _accion), _monto, Caja, _accion));

                        //if (_adicional == "") { inicializarMovs(); } 
                        if (_adicional == "") { inicializarAtributos(); }
                        
                        return true;
                    }
                    catch (Exception) { return false; }
                    return resultado;
                }
            }
            return resultado;
        }

        public bool RetirarDinero(float _monto, int cbu , string _adicional)
        {
            bool resultado = false;
            string _accion = "(-) Extraccion de $" + _monto + " en cbu: " + cbu;

            if (_adicional != "") { _accion = "(-) transf. de $" + _monto + " en cbu: " + cbu; }

            foreach (CajaDeAhorro Caja in usuarioActual.cajas)
            {
                if (Caja.cbu == cbu)
                {
                    Caja.saldo = Caja.saldo - _monto;
                    try
                    {
                        DB.cambiarMontoEnCajaDeAhorro(Caja.id, Caja.saldo);
                        DB.insertarMovimiento(Caja.id, _monto, _accion);
                        //Caja.movimientos.Add(new Movimiento(DB.insertarMovimiento(Caja.id, _monto, _accion), _monto, Caja, _accion));
                        //inicializarMovs();
                        if (_adicional == "") { inicializarMovs(); }
                        return true;
                    }
                    catch (Exception) { return false; }

                    resultado = true;
                    return resultado;
                }
                //return false;
            }
            return resultado;
        }
        
   
    

        public List<Movimiento> BuscarMovimientos(int _elCBU)
        {
            foreach (CajaDeAhorro laCajaDeAhorro in usuarioActual.cajas)
            {   if (laCajaDeAhorro.cbu == _elCBU)
                {movimientos= laCajaDeAhorro.movimientos;}
            }
            return movimientos; ;
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

        //*Metodos modificados para el 2do TP - Inicio
        public Banco()
        {
            usuarios = new List<Usuario>();
            cajas = new List<CajaDeAhorro>();
            tarjetas = new List<TarjetaDeCredito>();
            pagos = new List<Pago>();
            movimientos = new List<Movimiento>();
            pfs = new List<PlazoFijo>();

            //misDomicilios = new List<Domicilio>();

            misTitulares = new List<TitularesRel>();
            DB = new CONNECTION();
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            usuarios.Clear();
            misTitulares.Clear();
            cajas.Clear();
            movimientos.Clear();

            usuarios = DB.inicializarUsuarios();            // levanto todos los usuarios
            misTitulares = DB.inicializarTituLaresRel();    // levanto todos los titulares
            cajas = DB.inicializarCajasDeAhorro();          // levanto todas las CA

            cargarTitularesEnCajaDeAhorroYcajaEnUsuario();
            inicializarMovs();
        }

        private void cargarTitularesEnCajaDeAhorroYcajaEnUsuario()
        {
            foreach(Usuario usu in usuarios)
            {
                int idUsuario = usu.id;

                foreach(TitularesRel titu in misTitulares) //tiene cajas de ahorro asociada?
                {
                    if(titu.idUs == idUsuario)
                    {
                        int idCaja = titu.idCa;

                        foreach(CajaDeAhorro caja in cajas)
                        {
                            if(idCaja == caja.id)
                            { 
                                caja.titulares.Add(usu);
                                usu.cajas.Add(caja);
                            }
                        }

                    }
                }
            }
        }

        private void inicializarMovs()
        {
            movimientos = DB.inicializarMovimientos();      // levanto todos los movimientos
            this.relacionarCAconMovs();
        }

        private void relacionarCAconMovs()
        {
            

            foreach (Movimiento movs in movimientos)
            {
                foreach (CajaDeAhorro lacaja in cajas)
                {
                    //cajas.movimientos.Clear();

                    if (movs.caja.id == lacaja.id)
                    { 
                        lacaja.movimientos.Add(movs); 
                    }
                }
            }
        }

        public bool AltaUsuario(int dni, string nombre, string apellido, string mail, string password, bool isAdmin, bool bloqueado)
        {   if (!existeUsuario(dni)){
                try{    DB.agregaragregarUsuario_v2(dni, nombre, apellido, mail, password);
                        this.ActualizarDB_usuario();
                        return true;
                }catch (Exception) { return false; }
            }return false;
        }

        public void ActualizarDB_usuario(){usuarios.Clear();usuarios = DB.inicializarUsuarios();}

        public bool IniciarSesion(int DNI, string Contraseña)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.dni == DNI && usuario.password == Contraseña && usuario.bloqueado == false)
                {
                    usuarioActual = usuario;
                    return true;
                }
                if (usuario.dni == DNI && usuario.password != Contraseña && usuario.bloqueado == false)
                {
                    //  usuario.intentosFallidos++;
                    // MessageBox.Show("Password mal. A los 3 intentos fallidos se bloqueara cuenta." +
                    //  "Intentos Fallidos: " + usuario.intentosFallidos);
                    //   if (usuario.intentosFallidos == 3)
                    //    {
                    //   MessageBox.Show("El usuario " + usuario.nombre + " " + usuario.apellido + " se ha bloqueado." );
                    //      usuario.bloqueado = true;
                    //    }

                    return false;
                }
                if (usuario.bloqueado == true) { return false; }
            }
            return false;
        }

        //*****************************
        public bool AltaCajaAhorro_v2()
        {
            
            //Genera CBU a partir del DNI.
            int cbu = usuarioActual.dni * 10;

            Random rd = new Random();
            //int rand_num = rd.Next(cbu, cbu * 1109);
            int rand_num = rd.Next(cbu + 1);
            cbu = rand_num;

            int idCa = DB.agregaragregarCajaAhorro_v2(cbu);
            DB.agregaragregaTitular_v2(usuarioActual.id, idCa); // se le suma 1 al id del usuario xq lo levanta del listado de usuarios

            //luego poner alta titular respecto de caja de ahorro
            //usuarioActual.id
            inicializarAtributos();


            //Agregamos la caja
            //CajaDeAhorro caja = new CajaDeAhorro(cbu,0);
            //caja.titulares.Add(usuarioActual); // lo doy de alta como titular 
            //cajas.Add(caja);
            //usuarioActual.cajas.Add(caja);

            return true;
        }
        //*****************************

        //*Metodos modificados para el 2do TP - Fin
    }
}

