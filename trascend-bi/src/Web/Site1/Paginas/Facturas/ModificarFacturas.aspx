<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="ModificarFacturas.aspx.cs" Inherits="Paginas_Facturas_ModificarFacturas" %>

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
                    <li><a href="AnularFacturas.aspx">Anular<span></span></a></li>
                    <li><a href="ModificarFacturas.aspx" class="active">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <form id="Form1" runat="server">
                        <h3>
                            Saldar Facturas</h3>
                        <p class="small">
                            Introduzca el N° de factura a la que se quiere cambiar el estado</p>
                        <p class="large">
                            <table style="width: auto">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="uxBusqueda" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="uxBusquedaBoton" runat="server" Text="Buscar" OnClick="uxBusquedaBoton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </p>
                        <p class="small">
                            <asp:GridView ID="uxDetalleFactura" runat="server" AutoGenerateRows="false" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField HeaderText="N°" DataField="Numero" runat="server"></asp:BoundField>
                                    <asp:BoundField HeaderText="Titulo" DataField="Titulo" runat="server"></asp:BoundField>
                                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" runat="server"></asp:BoundField>
                                    <asp:BoundField HeaderText="%" DataField="Procentajepagado" runat="server"></asp:BoundField>
                                    <asp:BoundField HeaderText="Fecha" DataField="Fechaingreso" runat="server"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Propuesta" AccessibleHeaderText="Propuesta">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprop" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Prop.Titulo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Monto" AccessibleHeaderText="Monto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmont" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Prop.MontoTotal") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </p>
                        <p>
                            <br />
                            <br />
                            <asp:DropDownList ID="uxEstados" runat="server"  >
                                       </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="btAnular" runat="server" Text="Guardar" OnClick="btGuardar_Click" />
                        </p>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
