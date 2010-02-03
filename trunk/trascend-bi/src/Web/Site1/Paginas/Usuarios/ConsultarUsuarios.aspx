<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Title="Consultar Usuario" CodeFile="ConsultarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_ConsultarUsuarios" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

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
                 
                    <div class="features_overview_rightUser"> 
                        
                        <h3>Consultar Usuario</h3> 
                        
                       <p class="large">Introduzca la informacion a continuación</p> 
                       
                            
                        <form id="Form1" action="#" runat="server">
                        
                            <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                          <span style="text-align:center; font-size:small; color:Red">
                                    <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" 
                                                    Visible="false" />
                                       
                                        </span>  
                                    <p>
                                     
                                    <!--<div style="background-color:InfoBackground">
                                    <asp:Label runat="server" ID="Label13" Text="<%$ Resources:DSU, ConsultarUsuario%>" Visible="true">
                                    </asp:Label>
                                                </div>-->
                                    <div><b><asp:Label runat="server" ID="Label14" 
                                    Text="<%$ Resources:DSU, ConsultarUsuario%>" Visible="true"></asp:Label>
                                            </b></div>
                                    <br />
                                    <table class="solotablasuser">
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
                                     
                                        </table>
                                        <table class="solotablasuser">
                                            <tr>
                                             <td align="center">
                                                <asp:Button ID="uxBotonBuscar" runat="server" onclick="uxBotonBuscar_Click" 
                                                    Text="<%$ Resources:DSU, Buscar%>" Visible="false" />
                                                </td>
                                                
                                                <td>&nbsp;</td>
                                               
                                                <td>&nbsp;</td>
                                               
                                            </tr>
                                        </table>
                                      
                                       <table class="solotablasuser">
                                       <tr>
                                              <td>
                                                  <asp:GridView ID="uxConsultaUsuario" runat="server" AllowPaging="True" 
                                                      AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                                                      DataKeyNames="login" DataSourceID="uxObjectConsultaUsuario" 
                                                      Font-Names="Verdana" Font-Size="Smaller" 
                                                      onrowdatabound="uxGridView_RowDataBound" 
                                                      OnSelectedIndexChanging="SelectUsuarios" Width="100%">
                                                      <RowStyle HorizontalAlign="Center" />
                                                      <Columns>
                                                          <asp:BoundField DataField="Login" HeaderText="Usuario" />
                                                          <asp:BoundField DataField="Nombre" HeaderText="Nombre Empleado" />
                                                          <asp:BoundField DataField="Apellido" HeaderText="Apellido Empleado" />
                                                          <asp:BoundField DataField="Status" HeaderText="Status Usuario" />
                                                      </Columns>
                                                  </asp:GridView>
                                              </td>
                                          </tr>
                                        
                                                                              
                                       
                                        
                                    </table>
                                    
                                </asp:View>
                        
                                <asp:View ID="ViewUsuario" runat="server">
                        
                                    <p>
                                    <!--<div style="background-color:InfoBackground">
                                    <asp:Label runat="server" ID="Label11" Text="<%$ Resources:DSU, DatosUsuario%>" Visible="true">
                                    </asp:Label>
                                                </div>-->
                                    <div><asp:Label runat="server" ID="Label12" Text="<%$ Resources:DSU, DatosUsuario%>" Visible="true"></asp:Label>
                                                </div>
                                    <br />                    
                         
                                    <!--form id="uxFormConsultarUsuario" action=""-->
                            
                                        <table class="solotablasuser">
                                            
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="uxCampoNombreEmpleado" Text="<%$ Resources:DSU, Login %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxNombreU" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                       
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                       
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label1" Text="<%$ Resources:DSU, NombreEmpleadoAgregar %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxNombreEmp" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                       
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label2" Text="<%$ Resources:DSU, ApellidoEmpleado %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxApellidoEmp" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                       
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        
                                            <tr>
                                                <td><b><asp:Label runat="server" ID="Label3" Text="<%$ Resources:DSU, EstadoEmpleado %>"></asp:Label></b></td>
                                                <td><asp:Label ID="uxStatusU" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        
                                          
                                        </table>
                                            <table class="solotablasuser" style="width: 100%; border: 1px solid #799CBE">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DSU, Agregar %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DSU, Consultar %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:DSU, Modificar %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DSU, Eliminar %>"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>
                                                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:DSU, Permisos %>"></asp:Label>
                                                        </b>
                                                    </td>
                                                    
                                                        <td align="center">
                                                            <asp:CheckBoxList ID="uxCBLAgregar" runat="server">
                                                                <asp:ListItem Enabled="false" Text="Cargo" Value="1"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Cliente" Value="5"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Contacto" Value="9"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Empleado" Value="13"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Factura" Value="17"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Gasto" Value="21"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Propuesta" Value="25"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Usuario" Value="29"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBoxList ID="uxCBLConsultar" runat="server">
                                                                <asp:ListItem Enabled="false" Text="Cargo" Value="2"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Cliente" Value="6"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Contacto" Value="10"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Empleado" Value="14"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Factura" Value="18"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Gasto" Value="22"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Propuesta" Value="26"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Usuario" Value="30"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBoxList ID="uxCBLModificar" runat="server">
                                                                <asp:ListItem Enabled="false" Text="Cargo" Value="3"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Cliente" Value="7"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Contacto" Value="11"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Empleado" Value="15"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Factura" Value="19"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Gasto" Value="23"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Propuesta" Value="27"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Usuario" Value="31"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBoxList ID="uxCBLEliminar" runat="server">
                                                                <asp:ListItem Enabled="false" Text="Cargo" Value="4"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Cliente" Value="8"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Contacto" Value="12"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Empleado" Value="16"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Factura" Value="20"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Gasto" Value="24"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Propuesta" Value="28"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Usuario" Value="32"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                   
                                                </tr>
                                              
                                                <table style="width: 100%; border: 1px solid #799CBE">
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td><b><asp:Label ID="Label9" 
                                                        runat="server" Text="<%$ Resources:DSU, Reportes %>"></asp:Label></b></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td align="center"><asp:CheckBoxList ID="uxCBLReporte" CssClass="chkBoxListUser" runat="server">
                                                                <asp:ListItem Enabled="false" Text="Paquete Anual" Value="33"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Total Anual" Value="34"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Total de Horas Anuales" Value="35"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Gastos" Value="36"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Gastos Anuales" Value="37"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Facturas Emitidas" Value="38"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Facturas Cobradas" Value="39"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Facturas Por Cobrar" Value="40"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Total Facturas Emitidas" Value="41"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Total Facturas Cobradas" Value="42"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Total Facturas Por Cobrar" Value="43"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Propuestas Emitidas" Value="44"></asp:ListItem>
                                                                <asp:ListItem Enabled="false" Text="Total de Propuestas Emitidas" Value="45"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            <table class="solotablasuser">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                <td align="right"> <asp:Button ID="uxBotonRegresar" runat="server" Text="<%$ Resources:DSU, Regresar %>" 
                                                   onclick="uxBotonRegresar_Click"/></td>
                                                    <td align="right">
                                                        <asp:Button ID="uxBotonAceptar" runat="server" onclick="uxBotonAceptar_Click" 
                                                            Text="<%$ Resources:DSU, Aceptar %>" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--/form-->
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

<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaUsuario" DataObjectTypeName="Core.LogicaNegocio.Entidades.Usuario" /> 

</asp:Content>
