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
    public partial class ListarPersonas : System.Web.UI.Page
    {
        public List<Persona> listaPersonas { get; set; }
        public Persona persona = new Persona();
        public Direccion direccion = new Direccion();
        public Contacto contacto = new Contacto();
        public UsuarioNegocio negocioUsuario = new UsuarioNegocio();
        public PersonaNegocio negocioPersona = new PersonaNegocio();
        public DireccionNegocio negocioDireccion = new DireccionNegocio();
        public ContactoNegocio negocioContacto = new ContactoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonaNegocio negocio = new PersonaNegocio();
            try
            {
                if (!IsPostBack)
                {
                    listaPersonas = negocio.ListarPersona();
                    dgvPersona.DataSource = listaPersonas;
                    dgvPersona.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }

        protected void dgvPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
           Response.Redirect("AgregarPersona.aspx");
        }

        protected void ButtonPersona_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPersona.aspx");
        }

        protected void dgvPersona_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int index = convert.toint32(e.commandargument);
            //string idseleccionado = dgvpersona.rows[index].cells[0].text;
            //int idseleccionado = convert.toint32(idseleccionado);
            ////if (carro.producto.exists(a => a.id == idseleccionado))
            ////{
            ////persona = carro.producto.find(j => j.id == idseleccionado);
            ////carro.cantidad--;
            ////carro.total -= articulo.precio;
            ////carro.producto.remove(articulo);
            //session.add(session.sessionid + "persona", persona);
            //session.add(session.sessionid + "nombre", persona.nombre);
            //session.add(session.sessionid + "apellido", persona.apellido);
            //response.redirect("carrodecompras.aspx");

            //}

            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idPersona = Convert.ToInt32(dgvPersona.Rows[index].Cells[0].Text);
                negocioPersona.EliminarPersona(idPersona);
                Response.Redirect("ListarPersonas.aspx");
            }

            //if (e.CommandName == "Modificar")
            //{
            //    ListaUsuario = negocioUsuario.ListarUsuario();
            //    listaPersonas = negocioPersona.ListarPersona();
            //    listaDireccion = negocioDireccion.ListarDireccion();
            //    listaContacto = negocioContacto.ListarContacto();
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    int Personaselec = Convert.ToInt32(dgvPersona.Rows[index].Cells[0].Text);
            //    //persona = listaPersonas.Find(p => p.IdPersona == Personaselec);
            //    user = ListaUsuario.Find(p => p.IdUsuario = Personaselec);
            //    direccion = listaDireccion.Find(d => d.IdDireccion == Personaselec);
            //    contacto = listaContacto.Find(c => c.IdContacto == Personaselec);
            //    Session.Add(Session.SessionID + "PersonaModificar", persona);
            //    Session.Add(Session.SessionID + "IdModificarPersona", Personaselec);
            //    Session.Add(Session.SessionID + "IdModificarDireccion", Personaselec);
            //    Session.Add(Session.SessionID + "IdModificarContacto", Personaselec);
            //    negocioPersona.ModificarPersona(persona);
            //    negocioDireccion.ModificarDireccion(direccion);
            //    negocioContacto.ModificarContacto(contacto);
            //    Response.Redirect("ModificarPersona.aspx");
            //}
        }

    }
}
