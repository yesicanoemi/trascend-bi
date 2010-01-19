<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AgregarEmpleados.aspx.cs" Inherits="Paginas_Empleados_AgregarEmpleados" %>

<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Empleados</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarEmpleados.aspx" class="active">Agregar<span></span></a></li>
                    <li><a href="ConsultarEmpleados.aspx">Consultar<span></span></a></li>
                    <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li>
                    <li><a href="ModificarEmpleados.aspx">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview">
                        <div class="features_overview_right">
                            <h3>
                                Agregar Empleados</h3>
                            <p class="large">
                                Introduzca la informacón a continuación</p>
                            <p class="large">
                            </p>
                            <form id="Form1" action="#" runat="server">
                            <p class="large">
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                                            <asp:TextBox ID="uxSueldoBase" runat="server"></asp:TextBox><br /><asp:Label ID="lbRangoSueldo" Visible="false" runat="server"></asp:Label>
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
                                            <asp:DropDownList ID="uxCargoEmpleado" AutoPostBack="true" runat="server" OnSelectedIndexChanged="uxCargoEmpleado_SelectedIndexChanged">
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
                                        <td colspan="2">
                                            Dirección
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ciudad</td>
                                        <td>
                                            <asp:TextBox ID="uxCiudad" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Avenida</td>
                                        <td>
                                            <asp:TextBox ID="uxAvenida" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Calle</td>
                                        <td>
                                            <asp:TextBox ID="uxCalle" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Urbanización</td>
                                        <td>
                                            <asp:TextBox ID="uxUrbanizacion" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Edificio o Casa</td>
                                        <td>
                                            <asp:TextBox ID="uxEdificio" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Piso o Apartamento</td>
                                        <td>
                                            <asp:TextBox ID="uxPiso" runat="server"></asp:TextBox>
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
                            
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
