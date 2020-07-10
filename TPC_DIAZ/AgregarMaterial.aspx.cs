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
        CategoriaNegocio negocio = new CategoriaNegocio();
        public Material material = new Material();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Categoria> listanueva = new List<Categoria>();
                listanueva = negocio.ListarCategoria();
                DdlCategoria.Items.Add("--- Seleccione una categoria ---");
                DdlCategoria.AppendDataBoundItems = true;
                DdlCategoria.DataSource = listanueva;
                DdlCategoria.DataBind();
                DdlCategoria.DataTextField = "id";
                DdlCategoria.DataValueField = "NombreCategoria";
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            try
            {
                material.Nombre = NombreAgregar.Text;
                material.Descripcion = DescripcionAgregar.Text;
                //material.Categoria.Nombre = CategoriaAgregar.Text;
                material.Categoria.Id = Convert.ToInt32(Session[Session.SessionID + "id"]);
                material.Stock = Convert.ToInt32(CantidadAgregar.Text);
                material.Imagen = ImagenAgregar.Text;
                negocio.AgregarMaterial(material);
                Response.Redirect("StockMateriales.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DdlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Categoria> ListaCategoria = new List<Categoria>();
            
            ListaCategoria = negocio.ListarCategoria();
            String NombreCategoria = DdlCategoria.SelectedItem.Value;
            Categoria id = ListaCategoria.Find(k => k.Nombre == NombreCategoria);
            Session.Add(Session.SessionID + "id", id.Id);
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }
    }
}