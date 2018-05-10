using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Integra_Develoment;
using System.Data;
using IntegraBussines;

namespace Integra_Develomentt
{
    public partial class Ventas : System.Web.UI.Page
    {
        #region variables
        IntegraBussines.ProductosBLL ProdBLL = new ProductosBLL();
        static DataTable dtPartidas = new DataTable();
        static DataTable dtProductos = new DataTable();
        static DataTable dtClientesFisicos = new DataTable();
        static DataTable dtClientesMorales = new DataTable();
        static int iNumero_Columnas_Fisicas, iNumero_Columnas_Morales;
        #endregion
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                dtPartidas.Clear();
                dtProductos.Clear();
                dtClientesFisicos.Clear();
                dtClientesMorales.Clear();
                keycontainer.Value = "-1";
                txtBusquedaCliente_TextChanged(null, null);
                LlenarGridPartidas();
                LlenarGridClientes();
                LlenarGridProductos();
                SetFocus(txtBusquedaCliente);
            }
        }
        protected void txtBusquedaCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (keycontainer.Value != "")
                {
                    DataTable dt = ClientesBLL.ObtenerDatosCliente(Convert.ToInt32(Session["Company"]), Convert.ToInt32(keycontainer.Value));
                    if (dt.Rows.Count > 0)
                    {
                        lblNombreCliente.Text = dt.Rows[0]["Nombre"].ToString();
                        lblRFC.Text = dt.Rows[0]["RFC"].ToString();
                        lblDomicilio.Text = dt.Rows[0]["Domicilio"].ToString();
                        lblColonia.Text = dt.Rows[0]["Colonia"].ToString();
                        lblCodigoPostal.Text = dt.Rows[0]["Codigo_Postal"].ToString();
                        lblDelegacion.Text = dt.Rows[0]["Delegacion_Municipio"].ToString();
                        lblEstado.Text = dt.Rows[0]["Estado"].ToString();
                        lblTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                        hdnListaPrecio.Value = dt.Rows[0]["Lista_Precio"].ToString();
                        txtBusquedaCliente.Text = "";
                    }
                }
                else {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Ocurrió un error al obtener el cliente.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void txtBusquedaProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hdnProducto.Value != "")
                {
                    if (hdnListaPrecio.Value != "") {
                        txtBusquedaProducto.Text = "";
                        LabelTool.ShowSingleLabel(lblMsgMdlError, "Bien!", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
                    }
                    else
                    {
                        LabelTool.ShowSingleLabel(lblMsgMdlError, "El cliente no cuenta con una lista de precios. No se pueden agregar productos.", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
                    }
                }
                else {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Ocurrió un error al obtener el producto.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void lnkEliminarPartida_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnk.NamingContainer;
                dtPartidas.Rows.RemoveAt(row.RowIndex);
                GridViewTool.Bind(dtPartidas, grvPartidas);
                Label lblContadorPartidas = (Label)grvPartidas.HeaderRow.FindControl("lblContadorPartidas");
                lblContadorPartidas.Text = grvPartidas.Rows.Count.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso'); ToolTip();", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);

            }

        }
        protected void grvClientesFisicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < iNumero_Columnas_Fisicas; i++)
                {
                    e.Row.Cells[i].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    e.Row.Cells[i].Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    e.Row.Cells[i].Attributes["data-dismiss"] = "modal";
                    e.Row.Cells[i].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grvClientesFisicos, "Select$" + e.Row.RowIndex);
                    e.Row.Cells[i].ToolTip = "Seleccionar cliente";
                }
            }
        }
        protected void grvClientesMorales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < iNumero_Columnas_Morales; i++)
                {
                    e.Row.Cells[i].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    e.Row.Cells[i].Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    e.Row.Cells[i].Attributes["data-dismiss"] = "modal";
                    e.Row.Cells[i].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grvClientesMorales, "Select$" + e.Row.RowIndex);
                    e.Row.Cells[i].ToolTip = "Seleccionar cliente";
                }
            }
        }
        protected void grvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                //e.Row.Cells[2].Attributes["onmouseout"] = "this.style.textDecoration='none';";
                //e.Row.Cells[2].Attributes["data-dismiss"] = "modal";
                //e.Row.Cells[2].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grvProductos, "Select$" + e.Row.RowIndex, false);
                //e.Row.Cells[2].Attributes["onclick"] = ClientScript.GetPostBackEventReference(this.grvProductos, "Select$" + e.Row.RowIndex, false);
                e.Row.Cells[2].ToolTip = "Seleccionar producto";
            }
        }
        protected void grvClientesFisicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvClientesFisicos.SelectedRow;
                int iNumero_Cliente = Convert.ToInt32(grvClientesFisicos.DataKeys[row.RowIndex].Values["Numero"]);
                keycontainer.Value = iNumero_Cliente.ToString();
                txtBusquedaCliente_TextChanged(null, null);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "ToolTip();", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        protected void grvClientesMorales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvClientesMorales.SelectedRow;
                int iNumero_Cliente = Convert.ToInt32(grvClientesMorales.DataKeys[row.RowIndex].Values["Numero"]);
                keycontainer.Value = iNumero_Cliente.ToString();
                txtBusquedaCliente_TextChanged(null, null);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "ToolTip();", true);
                
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        //protected void grvProductos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GridViewRow row = grvProductos.SelectedRow;
        //        CheckBox chk = (CheckBox)row.FindControl("chkIndividual");
        //        if (chk != null)
        //            if (chk.Checked)
        //                chk.Checked = false;
        //            else
        //                chk.Checked = true;
        //        //GridViewRow row = grvClientesMorales.SelectedRow;
        //        //int iNumero_Cliente = Convert.ToInt32(grvClientesMorales.DataKeys[row.RowIndex].Values["Numero"]);
        //        //keycontainer.Value = iNumero_Cliente.ToString();
        //        //txtBusquedaCliente_TextChanged(null, null);
        //        //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "ToolTip();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
        //    }
        //}
        #endregion
        #region Métodos / Propiedades
        private void LlenarGridPartidas() {
            dtPartidas = CrearTablaPartidas();
            for (int i = 1; i <= 30; i++)
            {
                DataRow dr = dtPartidas.NewRow();
                dr["Numero_Producto"] = Convert.ToInt32(i);
                dr["Existencia"] = Convert.ToDecimal(i);
                dr["Producto"] = "Prueba " + i.ToString();
                dr["Cantidad"] = Convert.ToDecimal(i);
                dr["Precio"] = Convert.ToDecimal(i);
                dr["Total"] = Convert.ToDecimal(i * 1000000);
                dtPartidas.Rows.Add(dr);
            }
            GridViewTool.Bind(dtPartidas, grvPartidas);
            Label lblContadorPartidas = (Label)grvPartidas.HeaderRow.FindControl("lblContadorPartidas");
            lblContadorPartidas.Text = grvPartidas.Rows.Count.ToString();
        }
        private DataTable CrearTablaPartidas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero_Producto", typeof(int));
            dt.Columns.Add("Existencia", typeof(decimal));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Cantidad", typeof(decimal));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            return dt;
        }
        private void LlenarGridClientes() {
            try
            {
                dtClientesFisicos = ClientesBLL.ObtenerClientesPorPersonalidad(Convert.ToInt32(Session["Company"]), 1);
                dtClientesMorales = ClientesBLL.ObtenerClientesPorPersonalidad(Convert.ToInt32(Session["Company"]), 0);
                if (dtClientesFisicos.Rows.Count > 0)
                {
                    iNumero_Columnas_Fisicas = dtClientesFisicos.Columns.Count;
                    GridViewTool.Bind(dtClientesFisicos, grvClientesFisicos);
                }
                else
                {
                    LabelTool.ShowLabel(divAlertFisicas, spnDivAlertFisicas, lblDivAlertFisicas, "No hay clientes con personalidad fisica", 'i');
                }
                if (dtClientesMorales.Rows.Count > 0)
                {
                    iNumero_Columnas_Morales = dtClientesMorales.Columns.Count;
                    GridViewTool.Bind(dtClientesMorales, grvClientesMorales);
                }
                else
                {
                    LabelTool.ShowLabel(divAlertMorales, spnDivAlertMorales, lblDivAlertMorales, "No hay clientes con personalidad moral", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        private void LlenarGridProductos()
        {
            try
            {
                dtProductos = ProdBLL.ObtenerProductos(Convert.ToInt32(Session["Company"]));
                if (dtProductos.Rows.Count > 0)
                {
                    GridViewTool.Bind(dtProductos, grvProductos);
                }
                else
                {
                    LabelTool.ShowLabel(divAlertProductos, splAlertProductos, lblAlertProductos, "No tienes productos disponibles", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        #endregion
    }
}