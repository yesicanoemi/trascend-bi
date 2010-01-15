<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Title="Consultar Usuarios" CodeFile="ConsultarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_ConsultarUsuarios" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Usuarios</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarUsuarios.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarUsuarios.aspx" class="active">Consultar<span></span></a></li> 
  <li><a href="EliminarUsuarios.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarUsuarios.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
			<div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Usuario</h3> 
                    <p class="large">Introduzca el Nombre de Usuario</p> 
                 </div> 
                 
                  <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <form id="uxFormConsultarUsuario" runat="server">
                    <table style="width:100%;">
                       <tr>
                                   <td>Nombre de Usuario:</td>
                                   <td><asp:TextBox ID="uxLogin" runat="server"></asp:TextBox></td>
        
                                    <td>
                                <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" onclick="uxBotonBuscar_Click" 
                                    />
                            </td>
                               </tr>
                               
                               <tr>
                                <td></td>
                                   <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxLogin" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaUserName%>" Font-Size="Smaller" Display="Static" />
                                    </td>
                               </tr>
                              
                               <tr>
                          
                                   <td>Usuario:</td>
                                   <td><asp:Label ID="uxUsuario" runat="server" Text=""></asp:Label></td>
                                  
                               </tr>
                             
                               <tr>
                           
                                   <td>Nombre del Empleado:</td>
                                   <td><asp:Label ID="uxNombreE" runat="server" Text=""></asp:Label></td>
                                  
                               </tr>
                         
                                  <tr>
                         
                                   <td>Apellido del Empleado:</td>
                                   <td><asp:Label ID="uxApellidoE" runat="server" Text=""></asp:Label></td>
                                  
                               </tr>
                         
                                       <tr>
                            
                                   <td>Status del Usuario:</td>
                                   <td><asp:Label ID="uxStatusU" runat="server" Text=""></asp:Label></td>
                                  
                               </tr>
                              
               
         
                    </table>
                </form>
                 
                 
                 
                 
              </div>
								</div> 
				
			</div> 
		</div> 
</asp:Content>
