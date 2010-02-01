<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" Title="Eliminar Usuarios" AutoEventWireup="true" CodeFile="EliminarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_EliminarUsuarios" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacionBotonAceptar" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
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
                                                <p class="large">Introduzca la informacion a continuación</p> 
                                                 <form id="form1" action="#" runat="server">
                       <asp:MultiView ID="uxMultiViewEliminar" runat="server" ActiveViewIndex="0">
                                <asp:View ID="ViewConsultaUsuario" runat="server">
                               <span style="text-align:center"> <uc3:MensajeInformacionBotonAceptar ID="uxMensajeInformacionBotonAceptar" runat="server" Visible="false" /></span>
                                  <p><div style="background-color:InfoBackground">Consultar usuario</div>
                                    <br />
                                     
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            <asp:RadioButtonList ID="uxRbCampoBusqueda" runat="server" 
                                                    onselectedindexchanged="uxRbCampoBusqueda_SelectedIndexChanged" 
                                                    AutoPostBack="true" RepeatColumns="2" Width="610px">
                                                    <asp:ListItem Value="1" Text="Nombre Usuario"></asp:ListItem> 
                                                    <asp:ListItem Value="2" Text="Estado Usuario"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                          
                                            
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr>
                                        <td>
                                            </span><asp:Label runat="server" ID="uxLoginLabel" Text="<%$ Resources:DSU, IntroducirUsuario%>" Visible="false"></asp:Label>
                                                <asp:TextBox ID="uxLogin" runat="server" Visible="false">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="uxRequiredFieldValidator" runat="server" 
                                                ControlToValidate="uxLogin" Visible="false"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                              </td>
                                              </tr>
                                              <tr>
                                              <td>  
                                                <span style="color:#FF0000"><asp:Label ID="uxAsteriscoStatus" Visible="false" runat="server" Text="<%$ Resources:DSU, Asterisco%>">
                                        </asp:Label></span><asp:Label runat="server" ID="uxStatusDdLLabel" Text="<%$ Resources:DSU, SeleccioneEstado%>" Visible="false"></asp:Label>
                                                <asp:DropDownList ID="uxStatusDdL" runat="server" Visible="false">
                                                    <asp:ListItem Value="ninguno" Text="Seleccionar..."></asp:ListItem>
                                                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                                                   </asp:DropDownList>
                                                <asp:RequiredFieldValidator id="uxRequiredFieldValidator2" runat="server" ControlToValidate="uxStatusDdL" 
                   InitialValue="ninguno"  ErrorMessage="<%$ Resources:DSU, FaltaEstadoUsuario %>" Font-Size="Smaller" Display="Static" />
                                        </td>
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
                                      <tr> <td>
                                                <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" 
                                                    Visible="false" />
                                            </td></tr>
                                   </table>
                                   <table>
                                        <tr>
                                    
                                            <td align="center">
                                            <asp:Button ID="uxBotonBuscar" runat="server" onclick="uxBotonBuscar_Click" 
                                                Text="<%$ Resources:DSU, Buscar%>" Visible="false" />
                                            </td>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                          </tr>
                                         <tr><td>&nbsp;</td></tr>
                                      
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="uxConsultaEliminarUsuario" runat="server" AllowPaging="True" 
                                                    AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                                                    DataKeyNames="Login" DataSourceID="uxObjectConsultaEliminarUsuario" 
                                                    Font-Names="Verdana" Font-Size="Smaller"
                                                    OnSelectedIndexChanging="SelectUsuarios" PageSize="10" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Login" HeaderText="Usuario" />
                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Empleado" />
                                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido Empleado" />
                                                        <asp:BoundField DataField="Status" HeaderText="Status Usuario" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <center>
                                                            <!--  <span>No hay data cargada </span>-->
                                                        </center>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                            
                                </asp:View>
                            </asp:MultiView> 
                            <asp:UpdatePanel ID="up2" runat="server">
                                <ContentTemplate>
                                    <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </form>
                 </div> 
              </div>
        
				
								</div> 
				
			</div> 
		</div> 
    
    <pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaEliminarUsuario" DataObjectTypeName="Core.LogicaNegocio.Entidades.Usuario" /> 

</asp:Content>
