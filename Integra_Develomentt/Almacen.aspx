<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Almacen.aspx.cs" Inherits="Integra_Develomentt.Almacen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jsAlmacen.js"></script>
    <script type="text/javascript" src="Scripts/jsMaster.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active" id="tab1"><a href="#almacen" aria-controls="almacen" role="tab" data-toggle="tab">Almacén</a></li>
            <li role="presentation" id="tab2"><a href="#inventario" aria-controls="inventario" role="tab" data-toggle="tab">Inventario</a></li>
            <li role="presentation" id="tab3"><a href="#movimientos" aria-controls="movimientos" role="tab" data-toggle="tab">Movimientos</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane fade in active" id="almacen">
                <fieldset>
                    <legend style="margin-bottom:0px;">PRODUCTO / ALMACÉN</legend>
                    <asp:UpdatePanel ID="upnlAlmacen" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal fade" id="mdlAgregarRegistros">
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
                                                <asp:Label ID="lblMdlAgregarRegistros" runat="server" Text=""></asp:Label>
                                            </p>
                                            <p>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grvMdl" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled" Style="margin:0px;"
                                                        GridLines="None" ShowHeader="False" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                                        DataKeyNames="Numero, Nombre, Clas_Almacen, Almacen, Clas_Movimiento, Movimiento, Cantidad">
                                                        <Columns>
                                                            <asp:BoundField DataField="Numero" Visible="false"/>
                                                            <asp:BoundField DataField="Nombre" HeaderText="Producto">
                                                                <ItemStyle Width="40%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Clas_Almacen" Visible="false"/>
                                                            <asp:BoundField DataField="Almacen" HeaderText="Almacén">
                                                                <ItemStyle Width="30%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Clas_Movimiento" Visible="false"/>
                                                            <asp:BoundField DataField="Movimiento" HeaderText="Movimiento">
                                                                <ItemStyle Width="15%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                                <ItemStyle Width="15%"/>
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="info"/>
                                                    </asp:GridView>
                                                </div>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <asp:LinkButton ID="lnkMdlAgregar" runat="server" class="btn btn-success" OnClientClick="mdlToggle2('#mdlAgregarRegistros','#mdlProceso');"
                                                OnClick="lnkMdlAgregar_Click">
                                                <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp; Guardar
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
                                
                                <button type="button" class="btn btn-primary" role="button" onclick="Productos();">Agregar productos</button>
                                <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grvProductosAlmacen" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                    GridLines="None" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                    DataKeyNames="Numero, Nombre" Style="margin:0px;">
                                    <Columns>
                                        <asp:BoundField DataField="Numero" Visible="false"/>
                                        <asp:BoundField DataField="Nombre" HeaderText="Producto">
                                            <ItemStyle Width="41%"/>
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-Width="17.5%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom:2px;">Almacén</p>
                                                <asp:DropDownList ID="drpAlmacenGrvTodos" runat="server" Width="100%" CssClass="form-control input-sm"
                                                     AutoPostBack="true" onchange="mdlToggle('#mdlProceso')" OnSelectedIndexChanged="drpAlmacenGrvTodos_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="drpAlmacenGrv" runat="server" Width="100%" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="17.5%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom:2px;">Movimiento</p>
                                                <asp:DropDownList ID="drpMovimientoGrvTodos" runat="server" Width="100%" CssClass="form-control input-sm"
                                                     AutoPostBack="true" onchange="mdlToggle('#mdlProceso')" OnSelectedIndexChanged="drpMovimientoGrvTodos_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="drpMovimientoGrv" runat="server" Width="100%" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="17.5%">
                                            <HeaderTemplate>
                                                <p class="text-center" style="margin-bottom:2px;">Cantidad</p>
                                                <asp:TextBox ID="txtCantidadGrvTodos" MaxLength="19" runat="server" AutoPostBack="true"
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)" onchange="mdlToggle('#mdlProceso')"
                                                    OnTextChanged="txtCantidadGrvTodos_TextChanged">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdCantidadGrvTodos" runat="server" TargetControlID="txtCantidadGrvTodos"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidadGrv" MaxLength="19" runat="server"
                                                    Width="100%" CssClass="form-control input-sm" onclick="select(this)">
                                                </asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftdCantidadGrv" runat="server" TargetControlID="txtCantidadGrv"
                                                    FilterType="Custom, Numbers" ValidChars=".,">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkGuardarTodosGrv" runat="server" class="btn btn-success"
                                                    data-toggle="tooltip" data-placement="top" title="Guardar todos"
                                                    OnClick="lnkGuardarTodosGrv_Click" OnClientClick="mdlToggle('#mdlProceso');">
                                                    <span class="glyphicon glyphicon-floppy-disk"></span>
                                                </asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkGuardarGrv" runat="server" class="btn btn-info"
                                                    data-toggle="tooltip" data-placement="top" title="Guardar"
                                                     OnClick="lnkGuardarGrv_Click">
                                                    <span class="glyphicon glyphicon-floppy-disk"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="info"/>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
            <div role="tabpanel" class="tab-pane fade" id="inventario">
                <fieldset>
                    <legend style="margin-bottom:0px;">INVENTARIO DE PRODUCTOS</legend>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="divAlert2" role="alert" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <span id="spnAlert2" runat="server" aria-hidden="true"></span>
                                <asp:Label ID="lblAlert2" runat="server" Style=" font-size:medium;"></asp:Label>
                                <br />
                                <br />
                                <a class="btn btn-primary" href="#almacen" role="button" data-toggle="tab" onclick="tabAlmacen();">Registrar movimientos</a>
                                <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                            </div>
                            <label for="drpAlmacenInventario">Seleccione almacén:</label>
                            <asp:DropDownList ID="drpAlmacenInventario" runat="server" Width="100%" CssClass="form-control input-sm" 
                                 OnSelectedIndexChanged="drpAlmacenInventario_SelectedIndexChanged" AutoPostBack="true"/>
                            <br /> 
                            <div class="table-responsive">
                                <asp:GridView ID="grvExistenciaAlmacen" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                    GridLines="None" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                    DataKeyNames="Clas_Almacen, Almacen, Numero_Producto, Nombre_Producto, Existencia"  Style="margin:0px;">
                                    <Columns>
                                        <asp:BoundField DataField="Clas_Almacen" Visible="false"/>
                                        <asp:BoundField DataField="Almacen" HeaderText="Almacén">
                                            <ItemStyle Width="40%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Numero_Producto" Visible="false"/>
                                        <asp:BoundField DataField="Nombre_Producto" HeaderText="Producto">
                                            <ItemStyle Width="40%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Existencia" HeaderText="Existencia">
                                            <ItemStyle Width="20%"/>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="info" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
            </div>
            <div role="tabpanel" class="tab-pane fade" id="movimientos">
                <fieldset>
                    <legend style="margin-bottom:0px;">REGISTRO DE MOVIMIENTOS</legend>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="divAlert3" role="alert" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <span id="spnAlert3" runat="server" aria-hidden="true"></span>
                                <asp:Label ID="lblAlert3" runat="server" Style=" font-size:medium;"></asp:Label>
                                <br />
                                <br />
                                <a class="btn btn-primary" href="#almacen" role="button" data-toggle="tab" onclick="tabAlmacen();">Registrar movimientos</a>
                                <button type="button" class="btn btn-default" data-dismiss="alert">Cerrar</button>
                            </div>
                            <label for="drpAlmacenMovimientos">Seleccione almacén:</label>
                            <asp:DropDownList ID="drpAlmacenMovimientos" runat="server" Width="100%" CssClass="form-control input-sm" 
                                 OnSelectedIndexChanged="drpAlmacenMovimientos_SelectedIndexChanged" AutoPostBack="true"/>
                            <br /> 
                            <div class="table-responsive">
                                <asp:GridView ID="grvMovimientosAlmacen" runat="server" CellPadding="0" AutoGenerateColumns="False" ViewStateMode="Enabled"
                                    GridLines="None" Width="100%" CssClass="table table-striped table-bordered table-hover table-condensed"
                                    DataKeyNames="Clas_Almacen, Almacen, Numero_Producto, Producto, Movimiento, Existencia, Cantidad,
                                                    Existencia_Final, Fecha, Hora"  Style="margin:0px;">
                                    <Columns>
                                        <asp:BoundField DataField="Clas_Almacen" Visible="false"/>
                                        <asp:BoundField DataField="Almacen" HeaderText="Almacén">
                                            <ItemStyle Width="17.5%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Numero_Producto" Visible="false"/>
                                        <asp:BoundField DataField="Producto" HeaderText="Producto">
                                            <ItemStyle Width="20%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Movimiento" HeaderText="Movimiento">
                                            <ItemStyle Width="8%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Existencia" HeaderText="Existencia">
                                            <ItemStyle Width="12.5%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                            <ItemStyle Width="12.5%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Existencia_Final" HeaderText="Existencia Final">
                                            <ItemStyle Width="12.5%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                            <ItemStyle Width="9%"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Hora" HeaderText="Hora">
                                            <ItemStyle Width="8%"/>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="info" />
                                </asp:GridView>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
