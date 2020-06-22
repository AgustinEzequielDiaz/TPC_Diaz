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
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        public Categoria categoria = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                categoria.Nombre = NombreCategoria.Text;
                negocio.AgregarCategoria(categoria);
                //Response.Redirect(".aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}