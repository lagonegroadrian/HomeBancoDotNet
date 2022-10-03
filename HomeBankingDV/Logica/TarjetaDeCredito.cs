using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBankingDV
{
    public class TarjetaDeCredito
    {
        public int id { get; set; }
        public Usuario titular { get; set; } //en el diagrama dice user?
        public int numero { get; set; }
        public int codigoV { get; set; }
        public float limite { get; set; }
        public float consumos { get; set; } //deberia ser singular, no?

        //constructor
        public TarjetaDeCredito(int id, Usuario titular, int numero, int codigoV, float limite, float consumos)
        {
            this.id = id;
            this.titular = titular;
            this.numero = numero;
            this.codigoV = codigoV;
            this.limite = limite;
            this.consumos = consumos;
        }

        //public List<Usuario> titulares { get; set; }

    }
}
