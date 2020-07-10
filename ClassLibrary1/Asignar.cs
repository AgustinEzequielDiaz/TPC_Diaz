using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Asignar
    {
        public Asignar()
        {

            fechaAsignacion = new DateTime();
            IdUsuario = new Usuario();
            //Cantidad = 0;
        }
        public int IdAsignar { get; set; }
        public Usuario IdUsuario { get; set; }
        //public int Cantidad { get; set; }
        public DateTime fechaAsignacion { get; set; }
    }
}
