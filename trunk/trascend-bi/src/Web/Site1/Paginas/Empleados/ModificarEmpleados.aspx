<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="ModificarEmpleados.aspx.cs" Inherits="Paginas_Empleados_ModifcarEmpleados" %>

<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Empleados</h2> 
				</div> 
			<div class="subnav-container"> 
				
<ul id="subnav"> 
  <li><a href="AgregarEmpleados.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarEmpleados.aspx">Consultar<span></span></a></li> 
  <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li>
  <li><a href="ModificarEmpleados.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
    </div> 
				
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    
                    <h3>Modificar Empleado</h3>
                    
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
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td align="center"><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" onclick="uxBotonAceptar_Click" Visible="false"/></td>
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
             <span>No hay data cargada </span>
           </center>
         </EmptyDataTemplate>
       </asp:GridView></td>
   </tr>
</table>
                        </asp:View>
                        
                        <asp:View ID="ViewUsuario" runat="server">
                        
                            <b><span style="background-color: #0000CC; color: #FFFFFF;">
                                               DETALLES DEL EMPLEADO A MODIFICAR:&nbsp;&nbsp;&nbsp; </span></b>                    
                         
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
                                           <td><b>Nombre:</b></td>
                                           <td><asp:TextBox ID="uxNombreEmp" runat="server" Text=""></asp:TextBox></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                               <tr>
                                           <td><b>Apellido:</b></td>
                                           <td><asp:TextBox ID="uxApellidoEmp" runat="server" Text=""></asp:TextBox></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                         
                               </tr>
                               <tr>
                                           <td><b>Cedula:</b></td>
                                           <td><asp:TextBox ID="uxCedEmp" runat="server" Text=""></asp:TextBox></td>
                               </tr>
                               <tr>
                                          <td>&nbsp;</td>
                                          <td>&nbsp;</td>
                               </tr>
                               <tr>
                                           <td><b>Numero de Cuenta:</b></td>
                                           <td><asp:TextBox ID="uxNumCuentaE" runat="server" Text=""></asp:TextBox></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                              </tr>                              <tr>
                                           <td><b>Sueldo Base:</b></td>
                                           <td><asp:TextBox ID="uxSueldoBase" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                              </tr>
                              <tr>
                                           <td><b>Fecha de Nacimiento:</b></td>
                                           <td><asp:TextBox ID="uxFecNacE" runat="server"></asp:TextBox>
                                           <asp:Image ID="uxImgFechaNac" runat="server" ImageUrl="~/Images/calendario.png" /></td>
                                           <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                                ID="uxceFechaNac" Format="dd/MM/yy" TargetControlID="uxFecNacE" PopupButtonID="uxImgFechaNac">
                                            </AjaxControlToolkit:CalendarExtender>
                              </tr>
                              <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                              </tr>
                              <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                              </tr>
                              <tr>
                                           <td><b>Cargo:</b></td>
                                           <td><asp:DropDownList ID="uxCargoEmp" runat="server">
                                            </asp:DropDownList></td>
                                        </tr>
                                         <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
									   </tr>
                                        <tr>
                                           <td><b>Estado:</b></td>
                                           <td><asp:DropDownList ID="uxEstadoEmp" runat="server">
                                            </asp:DropDownList></td>
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
                                           <td><asp:TextBox ID="uxDirCalleEmp" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                                </tr>
                                <tr>
                                           <td><b>Avenida:</b></td>
                                           <td><asp:TextBox ID="uxDirAveEmp" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                               </tr>
                                       <tr>
                                           <td><b>Urbanizacion:</b></td>
                                           <td><asp:TextBox ID="uxDirUrbEmp" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td><b>Edificio o Casa:</b></td>
                                           <td><asp:TextBox ID="uxDirEdCasaEmp" runat="server" Text=""></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td><b>Piso/Apartamento:</b></td>
                                           <td><asp:TextBox ID="uxDirPisAptoEmp" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td><b>Ciudad:</b></td>
                                           <td><asp:TextBox ID="uxDirCiudadEmp" runat="server" Text=""></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                       </tr>
                                       <tr colspan="2" align="center">
                                           <td><asp:Button ID="Button1" runat="server" Text="Modificar" 
                                                   onclick="ModificarEmpleado" /></td>
                                           
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