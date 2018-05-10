using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace Integra_Develoment
{
    public static class GridViewTool
    {
        public static void uncheck_header(object sender, GridView grv, string headername)
        {
            if (!((CheckBox)sender).Checked)
            {
                GridViewRow row = grv.HeaderRow;

                CheckBox HrdChk = (CheckBox)row.FindControl(headername);

                if (HrdChk != null)
                {
                    HrdChk.Checked = false;
                }
            }
        }

        public static void Bind(DataTable source, GridView grv)
        {
            grv.DataSource = source;
            grv.DataBind();
        }

        public static void CleanGridViewSelection(GridView grv)
        {
            grv.SelectedIndex = -1;
        }
    }
}