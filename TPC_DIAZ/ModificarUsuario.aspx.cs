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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        Usuario usuario = new Usuario();
        Persona persona = new Persona();
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session[Session.SessionID + "UsuarioModificar"];
            if (!IsPostBack)
            {
                NombrePersona.Text = usuario.Nombre;
                ApellidoPersona.Text = usuario.Apellido;
                DNIPersona.Text = Convert.ToString(usuario.DNI);
                CallePersona.Text = usuario.direccion.Calle;
                NumeroPersona.Text = Convert.ToString(usuario.direccion.Numero);
                CPPersona.Text = Convert.ToString(usuario.direccion.CP);
                LocalidadPersona.Text = usuario.direccion.Localidad;
                ProvinciaPersona.Text = usuario.direccion.Provincia;
                //CargarDireccion(usuario.direccion);
                //usuario.direccion = (Direccion)Session[Session.SessionID + "Direccion"];
                EmailPersona.Text = usuario.contacto.Email; 
                (TelefonoPersona.Text) = Convert.ToString(usuario.contacto.Telefono);
                //CargarContacto(usuario.contacto);
                //usuario.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
            }
        }

        protected void CargarDireccion(Direccion nuevo)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            negocio.ModificarDireccion(nuevo);
            List<Direccion> lista = new List<Direccion>();
            Direccion direccion = new Direccion();
            lista = negocio.ListarDireccion();
            if (lista != null)
            {
                direccion = lista.Find(J => J.Calle == nuevo.Calle && J.Numero == nuevo.Numero && J.CP == nuevo.CP && J.Localidad == nuevo.Localidad && J.Provincia == nuevo.Provincia);
                Session.Add(Session.SessionID + "Direccion", direccion);
            }
        }

        protected void CargarContacto(Contacto nuevo)
        {
            ContactoNegocio negocio = new ContactoNegocio();
            negocio.ModificarContacto(nuevo);
            List<Contacto> lista = new List<Contacto>();
            Contacto contacto = new Contacto();
            lista = negocio.ListarContacto();
            if (lista != null)
            {
                contacto = lista.Find(J => J.Email == nuevo.Email && J.Telefono == nuevo.Telefono);
                Session.Add(Session.SessionID + "Contacto", contacto);
            }
        }

        protected void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            usuario.Nombre = NombrePersona.Text;
            usuario.Apellido = ApellidoPersona.Text;
            usuario.DNI = Convert.ToInt64(DNIPersona.Text);
            usuario.Imagen = ImagenPersona.Text;
            usuario.direccion.Calle = CallePersona.Text;
            usuario.direccion.Numero = Convert.ToInt32(NumeroPersona.Text);
            usuario.direccion.CP = Convert.ToInt32(CPPersona.Text);
            usuario.direccion.Localidad = LocalidadPersona.Text;
            usuario.direccion.Provincia = ProvinciaPersona.Text;
            CargarDireccion(usuario.direccion);
            usuario.direccion = (Direccion)Session[Session.SessionID + "Direccion"];
            usuario.contacto.Email = EmailPersona.Text;
            usuario.contacto.Telefono = Convert.ToInt64(TelefonoPersona.Text);
            CargarContacto(usuario.contacto);
            negocioUsuario.ModificarUsuario(usuario);
            Response.Redirect("ListarUsuariosCompleto.aspx");
            usuario.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
        }
    }
}
