using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;
using Dominio;
using Negocio;

namespace TPC_DIAZ
{
    public partial class AsignacionMateriales : System.Web.UI.Page
    {
        public List<Auto> listaAutos { get; set; }
        public Material material { get; set; }
        AsignarNegocio negocioAsignar = new AsignarNegocio();
        AutoNegocio negocioAuto = new AutoNegocio();
        Asignar asignar = new Asignar();
        List<Asignar> ListaAsignar = new List<Asignar>();
        //List<Material> materiales = new List<Material>();
        MATxASIG ASIG = new MATxASIG();
        Auto auto = new Auto();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[Session.SessionID + "material"] != null)
                {
                    ASIG.material = (List<Material>)Session[Session.SessionID + "material"];
                    dgvAsignacion.DataSource = ASIG.material;
                    dgvAsignacion.DataBind();

                    listaAutos = negocioAuto.ListarAuto();
                    dgvConductor.DataSource = listaAutos;
                    dgvConductor.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void dgvAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvAsignacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    int idMaterial = Convert.ToInt32(dgvAsignacion.Rows[index].Cells[0].Text);
            //    material = asignar.material.Find(J => J.Id == idMaterial);
            //    asignar.material.Remove(material);
            //    Response.Redirect("AsignacionMateriales.aspx");
            //}
            MaterialNegocio negocioMaterial = new MaterialNegocio();
            StockAuto stock = new StockAuto();
            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvAsignacion.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            if (ASIG.material.Exists(A => A.Id == idSeleccionado))
            {
                if (e.CommandName == "Eliminar")
                {
                    //asignar.Cantidad--;
                    //material.Cantidad--;
                    ASIG.material.Remove(material);
                    Session.Add(Session.SessionID + "material", ASIG.material);
                    //Session.Add(Session.SessionID + "Cantidad", ASIG.Cantidad);
                    Response.Redirect("AsignacionMateriales.aspx");
                }
                if (e.CommandName == "Restar")
                {
                    material = ASIG.material.Find(J => J.Id == idSeleccionado);
                    if (material.Cantidad > 1)
                    {
                        material.Stock++;
                        material.Cantidad--;
                        negocioMaterial.ModificarMaterial(material);
                        Session.Add(Session.SessionID + "material", ASIG.material);
                    }
                    //Session.Add(Session.SessionID + "Cantidad", asignar.Cantidad);
                    Response.Redirect("AsignacionMateriales.aspx");

                }
                if (e.CommandName == "Agregar")
                {
                    material = ASIG.material.Find(J => J.Id == idSeleccionado);
                    { 
                        if(material.Stock > 1)
                        material.Stock--;
                        material.Cantidad++;
                        negocioMaterial.ModificarMaterial(material);
                        Session.Add(Session.SessionID + "material", ASIG.material);
                    }
                    //Session.Add(Session.SessionID + "Cantidad", asignar.Cantidad);
                    Response.Redirect("AsignacionMateriales.aspx");



                }
            }
        }

        protected void dgvConductor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvConductor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<StockAuto> lista = new List<StockAuto>();
            StockAutoNegocio stockAutoNegocio = new StockAutoNegocio();
            if (e.CommandName == "AsignarStock")
            {
                //Usuario usua = (Usuario)Session[Session.SessionID + "Usuario"];
                //if (usua == null)
                //{
                //    Response.Redirect("Altausuario.aspx");
                //}
                //if (usua.idDomicilio.Partido == "")
                //{
                //    Response.Redirect("domicilio.aspx");
                //}
                //else
                //{
                StockAuto aux = new StockAuto();
                StockAuto nueva = new StockAuto();
                StockAutoNegocio negocio = new StockAutoNegocio();
                AsignarNegocio asignarNegocio = new AsignarNegocio();
                Asignar asignar = new Asignar();
                MATxASIG ASIG = new MATxASIG();
                int bandera = 0;
                int index = Convert.ToInt32(e.CommandArgument);
                string IDSeleccionado = dgvConductor.Rows[index].Cells[0].Text;
                int idSeleccionado = Convert.ToInt32(IDSeleccionado);
                ASIG.material = (List<Material>)Session[Session.SessionID + "material"];
                foreach (var item in ASIG.material)
                {
                    //nueva.IdAuto = 1;
                    //asignar.fechaAsignacion = Convert.ToDateTime(Session[Session.SessionID + "FechaAsignacion"])
                    asignar.fechaAsignacion = DateTime.Now.Date;
                    asignar.IdUsuario = (Usuario)(Session[Session.SessionID + "Usuario"]);
                    //asignar.Cantidad = Convert.ToInt32(Session[Session.SessionID + "Cantidad"]);
                    if (bandera == 0)
                    {
                        asignarNegocio.AgregarAsignacion(asignar);
                        bandera++;
                    }
                    ListaAsignar = asignarNegocio.listarAsignacion();
                    asignar = ListaAsignar[ListaAsignar.Count - 1];

                    nueva.IdAsignar.IdAsignar = asignar.IdAsignar;
                    nueva.IdAuto.IdAuto = idSeleccionado;

                    //nueva.material.Cantidad = item.Cantidad;
                    nueva.material = item;
                    stockAutoNegocio.AgregarMaterialAuto(nueva);
                    lista = stockAutoNegocio.ListadoStock();
                    nueva = lista[lista.Count - 1];
                    nueva.IdAsignar.IdAsignar = asignar.IdAsignar;
                    stockAutoNegocio.AgregarAsignacionAuto(nueva);

                }

                Response.Redirect("ListaStockAuto.aspx");
                //}

            }
        }

        protected void dgvAsignacion_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

        }

        //protected void Unnamed_Click(object sender, EventArgs e)
        //{

        //    Usuario usua = (Usuario)Session[Session.SessionID + "Usuario"];
        //    if (usua == null)
        //    {
        //        Response.Redirect("Altausuario.aspx");
        //    }
        //    if (usua.idDomicilio.Partido == "")
        //    {
        //        Response.Redirect("domicilio.aspx");
        //    }
        //    else
        //    {
        //        venta aux = new venta();
        //        venta nueva = new venta();
        //        int bandera = 0;
        //        carro = (Carrito)Session[Session.SessionID + "articulo"];
        //        foreach (var item in carro.producto)
        //        {
        //            nueva.fechaventa = DateTime.Now.Date;
        //            nueva.producto = item;
        //            nueva.Total = Convert.ToDecimal(Session[Session.SessionID + "Total"]);
        //            nueva.Cantidad = Convert.ToInt32(Session[Session.SessionID + "Cantidad"]);
        //            if (bandera == 0)
        //            {
        //                negocio1.AgregarVenta(nueva);
        //                bandera++;
        //            }
        //            lista = negocio1.listarTipo();
        //            aux = lista[lista.Count - 1];
        //            nueva.Id = aux.Id;
        //            negocio1.AgregarVentaxProducto(nueva);
        //        }
        //        Response.Redirect("ListadoPrincipal.aspx");
        //    }
        //}
    }
}
