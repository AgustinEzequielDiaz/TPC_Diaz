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

    public partial class AgregarMaterial : System.Web.UI.Page
    {
        public Material material = new Material();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{ 
            //    CategoriaAgregar.DataSource = listaCategoria;
            //    CategoriaAgregar.DataTextField = "Nombre";
            //    CategoriaAgregar.DataBind();
            //}
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            try
            {
                material.Nombre = NombreAgregar.Text;
                material.Descripcion = DescripcionAgregar.Text;
                //material.Categoria.Nombre = CategoriaAgregar.Text;
                material.Categoria.Id = Convert.ToInt32(CategoriaAgregarBox.Text);
                material.Cantidad = Convert.ToInt32(CantidadAgregar.Text);
                material.Imagen = ImagenAgregar.Text;
                negocio.AgregarMaterial(material);
                Response.Redirect("StockMateriales.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}