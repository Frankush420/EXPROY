<%@ Page Title="Cotización" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Cotizacion.aspx.cs" Inherits="Integra_Develomentt.Cotizacion" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jsCotizacion.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <fieldset>
            <legend>COTIZACIÓN</legend>
            <asp:UpdatePanel ID="upnlCotizacion" runat="server" UpdateMode="Always">
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="linkCancelacion" EventName="Click" />--%>
                    <%--<asp:PostBackTrigger ControlID="linkCancelacion" EventName="Click" />--%>
                </Triggers>
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </fieldset>
    </div>
</asp:Content>
