using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace HomeBankingDV
{
    public class PlazoFijo
    {
        public int idPlazoFijo { get; set; }
        public int NumUsuario { get; set; }
        public Usuario titularP { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
        public float tasa { get; set; }
        public bool pagado { get; set; }
        
        //constructor

        public PlazoFijo() { }
        public PlazoFijo(int idPlazoFijo, Usuario titular, float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
        {
            this.idPlazoFijo = idPlazoFijo;
            this.titularP = titular;
            this.monto = monto;
            this.fechaIni = fechaIni;
            this.fechaFin = fechaFin;
            this.tasa = tasa;
            this.pagado = pagado;
        }

        public PlazoFijo(Usuario titular, float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
        {
            this.titularP = titular;
            this.monto = monto;
            this.fechaIni = fechaIni;
            this.fechaFin = fechaFin;
            this.tasa = tasa;
            this.pagado = pagado;
        }
    }
}
