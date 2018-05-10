using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.IO;
using System.Collections;
using System.Web.UI.WebControls;
using Integra_Develoment;
using System.Data;
using System.Data.OleDb;
using IntegraBussines;
using LinqToExcel;
//using System.Windows.Forms;


namespace Integra_Develomentt
{
    public partial class Productos : System.Web.UI.Page
    {
        #region Variables
        IntegraBussines.ProductosBLL ProdBLL = new ProductosBLL();
        private string _dtProductosConsulta = "dtProductosConsulta", _ProductsTable = "dtProductos", _dtProductosExcel = "dtProductosExcel",
                        _dtValidaciones = "dtValidaciones";
        private DataTable dtValidaciones
        {
            get
            {
                if (ViewState[_dtValidaciones] == null)
                    return new DataTable();
                return (DataTable)ViewState[_dtValidaciones];
            }
            set
            {
                ViewState[_dtValidaciones] = value;
            }
        }
        private DataTable dtProductosConsulta
        {
            get
            {
                if (ViewState[_dtProductosConsulta] == null)
                    return new DataTable();
                return (DataTable)ViewState[_dtProductosConsulta];
            }
            set
            {
                ViewState[_dtProductosConsulta] = value;
            }
        }
        private DataTable dtProductosExcel
        {
            get
            {
                if (ViewState[_dtProductosExcel] == null)
                    return new DataTable();
                return (DataTable)ViewState[_dtProductosExcel];
            }
            set
            {
                ViewState[_dtProductosExcel] = value;
            }
        }
        private DataTable dtProductos
        {
            get
            {
                if (ViewState[_ProductsTable] == null)
                    return new DataTable();
                return (DataTable)ViewState[_ProductsTable];
            }
            set
            {
                ViewState[_ProductsTable] = value;
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    fupXLS.Attributes.Add("onchange", "mostrar();");
                    dtProductos = CreardtProductos();
                    LlenarGridProductosConsulta();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //protected void lnkXLS_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (fupXLS.HasFile)
        //        {
        //            string FileName = Path.GetFileName(fupXLS.PostedFile.FileName);
        //            string Extension = Path.GetExtension(fupXLS.PostedFile.FileName);
        //            string FolderPath = WebConfigurationManager.AppSettings["sFolderXLS"].ToString();
        //            string FilePath = Server.MapPath(FolderPath + FileName);
        //            fupXLS.SaveAs(FilePath);
        //            Import_To_Grid(FilePath, Extension, "Yes");
        //        }
        //        //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "LimpiarDatos();", true);
        //        //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "tabNuevos(); redirect('#nuevos');", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Label lblError = this.Master.FindControl("lblError") as Label;
        //        LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "tabNuevos(); mdlToggle('#mdlError');", true);
        //    }
        //}
        protected void lnkXLS_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    dtProductosExcel = new DataTable();
                    dtProductosExcel = CreardtProductos();
                    dtValidaciones = new DataTable();
                    dtValidaciones.Columns.Add("Descripcion");
                    for (int indice = 0; indice < Request.Files.Count; indice++)
                    {
                        string FileName = Path.GetFileName(Request.Files[indice].FileName);
                        string Extension = Path.GetExtension(Request.Files[indice].FileName);
                        string FolderPath = WebConfigurationManager.AppSettings["sFolderXLS"].ToString();
                        string FilePath = Server.MapPath(FolderPath + FileName);
                        Request.Files[indice].SaveAs(FilePath);
                        ObtenerProductosExcel(FilePath, Extension, "Yes", FileName);
                    }
                    AgregarProductosAGrid();
                }
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso'); tabNuevos();", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "smen();", true);
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "tabNuevos(); mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        private void AgregarProductosAGrid() {
            foreach (DataRow row in dtProductosExcel.Rows) { 
                DataRow dr = dtProductos.NewRow();
                dr["Producto"] = row["Producto"];
                dr["Caracteristicas"] = row["Caracteristicas"];
                dr["Precio"] = row["Precio"];
                dr["Clave"] = row["Clave"];
                dr["Codigo"] = row["Codigo"];
                dtProductos.Rows.Add(dr);
            }
            GridViewTool.Bind(dtProductos, grvProductos);
        }
        private void ObtenerProductosExcel(string FilePath, string Extension, string isHDR, string sFileName)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = WebConfigurationManager.AppSettings["Excel03"].ToString();
                    break;
                case ".xlsx": //Excel 07
                    conStr = WebConfigurationManager.AppSettings["Excel07"].ToString();
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //https://www.codeproject.com/Questions/1114342/How-to-read-data-from-uploaded-excel-file-using-Cs
            //https://www.codeproject.com/Answers/445403/Read-Excel-Sheet-Data-into-DataTable#answer1 como ciclar las hojas del archivo
            
