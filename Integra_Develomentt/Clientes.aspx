<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Clientes.aspx.cs" Inherits="Integra_Develomentt.Clientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsClientes.js"></script>
    <script type="text/javascript" src="Scripts/jsMaster.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active" id="tab1"><a href="#clientes" aria-controls="clientes" role="tab" data-toggle="tab">Clientes</a></li>
            <li role="presentation" id="tab2"><a href="#nuevos" aria-controls="nuevos" role="tab" data-toggle="tab">Nuevo</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="clientes">
                <fieldset>
                    <legend style="margin-bottom:0px;">CLIENTES</legend>
                    <asp:UpdatePanel ID="upnl3" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal fade" id="mdlEliminarCliente">
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
                                                <asp:Label ID="lblMdlEliminarCliente" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <asp:LinkButton ID="lnkMdlEliminar" runat="server" class="btn btn-danger" OnClientClick="mdlToggle2('#mdlEliminarCliente','#mdlProceso');"
                                                OnClick="lnkMdlEliminar_Click">
                                                <span class="glyphicon glyphicon-trash"></span>&nbsp; Eliminar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal fade" id="mdlModificarCliente">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title">
                                                <span id="Span7" runat="server" aria-hidden="true" class="glyphicon glyphicon-info-sign"></span>
                                                <asp:Label ID="Label4" runat="server" Text="Aviso"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>
                                                <asp:Label ID="lblMdlModificarCliente" runat="server" Text=""></asp:Label>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <asp:LinkButton ID="lnkMdlModificar" runat="server" class="btn btn-primary" OnClientClick="mdlToggle2('#mdlModificarCliente','#mdlProceso');"
                                                OnClick="lnkMdlModificar_Click">
                                                <span class="glyphicon glyphicon-pencil"></span>&nbsp; Modificar
                                            </asp:LinkButton>
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
                                                            <button type="button" class="btn btn-primary" data-toggle="tab" data-target="#nuevos" onclick="ClientesFisicos()">Alta de clientes fisicos</button>
                                                            <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="grvClientesFisicos" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                                                GridLines="None" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                                                DataKeyNames="Numero, Nombre, RFC, Celular, Correo_Electronico, Domicilio, Lista_Precios" style="margin:0px;"
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
                                                                <HeaderStyle CssClass="info"/>
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
                                                            <button type="button" class="btn btn-primary" data-toggle="tab" data-target="#nuevos" onclick="ClientesMorales()">Alta de clientes morales</button>
                                                            <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="grvClientesMorales" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                                                GridLines="None" Width="100%" CssClass="table table-responsive table-striped table-bordered table-hover table-condensed"
                                                                DataKeyNames="Numero, Nombre, Nombre_Corto, RFC, Correo_Electronico, Domicilio, Lista_Precios" style="margin:0px;"
                                                                OnRowDataBound="grvClientesMorales_RowDataBound" OnSelectedIndexChanged="grvClientesMorales_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Numero" Visible="false"/>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Razón Social">
                                                                        <ItemStyle Width="23%" Font-Size="X-Small"/>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre_Corto" HeaderText="Nombre Corto">
                                                                        <ItemStyle Width="10%" Font-Size="X-Small"/>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="RFC" HeaderText="RFC">
                                                                        <ItemStyle Width="10%" Font-Size="X-Small" />
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
                                                                <HeaderStyle CssClass="info"/>
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
                            <asp:HiddenField ID="hdnNumero_Domicilio" runat="server" />
                            <asp:HiddenField ID="keycontainer" runat="server" />
                            <div id="divMsj2" role="alert" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                        <span id="spnMsj2" runat="server" aria-hidden="true"></span>
                                        <asp:Label ID="lblMsj2" runat="server" Style=" font-size:medium;"></asp:Label>
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-primary" role="button" onclick="">Alta de Clientes</button>
                                        <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="form-group" style="margin:5px;">
                                        <label>BÚSQUEDA: </label>
                                        <div class="form-inline">
                                            <div class="form-group" Style="width:100%">
                                                <asp:TextBox ID="txtBusqueda" runat="server" AutoPostBack="true" 
                                                CssClass="form-control input-sm" OnTextChanged="txtBusqueda_TextChanged"
                                                Width="40%" Placeholder="Ingrese un cliente...">
                                                </asp:TextBox>
                                                <asp:AutoCompleteExtender ID="AcmpTxtBusqueda" runat="server" ServicePath="WSClientes.asmx"
                                                    ServiceMethod="ObtenerClientesPorPersonalidad" MinimumPrefixLength="1" EnableCaching="true"
                                                    TargetControlID="txtBusqueda" UseContextKey="true" CompletionSetCount="10"
                                                    CompletionInterval="0" OnClientItemSelected="GetKey">
                                                </asp:AutoCompleteExtender>
                                                <button type="button" class="btn btn-primary input-sm" runat="server" id="btnTodos" onclick="mdlToggle('#mdlClientes')">
                                                    Todos los clientes
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label for="drpTipoPersona2">Tipo de persona:</label>
                                    <asp:DropDownList ID="drpTipoPersona2" runat="server" Width="100%" CssClass="form-control input-sm" 
                                         OnSelectedIndexChanged="drpTipoPersona_SelectedIndexChanged" AutoPostBack="true"/>
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label><u>DATOS GENERALES</u></label>
                                </div>
                            </div>
                            <div id="divFisicas2" runat="server">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Nombre</h5>
                                            <asp:TextBox ID="txtNombreFisicas2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Apellido paterno</h5>
                                            <asp:TextBox ID="txtPaterno2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Apellido materno</h5>
                                            <asp:TextBox ID="txtMaterno2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Nombre corto</h5>
                                            <asp:TextBox ID="txtNombreCortoFisicas2" runat="server" MaxLength="25" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">CURP</h5>
                                            <asp:TextBox ID="txtCURP2" runat="server" MaxLength="18" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:1px;">RFC</h5>
                                            <asp:TextBox ID="txtRFCFisicas2" runat="server" MaxLength="36" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Fecha de Nacimiento</h5>
                                            <%--<asp:TextBox ID="txtFechaNacimiento2" runat="server"  CssClass="form-control input-sm">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fbxFechaCaducidad" runat="server" TargetControlID="txtFechaNacimiento2"
                                                FilterType="Custom, Numbers" ValidChars="/">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:CalendarExtender ID="cexFechaDeCaducidad" runat="server" TargetControlID="txtFechaNacimiento2">
                                            </asp:CalendarExtender>--%>
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtFechaNacimiento2" runat="server" MaxLength="11" 
                                                        CssClass="form-control input-sm">
                                                    </asp:TextBox>
                                                    <button type="button" class="btn btn-primary input-sm" runat="server" id="btnFecha2">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </button>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFechaNacimiento2"
                                                        Mask="99/99/9999" MessageValidatorTip="true" MaskType="Date" ErrorTooltipEnabled="True">
                                                    </asp:MaskedEditExtender>
                                                    <asp:MaskedEditValidator ID="dateMaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                        ControlToValidate="txtFechaNacimiento2" EmptyValueMessage="La fecha es requerida" InvalidValueMessage="La fecha es incorrecta"
                                                        Display="Dynamic" TooltipMessage=""></asp:MaskedEditValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="dateMaskedEditValidator2"
                                                        Enabled="True" runat="server">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaNacimiento2"
                                                        PopupButtonID="btnFecha2" >
                                                    </asp:CalendarExtender>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Teléfono Celular</h5>
                                            <asp:TextBox ID="txtCelular2" runat="server" MaxLength="20" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCelular2"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Correo Electrónico</h5>
                                            <asp:TextBox ID="txtCorreoFisicas2" runat="server" MaxLength="50" 
                                                CssClass="form-control input-sm" onclick="select(this)" type="mail">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divMorales2" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Razón Social</h5>
                                            <asp:TextBox ID="txtNombreMorales2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Nombre corto</h5>
                                            <asp:TextBox ID="txtNombreCortoMorales2" runat="server" MaxLength="25" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">RFC</h5>
                                            <asp:TextBox ID="txtRFCMorales2" runat="server" MaxLength="36" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Correo Electrónico</h5>
                                            <asp:TextBox ID="txtCorreoMorales2" runat="server" MaxLength="50" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label><u>DOMICILIO</u></label>
                                </div>
                            </div>
                            <div id="divDomicilio2" runat="server">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Calle y número</h5>
                                            <asp:TextBox ID="txtDomicilio2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Colonia</h5>
                                            <asp:TextBox ID="txtColonia2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Código Postal</h5>
                                            <asp:TextBox ID="txtCP2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCP2"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Delegación / Municipio</h5>
                                            <asp:TextBox ID="txtDelMun2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Estado</h5>
                                            <asp:TextBox ID="txtEstado2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Telefono</h5>
                                            <asp:TextBox ID="txtTelefonoDomicilio2" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtTelefonoDomicilio2"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <label><u>DETALLES</u></label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Lista de precios</h5>
                                            <asp:DropDownList ID="drpListaPrecios2" runat="server" Width="100%" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="divAccionesCliente" visible="false">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                            <div class="btn-group" role="group">
                                                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#mdlEliminarCliente">
                                                    <span class="glyphicon glyphicon-trash"></span>&nbsp; Eliminar cliente
                                                </button>
                                            </div>
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton ID="lnkModificarDatos" runat="server" class="btn btn-primary" OnClientClick="ValidarCampos2();" 
                                                    OnClick="lnkModificarDatos_Click" >
                                                    <span class="glyphicon glyphicon-pencil"></span>&nbsp; Modificar datos
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
            <div role="tabpanel" class="tab-pane fade" id="nuevos">
                <fieldset>
                    <legend style="margin-bottom:0px;">ALTA DE CLIENTES</legend>
                    <asp:UpdatePanel ID="upnlAlta" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="divMsj" role="alert" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                        <span id="spnMsj" runat="server" aria-hidden="true"></span>
                                        <asp:Label ID="lblMsj" runat="server" Style=" font-size:medium;"></asp:Label>
                                        <br />
                                        <br />
                                
                                        <button type="button" class="btn btn-primary" role="button" onclick="redirect('Precios.aspx');">Crear Lista de Precios</button>
                                        <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label for="drpTipoPersona">Tipo de persona:</label>
                                    <asp:DropDownList ID="drpTipoPersona" runat="server" Width="100%" CssClass="form-control input-sm" 
                                         OnSelectedIndexChanged="drpTipoPersona_SelectedIndexChanged" AutoPostBack="true"/>
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label><u>DATOS GENERALES</u></label>
                                </div>
                            </div>
                            <div id="divFisicas" runat="server">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Nombre</h5>
                                            <asp:TextBox ID="txtNombreFisicas" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Apellido paterno</h5>
                                            <asp:TextBox ID="txtPaterno" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Apellido materno</h5>
                                            <asp:TextBox ID="txtMaterno" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Nombre corto</h5>
                                            <asp:TextBox ID="txtNombreCortoFisicas" runat="server" MaxLength="25" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">CURP</h5>
                                            <asp:TextBox ID="txtCURP" runat="server" MaxLength="18" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">RFC</h5>
                                            <asp:TextBox ID="txtRFCFisicas" runat="server" MaxLength="36" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Fecha de Nacimiento</h5>
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="11" 
                                                        CssClass="form-control input-sm">
                                                    </asp:TextBox>
                                                    <button type="button" class="btn btn-primary input-sm" runat="server" id="btnFecha">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </button>
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaNacimiento"
                                                        Mask="99/99/9999" MessageValidatorTip="true" MaskType="Date" ErrorTooltipEnabled="True">
                                                    </asp:MaskedEditExtender>
                                                    <asp:MaskedEditValidator ID="dateMaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                        ControlToValidate="txtFechaNacimiento" EmptyValueMessage="La fecha es requerida" InvalidValueMessage="La fecha es incorrecta"
                                                        Display="Dynamic" TooltipMessage=""></asp:MaskedEditValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="dateMaskedEditValidator1"
                                                        Enabled="True" runat="server">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaNacimiento"
                                                        PopupButtonID="btnFecha" >
                                                    </asp:CalendarExtender>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Teléfono Celular</h5>
                                            <asp:TextBox ID="txtCelular" runat="server" MaxLength="20" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftdCelular" runat="server" TargetControlID="txtCelular"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Correo Electrónico</h5>
                                            <asp:TextBox ID="txtCorreoFisicas" runat="server" MaxLength="50" 
                                                CssClass="form-control input-sm" onclick="select(this)" type="mail">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divMorales" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Razón Social</h5>
                                            <asp:TextBox ID="txtNombreMorales" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Nombre corto</h5>
                                            <asp:TextBox ID="txtNombreCortoMorales" runat="server" MaxLength="25" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">RFC</h5>
                                            <asp:TextBox ID="txtRFCMorales" runat="server" MaxLength="36" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Correo Electrónico</h5>
                                            <asp:TextBox ID="txtCorreoMorales" runat="server" MaxLength="50" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label><u>DOMICILIO</u></label>
                                </div>
                            </div>
                            <div id="divDomicilio" runat="server">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Calle y número</h5>
                                            <asp:TextBox ID="txtDomicilio" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Colonia</h5>
                                            <asp:TextBox ID="txtColonia" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Código Postal</h5>
                                            <asp:TextBox ID="txtCP" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftdCP" runat="server" TargetControlID="txtCP"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Delegación / Municipio</h5>
                                            <asp:TextBox ID="txtDelMun" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Estado</h5>
                                            <asp:TextBox ID="txtEstado" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Telefono</h5>
                                            <asp:TextBox ID="txtTelefonoDomicilio" runat="server" MaxLength="100" 
                                                CssClass="form-control input-sm" onclick="select(this)">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftdTelefono" runat="server" TargetControlID="txtTelefonoDomicilio"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <label><u>DETALLES</u></label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group" style="margin:5px;">
                                            <h5 style="margin:2px;">Lista de precios</h5>
                                            <asp:DropDownList ID="drpListaPrecios" runat="server" Width="100%" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton ID="lnkLimpiar" runat="server" class="btn btn-default" OnClientClick="LimpiarDatos();">
                                                <span class="glyphicon glyphicon-erase"></span>&nbsp;Limpiar Datos
                                                </asp:LinkButton>
                                            </div>
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton ID="lnkGuardar" runat="server" OnClientClick="ValidarCampos();" 
                                                    OnClick="lnkGuardar_Click" class="btn btn-success">
                                                <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Guardar
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
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
                    <div class="modal fade" id="mdlListaPrecio">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">
                                        <asp:Label ID="Label2" runat="server">
                                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp;Aviso
                                        </asp:Label>
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblMdlListaPrecio" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                    <button type="button" class="btn btn-primary" onclick="redirect('Precios.aspx')">Agregar Listas de Precios</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
