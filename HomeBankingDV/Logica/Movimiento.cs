using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class Movimiento
    {
        //Segun diagrama tendriamos que heredar de Banco?,
        //pero no tiene sentido
        public int id { get; set; }
        public float monto { get; set; }
        public CajaDeAhorro caja { get; set; }
        public string detalle { get; set; }
        public DateTime fecha { get; set; } //preguntar a profe, no nos toma Date
        
        //constructor
        public Movimiento(int id, float monto, CajaDeAhorro caja, string detalle, DateTime fecha)
        {
            this.id = id;
            this.monto = monto;
            this.caja = caja;
            this.detalle = detalle;
            this.fecha = fecha;
        }

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
