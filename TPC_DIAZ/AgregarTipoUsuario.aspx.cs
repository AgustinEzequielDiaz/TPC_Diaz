using ClassLibrary1;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_DIAZ
{
    public partial class AgregarTipoUsuario : System.Web.UI.Page
    {
        public TipoUsuario tipoUsuario = new TipoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregarTipo_Click(object sender, EventArgs e)
        {
            TipoUsuarioNegocio negocio = new TipoUsuarioNegocio();
            try
            {
                tipoUsuario.Nombre = NombreTipoAgregar.Text;
                negocio.AgregarTipoUsuario(tipoUsuario);
                Response.Redirect("ListaTipoUsuario.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}