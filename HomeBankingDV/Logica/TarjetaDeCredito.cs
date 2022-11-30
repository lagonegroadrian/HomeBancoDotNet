using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeBankingDV
{
    public class TarjetaDeCredito
    {
        public int idTarjetaDeCredito { get; set; }
        public int idUsuario { get; set; }
        public Usuario titular { get; set; }
        public int numero { get; set; }
        public int codigoV { get; set; }
        public float limite { get; set; }
        public float consumos { get; set; }

        //constructor
        public TarjetaDeCredito() { }
        public TarjetaDeCredito(int id, Usuario titular, int numero, int codigoV, float limite, float consumos)
        {
            this.idTarjetaDeCredito = id;
            this.titular = titular;
            this.numero = numero;
            this.codigoV = codigoV;
            this.limite = limite;
            this.consumos = consumos;
        }

        public TarjetaDeCredito(/*int id,*/ Usuario titular, int numero, int codigoV, float limite, float consumos)
        {
            //this.idTarjetaDeCredito = id;
            this.titular = titular;
            this.numero = numero;
            this.codigoV = codigoV;
            this.limite = limite;
            this.consumos = consumos;
        }

        //public List<Usuario> titulares { get; set; }

    }
}
