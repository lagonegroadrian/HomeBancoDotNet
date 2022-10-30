using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class Movimiento
    {
        public int id { get; set; }
        public float monto { get; set; }
        public CajaDeAhorro caja { get; set; }
        public string detalle { get; set; }
        public DateTime fecha { get; set; }

        public Movimiento(int id, float monto, CajaDeAhorro caja, string detalle)
        {
            this.id = id;
            this.monto = monto;
            this.caja = caja;
            this.detalle = detalle;
            this.fecha = DateTime.Today;
        }
    }
}