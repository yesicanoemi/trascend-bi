<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarClientes.aspx.cs" Inherits="Paginas_Clientes_AgregarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
          <div class="features_overview_right"> 
            <h3>Agregar Clientes</h3>
            <p class="large">Introduzca la informacón a continuación</p> 
            <p class="large">
                  <form id="form1" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>R.I.F:</td>
                                   <td><asp:TextBox ID="uxRif" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Nombre:</td>
                                   <td><asp:TextBox ID="uxNombreCliente" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Calle/Avenida</td>
                                   <td><asp:TextBox ID="uxAvenidaCalle" runat="server"></asp:TextBox><tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr></td>
                               </tr>
                               <tr>
                                   <td>Urbanizacion</td>
                                   <td><asp:TextBox ID="uxUrbanizacion" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Edificio/Casa</td>
                                   <td><asp:TextBox ID="uxEdificioCasa" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Piso/Apartamento</td>
                                   <td><asp:TextBox ID="uxPisoApartamento" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                 <tr>
                                   <td>Ciudad:</td>
                                   <td><asp:DropDownList ID="uxciudad" runat="server" DataValueField="Caracas">
                                       <asp:ListItem>Caracas</asp:ListItem>
                                       <asp:ListItem>Maracaibo</asp:ListItem>
                                       <asp:ListItem>Barquisimeto</asp:ListItem>
                                       <asp:ListItem>Valencia</asp:ListItem>
                                       <asp:ListItem>Maracay</asp:ListItem>
                                       <asp:ListItem>Puerto la Cruz</asp:ListItem>
                                       <asp:ListItem>Maturín</asp:ListItem>
                                       <asp:ListItem>Barcelona</asp:ListItem>
                                       <asp:ListItem>Ciudad Bolívar</asp:ListItem>
                                       <asp:ListItem>Acarigua-Araure</asp:ListItem>
                                       <asp:ListItem>Los Teques</asp:ListItem>
                                       <asp:ListItem>San Cristóbal</asp:ListItem>
                                       <asp:ListItem>Barinas</asp:ListItem>
                                       <asp:ListItem>Cabimas</asp:ListItem>
                                       <asp:ListItem>Cumaná</asp:ListItem>
                                       <asp:ListItem>Puerto La Cruz</asp:ListItem>
                                       <asp:ListItem>Punto Fijo</asp:ListItem>
                                       <asp:ListItem>Guarenas</asp:ListItem>
                                       <asp:ListItem>Carúpano</asp:ListItem>
                                       </asp:DropDownList></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                <tr>
                                   <td>Area de Negocio:</td>
                                   <td><asp:TextBox ID="uxAreaNegocioCliente" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               
                               <tr>
                                   <td>Telefono Trabajo:</td>
                                   <td><asp:TextBox ID="uxCodTrabajo" runat="server" Width="40"></asp:TextBox>
                                        <asp:TextBox ID="uxTelefonoTrabajo" runat="server" Width="150"></asp:TextBox></td>
                               </tr>
                               <tr>s
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               
                               
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                                    
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                           onclick="uxBotonAceptar_Click" />
                                    </td>
                                </tr>
                           </table>
                    </form>
            </p> 
            
          </div> 
        </div> 
 
        
 
 
        
				
								</div> 
				
			</div> 
		</div> 
</asp:Content>
