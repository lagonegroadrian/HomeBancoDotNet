using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeBancoDotNet.Models
{
    public class CajaDeAhorro
    {
        public int idCajaDeAhorro { get; set; }
        public int cbu { get; set; }
        public ICollection<Usuario> titulares { get; set; } = new List<Usuario>();
        public float saldo { get; set; }
        public List<Movimiento> movimientos { get; set; } = new List<Movimiento>();

        public List<TitularesRel> UserCajas { get; set; } = new List<TitularesRel>();

        public CajaDeAhorro(int idCajaDeAhorro, int cbu, List<Usuario> titulares, float saldo, List<Movimiento> movimientos)
        {
            movimientos = new List<Movimiento>();
            titulares = new List<Usuario>();
            this.idCajaDeAhorro = idCajaDeAhorro;
            this.cbu = cbu;
            this.titulares = titulares;
            this.saldo = saldo;
            this.movimientos = movimientos;
        }

        public CajaDeAhorro() { }

        public CajaDeAhorro(int _cbu, float _saldo)
        {
            movimientos = new List<Movimiento>();
            titulares = new List<Usuario>();
         
            this.cbu = _cbu;
            this.saldo = _saldo;
        }

        public CajaDeAhorro( int cbu, List<Usuario> _titulares, float saldo, List<Movimiento> movimientos)
        {
            movimientos = new List<Movimiento>();
            titulares = _titulares;
            
            this.cbu = cbu;
            this.titulares = titulares;
            this.saldo = saldo;
            this.movimientos = movimientos;
        }


    }
}