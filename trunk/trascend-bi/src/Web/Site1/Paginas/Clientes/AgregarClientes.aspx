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
                  <form action="#" runat="server">
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
                                   <td>Direccion 1:</td>
                                   <td><asp:TextBox ID="uxDireccion1" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Direccion2:</td>
                                   <td><asp:TextBox ID="uxDireccion2" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                 <tr>
                                   <td>Ciudad:</td>
                                   <td><asp:TextBox ID="uxCiudad" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                 <tr>
                                   <td>Estado:</td>
                                   <td>
                                       <asp:DropDownList ID="uxEstado" runat="server">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Telefono 1:</td>
                                   <td>
                                       <asp:TextBox ID="uxTelefono1" runat="server"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Area de Negocio:</td>
                                   <td>
                                       <asp:DropDownList ID="uxAreaNegocio" runat="server">
                                       </asp:DropDownList>
                                   </td>
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
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" />
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
