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
                      <form id="Form1" action="#" runat="server">
                        <table>
                            <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Introduzca Tipo de Consulta" /></td>
                                <td><asp:DropDownList ID="opcion1" runat="server">
                                    <asp:ListItem>Busqueda por Cedula</asp:ListItem>
                                    <asp:ListItem>Busqueda por Nombre</asp:ListItem>
                                    <asp:ListItem>Busqueda por Cargo</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelSeparador" runat="server" Text = ""/>
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" />
                                    <br />
                                </td>
                            </tr>
                           <tr>
                                <td><asp:Label ID="LabelSeleccion" runat="server" Text = "Seleccione" />
                                    <br />
                                </td>
                                <td><asp:DropDownList ID="uxSeleccion" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar2" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar2_Click" /></td>
                            </tr>
                            
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                    Indique Parámetro de busqueda</td>
                                 <td><asp:Label ID="LabelParametro" runat="server" Text = "" /></td>
                                <td></td>
                            </tr>
                            
                             <tr>
                                <td>Cedula</td>
                                <td><asp:Label ID="LabelCedulaEmpleado" runat="server" /></td>    
                            </tr>
                            <tr>
                                <td>Nombre</td>
                                <td><asp:Label ID="LabelNombreEmpleado" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Apellido</td>
                                <td><asp:Label ID="LabelApellidoEmpleado" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Numero de Cuenta</td>
                                <td><asp:Label ID="LabelNumCuentaEmpleado" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Fecha Nacimiento</td>
                                <td><asp:Label ID="LabelFechaNacEmpleado" runat="server" /></td>
                            </tr>
                             <tr>
                                <td>Estado</td>
                                <td><asp:Label ID="LabelEstadoEmpleado" runat="server" /></td>
                            </tr>
                             <tr>
                                <td>Direccion</td>
                                <td><asp:Label ID="LabelDirEmpleado" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Cargo</td>
                                <td><asp:Label ID="LabelCargoEmpleado" runat="server" /></td>
                            </tr> 
                            </table>
                     </form>
                    </p> 
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>

