<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarEmpleados.aspx.cs" Inherits="Paginas_Empleados_ModifcarEmpleados" %>
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
    <li><a href="EliminarEmpleados.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarEmpleados.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Modificar Empleado</h3> 
                    <p class="large">
                        
                        <form id="Form1" action="#" runat="server">
                            <p class="large">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            Nombre:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxNombreEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxNombreEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreEmpleado%>" Font-Size="Smaller" Display="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Apellido:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxApellidoEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxApellidoEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaApellidoEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            C.I.:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxCedulaEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxCedulaEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaCIEmpleado%>" Font-Size="Smaller" Display="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Numero de Cuenta:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxNumCuentaEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxNumCuentaEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNumCuentaEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <asp:RegularExpressionValidator Display="Static" ID="RegularExpressionValidator2"
                                                runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoNumCuentaEmpleado%>"
                                                ControlToValidate="uxNumCuentaEmpleado" ValidationExpression="<%$Resources:DSU, ERNumCuentaEmpleado%>"
                                                Font-Size="Smaller">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Sueldo Base:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxSueldoBase" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Cargo:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="uxCargoEmpleado" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha de Nacimiento:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxFechaNac" runat="server" TabIndex="63"></asp:TextBox>
                                            <asp:Image ID="uxImgFechaNac" runat="server" ImageUrl="~/Images/calendario.png" />
                                        </td>
                                        <td>
                                            <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                                ID="uxceFechaNac" Format="dd/MM/yy" TargetControlID="uxFechaNac" PopupButtonID="uxImgFechaNac">
                                            </AjaxControlToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Dirección de Habitación
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxDireccion" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha de Ingreso
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxFechaIngreso" runat="server"></asp:TextBox>
                                            <asp:Image ID="uxImagenFechaIngreso" runat="server" ImageUrl="~/Images/calendario.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                                ID="uxFechaIngres" Format="dd/MM/yy" TargetControlID="uxFechaIngreso" PopupButtonID="uxImagenFechaIngreso">
                                            </AjaxControlToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha de Egreso
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxFechaEgreso" runat="server"></asp:TextBox>
                                            <asp:Image ID="uxImagenFechaEgreso" runat="server" ImageUrl="~/Images/calendario.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                                ID="uxFechaEgres" Format="dd/MM/yy" TargetControlID="uxFechaEgreso" PopupButtonID="uxImagenFechaEgreso">
                                            </AjaxControlToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" OnClick="uxBotonAceptar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </p>
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </form>
                    </p> 
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>
