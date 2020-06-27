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
                    //dgvMaterial.DataSource = lista;
                    //dgvMaterial.DataBind();
                    repetidor.DataSource = lista;
                    repetidor.DataBind();

                }
            }
            catch (Exception)
            {


            }
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ButtonMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMaterial.aspx");
        }

        protected void ButtonEliminarMaterial_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            Material Eliminado = new Material();
 
            try
            {
                lista = negocio.ListarMaterial();
                var materialSelec = Convert.ToInt32(((Button)sender).CommandArgument);
                negocio.EliminarMaterial(materialSelec);
                Response.Redirect("StockMateriales.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ButtonModificarMaterial_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            lista = negocio.ListarMaterial();
            var materialSelec = Convert.ToInt32(((Button)sender).CommandArgument);
            Material modificar = lista.Find(M => M.Id == materialSelec);
            Session.Add(Session.SessionID + "MaterialModificar", modificar);
            Session.Add(Session.SessionID + "IdModificar", materialSelec);
            Response.Redirect("ModificarMaterial.aspx");
        }

        protected void AgregarNuevoMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMaterial.aspx");
        }
    }
}