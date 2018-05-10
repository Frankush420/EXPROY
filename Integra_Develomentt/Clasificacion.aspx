<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Clasificacion.aspx.cs" Inherits="Integra_Develomentt.Clasificacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsClasificacion.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#Existentes" aria-controls="Existentes" role="tab" data-toggle="tab">Existentes</a></li>
            <li role="presentation"><a href="#Nuevos" aria-controls="Nuevos" role="tab" data-toggle="tab">Nuevos</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="Existentes">

            </div>
            <div role="tabpanel" class="tab-pane fade" id="Nuevos">
                <fieldset>
                    <legend>Alta de Clasificaciones</legend>
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="lnkAgregar">
                        <asp:UpdatePanel ID="upnlPrincipal" runat="server" UpdateMode="Always">
                            <Triggers>
                                <%--<asp:AsyncPostBackTrigger ControlID="linkCancelacion" EventName="Click" />--%>
                                <%--<asp:PostBackTrigger ControlID="linkCancelacion" EventName="Click" />--%>
                            </Triggers>
                            <ContentTemplate>
                                <div id="divMensaje2" role="alert" runat="server" visible="false">
                                    <span id="spnMensaje2" runat="server" aria-hidden="true"></span>
                                    <asp:Label ID="lblMensaje2" runat="server" Style=" font-size:medium;"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lnkTxtNombre" runat="server" OnClientClick="borrartxt(MainContent_txtNombre);" TabIndex="1" class="btn btn-default">
                                        <span class="glyphicon glyphicon-erase"></span>
                                        </asp:LinkButton>
                                    </span>
                                    <span class="input-group-addon" id="basic-addon1">Nombre</span>
                                    <asp:TextBox ID="txtNombre" runat="server" TabIndex="2" MaxLength="100" 
                                        CssClass="form-control" onblur="cambiarnombre(this)">
                                    </asp:TextBox>
                                </div>
                                <br />
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lnkTxtElemento" runat="server" OnClientClick="borrartxt(MainContent_txtElemento);" TabIndex="3" class="btn btn-default">
                                        <span class="glyphicon glyphicon-erase"></span>
                                        </asp:LinkButton>
                                    </span>
                                    <span class="input-group-addon" id="Span1">Elemento</span>
                                    <asp:TextBox ID="txtElemento" runat="server" TabIndex="4" MaxLength="100" CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                                <br />
                                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                    <div class="btn-group" role="group">
                                        <asp:LinkButton ID="lnkAgregar" runat="server" OnClick="lnkAgregar_Click" TabIndex="5" class="btn btn-default">
                                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar
                                        </asp:LinkButton>
                                    </div>
                                    <div class="btn-group" role="group">
                        
                                        <asp:LinkButton ID="lnkGuardar" runat="server" OnClientClick="ValidarCampos(this);" OnClick="lnkGuardar_Click" TabIndex="6" class="btn btn-success">
                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Guardar
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <table width="100%" class="table table-responsive">
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel ID="upnlElementos" runat="server" UpdateMode="Always">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="lnkAgregar"/>
                                                </Triggers>
                                                <ContentTemplate>
                                                    <table class="table table-responsive table-bordered" width="100%">
                                                        <tr class="info">
                                                            <td style="width:96%;">
                                                                <asp:Label ID="lblNombreClasificacion" runat="server" Text="Elemento"/>
                                                            </td>
                                                            <td style="width:4%;">
                                                                <span class="badge">
                                                                    <asp:Label ID="lblContadorElemento" runat="server" Text="0"/>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="grvElementos" runat="server" CellPadding="0" AutoGenerateColumns="False"
                                                        GridLines="None" ShowHeader="False" Width="100%" ViewStateMode="Enabled" CssClass="table table-striped"
                                                        OnSelectedIndexChanged="grvElementos_SelectedIndexChanged" DataKeyNames="Numero, Elemento">
                                                        <Columns>
                                                            <asp:BoundField DataField="Numero" HeaderText="Numero" Visible="false">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Elemento" HeaderText="Elemento">
                                                                <ItemStyle Width="96%"/>
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" ButtonType="Image" 
                                                                ItemStyle-HorizontalAlign="Center" SelectImageUrl="~/Imagenes/cerrar.png"
                                                                ItemStyle-Width="4%" ControlStyle-Width="25px" ControlStyle-Height="25px" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdnValidacion" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>
                            <div class="modal fade" id="ventana1" data-backdrop="static">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>--%>
                                            <h4 class="modal-title">
                                                <span id="spnHeaderModal" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                                <asp:Label ID="lblHeaderModal" runat="server" Text="Aviso"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                <asp:Label ID="lblMsgMdl" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-primary" onclick="reload();">Aceptar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
        </div>
    </div>  
</asp:Content>
