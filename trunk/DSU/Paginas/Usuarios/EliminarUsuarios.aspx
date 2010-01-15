<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" Title="Eliminar Usuarios" AutoEventWireup="true" Inherits="Paginas_Usuarios_EliminarUsuarios" Codebehind="EliminarUsuarios.aspx.cs" %>

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
                    <p class="large">
                        
                        
                        Introduzca el usuario o seleccionelo de la lista</p>
                     <p class="large">
                        
                        
                         Usuario:
                                                 
                        
                    </p>
                     <p class="large">
                        
                        
                         <asp:TextBox ID="uxUsuarioEliminar" runat="server"></asp:TextBox>
                        
                        
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
