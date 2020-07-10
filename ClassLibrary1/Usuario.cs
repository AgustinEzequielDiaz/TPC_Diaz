using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario:Persona
    {
        public Usuario()
        {
            //IdTipo = new TipoUsuario();
            //IdPersona = new Persona();
            IdAuto = 0;
            Permiso = 1;
            Clave = "";
            Eliminado = 0;
            FechaReg = System.DateTime.Now.Date;
        }
        public int IdUsuario { get; set; }
        public int IdAuto { get; set; }
        public int Permiso { get; set; }
        public string Clave{ get; set; }
        public int Eliminado { get; set; }
        public DateTime FechaReg { get; set; }
    }
}
