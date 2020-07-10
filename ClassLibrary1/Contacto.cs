using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Contacto
    {
        public Contacto()
        {
            //IdContacto = 1;
            Email = "";
            Telefono = 0;
            Eliminado = 0;
        }
        public int IdContacto { get; set; }
        public string Email { get; set; }
        public long Telefono { get; set; }
        public int Eliminado { get; set; }
    }
}
