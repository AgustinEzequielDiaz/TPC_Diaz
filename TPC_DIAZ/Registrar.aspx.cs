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
    public partial class Registrar : System.Web.UI.Page
    {
        UsuarioNegocio negocio = new UsuarioNegocio();
        DireccionNegocio negocioDireccion = new DireccionNegocio();
        ContactoNegocio negocioContacto = new ContactoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            
            Direccion direccion = new Direccion();
            Contacto contacto = new Contacto();
            Usuario nuevo = new Usuario();
            try
            {
                nuevo.Nombre = NombreUsuario.Text;
                if (ClaveRepetida.Text == ClaveUsuario.Text)
                {
                    nuevo.Clave = ClaveUsuario.Text;
                }
                nuevo.direccion = new Direccion();
                nuevo.contacto = new Contacto();
                Cargardomicilio(nuevo.direccion);
                Cargarcontacto(nuevo.contacto);
                nuevo.direccion = (Direccion)Session[Session.SessionID + "Domicilio"];
                nuevo.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
                //negocioDireccion.AgregarDireccion(nuevo.direccion);  
                //negocioContacto.AgregarContacto(nuevo.contacto);
                negocio.RegistrarUsuario(nuevo);
                Response.Redirect("LogIn.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Cargardomicilio(Direccion nuevo)
        {
            negocioDireccion.AgregarDireccion(nuevo);
            List<Direccion> lista = new List<Direccion>();
            Direccion tipo = new Direccion();
            lista = negocioDireccion.ListarDireccion();
            if (lista != null)
            {
                //tipo = lista.Find(J => J.Calle == nuevo.Calle && J.Numero == nuevo.Numero
                //&& J.CP == nuevo.CP && J.Localidad == nuevo.Localidad && J.Provincia == nuevo.Provincia);
                tipo = lista[lista.Count - 1];
                Session.Add(Session.SessionID + "Domicilio", tipo);
            }

        }

        protected void Cargarcontacto(Contacto nuevo)
        {
            negocioContacto.AgregarContacto(nuevo);
            List<Contacto> lista = new List<Contacto>();
            Contacto tipo = new Contacto();
            lista = negocioContacto.ListarContacto();
            if (lista != null)
            {
                //tipo = lista.Find(J => J.Telefono == nuevo.Telefono && J.Email == nuevo.Email);
                tipo = lista[lista.Count - 1];
                Session.Add(Session.SessionID + "Contacto", tipo);
            }

        }

    }
}