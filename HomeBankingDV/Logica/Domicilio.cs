using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBankingDV
{
    class Domicilio
    {
        public int id { get; set; }
        public string calle { get; set; }
        public int altura { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public int idUsuario { get; set; }
        public Domicilio (int Id, string Calle, int Altura, string Ciudad, string Provincia, int IDusuario)
        {
            id = Id;
            calle = Calle;
            altura = Altura;
            ciudad = Ciudad;
            provincia = Provincia;
            idUsuario = IDusuario;
        }
    }
}
