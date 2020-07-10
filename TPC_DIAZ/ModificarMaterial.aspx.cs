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
            Material material = new Material();
            material = (Material)Session[Session.SessionID + "MaterialModificar"];
            if(!IsPostBack)
            {
                NombreModificar.Text = material.Nombre;
                DescripcionModificar.Text = material.Descripcion;
                CantidadModificar.Text = Convert.ToString(material.Stock);
                ImagenModificar.Text = material.Imagen;
                CategoriaModificar.Text = Convert.ToString(material.Categoria.Id);
            }

        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            try
            {
                material.Id = Convert.ToInt32(Session[Session.SessionID + "IdModificar"]);
                material.Nombre = NombreModificar.Text;
                material.Descripcion = DescripcionModificar.Text;
                material.Stock = Convert.ToInt32(CantidadModificar.Text);
                material.Imagen = ImagenModificar.Text;
                material.Categoria.Id = Convert.ToInt32(CategoriaModificar.Text);
                negocio.ModificarMaterial(material);
                Response.Redirect("StockMateriales");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}