using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Direccion
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int CP { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
    }
}
