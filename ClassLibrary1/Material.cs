using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Material
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public Categoria Categoria { get; set; }
        public int Cantidad { get; set; }
        public int Eliminado { get; set; }
    }
}
