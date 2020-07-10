using Dominio;
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
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public List<Usuario> listaUsuarios { get; set; }
        UsuarioNegocio negocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    listaUsuarios = negocio.ListarUsuario();
                    dgvUsuario.DataSource = listaUsuarios;
                    dgvUsuario.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void dgvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int IdUsuario = Convert.ToInt32(dgvUsuario.Rows[index].Cells[0].Text);
                negocio.EliminarUsuario(IdUsuario);
                Response.Redirect("ListarUsuarios.aspx");
            }
            if(e.CommandName == "Detalles")
            {
                Response.Redirect("ListarUsuariosCompleto.aspx");
            }
            if(e.CommandName == "Modificar")
            {
                listaUsuarios = negocio.ListarUsuarioCompleto();
                int index = Convert.ToInt32(e.CommandArgument);
                int UserSelec = Convert.ToInt32(dgvUsuario.Rows[index].Cells[0].Text);
                usuario = listaUsuarios.Find(M => M.IdUsuario == UserSelec);
                Session.Add(Session.SessionID + "CuentaModificar", usuario);
                Session.Add(Session.SessionID + "IdModificarCuenta", UserSelec);
                //negocio.ModificarUsuario(usuario);
                Response.Redirect("ModificarCuenta.aspx");
            }
        }
    }
}