            connExcel.Open();
            DataTable dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();
            //====================================================================================
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * FROM [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            //====================================================================================
            if (ValidarColumnas(dt, sFileName)) {
                JuntarProductos(dt, sFileName);
            }
        }
        private void JuntarProductos(DataTable dt, string sNombreArchivo)
        {
            foreach (DataRow row in dt.Rows) {

                bool bandera = false;

                //Valida la columna 'Nombre'
                if (row["Nombre"] != DBNull.Value)
                {
                    if (row["Nombre"].ToString().Length > 2000)
                    {
                        //Excede el numero de caracteres permitido
                        DataRow dr = dtValidaciones.NewRow();
                        dr["Descripcion"] = "Error ('" + sNombreArchivo + "') La columna 'Nombre' excede el valor de caracteres permitido.";
                        dtValidaciones.Rows.Add(dr);
                    }
                    else 
                    {
                        bandera = true;
                        //Todo esta correcto
                    }
                }
                else 
                {
                    //La celda esta vacia
                    DataRow dr = dtValidaciones.NewRow();
                    dr["Descripcion"] = "Error ('" + sNombreArchivo + "') Existen celdas vacias en la columna 'Nombre'";
                    dtValidaciones.Rows.Add(dr);
                }

                if (bandera)
                {
                    bandera = false;

                    //Valida la columna 'Clave'
                    if (row["Clave"] != DBNull.Value)
                    {
                        if (row["Clave"].ToString().Length > 135)
                        {
                            //Excede el numero de caracteres permitido
                            DataRow dr = dtValidaciones.NewRow();
                            dr["Descripcion"] = "Error ('" + sNombreArchivo + "') La columna 'Clave' excede el valor de caracteres permitido.";
                            dtValidaciones.Rows.Add(dr);
                        }
                        else
                        {
                            //Todo esta correcto
                            bandera = true;
                        }
                    }
                    else
                    {
                        //La celda esta vacia
                        DataRow dr = dtValidaciones.NewRow();
                        dr["Descripcion"] = "Error ('" + sNombreArchivo + "') Existen celdas vacias en la columna 'Clave'";
                        dtValidaciones.Rows.Add(dr);
                    }

                    if (bandera)
                    {
                        bandera = false;

                        //Valida la columna 'Codigo_Barras'
                        if (row["Codigo_Barras"] != DBNull.Value)
                        {
                            if (row["Codigo_Barras"].ToString().Length > 135)
                            {
                                //Excede el numero de caracteres permitido
                                DataRow dr = dtValidaciones.NewRow();
                                dr["Descripcion"] = "Error ('" + sNombreArchivo + "') La columna 'Codigo_Barras' excede el valor de caracteres permitido.";
                                dtValidaciones.Rows.Add(dr);
                            }
                            else
                            {
                                //Todo esta correcto
                                bandera = true;
                            }

                        }
                        else
                        {
                            //La celda esta vacia
                            DataRow dr = dtValidaciones.NewRow();
                            dr["Descripcion"] = "Error ('" + sNombreArchivo + "') Existen celdas vacias en la columna 'Codigo_Barras'";
                            dtValidaciones.Rows.Add(dr);
                        }

                        if (bandera)
                        {
                            bandera = false;

                            //Valida la columna 'Caracteristicas'
                            if (row["Caracteristicas"] != DBNull.Value)
                            {
                                if (row["Caracteristicas"].ToString().Length > 50)
                                {
                                    //Excede el numero de caracteres permitido
                                    DataRow dr = dtValidaciones.NewRow();
                                    dr["Descripcion"] = "Error ('" + sNombreArchivo + "') La columna 'Caracteristicas' excede el valor de caracteres permitido.";
                                    dtValidaciones.Rows.Add(dr);
                                }
                                else
                                {
                                    //Todo esta correcto
                                    bandera = true;
                                }
                            }
                            else
                            {
                                //La celda esta vacia
                                DataRow dr = dtValidaciones.NewRow();
                                dr["Descripcion"] = "Error ('" + sNombreArchivo + "') Existen celdas vacias en la columna 'Caracteristicas'";
                                dtValidaciones.Rows.Add(dr);
                            }

                            if (bandera)
                            {
                                bandera = false;

                                //Valida la columna 'Precio'
                                if (row["Precio"] != DBNull.Value)
                                {
                                    decimal dPrecio;
                                    if (decimal.TryParse(row["Precio"].ToString(), out dPrecio))
                                    {

                                        if (row["Precio"].ToString().Length > 19)
                                        {
                                            //Excede el numero de caracteres permitido
                                            DataRow dr = dtValidaciones.NewRow();
                                            dr["Descripcion"] = "Error ('" + sNombreArchivo + "') La columna 'Precio' excede el valor de caracteres permitido.";
                                            dtValidaciones.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            //Todo esta correcto
                                            bandera = true;
                                        }
                                    }
                                    else {
                                        //No es un número
                                        DataRow dr = dtValidaciones.NewRow();
                                        dr["Descripcion"] = "Error ('" + sNombreArchivo + "') La columna 'Precio' solo acepta caracteres de tipo numerico.";
                                        dtValidaciones.Rows.Add(dr);
                                    }
                                }
                                else
                                {
                                    //La celda esta vacia
                                    DataRow dr = dtValidaciones.NewRow();
                                    dr["Descripcion"] = "Error ('" + sNombreArchivo + "') Existen celdas vacias en la columna 'Precio'";
                                    dtValidaciones.Rows.Add(dr);
                                }
                                if (bandera) {
                                    DataRow drNuevo = dtProductosExcel.NewRow();
                                    drNuevo["Producto"] = row["Nombre"];
                                    drNuevo["Caracteristicas"] = row["Caracteristicas"];
                                    drNuevo["Precio"] = row["Precio"];
                                    drNuevo["Clave"] = row["Clave"];
                                    drNuevo["Codigo"] = row["Codigo_Barras"];
                                    dtProductosExcel.Rows.Add(drNuevo);
                                }
                            }
                        }
                    }
                }
            }
        }
        private bool ValidarColumnas(DataTable dt, string sNombreArchivo) {
            string sValidacion = "";
            ArrayList Exception = new ArrayList();
            if (!dt.Columns.Contains("Nombre"))
                Exception.Add("Nombre");
            if (!dt.Columns.Contains("Clave"))
                Exception.Add("Clave");
            if (!dt.Columns.Contains("Codigo_Barras"))
                Exception.Add("Codigo_Barras");
            if (!dt.Columns.Contains("Precio"))
                Exception.Add("Precio");
            if (!dt.Columns.Contains("Caracteristicas"))
                Exception.Add("Caracteristicas");
            foreach (string s in Exception) {
                sValidacion = sValidacion + " " + s + ",";
            }
            if (sValidacion != "")
            {
                DataRow dr = dtValidaciones.NewRow();
                dr["Descripcion"] = "El archivo '" + sNombreArchivo + "' no cuenta con la(s) columna(s):" + sValidacion.TrimEnd(',');
                dtValidaciones.Rows.Add(dr);
                return false;
            }
            else {
                return true;
            }
        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvProductos.Rows.Count > 0)
                {
                    DataTable dtProductos = LlenarTabla();
                    ProdBLL.Producto(1, 0, 0, null, null, null, 0, null, 0, dtProductos);
                    LabelTool.ShowSingleLabel(lblMsgMdlMensaje, "Se guardaron los datos.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlMensaje');", true);
                }
                else {
                    throw new Exception("No se han registrado productos.");
                }
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                LabelTool.HideLabel(divMensaje2, spnMensaje2, lblMensaje2);
                if (hdnValidacion.Value == "")
                {
                    DataRow dr = dtProductos.NewRow();
                    dr["Producto"] = txtProducto.Text.ToUpper();
                    dr["Caracteristicas"] = txtCaracteristicas.Text.ToUpper();
                    dr["Precio"] = txtPrecio.Text;
                    dr["Clave"] = txtClave.Text;
                    dr["Codigo"] = txtCodigoBarras.Text;
                    dtProductos.Rows.Add(dr);
                    GridViewTool.Bind(dtProductos, grvProductos);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "LimpiarDatos();", true);
                }
                else {
                    throw new Exception(hdnValidacion.Value);
                }
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void grvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvProductos.SelectedRow;
                dtProductos.Rows.RemoveAt(row.RowIndex);
                GridViewTool.Bind(dtProductos, grvProductos);
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }

        }
        protected void lnkEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnk.NamingContainer;
                LinkButton lnkEditar = (LinkButton)row.FindControl("lnkEliminarProducto");
                hdnNumeroProducto.Value = grvProductosConsulta.DataKeys[row.RowIndex].Values["Numero"].ToString();
                hdnIndexProducto.Value = row.RowIndex.ToString();
                lblMdlEliminarProducto.Text = "El registro se eliminará permanentemente. ¿Desea continuar?";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlEliminarProducto');", true);
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void lnkEditarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnk.NamingContainer;
                LinkButton lnkEditar = (LinkButton)row.FindControl("lnkEditarProducto");
                hdnNumeroProducto.Value = grvProductosConsulta.DataKeys[row.RowIndex].Values["Numero"].ToString();
                hdnIndexProducto.Value = row.RowIndex.ToString();
                lblMdlModificarProducto.Text = "El registro se modificará. ¿Desea continuar?";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlModificarProducto');", true);
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void lnkMdlEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int iIndexProducto = Convert.ToInt32(hdnIndexProducto.Value);
                int iNumero_Producto = Convert.ToInt32(hdnNumeroProducto.Value);
                DataTable dt = new DataTable();
                ProdBLL.Producto(3, Convert.ToInt32(Session["Company"]), iNumero_Producto, null, null, null, 0, null, 0, dt);
                dtProductosConsulta.Rows.RemoveAt(iIndexProducto);
                GridViewTool.Bind(dtProductosConsulta, grvProductosConsulta);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso');", true);
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkMdlModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int iIndexProducto = Convert.ToInt32(hdnIndexProducto.Value);
                int iNumero_Producto = Convert.ToInt32(hdnNumeroProducto.Value);
                DataTable dt = new DataTable();
                TextBox txtCaracteristicasGrv = (TextBox)grvProductosConsulta.Rows[iIndexProducto].FindControl("txtCaracteristicasGrv");
                TextBox txtCodigo_BarrasGrv = (TextBox)grvProductosConsulta.Rows[iIndexProducto].FindControl("txtCodigo_BarrasGrv");
                TextBox txtNombreGrv = (TextBox)grvProductosConsulta.Rows[iIndexProducto].FindControl("txtNombreGrv");
                TextBox txtPrecioGrv = (TextBox)grvProductosConsulta.Rows[iIndexProducto].FindControl("txtPrecioGrv");
                TextBox txtClaveGrv = (TextBox)grvProductosConsulta.Rows[iIndexProducto].FindControl("txtClaveGrv");
                ProdBLL.Producto(2, Convert.ToInt32(Session["Company"]), iNumero_Producto, txtNombreGrv.Text, txtClaveGrv.Text, txtCodigo_BarrasGrv.Text, Convert.ToDecimal(txtPrecioGrv.Text), txtCaracteristicasGrv.Text, 1, dt);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlProceso');", true);
            }
            catch (Exception ex)
            {
                Label lblError = this.Master.FindControl("lblError") as Label;
                LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        #endregion

        #region Métodos/Propiedades
        private DataTable CreardtProductos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Producto");
            dt.Columns.Add("Caracteristicas");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Clave");
            dt.Columns.Add("Codigo");
            return dt;
        }
        private void LlenarGridProductosConsulta()
        {
            try
            {
                dtProductosConsulta = ProdBLL.ObtenerProductos(Convert.ToInt32(Session["Company"]));
                GridViewTool.Bind(dtProductosConsulta, grvProductosConsulta);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "1":
                        LabelTool.ShowLabel(divMsj, spnMsj, lblMsj, "No tienes productos disponibles", 'i');
                        break;
                    default:
                        Label lblError = this.Master.FindControl("lblError") as Label;
                        LabelTool.ShowSingleLabel(lblError, ex.Message, System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
                        break;
                }
            }
        }
        private DataTable CrearTablaProductos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero_Empresa", typeof(int));
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Clave", typeof(string));
            dt.Columns.Add("Codigo_Barras", typeof(string));
            dt.Columns.Add("Precio");
            dt.Columns.Add("Caracteristicas", typeof(string));
            dt.Columns.Add("Estatus", typeof(int));
            dt.Columns.Add("Clas_Categoria", typeof(string));
            dt.Columns.Add("Clas_Color", typeof(string));
            dt.Columns.Add("Clas_Unidad_Medida", typeof(string));
            return dt;
        }
        private DataTable LlenarTabla()
        {
            DataTable dtNumeros = ProdBLL.ProductoObtenerUltimoNumero(Convert.ToInt32(Session["Company"]));
            int iNumero = Convert.ToInt32(dtNumeros.Rows[0]["Numero"]);
            DataTable dt = CrearTablaProductos();
            foreach (GridViewRow row in grvProductos.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["Numero_Empresa"] = Convert.ToInt32(Session["Company"]);
                dr["Numero"] = iNumero;
                dr["Nombre"] = grvProductos.DataKeys[row.RowIndex].Values["Producto"].ToString();
                dr["Clave"] = grvProductos.DataKeys[row.RowIndex].Values["Clave"].ToString();
                dr["Codigo_Barras"] = grvProductos.DataKeys[row.RowIndex].Values["Codigo"].ToString();
                dr["Precio"] = Convert.ToDecimal(grvProductos.DataKeys[row.RowIndex].Values["Precio"]);
                dr["Caracteristicas"] = grvProductos.DataKeys[row.RowIndex].Values["Caracteristicas"].ToString();
                dr["Estatus"] = 1;
                dt.Rows.Add(dr);
                iNumero++;
            }
            return dt;
        }
        #endregion
    }
}
