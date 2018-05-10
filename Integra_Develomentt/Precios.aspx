<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Precios.aspx.cs" Inherits="Integra_Develomentt.Precios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsPrecios.js"></script>
    <script type="text/javascript" src="Scripts/jsMaster.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active" id="tab1"><a href="#listas" aria-controls="listas" role="tab" data-toggle="tab">Existentes</a></li>
            <li role="presentation" id="tab2"><a href="#nuevos" aria-controls="inventario" role="tab" data-toggle="tab">Nuevo</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="listas">
                <fieldset>
                    <legend style="margin-bottom:0px;">LISTAS DE PRECIOS</legend>
                    <asp:UpdatePanel ID="upnlListas" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="divMsj" role="alert" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <span id="spnMsj" runat="server" aria-hidden="true"></span>
                                <asp:Label ID="lblMsj" runat="server" Style=" font-size:medium;"></asp:Label>
                                <br />
                                <br />
                                <a class="btn btn-primary" href="#nuevos" role="button" data-toggle="tab" onclick="tab('#tab2');">Crear lista de precios</a>
                                <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                            </div>
                            <label for="drpListaPrecio">Seleccione lista:</label>
                            <asp:DropDownList ID="drpListaPrecio" runat="server" Width="100%" CssClass="form-control input-sm" 
                                 OnSelectedIndexChanged="drpListaPrecio_SelectedIndexChanged" AutoPostBack="true"/>
                            <br />
                            <div class="modal fade" id="mdlMsg" data-backdrop="static">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title">
                                                <span id="Span2" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                                <asp:Label ID="Label1" runat="server" Text="Aviso"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                <asp:Label ID="lblMdlMsg" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-primary" onclick="reload();">Aceptar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon" id="Span3"> Nombre </span>
                                <asp:TextBox ID="txtNombre" MaxLength="100" runat="server" Width="100%" 
                                    CssClass="form-control input-sm" onclick="select(this)">
                                </asp:TextBox>
                            </div>
                            <br /> 
                            <div class="table-responsive">
                                <asp:GridView ID="grvListas" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                    GridLines="None" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                    DataKeyNames="Numero, Producto, Precio, Utilidad" Style="margin:0px;">
                                    <Columns>
                                        <asp:BoundField DataField="Numero" Visible="false"/>
                                        <asp:BoundField DataField="Producto" HeaderText="Producto">
                                            <ItemStyle Width="40%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Precio" HeaderText="Precio compra">
                                            <ItemStyle Width="15%" HorizontalAlign="Center"/>
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-Width="15%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom2px;">Porcentaje</p>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtPorcentajeGrvTodos2" MaxLength="19" runat="server" OnTextChanged="txtPorcentajeGrvTodos_TextChanged"
                                                        Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true"
                                                        Style="text-align:right" onchange="mdlToggle('#mdlProceso')">
                                                    </asp:TextBox>
                                                    <span class="input-group-addon" id="Span6">%</span>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPorcentajeGrvTodos2"
                                                        FilterType="Custom, Numbers" ValidChars=".,">
                                                    </asp:FilteredTextBoxExtender>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtPorcentajeGrv2" MaxLength="19" runat="server" OnTextChanged="txtPorcentajeGrv_TextChanged"
                                                        Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true" Text='<%# Bind("Porcentaje") %>'
                                                        Style="text-align:right">
                                                    </asp:TextBox>
                                                    <span class="input-group-addon" id="Span4">%</span>
                                                    <asp:FilteredTextBoxExtender ID="ftdPorcentajeGrv2" runat="server" TargetControlID="txtPorcentajeGrv2"
                                                        FilterType="Custom, Numbers" ValidChars=".,">
                                                    </asp:FilteredTextBoxExtender>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="15%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom2px;">Precio final</p>
                                                <asp:TextBox ID="txtPrecioFinalGrvTodos2" MaxLength="19" runat="server" OnTextChanged="txtPrecioFinalGrvTodos_TextChanged"
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true" onchange="mdlToggle('#mdlProceso')">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPrecioFinalGrvTodos2"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrecioFinalGrv2" MaxLength="19" runat="server" OnTextChanged="txtPrecioFinalGrv_TextChanged"
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true" Text='<%# Bind("Precio_Final") %>'>
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdPrecioFinalgrv2" runat="server" TargetControlID="txtPrecioFinalGrv2"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Utilidad" HeaderText="Utilidad">
                                            <ItemStyle Width="15%" HorizontalAlign="Center"/>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="info" />
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="btn-group btn-group-justified" role="group">
                                <div class="btn-group" role="group">
                                    <asp:LinkButton ID="lnkModificar" runat="server" OnClick="lnkModificar_Click" OnClientClick="mdlToggle('#mdlProceso');" class="btn btn-primary">
                                        <span class="glyphicon glyphicon-pencil"></span>&nbsp;Modificar
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
            <div role="tabpanel" class="tab-pane fade" id="nuevos">
                <fieldset>
                    <legend style="margin-bottom:0px;">CREAR LISTA DE PRECIOS</legend>
                    <asp:UpdatePanel ID="upnlAlta" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="input-group">
                                <span class="input-group-addon" id="Span1"> Nombre </span>
                                <asp:TextBox ID="txtNombreLista" MaxLength="100" runat="server" Width="100%" 
                                    CssClass="form-control input-sm" onclick="select(this)">
                                </asp:TextBox>
                            </div>
                            <br /> 
                            <div class="table-responsive">
                                <asp:GridView ID="grvProductosLista" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                    GridLines="None" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                    DataKeyNames="Numero, Producto, Precio, Utilidad" Style="margin:0px;">
                                    <Columns>
                                        <asp:BoundField DataField="Numero" Visible="false"/>
                                        <asp:BoundField DataField="Producto" HeaderText="Producto">
                                            <ItemStyle Width="40%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Precio" HeaderText="Precio compra">
                                            <ItemStyle Width="15%" HorizontalAlign="Center"/>
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-Width="15%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom:2px;">Porcentaje</p>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtPorcentajeGrvTodos" MaxLength="19" runat="server" OnTextChanged="txtPorcentajeGrvTodos_TextChanged"
                                                        Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true"
                                                        Style="text-align:right" onchange="mdlToggle('#mdlProceso')">
                                                    </asp:TextBox>
                                                    <span class="input-group-addon" id="Spn">%</span>
                                                    <asp:FilteredTextBoxExtender ID="ftdPorcentajeGrvTodos" runat="server" TargetControlID="txtPorcentajeGrvTodos"
                                                        FilterType="Custom, Numbers" ValidChars=".,">
                                                    </asp:FilteredTextBoxExtender>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtPorcentajeGrv" MaxLength="19" runat="server" OnTextChanged="txtPorcentajeGrv_TextChanged"
                                                        Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true"
                                                        Style="text-align:right">
                                                    </asp:TextBox>
                                                    <span class="input-group-addon" id="Span4">%</span>
                                                    <asp:FilteredTextBoxExtender ID="ftdPorcentajeGrv" runat="server" TargetControlID="txtPorcentajeGrv"
                                                        FilterType="Custom, Numbers" ValidChars=".,">
                                                    </asp:FilteredTextBoxExtender>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="15%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom:2px;">Precio final</p>
                                                <asp:TextBox ID="txtPrecioFinalGrvTodos" MaxLength="19" runat="server" OnTextChanged="txtPrecioFinalGrvTodos_TextChanged"
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true" onchange="mdlToggle('#mdlProceso')">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdPrecioFinalgrvTodos" runat="server" TargetControlID="txtPrecioFinalGrvTodos"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrecioFinalGrv" MaxLength="19" runat="server" OnTextChanged="txtPrecioFinalGrv_TextChanged"
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)" AutoPostBack="true">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdPrecioFinalgrv" runat="server" TargetControlID="txtPrecioFinalGrv"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Utilidad" HeaderText="Utilidad">
                                            <ItemStyle Width="15%" HorizontalAlign="Center"/>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="info"/>
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="btn-group btn-group-justified" role="group">
                                <div class="btn-group" role="group">
                                    <asp:LinkButton ID="lnkGuardar" runat="server" OnClick="lnkGuardar_Click" OnClientClick="mdlToggle('#mdlProceso');" class="btn btn-success">
                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Guardar
                                    </asp:LinkButton>
                                </div>
                            </div>
                       </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <Triggers>
                </Triggers>
                <ContentTemplate>
                    <asp:HiddenField ID="hdnValidacion" runat="server" />
                    <div class="modal fade" id="mdlError">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">
                                        <span id="spnHeaderModal" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                        <asp:Label ID="lblHeaderMdlError" runat="server" Text="Error"></asp:Label>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblMsgMdlError" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="mdlMensaje" data-backdrop="static">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">
                                        <span id="Span5" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                        <asp:Label ID="lblHeaderModal" runat="server" Text="Aviso"></asp:Label>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblMsgMdlMensaje" runat="server" Text=""></asp:Label>
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
        </div>
    </div>
</asp:Content>
