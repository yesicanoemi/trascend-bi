<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" 
CodeFile="ConsultarEmpleados.aspx.cs" Inherits="Paginas_Empleados_ConsultarEmpleados" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>

<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>


<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Empleados</h2> 
				</div> 
			<div class="subnav-container"> 
				
<ul id="subnav"> 
  <li><a href="AgregarEmpleados.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarEmpleados.aspx" class="active">Consultar<span></span></a></li> 
  <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li>
  <li><a href="ModificarEmpleados.aspx">Modificar<span></span></a></li>
</ul> 
						
    </div> 
				
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    
                    <h3>Consultar Empleado</h3>
                    
                        <p class="large">
                        </p>
                            
                    <form id="Form1" action="#" runat="server">
                    
                    <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                          <asp:View ID="ViewConsulta" runat="server">
                          
                          <br />
                         
                           <table width="100%" border="0">
  <tr>
    <td colspan="2"><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Introduzca Tipo de Consulta" Font-Size="Medium"/></td>
  </tr>
  <tr>
    <td colspan="2">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2">&nbsp;</td>
  </tr>
   <tr>
    <td colspan="2" ><strong>Realizar consulta por:</strong></td>
  </tr>
  <tr>
    <td colspan="2">&nbsp;</td>
  </tr>
  <tr>
    <td width="50%"><asp:RadioButtonList ID="opcion1" runat="server" Width="200px"  
                                                    OnSelectedIndexChanged="uxRbCampoBusqueda_SelectedIndexChanged" 
                                                    AutoPostBack="true" Visible="true">
      <asp:ListItem Value="1">Cedula</asp:ListItem>
      <asp:ListItem Value="2">Nombre</asp:ListItem>
      <asp:ListItem Value="3">Cargo</asp:ListItem>
    </asp:RadioButtonList></td>
    <td width="50%"><table width="100%" border="1">
      <tr>
        <td align="left" width="50%">
            <asp:TextBox ID="uxParametro" runat="server" Visible="false">
     
            </asp:TextBox><asp:TextBox ID="uxParametroCedula" runat="server" Visible="false">
            </asp:TextBox>  <asp:DropDownList ID="listaCargo" runat="server" Visible="false"> </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td>        
        <asp:RegularExpressionValidator Display="Static" ID="RegularExpressionValidator1"
        runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoNumCedula%>"
        ControlToValidate="uxParametroCedula" ValidationExpression="<%$Resources:DSU, ERFormatoNumCedula%>"
        Font-Size="Smaller">
        </asp:RegularExpressionValidator>
                                            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxParametroCedula" 
        ErrorMessage="<%$ Resources:DSU, FaltaCIEmpleado%>" Font-Size="Smaller"
        Display="Static" />
        
     <AjaxControlToolkit:FilteredTextBoxExtender  
            runat="server" ID="FilteredTextBoxExtender6" TargetControlID="uxParametro" FilterType="LowercaseLetters, 
             UppercaseLetters">
     </AjaxControlToolkit:FilteredTextBoxExtender>
     
     <AjaxControlToolkit:FilteredTextBoxExtender  
            runat="server" ID="FilteredTextBoxExtender1" TargetControlID="uxParametroCedula" FilterType="Custom, Numbers">
     </AjaxControlToolkit:FilteredTextBoxExtender>
     
     

     </td>
      </tr>
      <tr>
        <td align="center"><asp:Button ID="uxBotonAceptar" runat="server" Text="Buscar" onclick="uxBotonAceptar_Click" Visible="false"/></td>
      </tr>
      <tr>
            <td>&nbsp;</td>
      </tr>
	   <tr>
        <td align="center"><asp:Label ID="Label1" runat="server" Text = "Introduzca" Visible = "False" /></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td colspan="2">&nbsp;</td>
  </tr>
   <tr>
       <td colspan="2"><asp:GridView ID="uxConsultarEmpleado" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultarEmpleado"
                                            AutoGenerateColumns="False" DataKeyNames ="ID" AutoGenerateSelectButton="True"
                                            Width="95%" Font-Names="Verdana" Font-Size="Smaller" PageSize = "10"
                                            OnSelectedIndexChanging="SelectUsuarios">
         <columns>
         <asp:BoundField HeaderText="Cedula" DataField="Cedula" SortExpression="Cedula"  />
         <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
         <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
         </columns>
         
         <EmptyDataTemplate>
           <center>
             <span></span>
           </center>
         </EmptyDataTemplate>
       </asp:GridView></td>
   </tr>
