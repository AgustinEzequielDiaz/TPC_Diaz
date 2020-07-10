using ClassLibrary1;
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
    public partial class ListaTipoUsuario : System.Web.UI.Page
    {
        public List<TipoUsuario> listaTipoUsuario { get; set; }
        public TipoUsuario tipo = new TipoUsuario();
        public TipoUsuarioNegocio negocio = new TipoUsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    listaTipoUsuario = negocio.ListarTipoUsuario();
                    dgvTiposUsuarios.DataSource = listaTipoUsuario;
                    dgvTiposUsuarios.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }

        protected void dgvTiposUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAuto.aspx");
        }

        protected void dgvTiposUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idTipoUsuario = Convert.ToInt32(dgvTiposUsuarios.Rows[index].Cells[0].Text);
                negocio.EliminarTipoUsuario(idTipoUsuario);
                Response.Redirect("listaTipoUsuario.aspx");
            }

            if (e.CommandName == "Modificar")
            {
                listaTipoUsuario = negocio.ListarTipoUsuario();
                int index = Convert.ToInt32(e.CommandArgument);
                int TipoSelec = Convert.ToInt32(dgvTiposUsuarios.Rows[index].Cells[0].Text);
                tipo = listaTipoUsuario.Find(M => M.IdTipoUsuario == TipoSelec);
                Session.Add(Session.SessionID + "TipoUsuarioModificar", tipo);
                Session.Add(Session.SessionID + "IdModificar", TipoSelec);
                negocio.ModificarTipoUsuario(tipo);
                Response.Redirect("ModificarTipoUsuario.aspx");
            }
        }

        protected void BtnAgregarTipoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTipoUsuario.aspx");
        }
    }
}