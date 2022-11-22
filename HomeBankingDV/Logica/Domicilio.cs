using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HomeBankingDV
{
    class Domicilio
    {
        public int idDomicilio { get; set; }
        public string calle { get; set; }
        public int altura { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }

        public int idUsuario { get; set; }

        public Usuario user { get; set; }

        public Domicilio() { }

    }
    

}
