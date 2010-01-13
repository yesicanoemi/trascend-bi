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
                  <li><a href="ConsultarUsuarios.aspx" class="active">Administrar<span></span></a></li> 
                  <li><a href="EliminarUsuarios.aspx" >Eliminar<span></span></a></li> 
                </ul> 
			</div> 
			<div class="sub-content"> 
        		<div class="features_overview"> 
                    <div class="features_overview_left"> 
                        <h3>Consultaro Usuario</h3> 
                        <p class="large"></p>
                        <p><!-- MULTIVIEW -->               
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <!-- CONSULTA -->
                                    <asp:View ID="ViewConsulta" runat="server">
                                    <form action="#" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="uxNombrep" runat="server" Text="<%$Resources:DSU, NombreObligatorio%>"
                                                        ></asp:Label>
                                                    &nbsp;</td>
                                                 
                                                <td>
                                                <asp:TextBox ID="uxNombreConsulta" runat="server" Width="150px"
                                                    ValidationGroup="valRegistro"></asp:TextBox>
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="uxNombreConsulta"
                                                    Display="Static" ErrorMessage="<%$ Resources:DSU, FaltaNombre%>"
                                                    ValidationGroup="valRegistro" />
                                                </td>
                                             <td>
                                                &nbsp;<asp:Button ID="uxBuscar" runat="server" Text="Buscar" OnClick="uxBuscar_Click"
                                                    ValidationGroup="valRegistro" TabIndex="2" />
                                            </td>
                                             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                          
                                             
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="<%$Resources:DSU, NombreUsuarioObligatorio%>"
                                                   ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="uxNombreUsuarioConsulta" runat="server" Width="221px" TabIndex="3" ValidationGroup="valBusquedaNombre"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="uxNombreUsuarioConsulta"
                                                    Display="Static" ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" ValidationGroup="valBusquedaNombre" />
                                               </td>
                                            <td>  
                                                &nbsp;<asp:Button ID="uxBuscarNombre" runat="server" Text="Buscar"
                                                    OnClick="uxBuscarNombre_Click" ValidationGroup="valBusquedaNombre" TabIndex="4" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            <!--
                                                <asp:GridView ID="uxConsultaUsuario" runat="server" AllowPaging="True" DataSourceID=""
                                                    AutoGenerateColumns="False" DataKeyNames="EntidadId" AutoGenerateSelectButton="True"
                                                    Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10" OnPageIndexChanging="PageChangingEstacionamiento"
                                                    OnSelectedIndexChanging="SelectEstacionamiento">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre DataField="nombreUsuario" />
                                                        <asp:BoundField HeaderText="Apellido" DataField="apellidoUsuario" />
                                                        <asp:BoundField HeaderText="Nombre de Usuario" DataField="nombredeUsuario" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <center>
                                                            <span>No hay data cargada </span>
                                                        </center>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>-->
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                                </asp:View>
        
                                <!-- MODIFICAR .-->
                                <asp:View ID="ViewModificar" runat="server">
                                
                                
                                </asp:View>
                         </asp:MultiView>
                     </p>
                 </div> 
                
              </div>
			</div> 
		</div> 
	</div> 
      
</asp:Content>
