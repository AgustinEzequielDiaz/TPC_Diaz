using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Persona
    {
        public Persona()
        {
            //IdUsuario = 0;
            Nombre = "";
            Apellido = "";
            Imagen = "";
            DNI = 000000;
            direccion = new Direccion();
            contacto = new Contacto();
            //FechaNac = System.DateTime.Now; 
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public long DNI { get; set; }
        public Direccion direccion { get; set; }
        public Contacto contacto { get; set; }
        //public DateTime FechaNac { get; set; }
       
    }
}
