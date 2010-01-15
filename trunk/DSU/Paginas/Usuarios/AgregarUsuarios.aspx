<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Inherits="Paginas_Usuarios_AgregarUsuarios" Codebehind="AgregarUsuarios.aspx.cs" %>

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
                          <div style="background-color:InfoBackground">Consultar Usuario</div>
                          <br />
                            <table width="70%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:DSU, NombreUsuario%>"></asp:Label>
                                    </td>
                                    <td>
                                         <asp:TextBox ID="uxNombreUsuario" runat="server" Width="150px" TabIndex="1"></asp:TextBox>
                                     </td>   
                                        
                                     <td>   
                                        <asp:Button ID="uxBuscar" runat="server" Text="Buscar" OnClick="uxBuscar_Click" TabIndex="2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxNombreUsuario"
                                            Display="Static" Font-Size="Smaller" ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>"/></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="uxConsultaUsuarios" runat="server" AllowPaging="True" DataSourceID=""
                                            AutoGenerateColumns="False" DataKeyNames="" AutoGenerateSelectButton="True"
                                            Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10" OnPageIndexChanging="PageChangingUsuarios"
                                            OnSelectedIndexChanging="SelectUsuarios">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Nombre">
                                                    <ItemTemplate>
                                                      <!--  <asp:HiddenField ID="DistribuidorId" runat="server" Value='<%# Eval("DistribuidorVehiculo.EntidadId") %>' />
                                                        <asp:Label ID="uxNombreUser" runat="server" Text='<%# Eval("Usuario.NombreUsuario") %>' />-->
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Apellido">
                                                    <ItemTemplate>
                                                      <!--  <asp:Label ID="uxApellidoUser" runat="server" Text='<%# Eval("Usuario.ApellidoUsuario") %>' /> -->
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nombre de Usuario">
                                                    <ItemTemplate>
                                                     <!--   <asp:Label ID="uxUserName" runat="server" Text='<%# Eval("Usuario.NombreDeUsuario") %>' /> -->
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                            <div style="background-color:InfoBackground">Ingresar Usuario</div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <form id="uxFormAgregarUsuario">
                            <table style="width:100%;">
                               <tr>
                                           <td>Nombre:</td>
                                           <td><asp:TextBox ID="uxNombre" runat="server"></asp:TextBox></td>
                                       </tr>
                                       <tr>
                                           <td>&nbsp;</td>
                                           <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="uxNombre" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                            </td>
                                       </tr>
                                       <tr>
                                           <td>Apellido:</td>
                                           <td><asp:TextBox ID="uxApellido" runat="server"></asp:TextBox></td>
                                       </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="uxApellido" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaApellidoUsuario%>" Font-Size="Smaller" Display="Static" />
                                            </td>
                                        </tr>
                                       <tr>
                                           <td>Nombre de Usuario:</td>
                                           <td><asp:TextBox ID="uxUsername" runat="server"></asp:TextBox></td>
                                       </tr>
                                       <tr>
                                           <td>&nbsp;</td>
                                           <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="uxUsername" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaUserName%>" Font-Size="Smaller" Display="Static" />
                                            </td>
                                        </tr>
                                        <tr>
                                           <td>Contraseña:</td>
                                           <td><asp:TextBox ID="uxPassword" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="uxPassword" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaContrasenaUsuario%>" Font-Size="Smaller" Display="Static" />
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                    <td>
                                        Permisos:</td>
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
                                                    <input id="Checkbox1" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox16" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox17" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox25" type="checkbox" /></td>
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
                                                    <input id="Checkbox2" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox15" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox18" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox26" type="checkbox" /></td>
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
                                                    <input id="Checkbox3" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox14" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox19" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox27" type="checkbox" /></td>
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
                                                    <input id="Checkbox4" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox13" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox20" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox28" type="checkbox" /></td>
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
                                                    <input id="Checkbox5" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox12" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox21" type="checkbox" /></td>
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
                                                    <input id="Checkbox6" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox11" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox22" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox29" type="checkbox" /></td>
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
                                                    <input id="Checkbox7" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox9" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox23" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox30" type="checkbox" /></td>
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
                                                    <input id="Checkbox8" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox10" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox24" type="checkbox" /></td>
                                                <td>
                                                    <input id="Checkbox31" type="checkbox" /></td>
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
                        
                       
                        
                        

                    </div>

                    
                </div> 

            </div> 

        </div> 
    </div> 
</form>
</asp:Content>
