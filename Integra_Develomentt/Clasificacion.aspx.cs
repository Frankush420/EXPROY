using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Integra_Develoment;
using System.Data;
using IntegraBussines;
using System.Windows.Forms;


namespace Integra_Develomentt
{
    public partial class Clasificacion : System.Web.UI.Page
    {
        #region Variables
            static DataTable dtElementos = new DataTable();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                dtElementos.Clear();

            }
        }
        #region Eventos

        
        protected void lnkAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                LabelTool.HideLabel(divMensaje2, spnMensaje2, lblMensaje2);
                if (txtElemento.Text != "")
                {
                    if (!dtElementos.Columns.Contains("Numero"))
                        dtElementos.Columns.Add("Numero", typeof(string));
                    if (!dtElementos.Columns.Contains("Elemento"))
                        dtElementos.Columns.Add("Elemento", typeof(string));
                    DataRow dr = dtElementos.NewRow();
                    dr["Numero"] = dtElementos.Rows.Count + 1;
                    dr["Elemento"] = txtElemento.Text.ToString().ToUpper();
                    dtElementos.Rows.Add(dr);
                    txtElemento.Text = "";
                    GridViewTool.Bind(dtElementos, grvElementos);
                    SetFocus(txtElemento);
                    lblContadorElemento.Text = dtElementos.Rows.Count.ToString();
                }
            }
            catch (Exception ex) {
                LabelTool.ShowLabel(divMensaje2, spnMensaje2, lblMensaje2, ex.Message, 'd');
            }
        }
        protected void grvElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvElementos.SelectedRow;
                dtElementos.Rows.RemoveAt(row.RowIndex);
                GridViewTool.Bind(dtElementos, grvElementos);
                lblContadorElemento.Text = dtElementos.Rows.Count.ToString();

            }
            catch (Exception ex) {
                LabelTool.ShowLabel(divMensaje2, spnMensaje2, lblMensaje2, ex.Message, 'd');
            }

        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                LabelTool.HideLabel(divMensaje2, spnMensaje2, lblMensaje2);
                if (ValidarCampos())
                {
                    DataTable dtClasificacion = LlenarTabla();
                    ClasificacionBLL.InsertarClasificacion(1, 1, 0, null, null, null, dtClasificacion);
                    
                    LabelTool.ShowSingleLabel(lblMsgMdl, "Se guardaron los datos.", System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "modal();", true);
                }
                
            }
            catch (Exception ex) {
                LabelTool.ShowLabel(divMensaje2, spnMensaje2, lblMensaje2, ex.Message, 'd');
            }
        }
        #endregion
        #region Métodos/Propiedades
        private DataTable CrearTablaClasificacion() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero_Empresa", typeof(int));
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Clave", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Clave1", typeof(string));
            dt.Columns.Add("Descripcion1", typeof(string));
            dt.Columns.Add("Clave2", typeof(string));
            dt.Columns.Add("Descripcion2", typeof(string));
            dt.Columns.Add("Numero_Padre", typeof(int));
            return dt;
        }
        private DataTable LlenarTabla() {
            DataTable dtNumeros = ClasificacionBLL.ClasificacionObtenerUltimoNumero(Convert.ToInt32(Session["Company"]));
            int iNumero = Convert.ToInt32(dtNumeros.Rows[0]["Numero"]);
            int iClave = Convert.ToInt32(dtNumeros.Rows[0]["Clave"]);
            DataTable dt = CrearTablaClasificacion();
            foreach (GridViewRow row in grvElementos.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["Numero_Empresa"] = Convert.ToInt32(Session["Company"]);
                dr["Numero"] = iNumero;
                dr["Clave"] = iClave.ToString();
                dr["Descripcion"] = txtNombre.Text.ToUpper();
                dr["Clave1"] = "0" + iClave.ToString();
                dr["Descripcion1"] = grvElementos.DataKeys[row.RowIndex].Values["Elemento"].ToString();
                dr["Clave2"] = "0" + iClave.ToString();
                dr["Descripcion2"] = DBNull.Value;
                dr["Numero_Padre"] = DBNull.Value;
                dt.Rows.Add(dr);
                iNumero++;
            }
            return dt;
        }
        private bool ValidarCampos() {
            if (hdnValidacion.Value != "" && hdnValidacion.Value != null)
            {
                LabelTool.ShowLabel(divMensaje2, spnMensaje2, lblMensaje2, hdnValidacion.Value, 'w');
                return false;
            }
            return true;
        }
        private void DivAgregar()
        {
            dtElementos.Clear();
            txtNombre.Focus();
        }
        
        #endregion


        
    }
}
