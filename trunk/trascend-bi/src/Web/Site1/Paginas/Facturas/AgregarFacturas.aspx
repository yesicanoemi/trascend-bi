<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AgregarFacturas.aspx.cs" Inherits="Paginas_Facturas_AgregarFacturas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Facturas</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarFacturas.aspx" class="active">Agregar<span></span></a></li>
                    <li><a href="ConsultarFacturas.aspx">Consultar<span></span></a></li>
                    <li><a href="AnularFacturas.aspx">Anular<span></span></a></li>
                    <li><a href="ModificarFacturas.aspx">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3>
                            Agregar Facturas</h3>
                        <p class="large">
                            Introduzca el nombre de la propuesta a buscar:</p>
                        <p class="large">
                            <asp:Label ID="lbMensaje" runat="server" Visible="false" ForeColor="Red" Font-Size="Medium"></asp:Label>
                        </p>
                        <form id="form1" runat="server">
                        <asp:MultiView ID="uxMultiViewFactura" runat="server" ActiveViewIndex="0">
                            <asp:View ID="ViewBuscarPropuesta" runat="server">
                                <table style="width: auto">
                                    <tr>
                                        <td>
                                            Nombre Propuesta:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="uxNombrePropuesta" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btBotonBuscar" runat="server" Text="Buscar" OnClick="btBotonBuscar_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"                                                                             
                                                CompletionListCssClass="list"
                                                CompletionListHighlightedItemCssClass="hoverlistitem" 
                                                CompletionListItemCssClass="listitem" CompletionSetCount="1"
				                                MinimumPrefixLength="1" 
                                                ServiceMethod="GetSuggestionsFacturaPropuesta" 
                                                ServicePath="../../SuggestionNames.asmx" TargetControlID="uxNombrePropuesta" >
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxNombrePropuesta"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombrePropuesta%>" Font-Size="Smaller"
                                                Display="None" />
                                            <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxNombrePropuesta" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom"
                                                ValidChars="' '" ID="FilteredTextBoxExtender4" runat="server" />
                                            <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                                                TargetControlID="RequiredFieldValidator4" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: auto">
                                    <tr style="background-color: #FFFFCC;">
                                        <td>
                                            Nombre Propuesta:
                                        </td>
                                        <td>
                                            <asp:Label ID="lbNombrePropuesta" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Monto Total:
                                        </td>
                                        <td>
                                            <asp:Label ID="lbMontoTotal" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #FFFFCC;">
                                        <td>
                                            Porcentaje Pagado:
                                        </td>
                                        <td>
                                            <asp:Label ID="lbPorcentajePagado" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Porcentaje Restante:
                                        </td>
                                        <td>
                                            <asp:Label ID="lbPorcentajeRestante" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr  style="background-color: #FFFFCC;">
                                        <td>
                                            Monto Pagado:
                                        </td>
                                        <td>
                                            <asp:Label ID="lbMontoPagado" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Monto Restante:
                                        </td>
                                        <td>
                                            <asp:Label ID="lbMontoRestante" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr align="center">
                                        <td align="center">
                                            <asp:Button ID="btBotonIngresarFactura" runat="server" Text="Ingresar Factura Nueva"
                                                OnClick="btBotonIngresarFactura_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="ViewAgregarFactura" runat="server">
                                <p class="large">
                                    Introduzca la informacion de la factura:</p>
                                <p class="large">
                                    <table style="width: auto">
                                        <tr>
                                            <td>
                                                <span style="color: #FF0000">*</span> Titulo:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="uxTitulo" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxTitulo"
                                                    ErrorMessage="<%$ Resources:DSU, FaltaTituloFactura%>" Font-Size="Smaller" Display="None" />
                                                <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxTitulo" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom"
                                                    ValidChars="' '" ID="FilteredTextBoxExtender1" runat="server" />
                                                <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                                    TargetControlID="RequiredFieldValidator1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="color: #FF0000">*</span> Descripcion:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="uxDescripcion" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxDescripcion"
                                                    ErrorMessage="<%$ Resources:DSU, FaltaDescripcionFactura%>" Font-Size="Smaller"
                                                    Display="None" />
                                                <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxDescripcion" FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom"
                                                    ValidChars="' '" ID="FilteredTextBoxExtender2" runat="server" />
                                                <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                                    TargetControlID="RequiredFieldValidator2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="color: #FF0000">*</span> Porcentaje a pagar:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="uxPorcentaje" runat="server" OnTextChanged="uxPorcentaje_TextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxPorcentaje"
                                                    ErrorMessage="<%$ Resources:DSU, FaltaPorcentajeFactura%>" Font-Size="Smaller"
                                                    Display="None" />
                                                <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxPorcentaje" FilterType="Numbers, Custom"
                                                    ValidChars="." ID="FilteredTextBoxExtender3" runat="server" />
                                                <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                                                    TargetControlID="RequiredFieldValidator3" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="color: #FF0000">*</span> Estado:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="uxEstado" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Monto a pagar:
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbMonto" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="btCargarTotal" runat="server" Text="Calcular" OnClick="btCalcularMonto_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="btBotonIngresar" Enabled="false" Visible="false" runat="server" Text="Ingresar" OnClick="btBotonIngresar_Click" 
                                                OnClientClick="return confirm('Esta seguro que quiere ingresar esta factura?');"/>
                                            </td>
                                        </tr>
                                    </table>
                                </p>
                            </asp:View>
                        </asp:MultiView>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
