<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="ConsultarFacturas.aspx.cs" Inherits="Paginas_Facturas_ConsultarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Facturas</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarFacturas.aspx">Agregar<span></span></a></li>
                    <li><a href="ConsultarFacturas.aspx" class="active">Consultar<span></span></a></li>
                    <li><a href="AnularFacturas.aspx">Anular<span></span></a></li>
                    <li><a href="ModificarFacturas.aspx">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3>
                            Consultar Facturas</h3>
                        <form id="form1" runat="server">
                        <p class="large">
                            Seleccione el tipo de busqueda e ingrese el parametro:</p>
                            <p class="large" >
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbMensaje" runat="server" Visible="false" ForeColor="Red" Font-Size="Medium"></asp:Label>
                            </p>
                        <table style="width: auto">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="uxParametroBox" runat="server" 
                                                    
                                                    AutoPostBack="true" RepeatColumns="1" Width="100px">
                                                    <asp:ListItem Value="1" Text="Nombre Propuesta"></asp:ListItem> 
                                                    <asp:ListItem Value="2" Text="Numero Factura"></asp:ListItem>
                                                </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="uxParametroTexto" runat="server"></asp:TextBox>
                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxParametroTexto" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="' '"
                                            ID="FilteredTextBoxExtender1" runat="server">
                                        </AjaxControlToolkit:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxParametroTexto"
                                            ErrorMessage="<%$ Resources:DSU, FaltaParametroBusqueda%>" Font-Size="Smaller" Display="None" />
                                        <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                            TargetControlID="RequiredFieldValidator1" />
                                </td>
                                <td>&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Button ID="btBotonBuscar" runat="server" Text="Buscar" OnClick="btBotonBuscar_Click" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr><td>&nbsp;</td></tr>
                        </table>
                        <asp:MultiView ID="uxMultiViewFactura" runat="server" ActiveViewIndex="0">
                            <asp:View ID="ViewBuscarPorPropuesta" runat="server">
                                <table style="width:auto">
                                    <tr>
                                        <td><b>Titulo:</b></td>
                                        <td><asp:Label ID ="lbTituloPropuesta" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><b>Monto Total:</b></td>
                                        <td><asp:Label ID ="lbMontoTotal" runat ="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                                <table style="width: auto">
                                        
                                        <p class="large">
                                        
                                            <asp:GridView Width="150%" ID="uxTablaFacturas" runat="server" AutoGenerateColumns="false" 
                                                CellPadding="10" CellSpacing="5" OnRowDataBound="uxTablaFacturas_RowDataBound">
                                                <RowStyle HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:BoundField DataField="Numero" HeaderText="Numero" 
                                                        ItemStyle-HorizontalAlign="Justify" />
                                                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                    <asp:BoundField DataField="Procentajepagado" HeaderText="Porcentaje" />
                                                    <asp:TemplateField ItemStyle-Width="15%" HeaderText="Fecha Ingreso">
                                                    <ItemTemplate>
                                                        <%# FormatearFecha((DateTime)Eval("Fechaingreso")) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="15%" HeaderText="Fecha Pago">
                                                    <ItemTemplate>
                                                        <%# FormatearFecha((DateTime)Eval("Fechapago")) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                </Columns>
                                            </asp:GridView>
                                        </p>
                                    </caption>
                                </table>
                            </asp:View>
                            <asp:View ID="ViewBuscarPorFactura" runat="server">
                                <table style="width: auto">
                                    <tr><td></td></tr>
                                    <tr>
                                        <td> <b>Titulo:</b></td>
                                        <td><asp:Label ID="lbTitulo" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr><td></td></tr>
                                     <tr>
                                        <td><b> Descripcion:</b></td>
                                        <td><asp:Label ID="lbDescripcion" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr><td></td></tr>
                                     <tr>
                                        <td><b> Porcentaje:</b></td>
                                        <td><asp:Label ID="lbPorcentaje" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr><td></td></tr>
                                     <tr>
                                        <td><b> Ingreso:</b></td>
                                        <td><asp:Label ID="lbFechaIngreso" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr><td></td></tr>
                                     <tr>
                                        <td><b> Fecha Pago:</b></td>
                                        <td><asp:Label ID="lbFechaPago" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr><td></td></tr>
                                     <tr>
                                        <td><b> Estado:</b></td>
                                        <td><asp:Label ID="lbEstado" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
