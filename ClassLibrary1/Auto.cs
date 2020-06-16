using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Auto
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public Usuario Conductor { get; set; }
    }
}
