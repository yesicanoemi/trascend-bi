<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarFacturas.aspx.cs" Inherits="Paginas_Facturas_ConsultarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Facturas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarFacturas.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarFacturas.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarFacturas.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarFacturas.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
 
        				
				
 
                  <div class="features_overview"> 
         
 
          <div class="features_overview_right"> 
            <h3>Consultar Facturas</h3>
            <p class="large">Introduzca la informacion a continuación</p>
            <asp:MultiView ID="uxMultiViewPropuesta" runat="server" ActiveViewIndex="0">
                <asp:View ID="uxConsultarPropuesta" runat="server">
                    <p><div style="background-color:InfoBackground">Consultar Factura</div>
                        <p>&nbsp;</p>
                        <p>Datos Propuesta:</p>
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
                                            <asp:Button ID="uxConsultarxNombreProp" runat="server" Text="Consultar" 
                                                onclick="uxConsultarxNombreProp_Click" />
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
                                            <asp:Button ID="uxConsultarxNumProp" runat="server" Text="Consultar" 
                                                onclick="uxConsultarxNumProp_Click" />
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
                                </tr>
                                <tr>
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
                                        <asp:Label ID="uxLabelDescProp" runat="server" 
                                            Text="<%$Resources:DSU, DescripcionPropuestaFactura%>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxDescProp" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                        </p>
                    </p>
                </asp:View>
            </asp:MultiView>
            
            
                           
          </div> 
        </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>

