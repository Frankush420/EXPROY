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
    /// Descripción breve de WSProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSProductos : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public string[] ObtenerProductos(string prefixText, int count)
        {
            IntegraBussines.ProductosBLL ProdBLL = new ProductosBLL();
            DataTable dtProductos;
            List<string> txtItems = new List<string>();

            using (dtProductos = ProdBLL.ObtenerProductosACMP(Convert.ToInt32(Session["Company"]), prefixText.ToUpper()))
            {
                int element = 0;
                if (dtProductos.Rows.Count > 0)
                {

                    foreach (DataRow row in dtProductos.Rows)
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
