using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IntegraBussines;

namespace Integra_Develomentt
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ObtenerDatosEmpresa();
                    //LinkButton lnk = this.Master.FindControl("lbl") as LinkButton;
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
        }
        protected void lnkSalirSistema_Click(object sender, EventArgs e)
        {
            try
            {
                Session["Company"] = "";
                Session["Person"] = "";
                Session["Office"] = "";
                Session["NamePerson"] = "";
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private void ObtenerDatosEmpresa()
        {
            if (Session["Company"].ToString() != "")
            {
                DataTable dt = new DataTable();
                dt = ControlsBLL.ObtenDatosEmpresa(Convert.ToInt32(Session["Company"]));
                if (dt.Rows.Count > 0)
                {
                    lblEmpresa.Text = Convert.ToString(dt.Rows[0][0]);
                    Page.Title = Convert.ToString(dt.Rows[0][0]).ToString().ToUpper();
                    
                }
                else
                {
                    lblEmpresa.Text = "Sin Empresa";
                }
                lnkCerrarSesion.Visible = true;
                lblUsuario.Text = Session["NamePerson"].ToString();
            }
        }
    }
}
