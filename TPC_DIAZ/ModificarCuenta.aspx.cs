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
    public partial class ModificarCuenta : System.Web.UI.Page
    {
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session[Session.SessionID + "CuentaModificar"];
            if (!IsPostBack)
            {
                NombreUsuario.Text = usuario.Nombre;
                ClaveUsuario.Text = usuario.Clave;                
                PermisoUsario.Text = Convert.ToString(usuario.Permiso);
                //ApellidoPersona.Text = usuario.Apellido;
                //DNIPersona.Text = Convert.ToString(usuario.DNI);
                //CallePersona.Text = usuario.direccion.Calle;
                //NumeroPersona.Text = Convert.ToString(usuario.direccion.Numero);
                //CPPersona.Text = Convert.ToString(usuario.direccion.CP);
                //LocalidadPersona.Text = usuario.direccion.Localidad;
                //ProvinciaPersona.Text = usuario.direccion.Provincia;
                //CargarDireccion(usuario.direccion);
                //usuario.direccion = (Direccion)Session[Session.SessionID + "Direccion"];
                //EmailPersona.Text = usuario.contacto.Email;
                //(TelefonoPersona.Text) = Convert.ToString(usuario.contacto.Telefono);
                //CargarContacto(usuario.contacto);
                //usuario.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
            }
        }

        protected void BtnModificarCuenta_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            usuario.Nombre = NombreUsuario.Text;
            usuario.Clave = ClaveUsuario.Text;
            usuario.Permiso = Convert.ToInt32(PermisoUsario.Text);
            negocioUsuario.ModificarCuenta(usuario);
            Response.Redirect("ListarUsuarios.aspx");
        }
    }
}