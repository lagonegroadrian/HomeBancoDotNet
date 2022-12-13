using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeBancoDotNet.Models
{
    public class Movimiento
    {
        public int idMovimiento { get; set; }
        public float monto { get; set; }

        public int idCaja { get; set; }
        public CajaDeAhorro caja { get; set; }
        public string detalle { get; set; }
        public DateTime fecha { get; set; }
        
        public Movimiento() { }
        public Movimiento(float monto, CajaDeAhorro caja, string detalle, DateTime fecha)
        {
           
            this.monto = monto;
            this.caja = caja;
            this.detalle = detalle;
            this.fecha = fecha;
        }
    }
}
