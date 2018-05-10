<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Productos.aspx.cs" Inherits="Integra_Develomentt.Productos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsProductos.js"></script>
    <script type="text/javascript" src="Scripts/jsMaster.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active" id="tab1"><a href="#disponibles" aria-controls="disponibles" role="tab" data-toggle="tab">Disponibles</a></li>
            <li role="presentation" id="tab2"><a href="#nuevos" aria-controls="nuevos" role="tab" data-toggle="tab">Nuevo</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="disponibles">
                <fieldset>
                    <legend>PRODUCTOS DISPONIBLES</legend>
                    <asp:UpdatePanel ID="upnlDisponibles" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal fade" id="mdlEliminarProducto">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title">
                                                <span id="Span6" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                                <asp:Label ID="lblHeaderMdl" runat="server" Text="Aviso"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                <asp:Label ID="lblMdlEliminarProducto" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <asp:LinkButton ID="lnkMdlEliminar" runat="server" class="btn btn-danger" OnClientClick="mdlToggle2('#mdlEliminarProducto','#mdlProceso');"
                                                OnClick="lnkMdlEliminar_Click">
                                                <span class="glyphicon glyphicon-trash"></span>&nbsp; Eliminar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal fade" id="mdlModificarProducto">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title">
                                                <span id="Span7" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                                <asp:Label ID="Label1" runat="server" Text="Aviso"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                <asp:Label ID="lblMdlModificarProducto" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <asp:LinkButton ID="lnkMdlModificar" runat="server" class="btn btn-primary" OnClientClick="mdlToggle2('#mdlModificarProducto','#mdlProceso');"
                                                OnClick="lnkMdlModificar_Click">
                                                <span class="glyphicon glyphicon-pencil"></span>&nbsp; Modificar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divMsj" role="alert" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <span id="spnMsj" runat="server" aria-hidden="true"></span>
                                <asp:Label ID="lblMsj" runat="server" Style=" font-size:medium;"></asp:Label>
                                <br />
                                <br />
                                <a class="btn btn-primary" href="#nuevos" role="button" data-toggle="tab" onclick="tabNuevos();">Agregar Productos</a>
                                <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grvProductosConsulta" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled" Style="margin:0px;"
                                    GridLines="None" ShowHeader="True" Width="100%" CssClass="table table-striped table-bordered table-condensed table-hover"
                                    DataKeyNames="Numero, Nombre, Caracteristicas, Precio, Clave, Codigo_Barras, Estatus"
                                    OnSelectedIndexChanged="grvProductos_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Numero" Visible="false"/>
                                        <asp:TemplateField ItemStyle-Width="17.5%" HeaderText="Producto" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNombreGrv" MaxLength="200" runat="server" Text='<%# Bind("Nombre") %>'
                                                    Width="98%" CssClass="form-control input-sm" onclick="select(this)">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="17.5%" HeaderText="Características" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCaracteristicasGrv" MaxLength="50" runat="server" Text='<%# Bind("Caracteristicas") %>'
                                                    Width="98%" CssClass="form-control input-sm" onclick="select(this)">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="17.5%" HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrecioGrv" MaxLength="19" runat="server" Text='<%# Bind("Precio") %>'
                                                    Width="98%" CssClass="form-control input-sm" onclick="select(this)">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdPreciogrv" runat="server" TargetControlID="txtPrecioGrv"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="17.5%" HeaderText="Clave" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtClaveGrv" MaxLength="19" runat="server" Text='<%# Bind("Clave") %>'
                                                    Width="98%" CssClass="form-control input-sm" onclick="select(this)">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="17.5%" HeaderText="Código de Barras" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCodigo_BarrasGrv" MaxLength="19" runat="server" Text='<%# Bind("Codigo_Barras") %>'
                                                    Width="98%" CssClass="form-control input-sm" onclick="select(this)">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEditarProducto" runat="server" class="btn btn-primary"
                                                    data-toggle="tooltip" data-placement="top" title="Modificar"
                                                    OnClick="lnkEditarProducto_Click">
                                                    <span class="glyphicon glyphicon-pencil"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEliminarProducto" runat="server" class="btn btn-danger"
                                                    data-toggle="tooltip" data-placement="top" title="Eliminar"
                                                    OnClick="lnkEliminarProducto_Click">
                                                    <span class="glyphicon glyphicon-trash"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Estatus" Visible="false">
                                            <ItemStyle Width="6%"/>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="info" />
                                </asp:GridView>
                            </div>
                            <button onclick="ATabNuevos();" type="button" class="btn btn-default" id="btn1">Prueba</button>
                                <%--<a class="btn btn-primary" href="#nuevos" role="button" data-toggle="tab" onclick="tabNuevos();">Agregar Productos</a>
                                <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <%--<fieldset>
                    <legend>HEY</legend>
                    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="upnl">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="fupXLS" runat="server" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" AllowMultiple="true"/>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:LinkButton ID="lnkXLS" runat="server" class="btn btn-danger" OnClick="btnXML_Click" Style="display: none;"/>
                </fieldset>--%>
            </div>
            <div role="tabpanel" class="tab-pane fade" id="nuevos">
                <fieldset>
                    <legend style="margin-bottom:0px;">AGREGAR UN PRODUCTO</legend>
                    <asp:UpdatePanel ID="upnlAgregar" runat="server" UpdateMode="Always">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>
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
                            <div id="divMensaje2" role="alert" runat="server" visible="false">
                                <span id="spnMensaje2" runat="server" aria-hidden="true"></span>
                                <asp:Label ID="lblMensaje2" runat="server" Style=" font-size:medium;"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div id="divImp" role="alert" runat="server" class="alert alert-success">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                        <span id="spnImp" runat="server" aria-hidden="true" class="glyphicon glyphicon-open-file"></span>
                                        Puedes agregar tus productos desde un archivo <strong>Excel</strong> haciendo click en el botón debajo.
                                        <br />
                                        <br />
                                        <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="upnl">
                                            <Triggers>
                                                <%--<asp:AsyncPostBackTrigger ControlID="lnkXLS" />--%>
                                                <asp:PostBackTrigger ControlID="lnkXLS" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:FileUpload ID="fupXLS" runat="server" AllowMultiple="true" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"/>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    
                                </div>
                            </div>
                            <asp:Panel ID="Panel2" runat="server" DefaultButton="lnkAgregar">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <h5 style="margin:5px;">Producto</h5>
                                        <div class="input-group" style="margin:5px;">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-default" onclick="borrartxt(MainContent_txtProducto);">
                                                    <span class="glyphicon glyphicon-erase"></span>
                                                </button>
                                            </span>
                                            <asp:TextBox ID="txtProducto" runat="server" MaxLength="200" CssClass="form-control" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <h5 style="margin:5px;">Precio</h5>
                                        <div class="input-group" style="margin:5px;">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-default" onclick="borrartxt(MainContent_txtPrecio);">
                                                    <span class="glyphicon glyphicon-erase"></span>
                                                </button>
                                            </span>
                                            <asp:TextBox ID="txtPrecio" runat="server" MaxLength="19" CssClass="form-control" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftdPrecio" runat="server" TargetControlID="txtPrecio"
                                                FilterType="Custom, Numbers" ValidChars=".">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <h5 style="margin:5px;">Características</h5>                                        
                                        <div class="input-group" style="margin:5px;">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-default" onclick="borrartxt(MainContent_txtCaracteristicas);">
                                                    <span class="glyphicon glyphicon-erase"></span>
                                                </button>
                                            </span>
                                            <asp:TextBox ID="txtCaracteristicas" runat="server" MaxLength="50" CssClass="form-control" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <h5 style="margin:5px;">Clave</h5>                                        
                                        <div class="input-group" style="margin:5px;">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-default" onclick="borrartxt(MainContent_txtClave);">
                                                    <span class="glyphicon glyphicon-erase"></span>
                                                </button>
                                            </span>
                                            <asp:TextBox ID="txtClave" runat="server" MaxLength="135" CssClass="form-control" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <h5 style="margin:5px;">Código de Barras</h5>
                                        <div class="input-group" style="margin:5px;">
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-default" onclick="borrartxt(MainContent_txtCodigoBarras);">
                                                    <span class="glyphicon glyphicon-erase"></span>
                                                </button>
                                            </span>
                                            <asp:TextBox ID="txtCodigoBarras" runat="server" MaxLength="135" CssClass="form-control" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="btn-group btn-group-justified" role="group" style="margin:5px;">
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton ID="lnkAgregar" runat="server" OnClick="lnkAgregar_Click" OnClientClick="ValidarCampos2();" class="btn btn-default">
                                                    <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar
                                                </asp:LinkButton>
                                            </div>
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton ID="lnkGuardar" runat="server" OnClick="lnkGuardar_Click" OnClientClick="mdlToggle('#mdlProceso');" class="btn btn-success">
                                                    <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Guardar
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:UpdatePanel ID="upnlElementos" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkAgregar"/>
                                            </Triggers>
                                            <ContentTemplate>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grvProductos" runat="server" CellPadding="0" AutoGenerateColumns="False" Style="margin:0px;"
                                                        GridLines="None" ShowHeader="True" Width="100%" ViewStateMode="Enabled" 
                                                        CssClass="table table-striped table-bordered table-condensed table-hover"
                                                        OnSelectedIndexChanged="grvProductos_SelectedIndexChanged" DataKeyNames="Producto, Caracteristicas, Precio,
                                                        Clave, Codigo">
                                                        <Columns>
                                                            <asp:BoundField DataField="Producto" HeaderText="Producto">
                                                                <ItemStyle Width="30%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Caracteristicas" HeaderText="Características">
                                                                <ItemStyle Width="30%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                                <ItemStyle Width="12%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Clave" HeaderText="Clave">
                                                                <ItemStyle Width="12%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Codigo" HeaderText="Código de Barras">
                                                                <ItemStyle Width="12%"/>
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" ButtonType="Image" 
                                                                ItemStyle-HorizontalAlign="Center" SelectImageUrl="~/Imagenes/cerrar.png"
                                                                ItemStyle-Width="4%" ControlStyle-Width="25px" ControlStyle-Height="25px" />
                                                        </Columns>
                                                        <HeaderStyle CssClass="info" />
                                                    </asp:GridView>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel UpdateMode="Always" runat="server" ID="UpdatePanel2">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>
                    <asp:LinkButton ID="lnkXLS" runat="server" class="btn btn-danger" OnClick="lnkXLS_Click" Style="display: none;"/>
                    <a class="btn btn-primary hidden" id="aTabNuevos" href="#nuevos" role="button" data-toggle="tab" onclick="tabNuevos();">Agregar Productos</a>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <Triggers>
                </Triggers>
                <ContentTemplate>
                    <asp:HiddenField ID="hdnValidacion" runat="server" />
                    <asp:HiddenField ID="hdnIndexProducto" runat="server" />
                    <asp:HiddenField ID="hdnNumeroProducto" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
