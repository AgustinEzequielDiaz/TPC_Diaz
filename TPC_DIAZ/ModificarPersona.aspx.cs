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
    public partial class ModificarPersona : System.Web.UI.Page
    {
        Persona persona = new Persona();
        protected void Page_Load(object sender, EventArgs e)
        {
            persona = (Persona)Session[Session.SessionID + "PersonaModificar"];
            if (!IsPostBack)
            {
                NombrePersona.Text = persona.Nombre;
                ApellidoPersona.Text = persona.Apellido;
                DNIPersona.Text = Convert.ToString(persona.DNI);
                CallePersona.Text = persona.direccion.Calle;
                NumeroPersona.Text = Convert.ToString(persona.direccion.Numero);
                CPPersona.Text = Convert.ToString(persona.direccion.CP);
                LocalidadPersona.Text = persona.direccion.Localidad;
                ProvinciaPersona.Text = persona.direccion.Provincia;
                CargarDireccion(persona.direccion);
                persona.direccion = (Direccion)Session[Session.SessionID + "Direccion"];
                persona.contacto.Email = EmailPersona.Text;
                persona.contacto.Telefono = Convert.ToInt64(TelefonoPersona.Text);
                CargarContacto(persona.contacto);
                persona.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
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
                Session.Add(Session.SessionID + "Direccion", direccion);
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

        //protected void BtnModificarPersona_Click(object sender, EventArgs e)
        //{
        //    PersonaNegocio negocio = new PersonaNegocio();
        //    try
        //    {
        //        persona.IdPersona = Convert.ToInt32(Session[Session.SessionID + "IdModificarPersona"]);
        //        persona.Nombre = NombrePersona.Text;
        //        persona.Apellido = ApellidoPersona.Text;
        //        persona.DNI = Convert.ToInt32(DNIPersona.Text);
        //        persona.direccion.IdDireccion = Convert.ToInt32(Session[Session.SessionID + "IdModificarDireccion"]);
        //        persona.direccion.CP = Convert.ToInt32(CPPersona.Text);
        //        persona.direccion.Calle = CallePersona.Text;
        //        persona.direccion.Numero = Convert.ToInt32(NumeroPersona.Text);
        //        persona.direccion.Localidad = LocalidadPersona.Text;
        //        persona.direccion.Provincia = ProvinciaPersona.Text;
        //        persona.contacto.IdContacto = Convert.ToInt32(Session[Session.SessionID + "IdModificarContacto"]);
        //        persona.contacto.Email = EmailPersona.Text;
        //        persona.contacto.Telefono = Convert.ToInt64(TelefonoPersona.Text);
        //        negocio.ModificarPersona(persona);
        //        Response.Redirect("ListarPersonas");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}