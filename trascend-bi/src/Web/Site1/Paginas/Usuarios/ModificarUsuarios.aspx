<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" Title="Modificar Usuarios" AutoEventWireup="true" CodeFile="ModificarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_ModificarUsuarios" %>
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
                <li><a href="ConsultarUsuarios.aspx" >Consultar<span></span></a></li> 
                <li><a href="EliminarUsuarios.aspx" >Eliminar<span></span></a></li> 
                <li><a href="ModificarUsuarios.aspx" class="active">Modificar<span></span></a></li>
                </ul> 

            </div> 


            <div class="sub-content"> 
                <div class="features_overview"> 
                    <div class="features_overview_right"> 
                        <h3>Modificar Usuario</h3> 
                        <p class="large">Introduzca la informacion a continuación</p> 
                       
<form id="Form1" action="#" runat="server">

                            <asp:MultiView ID="uxMultiViewModificar" runat="server" ActiveViewIndex="0">
                                <asp:View ID="ViewConsultaUsuario" runat="server">
                                <span style="text-align:center"><uc3:MensajeInformacionBotonAceptar ID="uxMensajeInformacionBotonAceptar" runat="server" Visible="false" />
                                  </span>
                                    <p><div style="background-color:InfoBackground">Consultar usuario</div>
                                    <br />
                                    <table width="70%">
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
                                                <asp:Label runat="server" ID="uxLoginLabel" Text="<%$ Resources:DSU, IntroducirUsuario%>" Visible="false"></asp:Label>
                                                <asp:TextBox ID="uxLogin" runat="server" Visible="false">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="uxRequiredFieldValidator" runat="server" 
                                                ControlToValidate="uxLogin" Visible="false"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                                
                                                <span style="color:#FF0000"><asp:Label ID="uxAsteriscoStatus" Visible="false" runat="server" Text="<%$ Resources:DSU, Asterisco%>">
                                        </asp:Label></span><asp:Label runat="server" ID="uxStatusDdLLabel" Text="<%$ Resources:DSU, SeleccioneEstado%>" Visible="false"></asp:Label>
                                                <asp:DropDownList ID="uxStatusDdL" runat="server" Visible="false">
                                                    <asp:ListItem Value="ninguno" Text="Seleccionar..."></asp:ListItem>
                                                    <asp:ListItem Value="Activo" Text="Activo"></asp:ListItem>
                                                    <asp:ListItem Value="Inactivo" Text="Inactivo"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator id="uxRequiredFieldValidator2" runat="server" ControlToValidate="uxStatusDdL" 
                   InitialValue="ninguno"  ErrorMessage="<%$ Resources:DSU, FaltaEstadoUsuario %>" Display="Static" /> 
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
                                                            <!--<span>No hay data cargada </span>-->
                                                        </center>
                                                    </EmptyDataTemplate>

                                                </asp:GridView>
                                </asp:View>
                                <asp:View ID="ViewUsuario" runat="server">

                                    <p><div style="background-color:InfoBackground">Datos del usuario</div>
                                    <br />                    

                                    <form id="uxFormConsultarUsuario">
                                        <table style="width:100%;">
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label1" Text="<%$ Resources:DSU, Login%>" Visible="true"></asp:Label></b></td>
                                                <td><asp:Label ID="uxNombreU" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label2" Text="<%$ Resources:DSU, NombreEmpleado%>" Visible="true"></asp:Label></b></td>
                                                <td><asp:Label ID="uxNombreEmp" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label3" Text="<%$ Resources:DSU, ApellidoEmpleado%>" Visible="true"></asp:Label></b></td>
                                                <td><asp:Label ID="uxApellidoEmp" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <b><asp:Label runat="server" ID="Label4" Text="<%$ Resources:DSU, EstadoUsuario%>" Visible="true"></b></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="uxStatusUsuario" runat="server" 
                                                        onselectedindexchanged="StatusUsuario_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>

                                            </tr>
                                           
                                        </table>  
                                             
                                      
                                        <table style="width: 100%; border: 1px solid #799CBE">
                                           <tr>
                                                            <td>&nbsp;</td>
                                                            <td><asp:Label runat="server" ID="Label5" Text="<%$ Resources:DSU, Agregar%>" Visible="false"></asp:Label></td>
                                                            <td><asp:Label runat="server" ID="Label8" Text="<%$ Resources:DSU, Consultar%>" Visible="false"></asp:Label></td>
                                                            <td><asp:Label runat="server" ID="Label7" Text="<%$ Resources:DSU, Modificar%>" Visible="false"></asp:Label></td>
                                                            <td><asp:Label runat="server" ID="Label6" Text="<%$ Resources:DSU, Eliminar%>" Visible="false"></asp:Label></td>
                                                        </tr>
                                                          <tr>
                                                            <td>&nbsp;</td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>(<asp:LinkButton ID="lbAllAgregar" runat="server" onclick="lbAllAgregar_Click">todos, </asp:LinkButton>
                                                                       </td>
                                                            <td>(<asp:LinkButton ID="lbAllConsultar" runat="server" onclick="lbAllConsultar_Click">todos, </asp:LinkButton>
                                                                        </td>
                                                            <td>(<asp:LinkButton ID="lbAllModificar" runat="server" onclick="lbAllModificar_Click">todos, </asp:LinkButton>
                                                                        </td>
                                                            <td>(<asp:LinkButton ID="lbAllEliminar" runat="server" onclick="lbAllEliminar_Click">todos </asp:LinkButton>
                                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td> <asp:LinkButton ID="lbNoneAgregar" runat="server" onclick="lbNoneAgregar_Click">ninguno)</asp:LinkButton>
                                                            </td>
                                                            <td><asp:LinkButton ID="lbNoneConsultar" runat="server" onclick="lbNoneConsultar_Click">ninguno)</asp:LinkButton>
                                                            </td>
                                                            <td><asp:LinkButton ID="lbNoneModificar" runat="server" onclick="lbNoneModificar_Click">ninguno)</asp:LinkButton>
                                                                        </td>
                                                            <td><asp:LinkButton ID="lbNoneEliminar" runat="server" onclick="lbNoneEliminar_Click">Select None)</asp:LinkButton>
                                                                        </td>
                                                        </tr>
                                              <tr>
                                                            <td>&nbsp;</td>
                                                            
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
                                                <table style="width: 100%; border: 1px solid #799CBE">
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            
                                                        </td>
                                                        <td align="left">
                                                            (<asp:LinkButton ID="lbAllReporte" runat="server" onclick="lbAllReporte_Click">todos,
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="lbNoneReporte" runat="server" onclick="lbNoneReporte_Click">ninguno)</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <b>
                                                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:DSU, Reportes%>" 
                                                                Visible="true"></asp:Label>
                                                            </b></td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td align="center">
                                                            <asp:CheckBoxList ID="uxCBLReporte" runat="server">
                                                                <asp:ListItem Text="Paquete Anual" Value="33"></asp:ListItem>
                                                                <asp:ListItem Text="Total Anual" Value="34"></asp:ListItem>
                                                                <asp:ListItem Text="Total de Horas Anuales" Value="35"></asp:ListItem>
                                                                <asp:ListItem Text="Gastos" Value="36"></asp:ListItem>
                                                                <asp:ListItem Text="Gastos Anuales" Value="37"></asp:ListItem>
                                                                <asp:ListItem Text="Facturas Emitidas" Value="38"></asp:ListItem>
                                                                <asp:ListItem Text="Facturas Cobradas" Value="39"></asp:ListItem>
                                                                <asp:ListItem Text="Facturas Por Cobrar" Value="40"></asp:ListItem>
                                                                <asp:ListItem Text="Total Facturas Emitidas" Value="41"></asp:ListItem>
                                                                <asp:ListItem Text="Total Facturas Cobradas" Value="42"></asp:ListItem>
                                                                <asp:ListItem Text="Total Facturas Por Cobrar" Value="43"></asp:ListItem>
                                                                <asp:ListItem Text="Propuestas Emitidas" Value="44"></asp:ListItem>
                                                                <asp:ListItem Text="Total de Propuestas Emitidas" Value="45"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                </table>
                                          
                                                  <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <table>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td align="right">
                                                    <asp:Button ID="uxBotonAceptar" runat="server" Text="<%$ Resources:DSU, Aceptar%>" 
                                                    onclick="uxBotonAceptar_Click" />
                                                </td>
                                            </tr>
                                            
                                         
                                        </table>
                                    </form>

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
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaModificarUsuario" DataObjectTypeName="Core.LogicaNegocio.Entidades.Usuario" /> 

</asp:Content>
