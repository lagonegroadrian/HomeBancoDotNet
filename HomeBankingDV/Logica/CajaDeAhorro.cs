using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBankingDV.Logica;
using Microsoft.EntityFrameworkCore;

namespace HomeBankingDV
{
    public class CajaDeAhorro
    {
        public int idCajaDeAhorro { get; set; }
        public int cbu { get; set; }
        public ICollection<Usuario> titulares { get; set; } 
        public float saldo { get; set; }
        public List<Movimiento> movimientos { get; set; }

        public List<TitularesRel> UserCajas { get; set; }
      

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
     

        public CajaDeAhorro(int _id, int _cbu, float _saldo)
        {
            movimientos = new List<Movimiento>();
            titulares = new List<Usuario>();
            this.idCajaDeAhorro = _id;
            this.cbu = _cbu;
            this.saldo = _saldo;
        }

       
    }
}