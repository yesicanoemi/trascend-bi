<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AgregarEmpleados.aspx.cs" Inherits="Paginas_Empleados_AgregarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>Empleados</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarEmpleados.aspx" class="active">Agregar<span></span></a></li>
                    <li><a href="ConsultarEmpleados.aspx">Administrar<span></span></a></li>
                    <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li>
                    
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                   
                        <div class="features_overview_right">
                            <h3>
                                Agregar Empleados</h3>
                            <p class="large">
                                Introduzca la informacón a continuación</p>
                           <p class="large">
                            <form id="Form1" runat="server">
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
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxNombreEmpleado" 
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
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="uxApellidoEmpleado" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaApellidoEmpleado%>" Font-Size="Smaller" Display="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            C.I.:
                                        </td>
                                        <td>
                                           <!-- Cedula venezolana o extranjera <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                            <asp:ListItem Value="0">V: </asp:ListItem>
                                            <asp:ListItem Value="1">E: </asp:ListItem>
                                            </asp:RadioButtonList> -->
                                            <asp:TextBox ID="uxCedulaEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="uxCedulaEmpleado" 
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
                                         <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="uxNumCuentaEmpleado" 
                                            ErrorMessage="<%$ Resources:DSU, FaltaNumCuentaEmpleado%>" Font-Size="Smaller" Display="Static" />
                                             <br />
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ErrorMessage="<%$Resources:DSU, ErrorFormatoNumCuentaEmpleado%>" ControlToValidate="uxNumCuentaEmpleado"
                                                    ValidationExpression="<%$Resources:DSU, ERNumCuentaEmpleado%>" Font-Size="Smaller">
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
                                            <asp:TextBox ID="uxFechaNac" runat="server"></asp:TextBox>
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
                                            Fecha de Egreso
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxFechaEgreso" runat="server"></asp:TextBox>
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                                onclick="uxBotonAceptar_Click" />
                                        </td>
                                    </tr>
                                </table>
                               </form>
                            </p>
                             
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
