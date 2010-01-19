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
                        
                        <p class="large"></p>
                            
                        <form id="Form1" action="#" runat="server">
                    
                            <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                          
                                    <br />
                          
                                    <p class="large">Introduzca los campos según su tipo de búsqueda</p> 
                    
                                    <table width="100%">
                                
                                        <tr>
                                            <td></td>
                                            <td><b>Consulta por Nombre</b></td>
                                        </tr>
                                        <tr>
                                            <td>Nombre de Usuario:</td>
                                            <td><asp:TextBox ID="uxLogin" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" onclick="uxBotonBuscar_Click"/>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td></td>
                                            <td><b>Consulta por Status</b></td>
                                        </tr>
                                         <tr>
                                            <td>Status del Usuario</td>
                                            <td>
                                                <asp:DropDownList ID="uxStatusDdL" runat="server">
                                                    <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                                    <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                                                </asp:DropDownList>
                                           </td>
                                           <td>
                                                <asp:Button ID="uxBotonBuscarStatus" runat="server" Text="Buscar" onclick="uxBotonBuscarStatus_Click"/>
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
                         
                                    <!--form id="uxFormConsultarUsuario" action=""-->
                            
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
                                                            <td>&nbsp;</td>
                                                            <td>Agregar</td>
                                                            <td>Consultar</td>
                                                            <td>Modificar</td>
                                                            <td>Eliminar</td>
                                                        </tr>
                                            
                                                        <tr>
                                                            <td> &nbsp; </td>
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLAgregar" runat="server">
                                                                    <asp:ListItem Value="1" Text="Cargo" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="Cliente" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="9" Text="Contacto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="13" Text="Empleado" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="17" Text="Factura" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="21" Text="Gasto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="25" Text="Propuesta" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="29" Text="Usuario" Enabled="false"></asp:ListItem>
                                                                </asp:CheckBoxList> 
                                                            </td>
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLConsultar" runat="server">
                                                                    <asp:ListItem Value="2" Text="Cargo" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Cliente" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="10" Text="Contacto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="14" Text="Empleado" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="18" Text="Factura" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="22" Text="Gasto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="26" Text="Propuesta" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="30" Text="Usuario" Enabled="false"></asp:ListItem>
                                                                </asp:CheckBoxList> 
                                                            </td>
                                            
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLModificar" runat="server">
                                                                    <asp:ListItem Value="3" Text="Cargo" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="7" Text="Cliente" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="11" Text="Contacto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="15" Text="Empleado" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="19" Text="Factura" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="23" Text="Gasto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="27" Text="Propuesta" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="31" Text="Usuario" Enabled="false"></asp:ListItem>
                                                                </asp:CheckBoxList> 
                                                            </td>
                                                    
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLEliminar" runat="server">
                                                                    <asp:ListItem Value="4" Text="Cargo" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="8" Text="Cliente" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="12" Text="Contacto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="16" Text="Empleado" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="20" Text="Factura" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="24" Text="Gasto" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="28" Text="Propuesta" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="32" Text="Usuario" Enabled="false"></asp:ListItem>
                                                                </asp:CheckBoxList> 
                                                            </td>
                                                        </tr>
                                           
                                                    </table>
                                                
                                                </td>
                                           </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td align="center"><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                                        onclick="uxBotonAceptar_Click" /></td>
                                            </tr>
                                        
                                        </table>
                                    
                                    <!--/form-->
                                
                                </asp:View>
                            
                            </asp:MultiView> 
                      </form>                  
                 </div> 
                 
              </div>
		
		</div> 
				
	</div> 
</div>

<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaUsuario" DataObjectTypeName="Core.LogicaNegocio.Entidades.Usuario" /> 

</asp:Content>
