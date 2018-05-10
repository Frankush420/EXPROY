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
    public partial class Almacen : System.Web.UI.Page
    {
        #region variables
        static DataTable dtProductosAlmacen = new DataTable();
        static DataTable dtExistenciaAlmacen = new DataTable();
        static DataTable dtMovimientosAlmacen = new DataTable();

        #endregion
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                dtProductosAlmacen.Clear();
                dtExistenciaAlmacen.Clear();
                dtMovimientosAlmacen.Clear();
                LlenarGridProductosAlmacen();
                LlenarGridExistenciaAlmacen();
                LlenarGridMovimientosAlmacen();
            }
        }
        protected void lnkGuardarGrv_Click(object sender, EventArgs e)
        {
            try {
                LinkButton lnk = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnk.NamingContainer;
                LinkButton lnkGuardar = (LinkButton)row.FindControl("lnkGuardarGrv");
                TextBox txtCantidad = (TextBox)grvProductosAlmacen.Rows[row.RowIndex].FindControl("txtCantidadGrv");
                if(txtCantidad.Text != ""){
                    DropDownList drpAlmacen = (DropDownList)grvProductosAlmacen.Rows[row.RowIndex].FindControl("drpAlmacenGrv");
                    DropDownList drpMovimiento = (DropDownList)grvProductosAlmacen.Rows[row.RowIndex].FindControl("drpMovimientoGrv");
                    DataTable dtMovimientos = CreaTablaMovimientos();
                    DataRow dr = dtMovimientos.NewRow();
                    dr["Numero"] = grvProductosAlmacen.DataKeys[row.RowIndex].Values["Numero"].ToString();
                    dr["Nombre"] = grvProductosAlmacen.DataKeys[row.RowIndex].Values["Nombre"].ToString();
                    dr["Clas_Almacen"] = drpAlmacen.SelectedValue;
                    dr["Almacen"] = drpAlmacen.SelectedItem;
                    dr["Clas_Movimiento"] = drpMovimiento.SelectedValue;
                    dr["Movimiento"] = drpMovimiento.SelectedItem;
                    dr["Cantidad"] = Convert.ToDecimal(txtCantidad.Text);
                    dtMovimientos.Rows.Add(dr);
                    GridViewTool.Bind(null, grvMdl);
                    GridViewTool.Bind(dtMovimientos, grvMdl);
                    LabelTool.ShowSingleLabel(lblMdlAgregarRegistros, "Se guardará el siguiente registro, ¿Desea continuar?", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlAgregarRegistros'); ToolTip();", true);
                }
                else{
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Ingrese una cantidad.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        protected void lnkGuardarTodosGrv_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMovimientos = CreaTablaMovimientos();
                foreach (GridViewRow row in grvProductosAlmacen.Rows)
                {
                    TextBox txtCantidad = (TextBox)grvProductosAlmacen.Rows[row.RowIndex].FindControl("txtCantidadGrv");
                    if (txtCantidad.Text != "")
                    {
                        DropDownList drpAlmacen = (DropDownList)grvProductosAlmacen.Rows[row.RowIndex].FindControl("drpAlmacenGrv");
                        DropDownList drpMovimiento = (DropDownList)grvProductosAlmacen.Rows[row.RowIndex].FindControl("drpMovimientoGrv");
                        DataRow dr = dtMovimientos.NewRow();
                        dr["Numero"] = grvProductosAlmacen.DataKeys[row.RowIndex].Values["Numero"].ToString();
                        dr["Nombre"] = grvProductosAlmacen.DataKeys[row.RowIndex].Values["Nombre"].ToString();
                        dr["Clas_Almacen"] = drpAlmacen.SelectedValue;
                        dr["Almacen"] = drpAlmacen.SelectedItem;
                        dr["Clas_Movimiento"] = drpMovimiento.SelectedValue;
                        dr["Movimiento"] = drpMovimiento.SelectedItem;
                        dr["Cantidad"] = Convert.ToDecimal(txtCantidad.Text);
                        dtMovimientos.Rows.Add(dr);
                    }
                }
                if (dtMovimientos.Rows.Count > 0)
                {
                    GridViewTool.Bind(null, grvMdl);
                    GridViewTool.Bind(dtMovimientos, grvMdl);
                    LabelTool.ShowSingleLabel(lblMdlAgregarRegistros, "Se guardarán los siguientes registros, ¿Desea continuar?", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlAgregarRegistros'); ToolTip();", true);
                }
                else {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "No se han registrado movimientos, revise las cantidades.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);
            }
        }
        protected void lnkMdlAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grvMdl.Rows)
                {
                    int iNumero, iClas_Almacen, iClas_Movimiento;
                    decimal dCantidad;
                    string sMovimieto = "";
                    iNumero = Convert.ToInt32(grvMdl.DataKeys[row.RowIndex].Values["Numero"]);
                    iClas_Almacen = Convert.ToInt32(grvMdl.DataKeys[row.RowIndex].Values["Clas_Almacen"]);
                    iClas_Movimiento = Convert.ToInt32(grvMdl.DataKeys[row.RowIndex].Values["Clas_Movimiento"]);
                    sMovimieto = grvMdl.DataKeys[row.RowIndex].Values["Movimiento"].ToString();
                    dCantidad = Convert.ToDecimal(grvMdl.DataKeys[row.RowIndex].Values["Cantidad"]);
                    AlmacenBLL.AlmacenMovimientos(Convert.ToInt32(Session["Company"]), iNumero, iClas_Almacen, iClas_Movimiento, sMovimieto, dCantidad);
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso'); reload();", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);
            }
        }
        protected void drpAlmacenInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtExistenciaAlmacen = AlmacenBLL.ObtenerExistenciaAlmacen(Convert.ToInt32(Session["Company"]), Convert.ToInt32(drpAlmacenInventario.SelectedValue));
                if (dtExistenciaAlmacen.Rows.Count > 0)
                {
                    GridViewTool.Bind(dtExistenciaAlmacen, grvExistenciaAlmacen);
                }
                else
                {
                    GridViewTool.Bind(null, grvExistenciaAlmacen);
                    LabelTool.ShowLabel(divAlert2, spnAlert2, lblAlert2, "Sin inventario disponible para '"+Convert.ToString(drpAlmacenInventario.SelectedItem)+"'", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        
        protected void drpAlmacenMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtMovimientosAlmacen = AlmacenBLL.ObtenerRegistroMovimientos(Convert.ToInt32(Session["Company"]), Convert.ToInt32(drpAlmacenMovimientos.SelectedValue));
                if (dtMovimientosAlmacen.Rows.Count > 0)
                {
                    GridViewTool.Bind(dtMovimientosAlmacen, grvMovimientosAlmacen);
                }
                else
                {
                    GridViewTool.Bind(null, grvMovimientosAlmacen);
                    LabelTool.ShowLabel(divAlert3, spnAlert3, lblAlert3, "No se han registado movimientos para '" + Convert.ToString(drpAlmacenInventario.SelectedItem) + "'", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        protected void drpAlmacenGrvTodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grvProductosAlmacen.Rows) {
                    DropDownList drpAlmacenGrvTodos = (DropDownList)grvProductosAlmacen.HeaderRow.FindControl("drpAlmacenGrvTodos");
                    int i = drpAlmacenGrvTodos.SelectedIndex;
                    DropDownList drpAlmacen = (DropDownList)row.FindControl("drpAlmacenGrv");
                    drpAlmacen.SelectedIndex = i;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso'); ToolTip();", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);
            }
        }
        protected void drpMovimientoGrvTodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grvProductosAlmacen.Rows)
                {
                    DropDownList drpMovimientoGrvTodos = (DropDownList)grvProductosAlmacen.HeaderRow.FindControl("drpMovimientoGrvTodos");
                    int i = drpMovimientoGrvTodos.SelectedIndex;
                    DropDownList drpMovimiento = (DropDownList)row.FindControl("drpMovimientoGrv");
                    drpMovimiento.SelectedIndex = i;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso'); ToolTip();", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);
            }
        }
        protected void txtCantidadGrvTodos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtCantidadGrvTodos = (TextBox)grvProductosAlmacen.HeaderRow.FindControl("txtCantidadGrvTodos");
                foreach (GridViewRow row in grvProductosAlmacen.Rows)
                {
                    TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadGrv");
                    txtCantidad.Text = txtCantidadGrvTodos.Text;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso'); ToolTip();", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError'); ToolTip();", true);
            }
        }
        #endregion
        #region Métodos / Propiedades
        private void LlenarGridProductosAlmacen() {
            try {
                dtProductosAlmacen = AlmacenBLL.ObtenerProductosDisponibles(Convert.ToInt32(Session["Company"]));
                if (dtProductosAlmacen.Rows.Count > 0)
                {
                    DataTable dtAlmacenes = AlmacenBLL.ObtenerAlmacenes(Convert.ToInt32(Session["Company"]));
                    if (dtAlmacenes.Rows.Count > 0)
                    {
                        DataTable dtMovimientos = AlmacenBLL.ObtenerMovimientosAlmacen(Convert.ToInt32(Session["Company"]));
                        if (dtMovimientos.Rows.Count > 0)
                        {
                            GridViewTool.Bind(dtProductosAlmacen, grvProductosAlmacen);

                            foreach (GridViewRow row in grvProductosAlmacen.Rows)
                            {
                                DropDownList drpAlmacen = (DropDownList)row.FindControl("drpAlmacenGrv");
                                DropTool.FillDrop(drpAlmacen, dtAlmacenes, "Descripcion", "Numero");
                                DropDownList drpMovimientos = (DropDownList)row.FindControl("drpMovimientoGrv");
                                DropTool.FillDrop(drpMovimientos, dtMovimientos, "Descripcion", "Numero");
                            }
                            DropDownList drpAlmacenGrvTodos = (DropDownList)grvProductosAlmacen.HeaderRow.FindControl("drpAlmacenGrvTodos");
                            DropDownList drpMovimientoGrvTodos = (DropDownList)grvProductosAlmacen.HeaderRow.FindControl("drpMovimientoGrvTodos");
                            DropTool.FillDrop(drpAlmacenGrvTodos, dtAlmacenes, "Descripcion", "Numero");
                            DropTool.FillDrop(drpMovimientoGrvTodos, dtMovimientos, "Descripcion", "Numero");
                        }
                        else {
                            LabelTool.ShowSingleLabel(lblMsgMdlError, "Sin movimientos disponibles para el almacen", System.Drawing.Color.Black);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
                        }
                    }
                    else {
                        LabelTool.ShowSingleLabel(lblMsgMdlError, "No tienes almacenes disponibles", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
                    }
                }
                else {
                    LabelTool.ShowLabel(divMsj, spnMsj, lblMsj, "No tienes productos disponibles", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        private DataTable CreaTablaMovimientos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Clas_Almacen", typeof(int));
            dt.Columns.Add("Almacen", typeof(string));
            dt.Columns.Add("Clas_Movimiento", typeof(int));
            dt.Columns.Add("Movimiento", typeof(string));
            dt.Columns.Add("Cantidad", typeof(decimal));;
            return dt;
        }

        private void LlenarGridMovimientosAlmacen()
        {
            try
            {
                DataTable dtAlmacenes = AlmacenBLL.ObtenerAlmacenes(Convert.ToInt32(Session["Company"]));
                if (dtAlmacenes.Rows.Count > 0)
                {
                    if (dtAlmacenes.Rows.Count > 1)
                        DropTool.CompleteDrop(dtAlmacenes, 0, "-- TODOS LOS ALMACENES --");
                    DropTool.FillDrop(drpAlmacenMovimientos, dtAlmacenes, "Descripcion", "Numero");
                    dtMovimientosAlmacen = AlmacenBLL.ObtenerRegistroMovimientos(Convert.ToInt32(Session["Company"]), Convert.ToInt32(drpAlmacenMovimientos.SelectedValue));
                    if (dtMovimientosAlmacen.Rows.Count > 0)
                    {
                        GridViewTool.Bind(dtMovimientosAlmacen, grvMovimientosAlmacen);
                    }
                    else
                    {
                        LabelTool.ShowLabel( divAlert3, spnAlert3, lblAlert3, "No se han registado movimientos.", 'i');
                    }
                }
                else
                {
                    LabelTool.ShowLabel(divAlert2, spnAlert2, lblAlert2, "No tienes almacenes relacionados", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        private void LlenarGridExistenciaAlmacen()
        {
            try
            {
                DataTable dtAlmacenes = AlmacenBLL.ObtenerAlmacenes(Convert.ToInt32(Session["Company"]));
                if (dtAlmacenes.Rows.Count > 0)
                {
                    if (dtAlmacenes.Rows.Count > 1)
                        DropTool.CompleteDrop(dtAlmacenes, 0, "-- TODOS LOS ALMACENES --");
                    DropTool.FillDrop(drpAlmacenInventario, dtAlmacenes, "Descripcion", "Numero");
                    dtExistenciaAlmacen = AlmacenBLL.ObtenerExistenciaAlmacen(Convert.ToInt32(Session["Company"]), Convert.ToInt32(drpAlmacenInventario.SelectedValue));
                    if (dtExistenciaAlmacen.Rows.Count > 0)
                    {
                        GridViewTool.Bind(dtExistenciaAlmacen, grvExistenciaAlmacen);
                    }
                    else
                    {
                        LabelTool.ShowLabel(divAlert2, spnAlert2, lblAlert2, "Sin inventario disponible", 'i');
                    }
                }
                else {
                    LabelTool.ShowLabel(divAlert2, spnAlert2, lblAlert2, "No tienes almacenes relacionados", 'i');
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError'); ToolTip();", true);
            }
        }
        #endregion
    }
}