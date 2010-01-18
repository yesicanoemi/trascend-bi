<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarFacturas.aspx.cs" Inherits="Paginas_Facturas_AgregarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Facturas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarFacturas.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarFacturas.aspx" >Consultar<span></span></a></li> 
  <li><a href="ModificarFacturas.aspx" >Modificar<span></span></a></li> 
   
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
 
          <div class="features_overview_right"> 
            <h3>Agregar Facturas</h3>
            <p class="large">Introduzca la informacion a continuación</p>
            <asp:MultiView ID="uxMultiViewPropuesta" runat="server" ActiveViewIndex="0">
                <asp:View ID="uxConsultarPropuesta" runat="server">
                    <p><div style="background-color:InfoBackground">Consultar Propuesta</div>
                        <p>&nbsp;</p>
                        <p>Titulo de propuesta a asignarle factura:</p>
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
                                            <asp:Button ID="uxBuscarTitulo" runat="server" onclick="uxBuscarTitulo_Click" 
                                                Text="Buscar" />
                                        </td>
                                       
                                           
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="uxTituloPropuesta" Display="Static" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaTituloPropuesta%>" Font-Size="Smaller" />
                                        </td>
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
                            
                        </p>
                        
                       
                    </p>
                    
                </asp:View>
                <asp:View ID="uxAgregarFactura" runat="server">
                    <p><div style="background-color:InfoBackground">Información Propuesta</div>
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
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelMontoTotal" runat="server" 
                                            Text="<%$Resources:DSU, MontoTotalPropuestaFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxMontoTotal" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelMontoCancelado" runat="server" 
                                            Text="<%$Resources:DSU, MontosCanceladosPropFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxMontoCancelado" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelTotalCancelado" runat="server" 
                                            Text="<%$Resources:DSU, TotalCanceladoFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxTotalCancelado" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelPorcCancelado" runat="server" 
                                            Text="<%$Resources:DSU, PorcentajeCanceladoPropFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxPorcentajeCancelado" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelMontoFalt" runat="server" 
                                            Text="<%$Resources:DSU, MontoFaltantePropFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxMontoFaltante" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="uxLabelPorcFalt" runat="server" 
                                            Text="<%$Resources:DSU, PorcentajeFaltantePropFact%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxPorcFaltante" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha de Pago:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxFechaPago" runat="server"></asp:TextBox>
                                        <asp:Image ID="uxImagenFechaPago" runat="server" 
                                            ImageUrl="~/Images/calendario.png" />
                                    </td>
                                </tr>
                                <tr>
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
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <AjaxControlToolkit:CalendarExtender ID="uxFechaPag" runat="server" 
                                            Animated="true" CssClass="ajax__calendar" Format="dd/MM/yyyy" 
                                            PopupButtonID="uxImagenFechaPago" TargetControlID="uxFechaPago"></AjaxControlToolkit:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="background-color:InfoBackground">
                                            Facturación</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Ingreso:</td>
                                    <td>
                                        <asp:TextBox ID="uxFechaIngresoFactProp" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
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
                                        <asp:TextBox ID="uxTituloFactura" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
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
                                        <asp:TextBox ID="uxDescProp" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Estado(cobrado o por cobrar): </td>
                                    <td>
                                        <asp:DropDownList ID="uxEstado" runat="server">
                                            <asp:ListItem>Cobrada</asp:ListItem>
                                            <asp:ListItem>Por Cobrar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
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
                                        <asp:TextBox ID="uxCodigoFactura" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
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
                                        <asp:TextBox ID="uxPorcentajePagar" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
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
                                        <asp:TextBox ID="uxMontoPagar" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                            onclick="uxBotonAceptar_Click" />
                                    </td>
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
                        </p>
                    </p>
                </asp:View>
            </asp:MultiView>
            
            
                           
          </div> 
        </div> 
	</div> 
				
			</div> 
		</div> 
</asp:Content>
