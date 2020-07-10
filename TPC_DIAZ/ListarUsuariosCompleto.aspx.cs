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
    public partial class ListarUsuariosCompleto : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public UsuarioNegocio negocio = new UsuarioNegocio();
        public DireccionNegocio negocioDireccion = new DireccionNegocio();
        public ContactoNegocio negocioContacto = new ContactoNegocio(); 
        public List<Usuario> listaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (!IsPostBack)
                {
                    listaUsuarios = negocio.ListarUsuarioCompleto();
                    dgvUsuariosCompleto.DataSource = listaUsuarios;
                    dgvUsuariosCompleto.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvUsuariosCompleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ListarUsuariosCompleto.aspx");
        }

        protected void dgvUsuariosCompleto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idUsuario = Convert.ToInt32(dgvUsuariosCompleto.Rows[index].Cells[0].Text);
                negocio.EliminarUsuario(idUsuario);
                //negocioDireccion.EliminarDireccion(IdDireccion);
                //negocioContacto.EliminarContacto(IdContacto);
                Response.Redirect("ListarUsuariosCompleto.aspx");
            }

            if (e.CommandName == "Modificar")
            {               
                listaUsuarios = negocio.ListarUsuarioCompleto();
                int index = Convert.ToInt32(e.CommandArgument);
                int UserSelec = Convert.ToInt32(dgvUsuariosCompleto.Rows[index].Cells[0].Text);
                usuario = listaUsuarios.Find(M => M.IdUsuario == UserSelec);
                Session.Add(Session.SessionID + "UsuarioModificar", usuario);
                Session.Add(Session.SessionID + "IdModificar", UserSelec);
                //negocio.ModificarUsuario(usuario);
                Response.Redirect("ModificarUsuario.aspx");
            }
        }
    }
}