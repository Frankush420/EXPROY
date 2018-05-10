<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Integra_Develomentt._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsDefault.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="modal fade bs-example-modal-sm" id="mdlLogin" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Iniciar Sesión</h4>
                    </div>
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="lnkEntrar">
                        <div class="modal-body">
                            <div id="divMensaje" role="alert" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <span id="spnMensaje" runat="server" aria-hidden="true"></span>
                                <asp:Label ID="lblMensaje" runat="server" Style=" font-size:medium;"></asp:Label>
                            </div>
                            <div class="form-group">
                                <span class="help-block">Correo electrónico o teléfono</span>
                                <asp:TextBox ID="txtUsr" runat="server" MaxLength="30" 
                                    CssClass="form-control input-sm">
                                </asp:TextBox>
                            </div>
                            <div class="form-group">
                                <span class="help-block">Contraseña</span>
                                <asp:TextBox ID="txtPswd" runat="server" MaxLength="20" 
                                    CssClass="form-control input-sm" TextMode="Password">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkEntrar" runat="server" class="btn btn-success btn-block" 
                                Text="Entrar" OnClick="lnkEntrar_Click"/>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
