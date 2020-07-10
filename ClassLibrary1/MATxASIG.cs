using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MATxASIG
    {
        public MATxASIG()
        {
            Cantidad = 0;
            material = new List<Material>();            
        }
        public int Cantidad { get; set; }
        public List<Material> material { get; set; }
        
    }
}
