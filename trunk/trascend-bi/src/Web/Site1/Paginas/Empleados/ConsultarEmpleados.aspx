<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarEmpleados.aspx.cs" Inherits="Paginas_Empleados_ConsultarEmpleados" %>

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
                         
                            <table width="100%">
                             <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Introduzca Tipo de Consulta" /></td>
                                <td><asp:DropDownList ID="opcion1" runat="server">
                                    <asp:ListItem>Busqueda por Cedula</asp:ListItem>
                                    <asp:ListItem>Busqueda por Nombre</asp:ListItem>
                                    <asp:ListItem>Busqueda por Cargo</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" /></td>
                            </tr>
                                                    
                       <tr>
                                   <td><asp:Label ID="LabelParametroB" runat="server" Text = "Introduzca" 
                                           Visible = "False" /></td>
                                   <td><asp:TextBox ID="uxParametro" runat="server" Visible="False"></asp:TextBox></td>
        
                                    <td>
                                <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" 
                                            onclick="uxBotonBuscar_Click" Visible="False" 
                                    />
                            </td>
                               </tr>
                               <tr>
                                <td><asp:Label ID="LabelSeleccion" runat="server" Text = "Seleccione Cargo:" Visible = "false" /></td>
                                <td><asp:DropDownList ID="uxSeleccion" runat="server" Visible="False">
                                    </asp:DropDownList></td>
                                 <td><asp:Button ID="uxBotonBuscar2" runat="server" Text="Buscar" 
                                        onclick="uxBotonBuscar_Click" Visible="False" /></td>   
                            </tr>

                               <tr>
                                <td></td>
                                   <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxParametro" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                                    </td>
                               </tr>
              <tr>
                                    <td colspan="2">
                                
                                        <asp:GridView ID="uxConsultarEmpleado" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultarEmpleado"
                                            AutoGenerateColumns="False" DataKeyNames ="Nombre" AutoGenerateSelectButton="True"
                                            Width="95%" Font-Names="Verdana" Font-Size="Smaller" PageSize = "10"
                                            OnSelectedIndexChanging="SelectUsuarios">
                                            
                                            <Columns>
                                            
                                            <asp:BoundField HeaderText="Cedula" DataField="Cedula" SortExpression="Cedula" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True"

                                                    SortExpression="Nombre" />
                                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                                                    SortExpression="Apellido" />
                                            
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
                        
                            <p class="large">Detalles de Empleado</p>                    
                         
                            <form id="uxFormConsultarUsuario">
                            <table style="width:100%;">
                               <tr>
                                           <td><b>Nombre:</b></td>
                                           <td><asp:Label ID="uxNombreEmp" runat="server" Text=""></asp:Label></td>
                                       </tr>
                                       <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td><b>Apellido:</b></td>
                                           <td><asp:Label ID="uxApellidoEmp" runat="server" Text=""></asp:Label></td>
                                       </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                         
                                        </tr>
                                       <tr>
                                           <td><b>Cedula:</b></td>
                                           <td><asp:Label ID="uxCedEmp" runat="server" Text=""></asp:Label></td>
                                       </tr>
                                       <tr>
                                           <td>&nbsp;</td>
                                          
                                        </tr>
                                        <tr>
                                           <td><b>Numero de Cuenta:</b></td>
                                           <td><asp:Label ID="uxNumCuentaE" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                        <tr>
                                           <td><b>Fecha de Nacimiento:</b></td>
                                           <td><asp:Label ID="uxFecNacE" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                        <tr>
                                           <td><b>Estado:</b></td>
                                           <td><asp:Label ID="uxEstadoE" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                        <tr>
                                           <td><b>Direccion:</b></td>
                                           <td><asp:Label ID="uxDirEmp" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td>&nbsp;</td>
                                           
                                       </tr>
                                        <tr>
                                           <td><b>Cargo:</b></td>
                                           <td><asp:Label ID="uxCargoEmp" runat="server" Text=""></asp:Label></td>
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

