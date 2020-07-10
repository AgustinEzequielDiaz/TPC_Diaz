using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_DIAZ
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "Usuario"];
            if (usuario == null)
            {
                BtnCerrarSesion.Visible = false;
                btnInicio.Visible = true;
                btnDeposito.Visible = false;
                btnVehiculo.Visible = false;
                btnRegistros.Visible = false;
                btnRegistrar.Visible = false;
                btnAsignar.Visible = false;
                btnStockAuto.Visible = false;
                btnUsuarios.Visible = false;
                if (HttpContext.Current.Request.Url.AbsolutePath != "/LogIn")
                {
                    Response.Redirect("LogIn.aspx");
                }
            }
            else if(!IsPostBack)
            {
                if (usuario.Permiso == 1)
                {
                    BtnCerrarSesion.Visible = true;
                    btnInicio.Visible = true;
                    btnDeposito.Visible = true;
                    btnVehiculo.Visible = true;
                    btnRegistros.Visible = true;
                    btnRegistrar.Visible = true;
                    btnAsignar.Visible = true;
                    btnStockAuto.Visible = true;
                    btnUsuarios.Visible = true;
                }
                else if (usuario.Permiso == 2)
                {
                    BtnCerrarSesion.Visible = true;
                    btnInicio.Visible = true;
                    btnDeposito.Visible = true;
                    btnRegistros.Visible = true;
                    btnAsignar.Visible = true;
                    btnStockAuto.Visible = true;
                }
                else if (usuario.Permiso == 3)
                {
                    BtnCerrarSesion.Visible = true;
                    btnInicio.Visible = true;
                    btnDeposito.Visible = true;
                    btnAsignar.Visible = true;
                    btnStockAuto.Visible = true;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LogIn.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnDeposito_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockMateriales.aspx");
        }

        protected void btnVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("listaautos.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrar.aspx");
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionMateriales.aspx");
        }

        protected void btnStockAuto_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaStockAuto.aspx");
        }

        protected void btnRegistros_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registros.aspx");
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarUsuarios.aspx");
        }
    }
}