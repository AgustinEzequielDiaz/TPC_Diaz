using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_DIAZ
{
    public partial class ModificarAuto : System.Web.UI.Page
    {
        UsuarioNegocio negociousuario = new UsuarioNegocio();
        Auto auto = new Auto();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            auto = (Auto)Session[Session.SessionID + "AutoModificar"];
            if (!IsPostBack)
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                listaUsuarios = negociousuario.ListarUsuario();
                PatenteModificar.Text = auto.Patente;
                ModeloModificar.Text = auto.Modelo;
                DdlConductor.Items.Add("--- Seleccione un conductor ---");
                DdlConductor.AppendDataBoundItems = true;
                DdlConductor.DataSource = listaUsuarios;
                DdlConductor.DataTextField = "Nombre";
                DdlConductor.DataValueField = "Nombre";
                DdlConductor.DataBind();
            }
        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            AutoNegocio negocio = new AutoNegocio();
            try
            {
                auto.IdAuto = Convert.ToInt32(Session[Session.SessionID + "IdModificar"]);
                auto.Patente = PatenteModificar.Text;
                auto.Modelo = ModeloModificar.Text;
                negocio.ModificarAuto(auto);
                Response.Redirect("listaAutos.aspx");
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
    }
}