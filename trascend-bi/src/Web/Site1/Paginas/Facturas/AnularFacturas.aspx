<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AnularFacturas.aspx.cs" Inherits="Paginas_Facturas_AnularFacturas"
    Title="Anular Factura" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Facturas</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarFacturas1.aspx">Agregar<span></span></a></li>
                    <li><a href="ConsultarFacturas.aspx">Consultar<span></span></a></li>
                    <li><a href="AnularFacturas.aspx" class="active">Anular<span></span></a></li>
                    <li><a href="ModificarFacturas.aspx">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3 style="font-size:small;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Anular Factura</h3>
                        <p class="large" style="font-size:small;">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            Introduzca el numero de factura a continuación</p>
                            <p class="large" >
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbMensaje" runat="server" Visible="false" ForeColor="Red" Font-Size="Medium"></asp:Label>
                            </p>
                        <form id="Form1" runat="server">
                        <p class="large">
                       
                            <table style="width: 75%;">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="uxBusqueda" runat="server" TabIndex="1"></asp:TextBox>
                                        <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxBusqueda" FilterType="Numbers"
                                            ID="FilteredTextBoxExtender1" runat="server">
                                        </AjaxControlToolkit:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxBusqueda"
                                            ErrorMessage="<%$ Resources:DSU, FaltaNumeroFactura%>" Font-Size="Smaller" Display="None" />
                                        <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                            TargetControlID="RequiredFieldValidator1" />
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="uxBusquedaBoton" runat="server" Text="Buscar" OnClick="uxBusquedaBoton_Click"
                                            TabIndex="2" />
                                    </td>
                                </tr>
                            </table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <table style="width: 100%;" visible="false" id="tbDatos" runat="server">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbDatosPropuesta" runat="server" Text="Datos de la Propuesta" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
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
                                        <asp:Label ID="lbNombre" runat="server" Text="Titulo:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbNombrePropuesta" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbMonto" runat="server" Text="Monto:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbMontoPropuesta" runat="server"></asp:Label>
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
                                        <asp:Label ID="lbDatosFactura" runat="server" Text="Datos de la Factura" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
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
                                        <asp:Label ID="lbNumero" runat="server" Text="Numero:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbNumeroFactura" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbTitulo" runat="server" Text="Titulo:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbTituloFactura" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbDescripcion" runat="server" Text="Descripcion:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbDescripcionFactura" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbFecha" runat="server" Text="Fecha Ingreso:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbFechaFactura" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbPorcentaje" runat="server" Text="Porcentaje:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbPorcentajeFactura" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbTotal" runat="server" Text="Total Factura:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbTotalFactura" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <table>
                                <tr>
                                    <td style="width: 77%;">
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btAnular" runat="server" Text="Anular" Visible="false" OnClick="btAnular_Click"
                                            OnClientClick="return confirm('Esta seguro que quiere anular ésta factura?');" 
                                            TabIndex="3" />                                       
                                    </td>
                                </tr>
                            </table>
                        </p>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
