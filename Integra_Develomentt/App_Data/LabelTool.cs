using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integra_Develoment
{
    public static class LabelTool
    {
        public static void ShowSingleLabel(System.Web.UI.WebControls.Label lbl, string msg, System.Drawing.Color colour)
        {
            lbl.Text = msg;
            lbl.ForeColor = colour;
            lbl.Visible = true;
        }
        public static void HideSingleLabel(System.Web.UI.WebControls.Label lbl)
        {
            lbl.Text = "";
            lbl.Visible = false;
        }
        public static void HideLabel(System.Web.UI.HtmlControls.HtmlGenericControl div,
                                    System.Web.UI.HtmlControls.HtmlGenericControl span,
                                    System.Web.UI.WebControls.Label lbl)
        {
            div.Attributes.CssStyle.Clear();
            span.Attributes.CssStyle.Clear();
            lbl.Attributes.CssStyle.Clear();
            div.Visible = false;
            span.Visible = false;
            lbl.Visible = false;
            lbl.Text = "";
        }
        public static void ShowLabel(System.Web.UI.HtmlControls.HtmlGenericControl div,
                                    System.Web.UI.HtmlControls.HtmlGenericControl span,
                                    System.Web.UI.WebControls.Label lbl,
                                    string mensaje,
                                    char tipo)
        {
            div.Visible = true;
            span.Visible = true;
            string cssdiv = "", cssspan = "", csslbl = "";
            switch (tipo)
            {
                case 's':
                    cssdiv = "alert alert-success";
                    cssspan = "glyphicon glyphicon-thumbs-up";
                    csslbl = "text-success";
                    break;
                case 'i':
                    cssdiv = "alert alert-info";
                    cssspan = "glyphicon glyphicon-info-sign";
                    csslbl = "text-primary";
                    break;
                case 'w':
                    cssdiv = "alert alert-warning";
                    cssspan = "glyphicon glyphicon-exclamation-sign";
                    csslbl = "text-warning";
                    break;
                case 'd':
                    cssdiv = "alert alert-danger";
                    cssspan = "glyphicon glyphicon-warning-sign";
                    csslbl = "text-danger";
                    break;
                default:
                    cssdiv = "alert alert-info";
                    cssspan = "glyphicon glyphicon-info-sign";
                    csslbl = "text-primary";
                    break;
            }
            div.Attributes.Add("class", cssdiv);
            span.Attributes.Add("class", cssspan);
            lbl.Text = mensaje;
            lbl.CssClass = csslbl;
            lbl.Visible = true;
        }
    }
}