using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaReg { get; set; }
        public bool Eliminado { get; set; }
    }
}
