<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarFacturas.aspx.cs" Inherits="Paginas_Facturas_ModificarFacturas" %>

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
  <li><a href="ModificarFacturas.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
         
 
          <div class="features_overview_right"> 
            <h3>Modificar Factura</h3>
            <p class="large">Introduzca la informacion a continuación</p>
            <asp:MultiView ID="uxMultiViewPropuesta" runat="server" ActiveViewIndex="0">
                <asp:View ID="uxConsultarPropuesta" runat="server">
                    <p><div style="background-color:InfoBackground">Consultar Propuesta</div>
                        <p>&nbsp;</p>
                        <p>Introduzca nombre o Código de Propuesta:</p>
                        <p>
                            <form id="Form1" runat="server">
                                <table>
                                    <tr>
                                        <td> 
                                            <asp:Label ID="uxLabelNomProp" runat="server" 
                                                Text="<%$Resources:DSU, NombrePropuestaFactura%>"></asp:Label>
                                        </td>
                                        <td> 
                                            <asp:TextBox ID="uxTituloPropuesta" runat="server"></asp:TextBox>
                                        </td>
                                       
                                           
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Button" onclick="uxConsultarxNombreProp_Click" />
                                        </td>
                                       
                                           
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                               
                              <table>
                                    <tr>
                                        <td> 
                                            <asp:Label ID="Label1" runat="server" 
                                                Text="<%$Resources:DSU, NumPropFact%>"></asp:Label>
                                        </td>
                                        <td> 
                                            <asp:TextBox ID="uxNumProp" runat="server"></asp:TextBox>
                                        </td>
                                       
                                           
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="Button" onclick="uxConsultarxNumProp_Click" />
                                        </td>
                                       
                                           
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table> 
                            </form>
                            
                            <p>
                            </p>
                            <p>
                            </p>
                            
                            <p>
                            </p>
                            
                        </p>
                        
                       
                    </p>
                    
                </asp:View>
                <asp:View ID="uxAgregarFactura" runat="server">
                    <p>
                        <p>
                        </p>
                        <p class="large">
                            <form ID="Form2" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="background-color:InfoBackground">
                                            Facturación</div>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Factura:</td>
                                    <td>
                                        <asp:DropDownList ID="uxFacturas" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                            Text="Consultar" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Ingreso:</td>
                                    <td>
                                        <asp:TextBox ID="uxFechaIngreso" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Pago:</td>
                                    <td>
                                        <asp:TextBox ID="uxFechaPago" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelTituloFact" runat="server" 
                                            Text="<%$Resources:DSU, TituloFactPropuesta%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxTituloFactura" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelDescProp" runat="server" 
                                            Text="<%$Resources:DSU, DescripcionPropuestaFactura%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxDescFact" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Estado(cobrado o por cobrar): </td>
                                    <td>
                                        <asp:TextBox ID="uxEstado" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelCodFactura" runat="server" 
                                            Text="<%$Resources:DSU, CodifoFactPropuesta%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxCodigoFactura" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelPorcPagar" runat="server" 
                                            Text="<%$Resources:DSU, PorcentajePagarFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxPorcentajePagar" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelMontoPagar" runat="server" 
                                            Text="<%$Resources:DSU, MontoPagarPropFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxMontoPagar" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Pagar" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </form>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                        </p>
                    </p>
                </asp:View>
            </asp:MultiView>
            
            
                           
          </div> 
        </div> 
			</div> 
		</div> 
</asp:Content>
