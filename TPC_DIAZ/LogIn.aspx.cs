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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IngresarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            List<Usuario> lista = new List<Usuario>();
            lista = negocio.ListarUsuario();
            try
            {
                //usuario.Nombre = NombreUsuario.Text;
                //usuario.Clave = PassUsuario.Text;
                //usuario = negocio.login(usuario);
                if (lista != null)
                {
                    usuario = lista.Find(k => k.Nombre == NombreUsuario.Text && k.Clave == PassUsuario.Text);
                    if (usuario != null)
                    {
                        Session.Add(Session.SessionID + "Usuario", usuario);
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Response.Redirect("Registrar.aspx");
                    }
                }
                //if (usuario.IdUsuario != 0)
                //{
                //    Session.Add("UserSession", usuario);
                //    Response.Redirect("StockMateriales.aspx");
                //}
                //else
                //{
                //    Session["Error" + Session.SessionID] = "Usuario o pass incorrecta.";
                //    Response.Redirect("Error.aspx");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void Unnamed_Click(object sender, EventArgs e)
        //{
        //    UsuarioNegocio negocio = new UsuarioNegocio();
        //    Usuario nuevo = new Usuario();
        //    List<Usuario> lista = new List<Usuario>();
        //    lista = negocio.listarUsuario();
        //    if (lista != null)
        //    {
        //        nuevo = lista.Find(k => k.Email == TxtEmail.Text && k.Contraseña == TxtContraseña.Text);
        //        if (nuevo != null)
        //        {
        //            Session.Add(Session.SessionID + "Usuario", nuevo);
        //            Response.Redirect("ListadoPrincipal.aspx");
        //        }
        //        else
        //        {
        //            Response.Redirect("AltaUsuario.aspx");
        //        }
        //    }
        //}

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
            //Response.Redirect("LogIn.aspx");
        }
    }
}