</table>
                        </asp:View>
                        
                        <asp:View ID="ViewUsuario" runat="server">
                        
                            <b><span style="background-color: #0000CC; color: #FFFFFF;">
                                               DETALLES DEL EMPLEADO:&nbsp;&nbsp;&nbsp; </span></b>                    
                         
                            <form id="uxFormConsultarUsuario">
                            <b><span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp; <b>
                            <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; <b>
                            <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; <b>
                            <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; <b>
                            <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; </span></b></span>
                            </b></span></b></span></b></span></b>
                            <table style="width:100%;">
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                               <tr>
                                           <td><b><span style="background-color: #0000CC; color: #FFFFFF;">
                                               Datos Personales<b><span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp;
                                               <b><span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; </span></b>
                                               </span></b></span></b></td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                               <tr>
                                           <td><b>Nombre:</b></td>
                                           <td><asp:Label ID="uxNombreEmp" runat="server" Text=""></asp:Label></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                               <tr>
                                           <td><b>Apellido:</b></td>
                                           <td><asp:Label ID="uxApellidoEmp" runat="server" Text=""></asp:Label></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                         
                               </tr>
                               <tr>
                                           <td><b>Cedula:</b></td>
                                           <td><asp:Label ID="uxCedEmp" runat="server" Text=""></asp:Label></td>
                               </tr>
                               <tr>
                                          <td>&nbsp;</td>
                                          <td>&nbsp;</td>
                               </tr>
                               <tr>
                                           <td><b>Numero de Cuenta:</b></td>
                                           <td><asp:Label ID="uxNumCuentaE" runat="server" Text=""></asp:Label></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                              </tr>
                              <tr>
                                           <td><b>Sueldo Base:</b></td>
                                           <td><asp:Label ID="uxSueldoBase" runat="server" Text=""></asp:Label></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                              </tr>
                              <tr>
                                           <td><b>Fecha de Nacimiento:</b></td>
                                           <td><asp:Label ID="uxFecNacE" runat="server" Text=""></asp:Label></td>
                              </tr>
                              <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                              </tr>
                              <tr>
                                           <td><b>Estado:</b></td>
                                           <td><asp:Label ID="uxEstadoE" runat="server" Text=""></asp:Label></td>
                              </tr>
                              <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                              </tr>
                              <tr>
                                           <td><b>Cargo:</b></td>
                                           <td><asp:Label ID="uxCargoEmp" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                               <tr>
                                           <td style="color: #0033CC"><b>
                                               <span style="background-color: #0000CC; color: #FFFFFF;">
                                               Direccion<b><span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; <b>
                                               <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; <b>
                                               <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; <b>
                                               <span style="background-color: #0000CC; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;&nbsp; </span></b></span>
                                               </b></span></b></span></b></span></b></td>
                                           <td style="font-size: large">&nbsp;</td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                               <tr>
                                           <td><b>Calle:</b></td>
                                           <td><asp:Label ID="uxDirCalleEmp" runat="server" Text=""></asp:Label></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                                </tr>
                                <tr>
                                           <td><b>Avenida:</b></td>
                                           <td><asp:Label ID="uxDirAveEmp" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                                       <tr>
                                           <td><b>Urbanizacion:</b></td>
                                           <td><asp:Label ID="uxDirUrbEmp" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td><b>Edificio o Casa:</b></td>
                                           <td><asp:Label ID="uxDirEdCasaEmp" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td><b>Piso/Apartamento:</b></td>
                                           <td><asp:Label ID="uxDirPisAptoEmp" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td><b>Ciudad:</b></td>
                                           <td><asp:Label ID="uxDirCiudadEmp" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>
                                       <tr colspan="2" align="center">
                                           <td><asp:Button ID="Button1" runat="server" Text="Aceptar" 
                                                   onclick="Button1_Click" /></td>
                                           
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
		<pp:Objectcontainerdatasource runat= "server" ID = "uxObjectConsultarEmpleado" DataObjectTypeName = "Core.LogicaNegocio.Entidades.Empleado"
		 />  
</asp:Content>

