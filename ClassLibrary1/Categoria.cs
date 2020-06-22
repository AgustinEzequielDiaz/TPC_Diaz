using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Categoria
    {
        public Categoria()
        {
            Nombre = "";
            Eliminado = 0;

        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Eliminado { get; set; }
    }
}
