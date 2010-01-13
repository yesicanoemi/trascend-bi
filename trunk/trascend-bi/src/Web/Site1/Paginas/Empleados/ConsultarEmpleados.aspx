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
  <li><a href="ConsultarEmpleados.aspx" class="active">Administrar<span></span></a></li> 
  <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li> 
  
</ul> 
						
				</div> 
				
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Administrar empleados</h3> 
                    <p class="large"></p> 
                    <p>
                     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <!-- CONSULTA -->
                                    <asp:View ID="ViewConsulta" runat="server">
                                    <form id="Form1" action="#" runat="server">
                                        <table width="100%">
                                            <tr>
                                                
                                                <td><asp:Label ID="uxCedula" runat="server" Text="<%$Resources:DSU, RIFoCIObligatorio%>"
                                                        ></asp:Label>&nbsp;</td>
                                                
                                                <td><asp:TextBox ID="uxCedulaEmpleado" runat="server" Width="150px"
                                                    ValidationGroup="valRegistro"></asp:TextBox>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxCedulaEmpleado"
                                                      Display="Static" ErrorMessage="<%$ Resources:DSU, FaltaCIFind%>"
                                                      ValidationGroup="valRegistro" Font-Size="Smaller"/></td>
                                                
                                                <td>&nbsp;<asp:Button ID="uxBuscarCedulaEmpleado" runat="server" Text="Buscar" OnClick="uxBuscarCedula_Click"
                                                    ValidationGroup="valRegistro" TabIndex="2" /></td>
                                                
                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                
                                                <td><asp:Label ID="uxNombre" runat="server" Text="<%$Resources:DSU, NombreObligatorio%>"
                                                   ></asp:Label></td>
                                                   
                                                <td><asp:TextBox ID="uxNombreEmpleado" runat="server"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxNombreEmpleado"
                                                      Display="Static" ErrorMessage="<%$ Resources:DSU, FaltaNombreEmpleado%>"
                                                      Font-Size="Smaller"/></td>
                                                <td>&nbsp;<asp:Button ID="uxBuscarNombreEmpleado" runat="server" Text="Buscar"
                                                    OnClick="uxBuscarNombre_Click" TabIndex="4" /></td>
                                            </tr>
                                            <tr>
                                            <td colspan="4">
                                            <!--
                                                <asp:GridView ID="uxConsultaUsuario" runat="server" AllowPaging="True" DataSourceID=""
                                                    AutoGenerateColumns="False" DataKeyNames="EntidadId" AutoGenerateSelectButton="True"
                                                    Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre DataField="nombreUsuario" />
                                                        <asp:BoundField HeaderText="Apellido" DataField="apellidoUsuario" />
                                                        <asp:BoundField HeaderText="Nombre de Usuario" DataField="nombredeUsuario" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <center>
                                                            <span>No hay data cargada </span>
                                                        </center>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>-->
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                                </asp:View>
        
                                <!-- MODIFICAR .-->
                                <asp:View ID="ViewModificar" runat="server">
                                
                                </asp:View>
                         </asp:MultiView>
                    </p>
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>

