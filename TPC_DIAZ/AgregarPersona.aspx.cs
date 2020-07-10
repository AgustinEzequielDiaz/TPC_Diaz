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
    public partial class AgregarPersona : System.Web.UI.Page
    {
        public Persona persona = new Persona();
        public Direccion direccion = new Direccion();
        public Contacto contacto = new Contacto();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ButtonAgregarPersona_Click(object sender, EventArgs e)
        {
            PersonaNegocio negocioPersona = new PersonaNegocio();
            DireccionNegocio negocioDireccion = new DireccionNegocio();
            ContactoNegocio negocioContacto = new ContactoNegocio();

            
            try
            {
                persona.Nombre = NombrePersona.Text;
                persona.Apellido = ApellidoPersona.Text;
                persona.DNI = Convert.ToInt64(DNIPersona.Text);
                //persona.FechaNac = Convert.ToDateTime(FechaNacPersona.Text);
                
                persona.direccion.Calle = CallePersona.Text;
                persona.direccion.Numero = Convert.ToInt32(NumeroPersona.Text);
                persona.direccion.CP = Convert.ToInt32(CPPersona.Text);
                persona.direccion.Localidad = LocalidadPersona.Text;
                persona.direccion.Provincia = ProvinciaPersona.Text;
                CargarDireccion(persona.direccion);
                persona.direccion = (Direccion)Session[Session.SessionID + "Direccion"];
                persona.contacto.Email = EmailPersona.Text;
                persona.contacto.Telefono = Convert.ToInt64(TelefonoPersona.Text);
                CargarContacto(persona.contacto);
                persona.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
                negocioPersona.AgregarPersona(persona);
                Response.Redirect("Registrar.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarDireccion(Direccion nuevo)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            negocio.AgregarDireccion(nuevo);
            List<Direccion> lista = new List<Direccion>();
            Direccion direccion = new Direccion();
            lista = negocio.ListarDireccion();
            if (lista != null)
            {
                direccion = lista.Find(J => J.Calle == nuevo.Calle && J.Numero == nuevo.Numero && J.CP == nuevo.CP && J.Localidad == nuevo.Localidad && J.Provincia == nuevo.Provincia);
            }
        }

        protected void CargarContacto(Contacto nuevo)
        {
            ContactoNegocio negocio = new ContactoNegocio();
            negocio.AgregarContacto(nuevo);
            List<Contacto> lista = new List<Contacto>();
            Contacto contacto = new Contacto();
            lista = negocio.ListarContacto();
            if (lista != null)
            {
                contacto = lista.Find(J => J.Email == nuevo.Email && J.Telefono == nuevo.Telefono);
                Session.Add(Session.SessionID + "Contacto", contacto);
            }
        }
    }
}