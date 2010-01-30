<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="EliminarEmpleados.aspx.cs" Inherits="Paginas_Empleados_EliminarEmpleados" %>

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
    <li><a href="EliminarEmpleados.aspx" class="active">Eliminar<span></span></a></li> 
  <li><a href="ModificarEmpleados.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Eliminar Empleados</h3>
                     <p>&nbsp;</p> 
                    <p class="large">    
                    </p> 
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
                                            AutoGenerateColumns="False" DataKeyNames ="Cedula" AutoGenerateSelectButton="True"
                                            Width="101%" Font-Names="Verdana" Font-Size="Smaller"
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
