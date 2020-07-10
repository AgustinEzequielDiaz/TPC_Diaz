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
    public partial class Registros : System.Web.UI.Page
    {
        List<StockAuto> ListaStockAuto = new List<StockAuto>();
        StockAutoNegocio negocio = new StockAutoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ListaStockAuto = negocio.ListarRegistros();
                    dgvRegistros.DataSource = ListaStockAuto;
                    dgvRegistros.DataBind();
                    dgvRegistros.RowStyle.CssClass = "font-weight-bold";
                    if (ListaStockAuto.Count > 0)
                    {
                        dgvRegistros.HeaderRow.CssClass = "bg-primary";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //protected void dgvRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //dgvRegistros.DataSource = ListaStockAuto;
        //    dgvRegistros.PageIndex = e.NewPageIndex;
        //    dgvRegistros.DataBind();
        //}
        //AllowPaging="True" PageSize="5"
    }
}