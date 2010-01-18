<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" Title="Modificar Usuarios" AutoEventWireup="true" CodeFile="ModificarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_ModificarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <div class="container subnav"> 
        <div class="content"> 
            <div class="sub-heading"> 
            <h2>Usuarios</h2> 
            </div> 
            
            <div class="subnav-container"> 
                <ul id="subnav"> 
                <li><a href="AgregarUsuarios.aspx">Agregar<span></span></a></li> 
                <li><a href="ConsultarUsuarios.aspx" >Consultar<span></span></a></li> 
                <li><a href="EliminarUsuarios.aspx" >Eliminar<span></span></a></li> 
                <li><a href="ModificarUsuarios.aspx" class="active">Modificar<span></span></a></li>
                </ul> 

            </div> 


            <div class="sub-content"> 
                <div class="features_overview"> 
                    <div class="features_overview_right"> 
                        <h3>Modificar Usuario</h3> 
                        <p class="large">Introduzca el Nombre de Usuario</p> 

                        <p class="large"></p>

                        <form id="Form1" action="#" runat="server">

                            <asp:MultiView ID="uxMultiViewModificar" runat="server" ActiveViewIndex="0">
                                <asp:View ID="ViewConsultaUsuario" runat="server">

                                    <br />
                                    <table width="70%">
                                        <tr>
                                            <td>Nombre de Usuario:</td>
                                            <td><asp:TextBox ID="uxLogin" runat="server"></asp:TextBox></td>

                                            <td>
                                            <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" onclick="uxBotonBuscar_Click"/>
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

                                                <asp:GridView ID="uxConsultaModificarUsuario" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaModificarUsuario"
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
                                            </table>  
                                             
                                        <td>&nbsp; </td>

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
                                                <td> <b>Permisos:</b></td>
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

                                            <tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelTipoConsulta" runat="server" Text = "Status Usuario" />
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="uxStatusUsuario" runat="server" 
                                                        onselectedindexchanged="StatusUsuario_SelectedIndexChanged">
                                                        <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                                        <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <td>
                                                <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                                onclick="uxBotonAceptar_Click" /></td>
                                            </tr>


                                        </table>
                                    </form>

                                </asp:View>
                            </asp:MultiView> 
                        </form>                  
                    </div> 
                </div>
            </div> 
        </div>
    </div> 
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaModificarUsuario" DataObjectTypeName="Core.LogicaNegocio.Entidades.Usuario" /> 

</asp:Content>
