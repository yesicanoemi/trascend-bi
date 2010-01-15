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
                    
                    
                    <p class="large">
                            </p>
                            
                    <form id="Form1" action="#" runat="server">
                    
                    <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                          <asp:View ID="ViewConsulta" runat="server">
                          
                          <br />
                          
                          
                          <p class="large">Introduzca el Nombre de Usuario</p> 
                    
                            <table width="100%">
                                
                                
                    
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
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                    </td>
                               </tr>
              <tr>
                                    <td colspan="2">
                                
                                        <asp:GridView ID="uxConsultaUsuario" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaUsuario"
                                            AutoGenerateColumns="False" DataKeyNames="login" AutoGenerateSelectButton="True"
                                            Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10"
                                            OnSelectedIndexChanging="SelectUsuarios">
                                            
                                            <Columns>
                                            
                                            <asp:BoundField HeaderText="Usuario" DataField="Login" />
                                            <asp:BoundField HeaderText="Nombre Empleado" DataField="Nombre" />
                                            <asp:BoundField HeaderText="Apellido Empleado" DataField="Apellido" />  
                                            <asp:BoundField HeaderText="Status Usuario" DataField="Status" /> 
                                            
                                            </Columns>
                                            
                                            <EmptyDataTemplate>
                                                <center>
                                                    <span>No hay data cargada </span>
                                                </center>
                                            </EmptyDataTemplate>
                                        
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        
                        <asp:View ID="ViewUsuario" runat="server">
                        
                            <p class="large">Datos del Usuario</p>                    
                         
                            <form id="uxFormConsultarUsuario">
                            <table style="width:100%;">
                               <tr>
                                           <td><b>Usuario:</b></td>
                                           <td><asp:Label ID="uxNombreU" runat="server" Text=""></asp:Label></td>
                                       </tr>
                                       <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td><b>Nombre del Empleado:</b></td>
                                           <td><asp:Label ID="uxNombreEmp" runat="server" Text=""></asp:Label></td>
                                       </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                         
                                        </tr>
                                       <tr>
                                           <td><b>Apellido del Empleado:</b></td>
                                           <td><asp:Label ID="uxApellidoEmp" runat="server" Text=""></asp:Label></td>
                                       </tr>
                                       <tr>
                                           <td>&nbsp;</td>
                                          
                                        </tr>
                                        <tr>
                                           <td><b>Status:</b></td>
                                           <td><asp:Label ID="uxStatusU" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                        </tr>
                                           <tr>
                                           <td>&nbsp;</td>
                                           
                                        </tr>
                                             <tr>
                                           <td>&nbsp;</td>
                                           
                                        </tr>
                                        <tr>
                                    <td><b>Permisos:</b></td>
                                    <td>
                                        <table style="width: 100%; border: 1px solid #799CBE">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    Agregar</td>
                                                <td>
                                                    Consultar</td>
                                                <td>
                                                    Modificar</td>
                                                <td>
                                                    Eliminar</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Cargos</td>
                                                <td>
                                                    <input id="uxCbAgregarCargo" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarCargo" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarCargo" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarCargo" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Clientes</td>
                                                <td>
                                                    <input id="uxCbAgregarCliente" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarCliente" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarCliente" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarCliente" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Contactos</td>
                                                <td>
                                                    <input id="uxCbAgregarContacto" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarContacto" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarContacto" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarContacto" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Empleados</td>
                                                <td>
                                                    <input id="uxCbAgregarEmpleado" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarEmpleado" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarEmpleado" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarEmpleado" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Facturas</td>
                                                <td>
                                                    <input id="uxCbAgregarFactura" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarFactura" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarFactura" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Gastos</td>
                                                <td>
                                                    <input id="uxCbAgregarGasto" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarGasto" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarGasto" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarGasto" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Propuestas</td>
                                                <td>
                                                    <input id="uxCbAgregarPropuesta" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarPropuesta" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarPropuesta" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarPropuesta" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Usuarios</td>
                                                <td>
                                                    <input id="uxCbAgregarUsuario" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbConsultarUsuario" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbModificarUsuario" type="checkbox" disabled="disabled"/></td>
                                                <td>
                                                    <input id="uxCbEliminarUsuario" type="checkbox" disabled="disabled"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                  <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                        </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" />
                                    </td>
                                </tr>
                            </table>
                        </form>
                        
                        </asp:View>
                      </asp:MultiView> 
                      </form>                  
                 </div> 
                 
                 
                  <br />
                    <br />
                    <br />
                    <br />
                    <br />
 
              </div>
								</div> 
				
			</div> 
		</div>
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaUsuario" DataObjectTypeName="Core.LogicaNegocio.Entidades.Usuario" /> 
</asp:Content>
