using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TipoUsuario
    {
        public TipoUsuario()
        {
            Nombre = "";
            Eliminado = 0;
            //Permisos = 0;
        }
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }    
        public int Eliminado { get; set; }
        //public int Permisos { get; set; }
    }
}
