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
        static int aux { get; set; }

        //constructor CREAR LAS LISTAS ACA
        public CajaDeAhorro(int id, int cbu, List<Usuario> titulares, float saldo, List<Movimiento> movimientos)
        {
            movimientos = new List<Movimiento>();
            titulares = new List<Usuario>();
            this.id = id;
            this.cbu = cbu;
            this.titulares = titulares;
            this.saldo = saldo;
            this.movimientos = movimientos;
        }


        public CajaDeAhorro(int _cbu, int _saldo)
        {
            movimientos = new List<Movimiento>();
            titulares = new List<Usuario>();
            this.cbu = _cbu;
            this.saldo = _saldo;
        }

        //constructor sobrecargado; al momento de crear una caja de ahorro ... no tengo movimientos 
        //public CajaDeAhorro(int _cbu, Usuario userActual)
        //{
        //movimientos = new List<Movimiento>();
        //titulares = new List<Usuario>();

        //id = aux++;
        //cbu = _cbu;
        //saldo = 0;
        //titulares.Add(userActual);
        //}
    }
}