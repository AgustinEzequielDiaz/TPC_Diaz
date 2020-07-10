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
    public partial class ListaStockAuto : System.Web.UI.Page
    {
        //public Material material { get; set; }
        //List<Material> materiales = new List<Material>();
        //StockAuto stock = new StockAuto();
        //StockAutoNegocio negocio = new StockAutoNegocio();
        //AsignarNegocio negocioAsignar = new AsignarNegocio();
        //UsuarioNegocio negocioUsuario = new UsuarioNegocio();
        //Usuario user = new Usuario();
        //List<Asignacion> asignaciones = new List<Asignacion>();
        //List<Asignar> listaAsignar = new List<Asignar>();
        //Asignar asignar = new Asignar();


        List<Material> ListaNuevaMaterial = new List<Material>();

        StockAutoNegocio negocioStockAuto = new StockAutoNegocio();
        UsuarioNegocio negocioUsuario = new UsuarioNegocio();
        MaterialNegocio negocioMaterial = new MaterialNegocio();
        AsignarNegocio negocioAsignar = new AsignarNegocio();
        AutoNegocio negocioAuto = new AutoNegocio();
        Asignar asignar = new Asignar();
        Usuario usuario = new Usuario();
        Material material = new Material();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Auto> ListaAuto = new List<Auto>();
            List<Asignar> ListaAsignar = new List<Asignar>();
            List<StockAuto> listaStockAuto = new List<StockAuto>();
            List<StockAuto> listaNuevaStockAuto = new List<StockAuto>();
            List<Material> ListaNuevoMaterial = new List<Material>();
            List<Material> ListaMaterial = new List<Material>();
            List<Usuario> ListaUsuario = new List<Usuario>();
            Auto auto = new Auto();
            try
            {
                ListaAuto = negocioAuto.ListarAuto();
                Usuario usuario = new Usuario();
                Usuario aux = new Usuario();
                usuario = (Usuario)Session[Session.SessionID + "Usuario"];
                ListaUsuario = negocioUsuario.BuscarAuto();
                if(ListaUsuario.Find(k => k.IdUsuario == usuario.IdUsuario) == null)
                {
                    Response.Redirect("AgregarAuto.aspx");
                }
                aux = ListaUsuario.Find(k=>k.IdUsuario == usuario.IdUsuario);
                auto = ListaAuto.Find(k => k.IdAuto == aux.IdAuto);
                lblTitulo.Text = lblTitulo.Text + " " + auto.Modelo + " " +  "(" + auto.Patente + ")";
                listaStockAuto = negocioStockAuto.ListadoAsigxMat(auto.IdAuto);
                ListaAsignar = negocioAsignar.listarAsignacion();
                ListaMaterial = negocioMaterial.ListarMaterial();
                if (listaStockAuto != null)
                {
                    if (!IsPostBack)
                    {
                        foreach (var item in listaStockAuto)
                        {
                            StockAuto stockAuto = new StockAuto();
                            stockAuto = (StockAuto)listaStockAuto.Find(a => a.material.Id == item.material.Id);
                            ListaMaterial = negocioMaterial.ListarMaterial();
                            Material material = new Material();
                            material = (Material)ListaMaterial.Find(b => b.Id == stockAuto.material.Id);
                            material.Cantidad = stockAuto.Cantidad;
                            ListaNuevoMaterial.Add(material);
                            //nuevo = (Material)ListaMaterial.Find(k => k.Id == item.material.Id);
                            listaNuevaStockAuto.Add(stockAuto);
                            dgvStockAuto.DataSource = ListaNuevoMaterial;
                            dgvStockAuto.DataBind();
                            //}
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void dgvStockAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAuto.aspx");
        }

        protected void dgvStockAuto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //StockAuto stock = new StockAuto();

            //int index = Convert.ToInt32(e.CommandArgument);
            //string IDSeleccionado = dgvStockAuto.Rows[index].Cells[0].Text;
            //int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            //if (ASIG.material.Exists(A => A.Id == idSeleccionado))
            //{
            //    if (e.CommandName == "Eliminar")
            //    {
            //        //asignar.Cantidad--;
            //        //material.Cantidad--;
            //        ASIG.material.Remove(material);
            //        Session.Add(Session.SessionID + "material", ASIG.material);
            //        //Session.Add(Session.SessionID + "Cantidad", ASIG.Cantidad);
            //        Response.Redirect("AsignacionMateriales.aspx");
            //    }
            //}
        }
    }
}