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
    public partial class AgregarAuto : System.Web.UI.Page
    {
        UsuarioNegocio negociousuario = new UsuarioNegocio();
        public Auto auto = new Auto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                listaUsuarios = negociousuario.ListarUsuario();
                DdlConductor.Items.Add("--- Seleccione un conductor ---");
                DdlConductor.AppendDataBoundItems = true;
                DdlConductor.DataSource = listaUsuarios;
                DdlConductor.DataTextField = "Nombre";
                DdlConductor.DataValueField = "Nombre";
                DdlConductor.DataBind();
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Auto vehiculo = new Auto();
            AutoNegocio negocio = new AutoNegocio();
            List<Auto> listaAutos = new List<Auto>();
            try
            {
                
                int IdUsuario = Convert.ToInt32(Session[Session.SessionID + "id"]);
                vehiculo.Patente = PatenteAgregar.Text;
                vehiculo.Modelo = ModeloAgregar.Text;
                negocio.AgregarAuto(vehiculo);
                listaAutos = negocio.ListarAuto();
                vehiculo = listaAutos.Find(a => a.Patente == PatenteAgregar.Text );
                negocio.AgregarConductorXAuto(vehiculo, IdUsuario);
                Response.Redirect("ListaAutos.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DdlConductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Usuario> ListaUsuario = new List<Usuario>();

            ListaUsuario = negociousuario.ListarUsuario();
            String NombreUsuario = DdlConductor.SelectedItem.Value;
            Usuario id = ListaUsuario.Find(k => k.Nombre == NombreUsuario);
            Session.Add(Session.SessionID + "id", id.IdUsuario);
        }

        protected void btnAgregarConductor_Click(object sender, EventArgs e)
        {

        }
    }
}