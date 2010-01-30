<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="EliminarFacturas.aspx.cs" Inherits="Paginas_Facturas_EliminarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Facturas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarFacturas.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarFacturas.aspx">Consultar<span></span></a></li> 
    <li><a href="EliminarFacturas.aspx" class="active">Anular<span></span></a></li>
  <li><a href="ModificarFacturas.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right">
                 <form id="Form1" runat="server"> 
                    <h3>Eliminar Facturas</h3> 
                    <p class="small"> 
                        Introduzca el N° de factura a Anular</p>
                     <p class="large">
                        <table style="width:auto">
                            <tr>
                                <td>
                                    <asp:TextBox ID="uxBusqueda" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="uxBusquedaBoton" runat="server" Text="Buscar" />
                                 </td>
                            </tr>
                        </table>
                     </p> 
                     <p class="small">
                        
                        <asp:DetailsView ID="uxDetalleFactura" runat="server" AutoGenerateRows="false">
                            <Fields>
                                <asp:BoundField DataField="IdFactura" runat="server"></asp:BoundField>
                                <asp:BoundField DataField="Titulo" runat="server"></asp:BoundField>
                                <asp:BoundField DataField="Descripcion" runat="server"></asp:BoundField>
                                <asp:BoundField DataField="Porcentaje" runat="server"></asp:BoundField>
                                <asp:BoundField DataField="FechaIngreso" runat="server"></asp:BoundField>
                                <asp:TemplateField HeaderText="Propuesta" AccessibleHeaderText="Propuesta">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprop" runat="server" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.Prop.titulo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monto" AccessibleHeaderText="Monto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmont" runat="server" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.Prop.monto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Fields>
                        </asp:DetailsView>
                        
                     </p>
                     <p>
                        <br />
                        <br />
                            <asp:Button ID="btAnular"
                                    runat="server" Text="Anular" />
                     </p>
                     </form>
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>