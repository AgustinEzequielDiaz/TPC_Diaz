using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Direccion
    {
        public Direccion()
        {
            //IdDireccion = 1;
            Calle = "";
            Numero = 0;
            CP = 0;
            Localidad = "";
            Provincia = "";
            Eliminado = 0;
        }
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int CP { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int Eliminado { get; set; }
    }
}
