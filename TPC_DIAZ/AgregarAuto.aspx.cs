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
    public partial class AgregarAuto : System.Web.UI.Page
    {
        public Auto auto = new Auto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            AutoNegocio negocio = new AutoNegocio();
            try
            {
                auto.Patente = PatenteAgregar.Text;
                auto.Modelo = ModeloAgregar.Text;
                negocio.AgregarAuto(auto);
                Response.Redirect("ListaAutos.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}