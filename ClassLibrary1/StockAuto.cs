using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class StockAuto
    {
        public StockAuto()
        {
            IdAsignar = new Asignar();
            IdAuto = new Auto();
            material = new Material();
            usuario = new Usuario();
            Cantidad = 0;
            Eliminado = 0;
        }
        public int IdStockAuto { get; set; }
        public Asignar IdAsignar { get; set; }
        public Auto IdAuto { get; set;}
        public Material material { get; set; }
        public Usuario usuario { get; set; }
        public int Cantidad { get; set; }
        public int Eliminado { get; set; }
    }
}
