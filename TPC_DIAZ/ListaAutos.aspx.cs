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
        public AutoNegocio negocio = new AutoNegocio();
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

        protected void dgvAutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idAuto = Convert.ToInt32(dgvAutos.Rows[index].Cells[0].Text);
                negocio.EliminarAuto(idAuto);
                Response.Redirect("listaAutos.aspx");
            }

            if (e.CommandName == "Modificar")
            {
                listaAutos = negocio.ListarAuto();
                int index = Convert.ToInt32(e.CommandArgument);
                int AutoSelec = Convert.ToInt32(dgvAutos.Rows[index].Cells[0].Text);
                auto = listaAutos.Find(M => M.IdAuto == AutoSelec);
                Session.Add(Session.SessionID + "AutoModificar", auto);
                Session.Add(Session.SessionID + "IdModificar", AutoSelec);
                negocio.ModificarAuto(auto);
                Response.Redirect("ModificarAuto.aspx");
            }
        }
    }
}