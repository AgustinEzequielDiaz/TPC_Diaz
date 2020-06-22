using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_DIAZ
{
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        public Material material = new Material();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            try
            {
                material.Nombre = NombreAgregar.Text;
                material.Descripcion = DescripcionAgregar.Text;
                material.Cantidad = Convert.ToInt32(CantidadAgregar.Text);
                material.Imagen = ImagenAgregar.Text;
                material.Categoria.Nombre = CategoriaAgregar.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}