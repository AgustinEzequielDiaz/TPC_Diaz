using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Persona
    {

        public Persona()
        {
            Nombre = "";
            Apellido = "";
            Imagen = "";
            DNI = 0;
            FechaNac = System.DateTime.Today;
            FechaReg = System.DateTime.Now;
            Eliminado = 0;
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaReg { get; set; }
        public int Eliminado { get; set; }
    }
}
