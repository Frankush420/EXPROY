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
    public partial class Precios : System.Web.UI.Page
    {
        #region Variables
        #endregion
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    LlenarDropListaPrecios();
                    LlenarGridProductosLista();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        protected void txtPorcentajeGrv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox sndr = sender as TextBox;
                string name = Convert.ToString(sndr.ClientID);
                string[] id = name.Split('_');
                if (id[2].Equals("txtPorcentajeGrv"))
                {
                    TextBox txt = (TextBox)sender;
                    GridViewRow row = (GridViewRow)txt.NamingContainer;
                    TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                    if (txtPorcentaje.Text != "")
                    {
                        decimal precio = Convert.ToDecimal(grvProductosLista.DataKeys[row.RowIndex].Values["Precio"].ToString());
                        decimal porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                        decimal utilidad = (precio * porcentaje) / 100;
                        decimal preciofinal = precio + utilidad;
                        TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                        txtPrecioFinal.Text = preciofinal.ToString("f4");
                        row.Cells[5].Text = utilidad.ToString("f4");
                    }
                    else
                    {
                        TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                        txtPrecioFinal.Text = "";
                        row.Cells[5].Text = "";
                    }
                }
                else if (id[2].Equals("txtPorcentajeGrv2")) {
                    TextBox txt = (TextBox)sender;
                    GridViewRow row = (GridViewRow)txt.NamingContainer;
                    TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                    if (txtPorcentaje.Text != "")
                    {
                        decimal precio = Convert.ToDecimal(grvListas.DataKeys[row.RowIndex].Values["Precio"].ToString());
                        decimal porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                        decimal utilidad = (precio * porcentaje) / 100;
                        decimal preciofinal = precio + utilidad;
                        TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                        txtPrecioFinal.Text = preciofinal.ToString("f4");
                        row.Cells[5].Text = utilidad.ToString("f4");
                    }
                    else
                    {
                        TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                        txtPrecioFinal.Text = "";
                        row.Cells[5].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void txtPrecioFinalGrv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox sndr = sender as TextBox;
                string name = Convert.ToString(sndr.ClientID);
                string[] id = name.Split('_');
                if (id[2].Equals("txtPrecioFinalGrv"))
                {
                    TextBox txt = (TextBox)sender;
                    GridViewRow row = (GridViewRow)txt.NamingContainer;
                    TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                    if (txtPrecioFinal.Text != "")
                    {
                        decimal precio = Convert.ToDecimal(grvProductosLista.DataKeys[row.RowIndex].Values["Precio"].ToString());
                        decimal preciofinal = Convert.ToDecimal(txtPrecioFinal.Text);
                        decimal utilidad = preciofinal - precio;
                        decimal porcentaje = (utilidad * 100) / precio;
                        TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                        txtPorcentaje.Text = porcentaje.ToString("f4");
                        row.Cells[5].Text = utilidad.ToString("f4");
                    }
                    else
                    {
                        TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                        txtPorcentaje.Text = "";
                        row.Cells[5].Text = "";
                    }
                }
                else if (id[2].Equals("txtPrecioFinalGrv2")) {
                    TextBox txt = (TextBox)sender;
                    GridViewRow row = (GridViewRow)txt.NamingContainer;
                    TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                    if (txtPrecioFinal.Text != "")
                    {
                        decimal precio = Convert.ToDecimal(grvListas.DataKeys[row.RowIndex].Values["Precio"].ToString());
                        decimal preciofinal = Convert.ToDecimal(txtPrecioFinal.Text);
                        decimal utilidad = preciofinal - precio;
                        decimal porcentaje = (utilidad * 100) / precio;
                        TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                        txtPorcentaje.Text = porcentaje.ToString("f4");
                        row.Cells[5].Text = utilidad.ToString("f4");
                    }
                    else
                    {
                        TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                        txtPorcentaje.Text = "";
                        row.Cells[5].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void txtPorcentajeGrvTodos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                string name = Convert.ToString(txt.ClientID);
                string[] id = name.Split('_');
                if (id[2].Equals("txtPorcentajeGrvTodos"))
                {
                    TextBox txtPrecioFinalGrvTodos = (TextBox)grvProductosLista.HeaderRow.FindControl("txtPrecioFinalGrvTodos");
                    TextBox txtPorcentajeGrvTodos = (TextBox)grvProductosLista.HeaderRow.FindControl("txtPorcentajeGrvTodos");
                    foreach (GridViewRow row in grvProductosLista.Rows)
                    {
                        if (txtPorcentajeGrvTodos.Text != "")
                        {
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                            decimal precio = Convert.ToDecimal(grvProductosLista.DataKeys[row.RowIndex].Values["Precio"].ToString());
                            decimal porcentaje = Convert.ToDecimal(txtPorcentajeGrvTodos.Text);
                            decimal utilidad = (precio * porcentaje) / 100;
                            decimal preciofinal = precio + utilidad;
                            txtPorcentaje.Text = txtPorcentajeGrvTodos.Text;
                            txtPrecioFinal.Text = preciofinal.ToString("f4");
                            row.Cells[5].Text = utilidad.ToString("f4");
                        }
                        else
                        {
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                            txtPorcentaje.Text = "";
                            txtPrecioFinal.Text = "";
                            row.Cells[5].Text = "";
                        }
                    }
                    txtPrecioFinalGrvTodos.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso');", true);
                }
                else if (id[2].Equals("txtPorcentajeGrvTodos2"))
                {
                    TextBox txtPorcentajeGrvTodos2 = (TextBox)grvListas.HeaderRow.FindControl("txtPorcentajeGrvTodos2");
                    TextBox txtPrecioFinalGrvTodos2 = (TextBox)grvListas.HeaderRow.FindControl("txtPrecioFinalGrvTodos2");
                    foreach (GridViewRow row in grvListas.Rows)
                    {
                        if (txtPorcentajeGrvTodos2.Text != "")
                        {
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                            decimal precio = Convert.ToDecimal(grvListas.DataKeys[row.RowIndex].Values["Precio"].ToString());
                            decimal porcentaje = Convert.ToDecimal(txtPorcentajeGrvTodos2.Text);
                            decimal utilidad = (precio * porcentaje) / 100;
                            decimal preciofinal = precio + utilidad;
                            txtPorcentaje.Text = txtPorcentajeGrvTodos2.Text;
                            txtPrecioFinal.Text = preciofinal.ToString("f4");
                            row.Cells[5].Text = utilidad.ToString("f4");
                        }
                        else
                        {
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                            txtPorcentaje.Text = "";
                            txtPrecioFinal.Text = "";
                            row.Cells[5].Text = "";
                        }
                    }
                    txtPrecioFinalGrvTodos2.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso');", true);
                }     
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void txtPrecioFinalGrvTodos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                string name = Convert.ToString(txt.ClientID);
                string[] id = name.Split('_');
                if (id[2].Equals("txtPrecioFinalGrvTodos"))
                {
                    TextBox txtPrecioFinalGrvTodos = (TextBox)grvProductosLista.HeaderRow.FindControl("txtPrecioFinalGrvTodos");
                    TextBox txtPorcentajeGrvTodos = (TextBox)grvProductosLista.HeaderRow.FindControl("txtPorcentajeGrvTodos");
                    foreach (GridViewRow row in grvProductosLista.Rows)
                    {

                        if (txtPrecioFinalGrvTodos.Text != "")
                        {
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                            decimal precio = Convert.ToDecimal(grvProductosLista.DataKeys[row.RowIndex].Values["Precio"].ToString());
                            decimal preciofinal = Convert.ToDecimal(txtPrecioFinalGrvTodos.Text);
                            decimal utilidad = preciofinal - precio;
                            decimal porcentaje = (utilidad * 100) / precio;
                            txtPrecioFinal.Text = txtPrecioFinalGrvTodos.Text;
                            txtPorcentaje.Text = porcentaje.ToString("f4");
                            row.Cells[5].Text = utilidad.ToString("f4");
                        }
                        else
                        {
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                            txtPrecioFinal.Text = "";
                            txtPorcentaje.Text = "";
                            row.Cells[5].Text = "";
                        }
                    }
                    txtPorcentajeGrvTodos.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso');", true);
                }
                else if (id[2].Equals("txtPrecioFinalGrvTodos2"))
                {
                    TextBox txtPrecioFinalGrvTodos2 = (TextBox)grvListas.HeaderRow.FindControl("txtPrecioFinalGrvTodos2");
                    TextBox txtPorcentajeGrvTodos2 = (TextBox)grvListas.HeaderRow.FindControl("txtPorcentajeGrvTodos2");
                    foreach (GridViewRow row in grvListas.Rows)
                    {

                        if (txtPrecioFinalGrvTodos2.Text != "")
                        {
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                            decimal precio = Convert.ToDecimal(grvListas.DataKeys[row.RowIndex].Values["Precio"].ToString());
                            decimal preciofinal = Convert.ToDecimal(txtPrecioFinalGrvTodos2.Text);
                            decimal utilidad = preciofinal - precio;
                            decimal porcentaje = (utilidad * 100) / precio;
                            txtPrecioFinal.Text = txtPrecioFinalGrvTodos2.Text;
                            txtPorcentaje.Text = porcentaje.ToString("f4");
                            row.Cells[5].Text = utilidad.ToString("f4");
                        }
                        else
                        {
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                            txtPrecioFinal.Text = "";
                            txtPorcentaje.Text = "";
                            row.Cells[5].Text = "";
                        }
                    }
                    txtPorcentajeGrvTodos2.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso');", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreLista.Text != "")
                {
                    if (ValidarDatosGrid())
                    {
                        DataTable dtLista = LlenaTablaLista();
                        PreciosBLL.Lista(1, 0, 0, 0, null, 0, 0, 0, 0, dtLista);
                        LabelTool.ShowSingleLabel(lblMsgMdlMensaje, "Se guardaron los datos.", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlMensaje');", true);
                    }
                    else {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
                    }
                }
                else {
                    SetFocus(txtNombreLista);
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Asigne un nombre a la lista.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "")
                {
                    if (ValidarDatosGrid2())
                    {
                        DataTable dtLista = CrearTablaLista();
                        int iNumero_Producto, iEmpresa = Convert.ToInt32(Session["Company"]);
                        decimal dPrecio_Compra, dUtilidad, dPorcentaje, dPrecio_Final;
                        string sNombre = txtNombre.Text;
                        foreach (GridViewRow row in grvListas.Rows) {
                            iNumero_Producto = Convert.ToInt32(grvListas.DataKeys[row.RowIndex].Values["Numero"]);
                            dPrecio_Compra = Convert.ToDecimal(grvListas.DataKeys[row.RowIndex].Values["Precio"]);
                            dUtilidad = Convert.ToDecimal(row.Cells[5].Text);
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                            TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                            dPorcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                            dPrecio_Final = Convert.ToDecimal(txtPrecioFinal.Text);

                            PreciosBLL.Lista(2,Convert.ToInt32(drpListaPrecio.SelectedValue), iEmpresa, iNumero_Producto, null, dPrecio_Compra, dPorcentaje, dPrecio_Final, dUtilidad, dtLista);
                        }
                        PreciosBLL.Lista(4, Convert.ToInt32(drpListaPrecio.SelectedValue), iEmpresa, 0, sNombre, 0, 0, 0, 0, dtLista);
                        LabelTool.ShowSingleLabel(lblMsgMdlMensaje, "Se modificaron los datos.", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlMensaje');", true);
                    }
                    else {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
                    }
                }
                else {
                    SetFocus(txtNombre);
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Asigne un nombre a la lista.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        
        protected void drpListaPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarGridListaPrecios();
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        
        #endregion
        #region Métodos / Propiedades
        private void LlenarGridProductosLista() {
            DataTable dtProductosLista = PreciosBLL.ObtenerProductosLista(Convert.ToInt32(Session["Company"]));
            if (dtProductosLista.Rows.Count > 0)
            {
                GridViewTool.Bind(dtProductosLista, grvProductosLista);
            }
            else { 
            
            }
        }
        private bool ValidarDatosGrid() {

            foreach (GridViewRow row in grvProductosLista.Rows)
            {
                TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                if (txtPorcentaje.Text == "")
                {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Para continuar, ingrese los datos faltantes.", System.Drawing.Color.Black);
                    SetFocus(txtPorcentaje);
                    return false;
                }
                if (txtPrecioFinal.Text == "")
                {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Para continuar, ingrese los datos faltantes.", System.Drawing.Color.Black);
                    SetFocus(txtPrecioFinal);
                    return false;
                }
            }
            return true;
        }
        private bool ValidarDatosGrid2()
        {

            foreach (GridViewRow row in grvListas.Rows)
            {
                TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv2");
                TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv2");
                if (txtPorcentaje.Text == "")
                {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Para continuar, ingrese los datos faltantes.", System.Drawing.Color.Black);
                    SetFocus(txtPorcentaje);
                    return false;
                }
                if (txtPrecioFinal.Text == "")
                {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, "Para continuar, ingrese los datos faltantes.", System.Drawing.Color.Black);
                    SetFocus(txtPrecioFinal);
                    return false;
                }
            }
            return true;
        }
        private DataTable CrearTablaLista() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Numero_Empresa", typeof(int));
            dt.Columns.Add("Numero_Producto", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Precio_Compra", typeof(decimal));
            dt.Columns.Add("Porcentaje", typeof(decimal));
            dt.Columns.Add("Precio_Final", typeof(decimal));
            dt.Columns.Add("Utilidad", typeof(decimal));
            return dt;
        }
        private DataTable LlenaTablaLista() {
            DataTable dt = CrearTablaLista();
            DataTable dtNumero = PreciosBLL.ObtenerUltimoNumero(Convert.ToInt32(Session["Company"]));
            int iNumero = Convert.ToInt32(dtNumero.Rows[0][0]);
            int iEmpresa = Convert.ToInt32(Session["Company"]);
            string sNombre = txtNombreLista.Text.ToUpper();
            int iNumero_Producto;
            decimal dPrecio_Compra, dPorcentaje, dPrecio_Final, dUtilidad;
            foreach (GridViewRow row in grvProductosLista.Rows) {

                iNumero_Producto = Convert.ToInt32(grvProductosLista.DataKeys[row.RowIndex].Values["Numero"]);
                dPrecio_Compra = Convert.ToDecimal(grvProductosLista.DataKeys[row.RowIndex].Values["Precio"]);
                dUtilidad = Convert.ToDecimal(row.Cells[5].Text);
                TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinalGrv");
                TextBox txtPorcentaje = (TextBox)row.FindControl("txtPorcentajeGrv");
                dPorcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                dPrecio_Final = Convert.ToDecimal(txtPrecioFinal.Text);

                DataRow dr = dt.NewRow();
                dr["Numero"] = iNumero;
                dr["Numero_Empresa"] = iEmpresa;
                dr["Numero_Producto"] = iNumero_Producto;
                dr["Nombre"] = sNombre;
                dr["Precio_Compra"] = dPrecio_Compra;
                dr["Porcentaje"] = dPorcentaje;
                dr["Precio_Final"] = dPrecio_Final;
                dr["Utilidad"] = dUtilidad;
                dt.Rows.Add(dr);

            }

            return dt;
        }
        private void LlenarDropListaPrecios()
        {
            DataTable dt = ClientesBLL.ObtenerListaPrecios(Convert.ToInt32(Session["Company"]));
            if (dt.Rows.Count > 0)
            {
                DropTool.FillDrop(drpListaPrecio, dt, "Descripcion", "Numero");
                LlenarGridListaPrecios();
            }
            else
            {
                LabelTool.ShowLabel(divMsj, spnMsj, lblMsj, "No se han registrado listas de precios", 'i');
            }
        }
        private void LlenarGridListaPrecios() {
            DataTable dt = PreciosBLL.ObtenerDetalleListaPrecios(Convert.ToInt32(Session["Company"]), Convert.ToInt32(drpListaPrecio.SelectedValue));
            GridViewTool.Bind(dt, grvListas);
            if (dt.Rows.Count > 0)
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
        }
        #endregion
    }
}