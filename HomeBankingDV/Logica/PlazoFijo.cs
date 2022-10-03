using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class PlazoFijo
    {
        public int id { get; set; }
        public Usuario titular { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
        public float tasa { get; set; }
        public bool pagado { get; set; }
        
        //constructor
        public PlazoFijo(int id, Usuario titular, float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
        {
            this.id = id;
            this.titular = titular;
            this.monto = monto;
            this.fechaIni = fechaIni;
            this.fechaFin = fechaFin;
            this.tasa = tasa;
            this.pagado = pagado;
        }
    }
}
