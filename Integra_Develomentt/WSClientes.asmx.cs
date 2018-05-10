using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using IntegraBussines;

namespace Integra_Develomentt
{
    /// <summary>
    /// Descripción breve de WSClientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSClientes : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string[] ObtenerClientes(string prefixText, int count)
        {
            DataTable dtClientes;
            List<string> txtItems = new List<string>();

            using (dtClientes = ClientesBLL.ObtenerTodosLosClientes(Convert.ToInt32(Session["Company"]), prefixText.ToUpper()))
            {
                int element = 0;
                if (dtClientes.Rows.Count > 0)
                {

                    foreach (DataRow row in dtClientes.Rows)
                    {
                        string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(row["Descripcion"].ToString(), row["Numero"].ToString().ToUpper());
                        txtItems.Add(item);
                        if (++element == count)
                            break;
                    }
                }
            }
            return txtItems.ToArray();
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string[] ObtenerClientesPorPersonalidad(string prefixText, int count)
        {
            DataTable dtClientes;
            List<string> txtItems = new List<string>();

            using (dtClientes = ClientesBLL.ObtenerClientes(Convert.ToInt32(Session["Company"]), Convert.ToInt32(Session["Tipo"]), prefixText.ToUpper()))
            {
                int element = 0;
                if (dtClientes.Rows.Count > 0)
                {

                    foreach (DataRow row in dtClientes.Rows)
                    {
                        string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(row["Descripcion"].ToString(), row["Numero"].ToString().ToUpper());
                        txtItems.Add(item);
                        if (++element == count)
                            break;
                    }
                }
            }
            return txtItems.ToArray();
        }
    }
}
