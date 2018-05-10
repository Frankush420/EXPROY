using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegraBussines;
using Integra_Develoment;
using System.Data;

namespace Integra_Develomentt
{
    public partial class _Default : System.Web.UI.Page
    {
        int iNumero_Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["Company"] = "";
                Session["Person"] = "";
                Session["Office"] = "";
                Session["NamePerson"] = "";
            }
        }
        protected void lnkEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSesion();
            }
            catch(Exception ex){
                LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, ex.Message, 'd');
            }
        }
        private void ValidarSesion() {
            string sUsr = txtUsr.Text.Trim();
            string sPswd = txtPswd.Text.Trim();
            if (sUsr.Contains('@'))
            {
                if (BusquedaUsuario(sUsr, 1))
                {
                    if (ValidarPassword(sPswd))
                    {
                        PermitirAcceso();
                    }
                    else {
                        LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, "La contraseña que has introducido es incorrecta", 'd');
                    }

                }
                else {
                    LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, "No encontramos una cuenta con ese correo electrónico.", 'd');
                }
            }
            else {
                double iNumero_Telefono;
                bool bandera = double.TryParse(sUsr, out iNumero_Telefono);
                if (bandera == true)
                {
                    if (BusquedaUsuario(sUsr, 2))
                    {
                        if (ValidarPassword(sPswd))
                        {
                            PermitirAcceso();
                        }
                        else
                        {
                            LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, "La contraseña que has introducido es incorrecta", 'd');
                        }
                    }
                    else
                    {
                        LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, "No encontramos una cuenta con ese número de teléfono.", 'd');
                    }
                }
                else
                {
                    LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, "Introduzca una cuenta de correo o teléfono valido.", 'd');
                }
            }
        }
        private bool BusquedaUsuario(string sUsuario, int iTipo) {
            bool bandera = false;
            DataTable dt = DefaultBLL.GetUserNumber(sUsuario,iTipo);
            if (dt.Rows.Count > 0) { 
                iNumero_Usuario = Convert.ToInt32(dt.Rows[0]["Numero"]);
                return true;
            }
            return (bandera);
        }
        private bool ValidarPassword(string sPswd) {
            bool bandera = false;
            DataTable dt = DefaultBLL.GetUserPassword(iNumero_Usuario, sPswd);
            if (Convert.ToInt32(dt.Rows[0]["Password"]) == 1) {
                return true;
            }
            return (bandera);
        }
        private void PermitirAcceso() {
            try
            {
                DataTable dt = DefaultBLL.GetUserData(iNumero_Usuario);
                Session["Company"] = dt.Rows[0]["Empresa"].ToString();
                Session["Person"] = dt.Rows[0]["Numero"].ToString();
                Session["NamePerson"] = dt.Rows[0]["Nombre"].ToString();
                Response.Redirect("Productos.aspx");
            }
            catch (Exception ex)
            {
                LabelTool.ShowLabel(divMensaje, spnMensaje, lblMensaje, ex.Message, 'd');
            }
        }
    }
}
