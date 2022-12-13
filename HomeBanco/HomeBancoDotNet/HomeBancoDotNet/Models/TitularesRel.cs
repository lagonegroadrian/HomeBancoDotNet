using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeBancoDotNet.Models
{
    public class TitularesRel
    {
        public int idTi { get; set; }
        public int idCa { get; set; }

        public CajaDeAhorro ca {get; set; }
        public int idUs { get; set; }

        public Usuario us { get; set; }

        public TitularesRel() { }
        public TitularesRel(/*int _idTi,*/ int _idCa, int _idUs)
        {
            //this.idTi = _idTi;
            this.idCa = _idCa;
            this.idUs = _idUs;
        }
    }
}
