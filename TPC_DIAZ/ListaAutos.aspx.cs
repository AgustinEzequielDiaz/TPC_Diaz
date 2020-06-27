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
    public partial class ListaAutos : System.Web.UI.Page
    {
        public List<Auto> listaAutos { get; set; }
        public Auto auto = new Auto();
        protected void Page_Load(object sender, EventArgs e)
        {
            AutoNegocio negocio = new AutoNegocio();
            try
            {
                if (!IsPostBack)
                {
                    listaAutos = negocio.ListarAuto();
                    dgvAutos.DataSource = listaAutos;
                    dgvAutos.DataBind();
                    //repetidor.DataSource = lista;
                    //repetidor.DataBind();

                }
            }
            catch (Exception)
            {


            }
        }

        protected void ButtonAuto_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAuto.aspx");
        }

        protected void dgvAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAuto.aspx");
        }
    }
}