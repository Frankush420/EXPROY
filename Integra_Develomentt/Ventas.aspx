<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Ventas.aspx.cs" Inherits="Integra_Develomentt.Ventas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsVentas.js"></script>
    <script type="text/javascript" src="Scripts/jsMaster.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <fieldset>
            <legend style="margin-bottom:0px;">VENTAS</legend>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:HiddenField ID="keycontainer" runat="server" />
                    <asp:HiddenField ID="hdnProducto" runat="server" />
                    <asp:HiddenField ID="hdnListaPrecio" runat="server" />
                    <asp:HiddenField ID="hdnValidacion" runat="server" />
                    <div class="modal fade" id="mdlError">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label ID="lblHeaderMdlError" runat="server">
                                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp;Error
                                        </asp:Label>
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
                    <div class="modal fade" id="mdlAviso" data-backdrop="static">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">
                                        <asp:Label ID="Label1" runat="server">
                                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp;Aviso
                                        </asp:Label>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblMdlAviso" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-primary" onclick="reload();">Aceptar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade bs-example-modal-lg" id="mdlClientes">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label ID="Label3" runat="server">
                                        <span class="glyphicon glyphicon-user"></span><span class="glyphicon glyphicon-search"></span>&nbsp;BÚSQUEDA DE TODOS LOS CLIENTES
                                        </asp:Label>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <ul class="nav nav-tabs" role="tablist">
                                        <li role="presentation" class="active" id="tabmdl1"><a href="#ClientesFisicos" aria-controls="ClientesFisicos" role="tab" data-toggle="tab">Persona Fisica</a></li>
                                        <li role="presentation" id="tabmdl2"><a href="#ClientesMorales" aria-controls="ClientesMorales" role="tab" data-toggle="tab">Persona Moral</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="ClientesFisicos">
                                            <p class="text-center">
                                                <div id="divAlertFisicas" role="alert" runat="server" visible="false">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                    <span id="spnDivAlertFisicas" runat="server" aria-hidden="true"></span>
                                                    <asp:Label ID="lblDivAlertFisicas" runat="server" Style=" font-size:medium;"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <a class="btn btn-primary" href="Clientes.aspx" role="button">Agregar clientes fisicos</a>
                                                    <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grvClientesFisicos" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                                        GridLines="None" ShowHeader="True" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                                        DataKeyNames="Numero, Nombre, RFC, Celular, Correo_Electronico, Domicilio, Lista_Precios" Style="margin:0px;"
                                                        OnRowDataBound="grvClientesFisicos_RowDataBound" OnSelectedIndexChanged="grvClientesFisicos_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="Numero" Visible="false"/>
                                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                                <ItemStyle Width="23%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RFC" HeaderText="RFC">
                                                                <ItemStyle Width="10%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Celular" HeaderText="Celular">
                                                                <ItemStyle Width="10%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Correo_Electronico" HeaderText="E-mail">
                                                                <ItemStyle Width="23%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio">
                                                                <ItemStyle Width="21%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Lista_Precios" HeaderText="Lista de precios">
                                                                <ItemStyle Width="13%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
                                                        </Columns>
                                                        <HeaderStyle CssClass="info" />
                                                    </asp:GridView>
                                                </div>
                                            </p>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="ClientesMorales">
                                            <p class="text-center">
                                                <div id="divAlertMorales" role="alert" runat="server" visible="false">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                    <span id="spnDivAlertMorales" runat="server" aria-hidden="true"></span>
                                                    <asp:Label ID="lblDivAlertMorales" runat="server" Style=" font-size:medium;"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <a class="btn btn-primary" href="Clientes.aspx" role="button">Agregar clientes morales</a>
                                                    <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grvClientesMorales" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                                        GridLines="None" ShowHeader="True" Width="100%" CssClass="table table-responsive table-striped table-bordered table-hover table-condensed"
                                                        DataKeyNames="Numero, Nombre, Nombre_Corto, RFC, Correo_Electronico, Domicilio, Lista_Precios" Style="margin:0px;" HeaderStyle-CssClass="info"
                                                        OnRowDataBound="grvClientesMorales_RowDataBound" OnSelectedIndexChanged="grvClientesMorales_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="Numero" Visible="false"/>
                                                            <asp:BoundField DataField="Nombre" HeaderText="Razón Social">
                                                                <ItemStyle Width="23%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Nombre_Corto" HeaderText="Nombre corto">
                                                                <ItemStyle Width="10%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RFC" HeaderText="RFC">
                                                                <ItemStyle Width="10%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Correo_Electronico" HeaderText="E-mail">
                                                                <ItemStyle Width="23%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio">
                                                                <ItemStyle Width="21%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Lista_Precios" HeaderText="Lista de precios">
                                                                <ItemStyle Width="13%" Font-Size="X-Small"/>
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="mdlProductos">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label ID="Label2" runat="server">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp;BÚSQUEDA DE TODOS LOS PRODUCTOS
                                        </asp:Label>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <p class="text-center">
                                        <div id="divAlertProductos" role="alert" runat="server" visible="false">
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                            <span id="splAlertProductos" runat="server" aria-hidden="true"></span>
                                            <asp:Label ID="lblAlertProductos" runat="server" Style=" font-size:medium;"></asp:Label>
                                            <br />
                                            <br />
                                            <a class="btn btn-primary" href="Productos.aspx" role="button">Agregar productos</a>
                                            <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                        </div>
                                        <div class="table-responsive">
                                        <%--OnSelectedIndexChanged="grvProductos_SelectedIndexChanged"--%>
                                            <asp:GridView ID="grvProductos" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled" Style="margin:0px;"
                                                GridLines="None" ShowHeader="True" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                                OnRowDataBound="grvProductos_RowDataBound" 
                                                DataKeyNames="Numero" HeaderStyle-CssClass="info">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <%--<HeaderTemplate>
                                                            <asp:CheckBox ID="chkTodos" runat="server"/>
                                                        </HeaderTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkIndividual" runat="server" onchange="Check(this);"/> 
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Numero" Visible="false"/>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Producto">
                                                        <ItemStyle Width="100%" Font-Size="X-Small"/>
                                                    </asp:BoundField>
                                                   <%-- <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>--%>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:HiddenField runat="server" ID="hdnProductosSeleccionados" />
                                        </div>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                    <asp:LinkButton ID="lnkAgregarProductos" runat="server" class="btn btn-primary" OnClientClick="mdlToggle2('#mdlProductos','#mdlProceso');">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp; Agregar productos
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="form-inline">
                                <div class="form-group" Style="width:100%">
                                    <label>CLIENTE: </label>
                                    <asp:TextBox ID="txtBusquedaCliente" runat="server" AutoPostBack="true" 
                                        CssClass="form-control input-sm" OnTextChanged="txtBusquedaCliente_TextChanged"
                                        Width="40%" Placeholder="Ingrese un cliente...">
                                    </asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AcmpTxtBusquedaCliente" runat="server" ServicePath="WSClientes.asmx"
                                        ServiceMethod="ObtenerClientes" MinimumPrefixLength="1" EnableCaching="true"
                                        TargetControlID="txtBusquedaCliente" UseContextKey="true" CompletionSetCount="10"
                                        CompletionInterval="0" OnClientItemSelected="GetKey">
                                    </asp:AutoCompleteExtender>
                                    <button type="button" class="btn btn-primary input-sm" runat="server" id="btnTodos" onclick="mdlToggle('#mdlClientes')">
                                        Todos los clientes
                                    </button>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading" role="tab" id="headingOne">
                                    <h4 class="panel-title">
                                        <a role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                            <asp:Label ID="lblNombreCliente" runat="server" Text=""/>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                    <div class="panel-body">
                                        <dl class="dl-horizontal" style="margin:0px;">
                                            <dt>RFC </dt>
                                            <dd><asp:Label ID="lblRFC" runat="server" Text=""/></dd>
                                            <dt>DOMICILIO </dt>
                                            <dd><asp:Label ID="lblDomicilio" runat="server" Text=""/></dd>
                                            <dt>COLONIA </dt>
                                            <dd><asp:Label ID="lblColonia" runat="server" Text=""/></dd>
                                            <dt>DELEGACIÓN</dt>
                                            <dd><asp:Label ID="lblDelegacion" runat="server" Text=""/></dd>
                                            <dt>C.P. </dt>
                                            <dd><asp:Label ID="lblCodigoPostal" runat="server" Text=""/></dd>
                                            <dt>ESTADO</dt>
                                            <dd><asp:Label ID="lblEstado" runat="server" Text=""/></dd>
                                            <dt>TELÉFONO</dt>
                                            <dd><asp:Label ID="lblTelefono" runat="server" Text=""/></dd>
                                        </dl>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="form-inline">
                                <div class="form-group" Style="width:100%">
                                    <label>PRODUCTO: </label>
                                    <asp:TextBox ID="txtBusquedaProducto" runat="server" AutoPostBack="true" 
                                        CssClass="form-control input-sm" OnTextChanged="txtBusquedaProducto_TextChanged"
                                        Width="40%" Placeholder="Ingrese un producto...">
                                    </asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AcmpTxtBusquedaProducto" runat="server" ServicePath="WSProductos.asmx"
                                        ServiceMethod="ObtenerProductos" MinimumPrefixLength="1" EnableCaching="true"
                                        TargetControlID="txtBusquedaProducto" UseContextKey="true" CompletionSetCount="10"
                                        CompletionInterval="0" OnClientItemSelected="GetKeyProduct">
                                    </asp:AutoCompleteExtender>
                                    <button type="button" class="btn btn-primary input-sm" runat="server" id="Button1" onclick="mdlToggle('#mdlProductos')">
                                        Todos los productos
                                    </button>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <div class="table-responsive" style="overflow:scroll; height:300px;">
                                <asp:GridView ID="grvPartidas" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                    GridLines="None" ShowHeader="True" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                    DataKeyNames="Numero_Producto" Style="padding:20px;">
                                    <Columns>
                                        <asp:BoundField DataField="Numero_Producto" Visible="false"/>
                                        <asp:TemplateField ItemStyle-Width="11%" HeaderText="Existencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExistencia" runat="server" Text='<%# Bind("Existencia") %>'
                                                    data-toggle="tooltip" data-placement="top" title="Existencia"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="15%" HeaderText="Almacén">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="drpAlmacenGrv" runat="server" Width="100%" CssClass="form-control input-sm"
                                                    data-toggle="tooltip" data-placement="top" title="Almacén">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="35%" HeaderText="Producto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProducto" runat="server" Text='<%# Bind("Producto") %>'
                                                    data-toggle="tooltip" data-placement="top" title="Producto"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="11%" HeaderText="Cantidad">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidadGrv" MaxLength="19" runat="server" Text='<%# Bind("Cantidad") %>'
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)"
                                                    data-toggle="tooltip" data-placement="top" title="Cantidad">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdCantidadGrv" runat="server" TargetControlID="txtCantidadGrv"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="11%" HeaderText="Precio">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrecioGrv" MaxLength="19" runat="server" Text='<%# Bind("Precio") %>'
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)"
                                                    data-toggle="tooltip" data-placement="top" title="Precio">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdPrecioGrv" runat="server" TargetControlID="txtPrecioGrv"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="11%" HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'
                                                    data-toggle="tooltip" data-placement="top" title="Total"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%">
                                            <HeaderTemplate>
                                                <span class="badge">
                                                    <asp:Label ID="lblContadorPartidas" runat="server" Text="0"/>
                                                </span>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEliminarPartida" runat="server" CssClass="btn btn-danger"
                                                    OnClick="lnkEliminarPartida_Click" OnClientClick="mdlToggle('#mdlProceso')"
                                                    data-toggle="tooltip" data-placement="top" title="Eliminar partida">
                                                    <span class="glyphicon glyphicon-remove"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/>
                                    </Columns>
                                    <HeaderStyle CssClass="info" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                            <table style="width:100%;" class="table table-hover table-condensed table-bordered">
                                <tr>
                                    <td class="info">
                                        <small><label>subtotal</label></small>
                                    </td>
                                    <td class="success" style="text-align:right">
                                        <small><label>0.00</label></small>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <small><label>iva</label></small>
                                    </td>
                                    <td class="success" style="text-align:right">
                                        <small><label>0.00</label></small>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">
                                        <small><label>total</label></small>
                                    </td>
                                    <td class="success" style="text-align:right">
                                        <small><label>0.00</label></small>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </fieldset>
    </div>
</asp:Content>
