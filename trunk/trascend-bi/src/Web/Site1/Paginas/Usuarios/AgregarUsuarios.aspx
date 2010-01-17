<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_AgregarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<form id="form1" runat="server">

    <div class="container subnav"> 
    
        <div class="content"> 
    
            <div class="sub-heading"> 
                <h2>Usuarios</h2> 
            </div> 
    
            <div class="subnav-container"> 

                <ul id="subnav"> 
                    
                    <li><a href="AgregarUsuarios.aspx" class="active">Agregar<span></span></a></li> 
                    
                    <li><a href="ConsultarUsuarios.aspx" >Consultar<span></span></a></li> 
                    
                    <li><a href="EliminarUsuarios.aspx" >Eliminar<span></span></a></li> 
                    
                    <li><a href="ModificarUsuarios.aspx" >Modificar<span></span></a></li>
                </ul> 

            </div> 

            <div class="sub-content"> 

                <div class="features_overview"> 
    
                    <div class="features_overview_right"> 
                        <h3>Agregar Usuarios</h3>
                        
                        <p class="large">Introduzca la informacón a continuación</p>  
                      
                        
                        <asp:MultiView ID="uxMultiViewAgregar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                          
                                    <br />
                          
                                    <p class="large">Introduzca el Nombre del Empleado</p> 
                    
                                    <table width="100%">
                                
                                        <tr>
                                            <td>Nombre de Empleado:</td>
                                            <td><asp:TextBox ID="uxNombreEmpleadoBuscar" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" onclick="uxBotonBuscar_Click"/>
                                            </td>
                                        </tr>
                               
                                        <tr>
                                            <td></td>
                                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="uxNombreEmpleadoBuscar" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="uxConsultaEmpleado" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaEmpleado"
                                                AutoGenerateColumns="False" DataKeyNames="cedula" AutoGenerateSelectButton="True"
                                                Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10"
                                                OnSelectedIndexChanging="SelectEmpleados">
                                            
                                                    <Columns>
                                            
                                                        <asp:BoundField HeaderText="Cedula" DataField="cedula" />
                                                        <asp:BoundField HeaderText="Nombre Empleado" DataField="nombre" />
                                                        <asp:BoundField HeaderText="Apellido Empleado" DataField="apellido" />  
                                                        <asp:BoundField HeaderText="Status Empleado" DataField="estado" /> 
                                                        
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
                        
                                <asp:View ID="ViewEmpleado" runat="server">
                        
                                    <p class="large">Datos del Empleado</p>                    
                         
                                    <!--form id="uxFormConsultarUsuario" action=""-->
                            
                                        <table style="width:100%;">
                                            
                                            <tr>
                                                <td><b>Cedula:</b></td>
                                                <td><asp:Label ID="uxCedula" runat="server" Text=""></asp:Label></td>
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
                                                <td><b>Status del Empleado:</b></td>
                                                <td><asp:Label ID="uxStatusE" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        
                                            <tr>
                                                <td>Login:</td>
                                                <td><asp:TextBox ID="uxLogin" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                    ControlToValidate="uxLogin" 
                                                    ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>Contraseña:</td>
                                                <td><asp:TextBox ID="uxContrasena" runat="server" TextMode="Password"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                    ControlToValidate="uxLogin" 
                                                    ErrorMessage="<%$ Resources:DSU, FaltaContrasena%>" Font-Size="Smaller" Display="Static" />
                                                </td>
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
                                                                    <asp:ListItem Value="1" Text="Cargo"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="Cliente"></asp:ListItem>
                                                                    <asp:ListItem Value="9" Text="Contacto"></asp:ListItem>
                                                                    <asp:ListItem Value="13" Text="Empleado"></asp:ListItem>
                                                                    <asp:ListItem Value="17" Text="Factura"></asp:ListItem>
                                                                    <asp:ListItem Value="21" Text="Gasto"></asp:ListItem>
                                                                    <asp:ListItem Value="25" Text="Propuesta"></asp:ListItem>
                                                                    <asp:ListItem Value="29" Text="Usuario"></asp:ListItem>
                                                                </asp:CheckBoxList> 
                                                            </td>
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLConsultar" runat="server">
                                                                    <asp:ListItem Value="2" Text="Cargo"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Cliente"></asp:ListItem>
                                                                    <asp:ListItem Value="10" Text="Contacto"></asp:ListItem>
                                                                    <asp:ListItem Value="14" Text="Empleado"></asp:ListItem>
                                                                    <asp:ListItem Value="18" Text="Factura"></asp:ListItem>
                                                                    <asp:ListItem Value="22" Text="Gasto"></asp:ListItem>
                                                                    <asp:ListItem Value="26" Text="Propuesta"></asp:ListItem>
                                                                    <asp:ListItem Value="30" Text="Usuario"></asp:ListItem>
                                                                    
                                                                </asp:CheckBoxList> 
                                                            </td>
                                            
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLModificar" runat="server">
                                                                    <asp:ListItem Value="3" Text="Cargo"></asp:ListItem>
                                                                    <asp:ListItem Value="7" Text="Cliente"></asp:ListItem>
                                                                    <asp:ListItem Value="11" Text="Contacto"></asp:ListItem>
                                                                    <asp:ListItem Value="15" Text="Empleado"></asp:ListItem>
                                                                    <asp:ListItem Value="19" Text="Factura"></asp:ListItem>
                                                                    <asp:ListItem Value="23" Text="Gasto"></asp:ListItem>
                                                                    <asp:ListItem Value="27" Text="Propuesta"></asp:ListItem>
                                                                    <asp:ListItem Value="31" Text="Usuario"></asp:ListItem>
                                                                    </asp:CheckBoxList> 
                                                            </td>
                                                    
                                                            <td align="center"> 
                                                                <asp:CheckBoxList ID="uxCBLEliminar" runat="server">
                                                                    <asp:ListItem Value="4" Text="Cargo"></asp:ListItem>
                                                                    <asp:ListItem Value="8" Text="Cliente"></asp:ListItem>
                                                                    <asp:ListItem Value="12" Text="Contacto"></asp:ListItem>
                                                                    <asp:ListItem Value="16" Text="Empleado"></asp:ListItem>
                                                                    <asp:ListItem Value="20" Text="Factura" Enabled="false"></asp:ListItem>
                                                                    <asp:ListItem Value="24" Text="Gasto"></asp:ListItem>
                                                                    <asp:ListItem Value="28" Text="Propuesta"></asp:ListItem>
                                                                    <asp:ListItem Value="32" Text="Usuario"></asp:ListItem>
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
                       
                        
                        

                    </div>

                    
                </div> 

            </div> 

        </div> 
    </div> 
</form>
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaEmpleado" DataObjectTypeName="Core.LogicaNegocio.Entidades.Empleado" /> 

</asp:Content>
