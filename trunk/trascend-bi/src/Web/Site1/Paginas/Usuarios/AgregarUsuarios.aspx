<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_AgregarUsuarios" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacionBotonAceptar" TagPrefix="uc3" %>

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
                         <p class="large">Introduzca la informacion a continuación</p> 
                        
                      
                        
                        <asp:MultiView ID="uxMultiViewAgregar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                                  <span style="text-align:center"><uc3:MensajeInformacionBotonAceptar ID="uxMensajeInformacionBotonAceptar" 
                                                        runat="server" Visible="false" /></span>
                                    <p><div style="background-color:InfoBackground">Consultar por nombre de empleado que no tienen acceso al sistema</div>
                                   
                                    <br />
                    
                                    <table width="1000px">
                                
                                        <tr>
                                            <td><asp:Label runat="server" ID="uxCampoNombreEmpleado" Text="<%$ Resources:DSU, NombreEmpleadoObligatorio %>"></asp:Label></td>
                                            <td><asp:TextBox ID="uxNombreEmpleadoBuscar" runat="server"></asp:TextBox>
                                            </td>
                                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="uxNombreEmpleadoBuscar" 
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" /></td>
                                        </tr>
                                        
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="center">&nbsp;&nbsp;<asp:Button ID="uxBotonBuscar" runat="server" Text="<%$ Resources:DSU, Buscar%>" onclick="uxBotonBuscar_Click"/></td>
                                        </tr>
                                       
                                        
                                         <tr><td>&nbsp;</td></tr>
                                    </table>
                                     <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" EnableViewState="false" Visible="false" />
                                     
                                    <asp:GridView ID="uxConsultaEmpleado" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaEmpleado"
                                                AutoGenerateColumns="False" DataKeyNames="cedula" AutoGenerateSelectButton="True"
                                                Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10"
                                                OnSelectedIndexChanging="SelectEmpleados">
                                            
                                                    <Columns>
                                            
                                                        <asp:BoundField HeaderText="Cedula" DataField="cedula" />
                                                        <asp:BoundField HeaderText="Nombre Empleado" DataField="nombre" />
                                                        <asp:BoundField HeaderText="Apellido Empleado" DataField="apellido" />
                                                        
                                                    </Columns>
                                            
                                                    <EmptyDataTemplate>
                                                        <center>
                                                            <!--<span>No hay data cargada </span>-->
                                                            </center>
                                                    </EmptyDataTemplate>
                                        
                                                 </asp:GridView>
                                </asp:View>
                        
                                <asp:View ID="ViewEmpleado" runat="server">
                        
                                   <p><div style="background-color:InfoBackground">Datos del Empleado</div>
                                                     
                         
                                    <!--form id="uxFormConsultarUsuario" action=""-->
                            
                                        <table style="width:100%;">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td><b><asp:Label ID="uxCampoCedula" runat="server" Text="<%$ Resources:DSU, CampoCedula%>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxCedula" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                       
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                       
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label3" Text="<%$ Resources:DSU, NombreEmpleado %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxNombreEmp" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                       
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label4" Text="<%$ Resources:DSU, ApellidoEmpleado %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxApellidoEmp" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                       
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label5" Text="<%$ Resources:DSU, EstadoEmpleado %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxStatusE" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        
                                            <tr>
                                                <td><asp:Label ID="Label1" runat="server" Text="<%$ Resources:DSU, Login%>"></asp:Label></td>
                                                <td><asp:TextBox ID="uxLogin" runat="server"></asp:TextBox></td>
                                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                    ControlToValidate="uxLogin" 
                                                    ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><asp:Label ID="Label2" runat="server" Text="<%$ Resources:DSU, Contrasena%>"></asp:Label></td>
                                                <td><asp:TextBox ID="uxContrasena" runat="server"></asp:TextBox></td>
                                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                    ControlToValidate="uxLogin" 
                                                    ErrorMessage="<%$ Resources:DSU, FaltaContrasena%>" Font-Size="Smaller" Display="Static" /></td>
                                            </tr>
                                            <tr>
                                               <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                        <table>
                                          
                                           
                                           <tr>
                                                <td>&nbsp;</td>
                                           </tr>
                                        
                                           <tr>
                                                <td><b><asp:Label ID="Label6" runat="server" Text="<%$ Resources:DSU, Permisos%>"></asp:Label></b></td>
                                                <td>
                                                    <table style="width: 500px; border: 1px solid #799CBE">
                                                     <tr>
                                                            <td>&nbsp;</td>
                                                            <td><asp:Label ID="Label8" runat="server" Text="<%$ Resources:DSU, Aceptar%>"></asp:Label></td>
                                                            <td><asp:Label ID="Label9" runat="server" Text="<%$ Resources:DSU, Consultar%>"></asp:Label></td>
                                                            <td><asp:Label ID="Label10" runat="server" Text="<%$ Resources:DSU, Modificar%>"></asp:Label></td>
                                                            <td><asp:Label ID="Label11" runat="server" Text="<%$ Resources:DSU, Eliminar%>"></asp:Label></td>
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
                                                    
                                                    <table style="width: 100%; border: 1px solid #799CBE">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                          
                                                        </tr>
                                                        
                                                          <tr>
                                                            <td>&nbsp;</td>
                                                            <td><asp:Label ID="Label7" runat="server" Text="<%$ Resources:DSU, Reportes%>"></asp:Label></td>
                                                            <td>(<asp:LinkButton ID="lbAllReporte" runat="server" onclick="lbAllReporte_Click">todos, </asp:LinkButton>
                                                                <asp:LinkButton ID="lbNoneReporte" runat="server" onclick="lbNoneReporte_Click">ninguno)</asp:LinkButton>
                                                            </td>
                                                          </tr>
                                                          
                                                          <tr>
                                                          <td>&nbsp;</td>
                                                          <td>&nbsp;</td>
                                                           <td> 
                                                                <asp:CheckBoxList ID="uxCBLReporte" runat="server">
                                                                    <asp:ListItem Value="33" Text="Paquete Anual" ></asp:ListItem>
                                                                    <asp:ListItem Value="34" Text="Total Anual" ></asp:ListItem>
                                                                    <asp:ListItem Value="35" Text="Total de Horas Anuales"></asp:ListItem>
                                                                    <asp:ListItem Value="36" Text="Gastos"></asp:ListItem>
                                                                    <asp:ListItem Value="37" Text="Gastos Anuales" ></asp:ListItem>
                                                                    <asp:ListItem Value="38" Text="Facturas Emitidas" ></asp:ListItem>
                                                                    <asp:ListItem Value="39" Text="Facturas Cobradas" ></asp:ListItem>
                                                                    <asp:ListItem Value="40" Text="Facturas Por Cobrar" ></asp:ListItem>
                                                                    <asp:ListItem Value="41" Text="Total Facturas Emitidas" ></asp:ListItem>
                                                                    <asp:ListItem Value="42" Text="Total Facturas Cobradas" ></asp:ListItem>
                                                                    <asp:ListItem Value="43" Text="Total Facturas Por Cobrar" ></asp:ListItem>
                                                                    <asp:ListItem Value="44" Text="Propuestas Emitidas" ></asp:ListItem>
                                                                    <asp:ListItem Value="45" Text="Total de Propuestas Emitidas" ></asp:ListItem>
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
                                                <td align="right"><asp:Button ID="uxBotonAceptar" runat="server" Text="<%$ Resources:DSU, Aceptar%>" 
                                                        onclick="uxBotonAceptar_Click" /></td>
                                            </tr>
                                       
                                            
                                        
                                        </table>
                                        
                                    <!--/form-->
                                
                                </asp:View>
                            
                            </asp:MultiView> 
                           <asp:UpdatePanel ID="up2" runat="server">
                                <ContentTemplate>
                                    <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        
                        

                    </div>

                    
                </div> 

            </div> 

        </div> 
    </div> 
</form>
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaEmpleado" DataObjectTypeName="Core.LogicaNegocio.Entidades.Empleado" /> 

</asp:Content>
