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
    public partial class _Default : Page
    {
        public List<Material> lista { get; set; }
        public Material articulo = new Material();
        MaterialNegocio negocio = new MaterialNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lista = negocio.ListarMaterial();

                if (!IsPostBack)
                {
                    //pregunto si es la primera carga de la page
                    //esto es lo que necesitamos para el repeater.
                    repetidor.DataSource = lista;
                    repetidor.DataBind();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

            MaterialNegocio negocio = new MaterialNegocio();
            StockDeposito stockDep = new StockDeposito();
            try
            {

                lista = negocio.ListarMaterial();
                var materialSelec = Convert.ToInt32(((Button)sender).CommandArgument);
                articulo = lista.Find(J => J.Id == materialSelec);
                if (Session[Session.SessionID + "material"] != null)
                {
                    stockDep = (StockDeposito)Session[Session.SessionID + "material"];
                }
                if (!stockDep.Materiales.Exists(A => A.Id == articulo.Id))
                {
                    stockDep.Materiales.Add(articulo);
                    Session.Add(Session.SessionID + "material", stockDep);
                }

            }
            catch (Exception ex)
            {
                throw ex;
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