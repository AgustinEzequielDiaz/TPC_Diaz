using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Auto
    {
        public Auto()
        {
            Modelo = "";
            Patente = "";
            Eliminado = 0;
        }
        public int IdAuto { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public int Eliminado { get; set; }
    }
}
