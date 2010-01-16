<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" Title="Eliminar Usuarios" AutoEventWireup="true" CodeFile="EliminarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_EliminarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Usuarios</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarUsuarios.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarUsuarios.aspx">Consultar<span></span></a></li> 
  <li><a href="EliminarUsuarios.aspx" class="active">Eliminar<span></span></a></li> 
  <li><a href="ModificarUsuarios.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        		<div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Eliminar Usuario</h3>
                                                 <p>Seleccione el usuario a eliminar de la lista</p> 
                     <p class="large">
                        
                        
                         Usuario:
                                                 
                        
                    </p>
                     <p class="large">
                        
                        
                         
 
                         <asp:DropDownList ID="uxUsuarioEliminar" runat="server" DataTextField="LoginUsuario" DataValueField="LoginUsuario" 
                         AutoPostBack="false" AppendDataBoundItems="True" TabIndex="3">
                         </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxUsuarioEliminar"/>
                        
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                        
                    </p>
                     <p class="large">
                        
                        
                         &nbsp;&nbsp;
                        
                        
                         <asp:Button ID="uxBotonEliminar" runat="server" Text="Eliminar" />
                        
                        
                    </p>
                     <p class="large">
                        
                        
                         &nbsp;</p>
                 </div> 
              </div>
        
				
								</div> 
				
			</div> 
		</div> 
    </form>
</asp:Content>
