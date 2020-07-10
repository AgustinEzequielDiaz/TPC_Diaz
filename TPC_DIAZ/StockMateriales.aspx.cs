using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;
using Dominio;
using Negocio;

namespace TPC_DIAZ
{
    public partial class StockMateriales : System.Web.UI.Page
    {
        public List<Material> lista { get; set; }
        List<StockAuto> stockAutos { get; set; }

        MATxASIG ASIG = new MATxASIG();

        public Material material = new Material();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //Usuario usuario = (Usuario)Session["UserSession"];
                //if (usuario == null)
                //{ 
                //    Response.Redirect("LogIn.aspx");
                //}
                //if(!usuario.IdPersona.Nombre.ToLower().Contains("admin"))
                //{
                //    Session["Error" + Session.SessionID] = "El perfil " + ' ' + usuario.IdPersona.Nombre + ' ' + " no tiene los permisos requeridos";
                //    Response.Redirect("Error.aspx");                
                //}

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

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            MaterialNegocio negocio = new MaterialNegocio();
            Asignar asignar = new Asignar();
            try
            {
                lista = negocio.ListarMaterial();
                var materialSelec = Convert.ToInt32(((Button)sender).CommandArgument);
                material = lista.Find(a => a.Id == materialSelec);
                if(Session[Session.SessionID + "material"]!=null)
                {
                    ASIG.material = (List<Material>)Session[Session.SessionID + "material"];
                }
                if(!ASIG.material.Exists(M => M.Id == material.Id))
                {
                    ASIG.material.Add(material);
                    //ASIG.Cantidad+=;
                    Session.Add(Session.SessionID + "material", ASIG.material);
                }
                //if(!lista.Find(s => s.Id == articulo.Id))
                //{
                //    stock.Material.Add(articulo);
                //    stock.Cantidad+=1;
                //    Session.Add(Session.SessionID + "articulo", stock);
                //    Session.Add(Session.SessionID + "Cantidad", stock.Cantidad);
                //}

            }
            catch (Exception ex)
            {
                throw ex ;
            }


        }

        //protected void Filtrar_TextChanged(object sender, EventArgs e)
        //{
        //    List<Articulo> listaFiltrada;
        //    try
        //    {
        //        lista = negocio.ListarArticulo2();
        //        if (txtFiltrar.Text == "")
        //        {
        //            listaFiltrada = lista;
        //            Session.Add(Session.SessionID + "filtrado", listaFiltrada);
        //            repetidor.DataSource = listaFiltrada;
        //            repetidor.DataBind();

        //        }
        //        else
        //        {
        //            listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltrar.Text.ToLower()) ||
        //              k.Marca.DescMarca.ToLower().Contains(txtFiltrar.Text.ToLower()) ||
        //              k.Categoria.DescCat.ToLower().Contains(txtFiltrar.Text.ToLower()) ||
        //              k.Codigo.ToLower().Contains(txtFiltrar.Text.ToLower()));
        //            Session.Add(Session.SessionID + "filtrado", listaFiltrada);
        //            repetidor.DataSource = listaFiltrada;
        //            repetidor.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}