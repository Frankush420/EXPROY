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
    public partial class Clientes : System.Web.UI.Page
    {
        #region Variables
        static int iNumero_Columnas_Fisicas, iNumero_Columnas_Morales;
        #endregion
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    LlenarDropPersonas();
                    LlenarDropListaPrecios();
                    LLenarGridClientes();
                    SetFocus(txtBusqueda);
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
        }
        protected void drpTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                DropDownList sndr = sender as DropDownList;
                string name = Convert.ToString(sndr.ClientID);
                string[] id = name.Split('_');
                if (id[1].Equals("drpTipoPersona"))
                {
                    int i = Convert.ToInt32(drpTipoPersona.SelectedValue);
                    if (i == 1)
                    {
                        Session["Tipo"] = 1;
                        divFisicas.Visible = true;
                        divMorales.Visible = false;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "LimpiarDatos();", true);
                    }
                    else
                    {
                        Session["Tipo"] = 0;
                        divFisicas.Visible = false;
                        divMorales.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "LimpiarDatos();", true);
                    }
                }
                else if (id[1].Equals("drpTipoPersona2"))
                {
                    int i = Convert.ToInt32(drpTipoPersona2.SelectedValue);
                    if (i == 1)
                    {
                        Session["Tipo"] = 1;
                        divFisicas2.Visible = true;
                        divMorales2.Visible = false;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "LimpiarDatos2();", true);
                    }
                    else
                    {
                        Session["Tipo"] = 0;
                        divFisicas2.Visible = false;
                        divMorales2.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "LimpiarDatos2();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        { 
            try
            {
                divAccionesCliente.Visible = false;
                if (keycontainer.Value != "")
                {
                    txtBusqueda.Text = "";
                    DataTable dt = ClientesBLL.ObtenerDatosCliente(Convert.ToInt32(Session["Company"]), Convert.ToInt32(keycontainer.Value));
                    hdnNumero_Domicilio.Value = dt.Rows[0]["Numero_Domicilio"].ToString();
                    txtDomicilio2.Text = dt.Rows[0]["Domicilio"].ToString();
                    txtColonia2.Text = dt.Rows[0]["Colonia"].ToString();
                    txtCP2.Text = dt.Rows[0]["Codigo_Postal"].ToString();
                    txtDelMun2.Text = dt.Rows[0]["Delegacion_Municipio"].ToString();
                    txtEstado2.Text = dt.Rows[0]["Estado"].ToString();
                    txtTelefonoDomicilio2.Text = dt.Rows[0]["Telefono"].ToString();
                    DataTable dt2 = ClientesBLL.ObtenerListaPrecios(Convert.ToInt32(Session["Company"]));
                    if (dt2.Rows.Count > 0)
                    {
                        DropTool.FillDrop(drpListaPrecios2, dt2, "Descripcion", "Numero");
                        drpListaPrecios2.SelectedValue = drpListaPrecios2.Items.FindByValue(dt.Rows[0]["Lista_Precio"].ToString()).Value;
                    }
                    
                    if (Convert.ToInt32(drpTipoPersona2.SelectedValue) == 1)
                    {
                        txtNombreFisicas2.Text = dt.Rows[0]["Nombre"].ToString();
                        txtPaterno2.Text = dt.Rows[0]["Paterno"].ToString();
                        txtMaterno2.Text = dt.Rows[0]["Materno"].ToString();
                        txtNombreCortoFisicas2.Text = dt.Rows[0]["Nombre_Corto"].ToString();
                        txtCURP2.Text = dt.Rows[0]["CURP"].ToString();
                        txtRFCFisicas2.Text = dt.Rows[0]["RFC"].ToString();
                        txtFechaNacimiento2.Text = dt.Rows[0]["Fecha_Nacimiento"].ToString();
                        txtCelular2.Text = dt.Rows[0]["Celular"].ToString();
                        txtCorreoFisicas2.Text = dt.Rows[0]["Correo_Electronico"].ToString();
                        lblMdlEliminarCliente.Text = "El cliente " + dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Paterno"].ToString() + " " + dt.Rows[0]["Materno"].ToString() + " se eliminará de forma permanente. ¿Desea continuar?";
                        lblMdlModificarCliente.Text = "Los datos del cliente " + dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Paterno"].ToString() + " " + dt.Rows[0]["Materno"].ToString() + " serán modificados. ¿Desea continuar?";
                        txtNombreFisicas2.Focus();
                    }
                    else 
                    {
                        txtNombreMorales2.Text = dt.Rows[0]["Nombre"].ToString();
                        txtNombreCortoMorales2.Text = dt.Rows[0]["Nombre_Corto"].ToString();
                        txtRFCMorales2.Text = dt.Rows[0]["RFC"].ToString();
                        txtCorreoMorales2.Text = dt.Rows[0]["Correo_Electronico"].ToString();
                        lblMdlEliminarCliente.Text = "El cliente " + dt.Rows[0]["Nombre"].ToString() + " se eliminará de forma permanente. ¿Desea continuar?";
                        lblMdlModificarCliente.Text = "Los datos del cliente " + dt.Rows[0]["Nombre"].ToString() + " serán modificados. ¿Desea continuar?";
                        txtNombreMorales2.Focus();
                    }
                    divAccionesCliente.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnValidacion.Value == "")
                {
                    if (drpListaPrecios.Items.Count > 0)
                    {
                        string sAviso ="";
                        if (Convert.ToInt32(Session["Tipo"]) == 1)
                        {
                            ClientesBLL.Cliente(1, 0, Convert.ToInt32(Session["Company"]), txtNombreFisicas.Text.ToUpper(), txtPaterno.Text.ToUpper(), txtMaterno.Text.ToUpper(),
                                                txtNombreFisicas.Text.ToUpper() + " " + txtPaterno.Text.ToUpper() + " " + txtMaterno.Text.ToUpper(), txtNombreCortoFisicas.Text.ToUpper(),
                                                txtRFCFisicas.Text.ToUpper(), txtCURP.Text.ToUpper(), Convert.ToDateTime(txtFechaNacimiento.Text), txtCelular.Text,
                                                txtCorreoFisicas.Text, "F", Convert.ToDateTime(DateTime.Today), 1, 0, txtDomicilio.Text.ToUpper(), txtColonia.Text.ToUpper(),
                                                txtDelMun.Text.ToUpper(), txtCP.Text, txtEstado.Text.ToUpper(), "", txtTelefonoDomicilio.Text, "", 1, "",
                                                Convert.ToInt32(drpListaPrecios.SelectedValue));
                            sAviso = txtNombreFisicas.Text.ToUpper() + " " + txtPaterno.Text.ToUpper() + " " + txtMaterno.Text.ToUpper();
                        }
                        else
                        {
                            ClientesBLL.Cliente(1, 0, Convert.ToInt32(Session["Company"]), txtNombreMorales.Text.ToUpper(), "", "", "", txtNombreCortoMorales.Text.ToUpper(),
                                                txtRFCMorales.Text.ToUpper(), "", Convert.ToDateTime(DateTime.Today), "", txtCorreoMorales.Text, "M",
                                                Convert.ToDateTime(DateTime.Today), 1, 0, txtDomicilio.Text.ToUpper(), txtColonia.Text.ToUpper(),
                                                txtDelMun.Text.ToUpper(), txtCP.Text, txtEstado.Text.ToUpper(), "", txtTelefonoDomicilio.Text, "", 1, "",
                                                Convert.ToInt32(drpListaPrecios.SelectedValue));
                            sAviso = txtNombreMorales.Text.ToUpper();
                        }
                        LabelTool.ShowSingleLabel(lblMdlAviso, sAviso + " se registró como cliente.", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlAviso');", true);
                    }
                    else
                    {
                        LabelTool.ShowSingleLabel(lblMdlListaPrecio, "Para dar de alta un cliente debe tener listas de precios registradas.", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlListaPrecio');", true);

                    }
                }
                else {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, hdnValidacion.Value, System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);

                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkModificarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnValidacion.Value == "")
                {
                    if (drpListaPrecios2.Items.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlModificarCliente');", true);
                    }
                    else
                    {
                        LabelTool.ShowSingleLabel(lblMdlListaPrecio, "Para modificar un cliente debe tener listas de precios registradas.", System.Drawing.Color.Black);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlListaPrecio');", true);

                    }
                }
                else
                {
                    LabelTool.ShowSingleLabel(lblMsgMdlError, hdnValidacion.Value, System.Drawing.Color.Black);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);

                }
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkMdlModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string sAviso = "";
                if (Convert.ToInt32(Session["Tipo"]) == 1)
                {
                    ClientesBLL.Cliente(2, Convert.ToInt32(keycontainer.Value), Convert.ToInt32(Session["Company"]), txtNombreFisicas2.Text.ToUpper(), txtPaterno2.Text.ToUpper(), txtMaterno2.Text.ToUpper(),
                                        txtNombreFisicas2.Text.ToUpper() + " " + txtPaterno2.Text.ToUpper() + " " + txtMaterno2.Text.ToUpper(), txtNombreCortoFisicas2.Text.ToUpper(),
                                        txtRFCFisicas2.Text.ToUpper(), txtCURP2.Text.ToUpper(), Convert.ToDateTime(txtFechaNacimiento2.Text), txtCelular2.Text,
                                        txtCorreoFisicas2.Text, "F", Convert.ToDateTime(DateTime.Today), 1, Convert.ToInt32(hdnNumero_Domicilio.Value), txtDomicilio2.Text.ToUpper(), txtColonia2.Text.ToUpper(),
                                        txtDelMun2.Text.ToUpper(), txtCP2.Text, txtEstado2.Text.ToUpper(), "", txtTelefonoDomicilio2.Text, "", 1, "",
                                        Convert.ToInt32(drpListaPrecios2.SelectedValue));
                    sAviso = txtNombreFisicas2.Text.ToUpper() + " " + txtPaterno2.Text.ToUpper() + " " + txtMaterno2.Text.ToUpper();
                }
                else
                {
                    ClientesBLL.Cliente(2, Convert.ToInt32(keycontainer.Value), Convert.ToInt32(Session["Company"]), txtNombreMorales2.Text.ToUpper(), "", "", "", txtNombreCortoMorales2.Text.ToUpper(),
                                        txtRFCMorales2.Text.ToUpper(), "", Convert.ToDateTime(DateTime.Today), "", txtCorreoMorales2.Text, "M",
                                        Convert.ToDateTime(DateTime.Today), 1, Convert.ToInt32(hdnNumero_Domicilio.Value), txtDomicilio2.Text.ToUpper(), txtColonia2.Text.ToUpper(),
                                        txtDelMun2.Text.ToUpper(), txtCP2.Text, txtEstado2.Text.ToUpper(), "", txtTelefonoDomicilio2.Text, "", 1, "",
                                        Convert.ToInt32(drpListaPrecios2.SelectedValue));
                    sAviso = txtNombreMorales2.Text.ToUpper();
                }
                LabelTool.ShowSingleLabel(lblMdlAviso, "Se modificaron los datos de " + sAviso, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlAviso');", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
            }
        }
        protected void lnkMdlEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ClientesBLL.Cliente(3, Convert.ToInt32(keycontainer.Value), Convert.ToInt32(Session["Company"]),"", "", "", "", "", "", "", 
                                    Convert.ToDateTime(DateTime.Today), "", "", "M", Convert.ToDateTime(DateTime.Today), 1, 
                                    Convert.ToInt32(hdnNumero_Domicilio.Value), "", "","", "", "", "", "", "", 1, "",
                                    Convert.ToInt32(drpListaPrecios2.SelectedValue));
                LabelTool.ShowSingleLabel(lblMdlAviso, "El cliente ha sido eliminado.", System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlAviso');", true);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle2('#mdlProceso','#mdlError');", true);
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
        protected void grvClientesFisicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvClientesFisicos.SelectedRow;
                int iNumero_Cliente = Convert.ToInt32(grvClientesFisicos.DataKeys[row.RowIndex].Values["Numero"]);
                keycontainer.Value = iNumero_Cliente.ToString();
                drpTipoPersona2.SelectedValue = drpTipoPersona2.Items.FindByValue("1").Value;
                Session["Tipo"] = 1;
                divFisicas2.Visible = true;
                divMorales2.Visible = false;
                txtBusqueda_TextChanged(null, null);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        protected void grvClientesMorales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvClientesMorales.SelectedRow;
                int iNumero_Cliente = Convert.ToInt32(grvClientesMorales.DataKeys[row.RowIndex].Values["Numero"]);
                keycontainer.Value = iNumero_Cliente.ToString();
                drpTipoPersona2.SelectedValue = drpTipoPersona2.Items.FindByValue("0").Value;
                Session["Tipo"] = 0;
                divFisicas2.Visible = false;
                divMorales2.Visible = true;
                txtBusqueda_TextChanged(null, null);
            }
            catch (Exception ex)
            {
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        #endregion
        #region Métodos / Propiedades
        private void LlenarDropPersonas() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));
            DropTool.CompleteDrop(dt, 0, "Persona Moral");
            DropTool.CompleteDrop(dt, 1, "Persona Fisica");
            DropTool.FillDrop(drpTipoPersona, dt, "Descripcion", "Numero");
            DropTool.FillDrop(drpTipoPersona2, dt, "Descripcion", "Numero");
            //drpTipoPersona_SelectedIndexChanged(null, null);
            Session["Tipo"] = 1;
        }
        private void LlenarDropListaPrecios() {
            DataTable dt = ClientesBLL.ObtenerListaPrecios(Convert.ToInt32(Session["Company"]));
            if (dt.Rows.Count > 0){
                DropTool.FillDrop(drpListaPrecios, dt, "Descripcion", "Numero");
            }else {
                LabelTool.ShowLabel(divMsj, spnMsj, lblMsj, "No tienes listas de precios, no se daran de alta los usuarios sin una lista", 'i');
            }
        }
        private void LLenarGridClientes()
        {
            try{
                DataTable dtFisicas = ClientesBLL.ObtenerClientesPorPersonalidad(Convert.ToInt32(Session["Company"]), 1);
                DataTable dtMorales = ClientesBLL.ObtenerClientesPorPersonalidad(Convert.ToInt32(Session["Company"]), 0);
                if (dtFisicas.Rows.Count > 0){
                    iNumero_Columnas_Fisicas = dtFisicas.Columns.Count;
                    GridViewTool.Bind(dtFisicas, grvClientesFisicos);
                }else {
                    LabelTool.ShowLabel(divAlertFisicas, spnDivAlertFisicas, lblDivAlertFisicas, "No hay clientes con personalidad fisica", 'i');
                }
                if (dtMorales.Rows.Count > 0){
                    iNumero_Columnas_Morales = dtMorales.Columns.Count;
                    GridViewTool.Bind(dtMorales, grvClientesMorales);
                }else{
                    LabelTool.ShowLabel(divAlertMorales, spnDivAlertMorales, lblDivAlertMorales, "No hay clientes con personalidad moral", 'i');
                }
            }
            catch (Exception ex){
                LabelTool.ShowSingleLabel(lblMsgMdlError, ex.Message, System.Drawing.Color.Black);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "mdlToggle('#mdlError');", true);
            }
        }
        #endregion
    }
}