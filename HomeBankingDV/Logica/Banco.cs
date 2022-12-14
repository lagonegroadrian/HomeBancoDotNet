

using HomeBankingDV.Logica;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Dynamic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HomeBankingDV
{
    public class Banco
    {

        private MiContexto contexto;
        private Usuario usuarioActual;
        private int intentos = 0;

        public Banco(){inicializarAtributos();}

        private void inicializarAtributos()
        {
            try
            {
                contexto = new MiContexto();
                //contexto.usuarios.Include(c => c.cajas).Include(p => p.pfs).Include(t => t.tarjetas).Include(p => p.pagos).Include(u => u.UserCajas).Load();
                contexto.usuarios.Include(c => c.cajas).Include(p => p.pfs).Include(t => t.tarjetas).Include(u => u.UserCajas).Include(u => u.pagos).Load();
                //  contexto.usuarios.Load();
              // correccion.!
                contexto.cajaDeAhorros.Include(m => m.titulares).Include(m => m.movimientos).Load();
                contexto.plazoFijos.Load();
                contexto.tarjetaDeCredito.Load();
                contexto.pago.Load();
                contexto.movimientos.Load();
                contexto.titulares.Load();
            }catch (Exception){}
        }
        public bool existeUsuario(int dni)
        {   try
            {   foreach (Usuario usuario in contexto.usuarios)
                {   if (usuario.dni == dni){return true;}
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        //public Usuario hacerLogin(int _dni, string _contraseña)
        public bool hacerLogin(int _dni, string _contraseña)
        {
            //usuarioActual = contexto.usuarios.Where(U => U.dni == _dni && U.password == _contraseña).FirstOrDefault();

            usuarioActual = contexto.usuarios.Where(U => U.dni == _dni).FirstOrDefault();

            if (usuarioActual is null) 
            {
                return false;
            }
            else
            {
                if(usuarioActual.password == _contraseña && usuarioActual.bloqueado==false) { return true; }
                else
                {
                    intentos++;
                    if (intentos > 2 && usuarioActual.bloqueado == false)
                    {
                        usuarioActual.bloqueado = true;
                        contexto.usuarios.Update(usuarioActual);
                        contexto.SaveChanges();
                        intentos = 0;
                        //contexto.Update(usuarioActual);
                    }
                    return false;
                }
            }

            //return contexto.usuarios.Where(U => U.dni == _dni && U.password == _contraseña).FirstOrDefault(); 
            // asignar a usuario logueado... no puedo regresar el user completo
        }

        public float MostrarSaldoDeCAdeUsuarioActual(int _elCBU)
        {
            float saldo_ = 0;

            try
            {
                foreach (CajaDeAhorro laCajaDeAhorro in usuarioActual.cajas)
                {
                    if (laCajaDeAhorro.cbu == _elCBU)
                    { return saldo_ = laCajaDeAhorro.saldo; }

                }
                return saldo_;
            }
          catch(Exception)
            {
                return saldo_;
            }
        }

      // corregir redundancia!
        public bool BajaPlazoFijo(int _elId)
        {
            PlazoFijo elPl = contexto.plazoFijos.Where(u => u.idPlazoFijo == _elId).FirstOrDefault();

            bool salida = false;
           
                    if (elPl.pagado) 
                    { 
                    contexto.plazoFijos.Remove(elPl); 
                    salida = true;
            }
            if (salida)
                contexto.SaveChanges();
            return salida;


            /*
            try
            {
                foreach (PlazoFijo plazo in contexto.plazoFijos)
                {
                    if (plazo.idPlazoFijo == _elId)
                    {
                        if (plazo.pagado == true) { 
                        contexto.plazoFijos.Remove(plazo);
                        usuarioActual.pfs.Remove(plazo);
                        contexto.SaveChanges();
                        return true;
                        }
                        else 
                        { return false; }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }*/
           
        }


       // encontrar movimientos que corresponden a los retiros sumarlos y devolverlos.

        public double calcularGastosUsuarioActual()
        {
            double TotalMovimientos = 00;

            foreach(CajaDeAhorro caja in usuarioActual.cajas)
            {
                foreach (Movimiento mov in caja.movimientos)
                {
                    if (mov.detalle == "retiro")
                    {
                        TotalMovimientos += mov.monto;

                    }

                }

            }

            return TotalMovimientos;

        }



        public bool BajaCajaAhorro(int _elCBU)
        {

            CajaDeAhorro laCA = contexto.cajaDeAhorros.Where(u => u.cbu == _elCBU).FirstOrDefault();

            bool salida = false;
            foreach (CajaDeAhorro caj in contexto.cajaDeAhorros)
            {
                if (caj.idCajaDeAhorro== laCA.idCajaDeAhorro && caj.saldo == 0) 
                { 
                    contexto.cajaDeAhorros.Remove(caj); 
                    salida = true; 
                }
            }
            if (salida) 
            { 
                contexto.SaveChanges();
            }
            return salida;



            /*
            try
            {
                foreach (CajaDeAhorro caja in contexto.cajaDeAhorros)
                {
                    if (caja.cbu == _elCBU)
                    {
                        if (caja.saldo == 0)
                        {
                            contexto.cajaDeAhorros.Remove(caja);
                            usuarioActual.cajas.Remove(caja);
                            contexto.SaveChanges();
                            return true;
                        }
                        }
                    }
                
                return false;
            }
            catch (Exception)
            {
                return false;
            }*/
         
        }

        // revisar!
        public bool AgregarTitularCajaAhorro(int _cbu, int _dni)
        {
            try
            {
                CajaDeAhorro laCA = contexto.cajaDeAhorros.Where(u => u.cbu == _cbu).FirstOrDefault();
                Usuario elUser = contexto.usuarios.Where(U => U.dni == _dni).FirstOrDefault();
                laCA.titulares.Add(elUser);

                //TitularesRel t = new TitularesRel(laCA.idCajaDeAhorro, elUser.idUsuario);
                //contexto.titulares.Add(t);
                elUser.cajas.Add(laCA);

                contexto.SaveChanges();

                //contexto.SaveChanges();
                return true;

            } catch (Exception){return false;}
            return false;
        }

        public bool EliminarTitularCajaAhorro(int _cbu, int _dni)
        {
            CajaDeAhorro laCA = contexto.cajaDeAhorros.Where(u => u.cbu == _cbu).FirstOrDefault();
            Usuario elUser = contexto.usuarios.Where(U => U.dni == _dni).FirstOrDefault();

            bool salida = false;
            foreach (TitularesRel elTitu in contexto.titulares) 
            {
                if(elTitu.idCa == laCA.idCajaDeAhorro && elTitu.idUs == elUser.idUsuario) { contexto.titulares.Remove(elTitu); salida = true; }
            }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }


        public bool AltaMovimiento(float monto, CajaDeAhorro caja, string detalle, DateTime fecha) 
        {

            try
            {
                Movimiento m = new Movimiento(monto, caja, detalle, fecha);
                contexto.movimientos.Add(m);

                caja.movimientos.Add(m);
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

      
        public bool BajaMovimiento(int id)
        {
            try
            {
                foreach(Movimiento mov in contexto.movimientos)
                {
                    if(mov.idMovimiento == id)
                    {
                        contexto.movimientos.Remove(mov);
                        contexto.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool AltaPago(string _nombre, float _monto, string _metodo)
        {
            Pago pago;
            Usuario titular = usuarioActual;
            bool pagado = false;

            Random rd = new Random();
            //int idPlazoFijo = rd.Next(usuarioActual.idUsuario + 3);

            try
            {
                Pago p = new Pago(titular, _nombre, _monto, pagado, _metodo);
                contexto.pago.Add(p);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        
        public bool BajaPago(int _id)
        {
            try
            {
                Pago elPapago = contexto.pago.Where(U => U.idPago== _id).FirstOrDefault();

                contexto.pago.Remove(elPapago);
                //usuarioActual.pagos.Remove(elPapago);
                contexto.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool ModificarPago(int id, bool pagado, string metodo, float _saldoCaPaPagar, int _nroCBU)
        {
            try
            {
                Pago p = contexto.pago.Where(U => U.idPago == id).FirstOrDefault();
                p.pagado = pagado;
                p.metodo = metodo;

                if(p.monto > _saldoCaPaPagar) { return false; }

                this.RetirarDinero(p.monto, _nroCBU, "(x)Pago");

                contexto.Update(p);
                contexto.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

       
        public bool AltaPlazoFijo(float _monto, int _cantDias , float _tasa)
        {
            PlazoFijo plazo;
            DateTime fechaIni=DateTime.Now;
            _cantDias = 90;
             DateTime fechaFin = fechaIni.AddDays(_cantDias);
            
            Usuario titular = usuarioActual;

            float tasa = _tasa;

            bool pagado = false;
            Random rd = new Random();
            //int idPlazoFijo = rd.Next(usuarioActual.idUsuario + 3);

            try
            {
                plazo = new PlazoFijo(titular, _monto, fechaIni, fechaFin, tasa, pagado);
                contexto.plazoFijos.Add(plazo);
                contexto.SaveChanges();
                //this.AltaPago("Plazo Fijo", _monto, "a cobrar");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool eliminarPlazoFijo(int id)
        {
            try
            {
                foreach(PlazoFijo plazo in contexto.plazoFijos)
                {
                    if (plazo.idPlazoFijo == id)
                    {
                        contexto.plazoFijos.Remove(plazo);
                        usuarioActual.pfs.Remove(plazo);
                        contexto.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }


        //public bool AltaTarjetaCredito(int numero, int codigoV, float limite, float consumos,int idTarjeta)
        public bool AltaTarjetaCredito()
        {
            Random rd = new Random();

            int numero = rd.Next(100, 300);
            int codigoV = rd.Next(100, 999);
            float limite = 12000F;
            float consumos = rd.Next(10, 900);

            try
            {
                TarjetaDeCredito tj = new TarjetaDeCredito(usuarioActual, numero, codigoV, limite, consumos);
                contexto.tarjetaDeCredito.Add(tj);
                //?usuarioActual.tarjetas.Add(tj);--> no hace falta porque ya con el include en banco lo levanta... sino como que tengo repetido 2 veces el ultimo ingreso
                contexto.SaveChanges();

                this.AltaPago("tarjeta credito", consumos, "Credito");

                return true;

            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool BajaTarjetaCredito(int id)
        {
            foreach (TarjetaDeCredito tj in usuarioActual.tarjetas)
            {
                if (tj.idTarjetaDeCredito == id)
                {
                    if (tj.consumos == 0)
                    {
                        usuarioActual.tarjetas.Remove(tj);
                        contexto.tarjetaDeCredito.Remove(tj);
                        contexto.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ModificarTarjetaCredito(int id, float limite)
        {   try
            {   foreach (TarjetaDeCredito tj in usuarioActual.tarjetas)
                {
                    if (tj.idTarjetaDeCredito == id)
                    {
                        tj.limite = limite;
                        contexto.tarjetaDeCredito.Update(tj);
                        contexto.SaveChanges();
                        return true;
                    }
                }
                return false;
            }catch (Exception){return false;}
            return false;
        }

        public List<CajaDeAhorro> obtenerCajas() { return contexto.cajaDeAhorros.ToList(); }

        public List<TitularesRel> obtenerTitulares() { return contexto.titulares.ToList(); }

        public List<Usuario> obtenerTitularesXcaja(int _cbu)
        {
            try
            {
                foreach (CajaDeAhorro caja in contexto.cajaDeAhorros)
                {
                    if (caja.cbu == _cbu)
                    {
                        return caja.titulares.ToList();
                    }
                }

            }catch(Exception)
            {
                return null;
            }
            return null;
         
        }
        public List<Movimiento> obtenerTodosLosMovimientos() { return contexto.movimientos.ToList(); }

        // esta ok?
        public List<Movimiento> obtenerMovimientosXcbu(int _cbu) 
        {
            foreach (Movimiento movimiento in obtenerTodosLosMovimientos())
            {
                if (movimiento.caja.cbu == _cbu)
                {
                    return movimiento.caja.movimientos.ToList();
                }
            }
            return null;
        } 


        public List<Movimiento> obtenerMovimientos(int idCaja)
        {
            List<Movimiento> listaMovimientos = null;
            foreach (CajaDeAhorro caja in usuarioActual.cajas)
            {
                if (caja.idCajaDeAhorro == idCaja)
                {
                    return listaMovimientos = caja.movimientos.ToList();
                }
                return listaMovimientos;
            }
            return listaMovimientos;
        }


        
        
        //  METODOS DE RETORNO DE DATOS DEL USUARIO 

        public int obtenerUsuarioActualId(){return usuarioActual.idUsuario;}

        public int obtenerUsuarioActualDni() { return usuarioActual.dni;}

        public string obtenerUsuarioActualNombre() { return usuarioActual.nombre; }

        public string obtenerUsuarioActualApellido() { return usuarioActual.apellido; }
            
        public string obtenerUsuarioActualMail() {return usuarioActual.mail; }
        
        public bool obtenerUsuarioActualIsAdmin()
        {
            if (usuarioActual.isAdmin == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }    
            
          public bool obtenerUsuarioActualBloqueado()
        {
            if(usuarioActual.bloqueado == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CajaDeAhorro> obtenerUsuarioActualCajasDeAhorro() { return usuarioActual.cajas.ToList();  }  
                
        public List<Pago> obtenerUsuarioActualPagos() { return usuarioActual.pagos.ToList(); }

        public List<PlazoFijo> obtenerUsuarioActualPlazosFijos() { return usuarioActual.pfs.ToList(); }

        public List<TarjetaDeCredito> obtenerUsuarioActualTarjetasDeCredito() { return usuarioActual.tarjetas.ToList(); }

        // -----------------------------------------------------------------------------------------------------------

  

        public  void ponerUsuario(Usuario _elUser){usuarioActual = _elUser;}

        public List<Usuario> obtenerUsuarios() { return contexto.usuarios.ToList();}

        public bool TransferirDinero(float MontoTranferido, int CBUOrigen, int CBUDestino)
        {
            bool salida = false;
            string _mensaje = "[transf]";
            try
            {
                //foreach (CajaDeAhorro cajaU in usuarioActual.cajas)
                CajaDeAhorro CAorigen = contexto.cajaDeAhorros.Where(u => u.cbu == CBUOrigen).FirstOrDefault();
                CajaDeAhorro CAdestino = contexto.cajaDeAhorros.Where(u => u.cbu == CBUDestino).FirstOrDefault();

                this.DepositarDinero(MontoTranferido, CBUDestino, _mensaje);
                this.RetirarDinero(MontoTranferido, CBUOrigen, _mensaje);

                contexto.cajaDeAhorros.Update(CAorigen);
                contexto.cajaDeAhorros.Update(CAdestino);

                contexto.SaveChanges();

                /*
                foreach (CajaDeAhorro cajaU in contexto.cajaDeAhorros)
                {
                    if (cajaU.cbu == CBUOrigen)
                    {
                        if (cajaU.saldo > 0 && MontoTranferido <= cajaU.saldo)
                        {
                            if (this.RetirarDinero(MontoTranferido, CBUOrigen, _mensaje))
                            {
                                this.DepositarDinero(MontoTranferido, CBUDestino, _mensaje);
                                contexto.cajaDeAhorros.Update(cajaU);
                                contexto.SaveChanges();
                                salida = true;
                            }
                            return salida;
                        }
                    }
                }
                */
            }
            catch (Exception){throw;}
            return salida;
        }


        public bool DepositarDinero(float _monto, int cbu, string _adicional)
        {   bool resultado = false;

            string _accion = "(+) Depo - cbu:" + cbu;

            if (_adicional != ""){ _accion += _adicional; }

            foreach (CajaDeAhorro Caja in contexto.cajaDeAhorros)
            {   if (Caja.cbu == cbu)
                {   Caja.saldo = Caja.saldo + _monto;
                    try
                    {
                        DateTime fecha = DateTime.Now;

                        if (_monto > 0)
                        {
                            contexto.cajaDeAhorros.Update(Caja);
                            Movimiento mov = new Movimiento(_monto,Caja,_accion,fecha);
                            contexto.movimientos.Add(mov);
                            contexto.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception) { return false; }
                    return resultado;
                }
            }
            return resultado;
        }

        public bool RetirarDinero(float _monto, int cbu, string _adicional)
        {
            string _accion = "(-) Extraccion - cbu:" + cbu;

            if (_adicional != ""){ _accion += _adicional; }
            try{
                foreach (CajaDeAhorro Caja in contexto.cajaDeAhorros)
                {
                    if (Caja.cbu == cbu)
                    {
                        if (Caja.saldo >= _monto) {
                       Caja.saldo = Caja.saldo - _monto;

                        DateTime fecha=DateTime.Now;
                        contexto.cajaDeAhorros.Update(Caja);
                        Movimiento mov = new Movimiento(_monto, Caja, _accion, fecha);
                        contexto.movimientos.Add(mov);
                        }
                    }
                }
                contexto.SaveChanges();return true;
                }catch (Exception){return false;}return false;
        }



        public bool PagarTarjeta(int NumeroDeTarjeta, int CBU, String detalle, DateTime fecha)
        {
            try
            {
                foreach (TarjetaDeCredito TarjetaAPagar in usuarioActual.tarjetas)
                {
                    if (TarjetaAPagar.numero == NumeroDeTarjeta)
                    {
                        float Saldo = TarjetaAPagar.consumos;
                        foreach (CajaDeAhorro CajaDePago in usuarioActual.cajas)
                        {
                            if (CajaDePago.idCajaDeAhorro == CBU)
                            {
                                CajaDePago.saldo = CajaDePago.saldo - Saldo;
                                TarjetaAPagar.consumos = 0;
                                //AltaMovimiento(TarjetaAPagar.consumos, CajaDePago, detalle, fecha);

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        private void cargarPlazosFijoEnUsuarios()
        {
            foreach (Usuario usu in contexto.usuarios)
            {
                foreach (PlazoFijo oPLazoFizo in contexto.plazoFijos) //tiene cajas de ahorro asociada?
                {
                    if(oPLazoFizo.titularP.idUsuario == usu.idUsuario) 
                    {
                        usu.pfs.Add(oPLazoFizo);
                        contexto.SaveChanges();
                    }

                }
            }
        }

        public bool AltaUsuario(int dni, string nombre, string apellido, string mail, string password, bool isAdmin, bool bloqueado)
        {
            try 
            {
                if (!existeUsuario(dni))
                {
                    Usuario u = new Usuario(dni,  nombre,  apellido, mail, password,isAdmin,bloqueado);
                    contexto.usuarios.Add(u);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception){return false;}
            return false;
        }

        public bool IniciarSesion(int DNI, string Contraseña)
        {
            int intentos = 0;
            try
            {
                foreach (Usuario usuario in contexto.usuarios)
                {
                    if (existeUsuario(DNI))
                    {
                        if (usuario.bloqueado == false && usuario.password == Contraseña)
                        {
                            usuarioActual = usuario;
                            return true;
                        }
                        else
                        {
                            intentos++; /// cod 887
                            contexto.Update(intentos);
                            return false;
                        }
                    } else
                    {
                        return false;
                    }
                    if (intentos == 3)
                    {
                        usuario.bloqueado = true;
                        contexto.Update(usuario);
                    }
                }
            }catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool AltaCajaAhorro()
        {try {
                int cbu = usuarioActual.dni * 10;

                Random rd = new Random();
                int rand_num = rd.Next(cbu + 1);
                cbu = rand_num;
                float saldo=0;
                int idCajaDeAhorro = rd.Next(cbu + 2);

                CajaDeAhorro c = new CajaDeAhorro(cbu, saldo);
                contexto.cajaDeAhorros.Add(c);

                c.titulares.Add(usuarioActual);
                usuarioActual.cajas.Add(c);

                contexto.SaveChanges();

                contexto.cajaDeAhorros.Load();
                CajaDeAhorro nuevaCA = contexto.cajaDeAhorros.Where(u => u.cbu == cbu).FirstOrDefault();
                if (nuevaCA.idCajaDeAhorro >= 0) 
                {
                    TitularesRel t = new TitularesRel(nuevaCA.idCajaDeAhorro, usuarioActual.idUsuario);
                    contexto.titulares.Add(t);

                    Movimiento mov = new Movimiento(0, nuevaCA, "(*) Alta caja de ahorro", DateTime.Now);
                    contexto.movimientos.Add(mov);

                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception){return false;}
            return false;
        }

        public void cerrarPrograma(){contexto.Dispose();}
    }
}