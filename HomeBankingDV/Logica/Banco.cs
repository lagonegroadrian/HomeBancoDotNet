

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
       

        public Banco()
        {

            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                contexto = new MiContexto();
              
                contexto.usuarios.Include(c => c.cajas).Include(p => p.pfs).Load();
                contexto.cajaDeAhorros.Load();
                contexto.plazoFijos.Load();
                contexto.tarjetaDeCredito.Load();
                contexto.pago.Load();
                contexto.movimientos.Load();
                contexto.titulares.Load();
                contexto.domicilios.Load();

                contexto.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        public bool existeUsuario(int dni)
        {
            try
            {
                foreach (Usuario usuario in contexto.usuarios)
                {
                    if (usuario.dni == dni)
                    {
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

        public Usuario hacerLogin(int _dni, string _contraseña)
        { return contexto.usuarios.Where(U => U.dni == _dni && U.password == _contraseña).FirstOrDefault(); }

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
        // faltan condicionales que cumplan consigna!
        public bool BajaPlazoFijo(int _elId)
        {
            try
            {
                foreach (PlazoFijo plazo in contexto.plazoFijos)
                {
                    if (plazo.idPlazoFijo == _elId)
                    {
                        contexto.plazoFijos.Remove(plazo);
                        usuarioActual.pfs.Remove(plazo);
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public bool BajaCajaAhorro(int _elCBU)
        {
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
            }
         
        }


        public bool AgregarTitularCajaAhorro(int _cbu, int _dni)
        {
            try
            {
                foreach (CajaDeAhorro cajaU in contexto.cajaDeAhorros)
                {
                    if (cajaU.cbu == _cbu)
                    {
                        foreach (Usuario usuario in contexto.usuarios)
                        {
                            if (usuario.dni == _dni)
                            {
                                cajaU.titulares.Add(usuario);
                                contexto.cajaDeAhorros.Add(cajaU);
                                contexto.SaveChanges();
                                return true;
                            }
                        }
                    }
                }
            } catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool EliminarTitularCajaAhorro(int _cbu, int _dni)
        {//REEMPLAZAR POR DATO IDENTIFICABLE DNI O ID, NUNCA PASAR OBJETO DESD LA VISTA
            foreach (CajaDeAhorro cajaU in contexto.cajaDeAhorros)
            {
                if (cajaU.cbu == _cbu)
                {
                    if (cajaU.titulares.Count >= 2)
                    {
                        foreach (Usuario usuario in contexto.usuarios)
                        {
                            if (usuario.dni == _dni)
                            {
                                
                                cajaU.titulares.Remove(usuario);
                                    contexto.SaveChanges();
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
        public bool AltaMovimiento(float monto, CajaDeAhorro caja, string detalle, DateTime fecha) //LA FECHA DATETIME .NOW()
        {

            try
            {
                Movimiento m = new Movimiento(monto, caja, detalle, fecha);
                contexto.movimientos.Add(m);
                foreach (CajaDeAhorro cajaM in contexto.cajaDeAhorros)
                {
                    if (cajaM.idCajaDeAhorro == caja.idCajaDeAhorro)
                    {
                        cajaM.movimientos.Add(m);
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

        //NO IMPLEMENTAR//
        public bool ModificarMovimiento(int id, float monto, CajaDeAhorro caja, string detalle, DateTime fecha)
        {
            try
            {
                foreach(Movimiento mov in contexto.movimientos)
                {
                    if (mov.idMovimiento == id)
                    {
                        mov.monto = monto;
                        mov.caja = caja;
                        mov.detalle = detalle;
                        mov.fecha = fecha;
                        contexto.movimientos.Update(mov);
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

        //AGREGA UN PAGO A LA LISTA DE PAGOS DEL BANCO Y A LA LISTA DE PAGOS DE UN USUARIO EN PARTICULAR//
        public bool AltaPago(int id, Usuario user, string nombre, float monto, bool pagado, string metodo)
        {
            try
            {
                Pago p = new Pago(id,user,nombre, monto,pagado,metodo); 
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        //ELIMINA UN PAGO DE LA LISTA DE PAGOS DEL BANCO Y DE LA LISTA DE PAGOS DE UN USUARIO EN PARTICULAR//
        public bool BajaPago(int id)
        {
            try
            {
                foreach (Pago p in contexto.pago)
                {
                    if (p.idPago == id)
                    {
                        contexto.pago.Remove(p);
                        usuarioActual.pagos.Remove(p);
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

        //MODIFICA UN PAGO DE LA LISTA DE PAGOS DEL BANCO Y DE LA LISTA DE PAGOS DE UN USUARIO EN PARTICULAR//
        public bool ModificarPago(int id, bool pagado, string metodo)
        {
            try 
            {
                foreach (Pago pU in contexto.pago)
                {
                    if (pU.idPago == id)
                    {
                        pU.pagado = pagado;
                        pU.metodo = metodo;

                        contexto.Update(pU);
                        usuarioActual.pagos.Add(pU);
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


        //AGREGA UN PLAZO FIJO A LA LISTA DE PFS DEL BANCO Y A LA LISTA DE PFS DE UN USUARIO EN PARTICULAR//
        public bool AltaPlazoFijo(float _monto, int _cantDias)
        {
            PlazoFijo plazo;
            DateTime fechaIni=DateTime.Now;
            DateTime fechaFin = fechaIni.AddDays(_cantDias);
            Usuario titular = usuarioActual;
            float tasa = 8;
            bool pagado = false;
            Random rd = new Random();
            int idPlazoFijo = rd.Next(usuarioActual.idUsuario + 3);

            try
            {
              

                plazo = new PlazoFijo(idPlazoFijo,titular,_monto,fechaIni,fechaFin,tasa,pagado);
                contexto.plazoFijos.Add(plazo);
                usuarioActual.pfs.Add(plazo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        //ELIMINA UN PFS DE LA LISTA DE PFS DEL BANCO Y DE LA LISTA DE PFS DE UN USUARIO EN PARTICULAR//
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


        //NO IMPLEMENTAR//
        public bool ModificarPlazoFijo(int id,Usuario titular,float monto,DateTime fechaIni ,DateTime fechaFin,float tasa,bool pagado)
        {
            try
            {
                foreach(PlazoFijo plazo in contexto.plazoFijos)
                {
                    plazo.titularP = titular;
                    plazo.monto = monto;
                    plazo.fechaIni = fechaIni;
                    plazo.fechaFin = fechaFin;
                    plazo.tasa = tasa;
                    plazo.pagado = pagado;

                    contexto.plazoFijos.Update(plazo);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        //AGREGA UNA TARJETA DE CREDITO A LA LISTA DE PFS DEL BANCO Y A LA LISTA DE TARJETAS DE CREDITO DE UN USUARIO EN PARTICULAR//
        public bool AltaTarjetaCredito(int numero, int codigoV, float limite, float consumos,int idTarjeta)
        {
            try
            {
                TarjetaDeCredito tj = new TarjetaDeCredito(idTarjeta, usuarioActual, numero, codigoV, limite, consumos);
                contexto.tarjetaDeCredito.Add(tj);
                usuarioActual.tarjetas.Add(tj);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        //ELIMINA UNA TJ DE LA LISTA DE TJS DEL BANCO Y DE LA LISTA DE TJS DE UN USUARIO EN PARTICULAR//
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
                return false;
            }
            return false;
        }


        //MODIFICA EL LIMITE DE UNA TJ DE LA LISTA DE TJS DEL BANCO Y DE LA LISTA DE TJS DE UN USUARIO EN PARTICULAR//
        public bool ModificarTarjetaCredito(int id, float limite)
        {
            try
            {
                foreach (TarjetaDeCredito tj in usuarioActual.tarjetas)
                {
                    if (tj.idTarjetaDeCredito == id)
                    {
                        tj.limite = limite;
                        contexto.tarjetaDeCredito.Update(tj);
                        contexto.SaveChanges();
                        return true;

                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
          
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
        public List<Movimiento> obtenerMovimientos(int idCaja) // revisar returns
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

        public List<Pago> obtenerPagos(){return usuarioActual.pagos.ToList();}

        public List<PlazoFijo> obtenerPlazosFijos(){return usuarioActual.pfs.ToList();}

        public List<TarjetaDeCredito> obtenerTarjetasDeCredito(){return usuarioActual.tarjetas.ToList();}

        public Usuario traerUsuario(){return usuarioActual;}

        public List<Usuario> obtenerUsuarios() { return contexto.usuarios.ToList();}

        public bool TransferirDinero(float MontoTranferido, int CBUOrigen, int CBUDestino)
        {
            bool salida = false;
            string _mensaje = "[transf]";
            try
            {
                foreach (CajaDeAhorro cajaU in usuarioActual.cajas)
                {
                    if (cajaU.cbu == CBUOrigen)
                    {
                        if (cajaU.saldo > 0 && MontoTranferido <= cajaU.saldo)
                        {
                            if (this.RetirarDinero(MontoTranferido, CBUOrigen, _mensaje))
                            {
                                this.DepositarDinero(MontoTranferido, CBUDestino, _mensaje);
                                contexto.SaveChanges();
                                salida = true;
                            }
                            return salida;
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return salida;
        }
          


        public bool DepositarDinero(float _monto, int cbu, string _adicional)
        {   bool resultado = false;

            string _accion = "(+) Depo: $" + _monto + "; cbu:" + cbu;

            if (_adicional != "") //{ _accion = "(+) transf. de $" + _monto + " en cbu: " + cbu; }
            { _accion += _adicional; }

            foreach (CajaDeAhorro Caja in usuarioActual.cajas)
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

            string _accion = "(-) Extrac: $" + _monto + "; cbu:" + cbu;

            if (_adicional != "") //{ _accion = "(-) transf.$" + _monto + "; cbu:" + cbu + ";  + _adicional; }
            { _accion += _adicional; }

        
                    try
                    {
                foreach (CajaDeAhorro Caja in usuarioActual.cajas)
                {
                    if (Caja.cbu == cbu)
                    {

                        if (Caja.saldo > 0)
                        {
                            Caja.saldo = Caja.saldo - _monto;
                        }
                        DateTime fecha=DateTime.Now;
                        contexto.cajaDeAhorros.Update(Caja);
                        Movimiento mov = new Movimiento(_monto, Caja, _accion, fecha);
                        contexto.movimientos.Add(mov);
                    }
                }   
                    contexto.SaveChanges();
                        return true;
                 
                }
                    
                    catch (Exception)
                {
                    return false;
                }
                return false;
            
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
                        if (CajaDePago.idCajaDeAhorro == CBU)
                        {
                            CajaDePago.saldo = CajaDePago.saldo - Saldo;
                            TarjetaAPagar.consumos = 0;
                            AltaMovimiento(TarjetaAPagar.consumos, CajaDePago, detalle, fecha);
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
                  
                    
                    Usuario u = new Usuario(  dni,  nombre,  apellido, mail, password,isAdmin,bloqueado);
                    contexto.usuarios.Add(u);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public void Actualizar_usuarios(){contexto.usuarios.Load();}
        // inicio de sesion:
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
                            intentos++;
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
            

        //*****************************
        public bool AltaCajaAhorro()
        {
            try 
            {
                //Genera CBU a partir del DNI.
                int cbu = usuarioActual.dni * 10;

                Random rd = new Random();
                //int rand_num = rd.Next(cbu, cbu * 1109);
                int rand_num = rd.Next(cbu + 1);
                cbu = rand_num;
                float saldo=0;
               int idCajaDeAhorro = rd.Next(cbu + 2);
                List<Usuario> titulares = new List<Usuario>();
                List<Movimiento> movimientos = new List<Movimiento>();

                CajaDeAhorro c = new CajaDeAhorro(idCajaDeAhorro, cbu, titulares, saldo, movimientos);
                usuarioActual.cajas.Add(c);
                contexto.cajaDeAhorros.Add(c);
                contexto.SaveChanges();

            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
       
        public void cerrarPrograma()
        {
            contexto.Dispose();
        }

        //*Metodos modificados para el 2do TP - Fin
    }
}

