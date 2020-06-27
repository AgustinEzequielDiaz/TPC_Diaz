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
        public List<Persona> lista { get; set; }
        public Persona persona = new Persona();
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonaNegocio negocio = new PersonaNegocio();
            try
            {
                if (!IsPostBack)
                {
                    lista = negocio.ListarPersona();
                    dgvPersona.DataSource = lista;
                    dgvPersona.DataBind();
                    //repetidor.DataSource = lista;
                    //repetidor.DataBind();

                }
            }
            catch (Exception)
            {


            }
        }

        protected void dgvPersona_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ButtonPersona_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPersona.aspx");
        }

        //protected void dgvPersona_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    int index = Convert.ToInt32(e.CommandArgument);
        //    string IDSeleccionado = dgvPersona.Rows[index].Cells[0].Text;
        //    int idSeleccionado = Convert.ToInt32(IDSeleccionado);
        //    //if (carro.producto.Exists(A => A.id == idSeleccionado))
        //    //{
        //        //persona = carro.producto.Find(J => J.id == idSeleccionado);
        //        //carro.cantidad--;
        //        //carro.Total -= Articulo.Precio;
        //        //carro.producto.Remove(Articulo);
        //        Session.Add(Session.SessionID + "persona", persona);
        //        Session.Add(Session.SessionID + "Nombre", persona.Nombre);
        //        Session.Add(Session.SessionID + "Apellido", persona.Apellido);
        //        //Response.Redirect("Carrodecompras.aspx");

        //    //}
        //}
    }
}
