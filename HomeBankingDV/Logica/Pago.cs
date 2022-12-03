using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeBankingDV
{
    public class Pago
    //Segun diagrama tendriamos que heredar de Banco?,
    //pero no tiene sentido
    {
        public int idPago { get; set; }
        public int NumUsuario { get; set; }
        public Usuario user { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public string metodo { get; set; }

        //public TarjetaDeCredito tarjeta { get; set; }

        //constructor

        public Pago() { }
        public Pago(/*int id,*/ Usuario user, string nombre, float monto, bool pagado, string metodo)
        {
            //this.idPago = id;
            this.user = user;
            this.nombre = nombre;
            this.monto = monto;
            this.pagado = pagado;
            this.metodo = metodo;
        }
    }
}
