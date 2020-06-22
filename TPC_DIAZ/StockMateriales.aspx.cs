using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_DIAZ
{
    public partial class StockMateriales : System.Web.UI.Page
    {
        public List<Material> lista { get; set; }
        public Material articulo = new Material();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MaterialNegocio negocio = new MaterialNegocio();
                lista = negocio.ListarMaterial();
                if (!IsPostBack)
                {
                    dgvCarrito.DataSource = lista;
                    dgvCarrito.DataBind();

                }
            }
            catch (Exception)
            {


            }
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ButtonCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }
    }
}