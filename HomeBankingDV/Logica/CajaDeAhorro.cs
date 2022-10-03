using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class CajaDeAhorro
    {
        public int id { get; set; }
        public int cbu { get; set; }
        public List<Usuario> titulares { get; set; }
        public float saldo { get; set; }
        public List<Movimiento> movimientos { get; set; }

        //constructor
        public CajaDeAhorro(int id, int cbu, List<Usuario> titulares, float saldo, List<Movimiento> movimientos)
        {
            this.id = id;
            this.cbu = cbu;
            this.titulares = titulares;
            this.saldo = saldo;
            this.movimientos = movimientos;
        }
        

    }
}
