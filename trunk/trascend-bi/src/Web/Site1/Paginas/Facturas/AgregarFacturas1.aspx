﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" 
        CodeFile="AgregarFacturas1.aspx.cs" Inherits="Paginas_Facturas_AgregarFacturas1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Facturas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarFacturas1.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarFacturas.aspx" >Consultar<span></span></a></li>
  <li><a href="AnularFacturas.aspx">Anular<span></span></a></li> 
  <li><a href="ModificarFacturas.aspx" >Modificar<span></span></a></li> 
   
</ul> 
						
				</div> 
				
<div class="sub-content"> 
   <div class="features_overview"> 
      <div class="features_overview_right"> 
          <h3>Agregar Facturas</h3>
            
            
       
        <form id="form1" runat="server">
        <asp:MultiView ID="uxMultiViewFactura" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewBuscarPropuesta" runat="server">
            <p class="large">Introduzca el nombre de la propuesta a buscar:</p>
                <p class="large">&nbsp;<table style="width:auto">
                        
                        <tr>
                            <td> Nombre Propuesta:</td>
                        </tr>
                        <tr>
                            
                            <td><asp:TextBox ID="uxNombrePropuesta" runat="server"></asp:TextBox></td>
                            <td><asp:Button ID="btBotonBuscar" runat="server" Text="Buscar" OnClick = "btBotonBuscar_Click"/></td>
                            
                        </tr>
                        
                        <tr>
                      
                            <td> Nombre Propuesta:</td>
                            <td><asp:Label ID="lbNombrePropuesta" runat="server" Text=""></asp:Label></td>
                            
                        </tr>
                        <tr>
                           
                            <td> Monto Total: </td> 
                            <td><asp:Label ID="lbMontoTotal" runat="server" Text=""></asp:Label></td>
                        </tr>
                        
                        <tr>
                           
                            <td> Porcentaje Pagado: </td> 
                            <td><asp:Label ID="lbPorcentajePagado" runat="server" Text=""></asp:Label></td>
                        </tr>
                        
                        <tr>
                           
                            <td> Porcentaje Restante: </td> 
                            <td><asp:Label ID="lbPorcentajeRestante" runat="server" Text=""></asp:Label></td>
                        </tr>
                        
                        <tr>
                           
                            <td> Monto Pagado: </td> 
                            <td><asp:Label ID="lbMontoPagado" runat="server" Text=""></asp:Label></td>
                        </tr>
                        
                        <tr>
                           
                            <td> Monto Restante: </td> 
                            <td><asp:Label ID="lbMontoRestante" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="btBotonIngresarFactura" runat="server" Text="Ingresar Factura" OnClick = "btBotonIngresarFactura_Click"/></td>
                        </tr>
                        
                        
                    </table>
                </p>
                
        </asp:View>
        <asp:View ID="ViewAgregarFactura" runat="server">
        <p class="large">Introduzca la informacion de la factura:</p>
                <p class="large">
                    <table style="width:auto">
                    <tr>
                        <td> Titulo:</td>
                        <td><asp:TextBox ID="uxTitulo" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="uxTitulo" 
                                ErrorMessage="Debe introducir un Titulo" Font-Size="Smaller" Display="Static" />
                       </td>
                    </tr>
                    <tr>
                        <td> Descripcion:</td>
                        <td><asp:TextBox ID="uxDescripcion" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="uxDescripcion" 
                                ErrorMessage="Debe introducir una Descripcion" Font-Size="Smaller" Display="Static" />
                       </td>
                    </tr>
                    <tr>
                        <td> Porcentaje a pagar:</td>
                        <td><asp:TextBox ID="uxPorcentaje" runat="server" 
                                ontextchanged="uxPorcentaje_TextChanged"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="uxPorcentaje" 
                                ErrorMessage="Debe introducir un Porcentaje" Font-Size="Smaller" Display="Static" />
                       </td>
                    </tr>
                    
                   
                    <tr>
                        <td> Estado:</td>
                        <td>
                            <asp:DropDownList ID="uxEstado" runat="server"></asp:DropDownList> 
                        </td>
                    
                    </tr>
                    <tr>
                       <td>&nbsp;</td>
                      
                    </tr>
                     <tr>
                        <td> Monto a pagar:</td>
                        <td><asp:Label ID="lbMonto" runat="server"></asp:Label></td>
                    </tr>
                    
                    <tr>
                        <td><asp:Button ID="btBotonVolver" runat="server" Text="Volver" OnClick = "btBotonVolver_Click" /></td>
                        <td><asp:Button ID="btBotonIngresar" runat="server" Text="Ingresar" OnClick = "btBotonIngresar_Click" /></td>
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