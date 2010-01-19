<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="EliminarClientes.aspx.cs" Inherits="Paginas_Clientes_EliminarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx">Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" class="active">Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Eliminar Clientes</h3> 
                    <p class="large">
                       <form id="Form1" action="#" runat="server">
                            <table>
                                <tr>
                                    <td><asp:Label ID="uxLabelEliminar" runat="server" Text = "Seleccione el Cliente" Visible = "false" /></td>
                                    <td><asp:DropDownList ID="uxSeleccionCliente" runat="server" Visible="false">
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><asp:Button ID="uxBotonEliminar" runat="server" Text="Eliminar" Visible="true" 
                                            onclick="uxBotonEliminar_Click"/></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><asp:Label ID="uxLabelCompletado" runat="server" Visible = "false" /></td>
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
