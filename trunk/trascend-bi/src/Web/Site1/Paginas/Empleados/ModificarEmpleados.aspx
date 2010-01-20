<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="ModificarEmpleados.aspx.cs" Inherits="Paginas_Empleados_ModifcarEmpleados" %>

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
                    <li><a href="AgregarEmpleados.aspx">Agregar<span></span></a></li>
                    <li><a href="ConsultarEmpleados.aspx">Consultar<span></span></a></li>
                    <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li>
                    <li><a href="ModificarEmpleados.aspx" class="active">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3>
                            Modificar Empleado</h3>
                        <p class="large">
                            <form id="Form2" action="#" runat="server">
                            <asp:MultiView ID="uxMultiViewEmpleado" runat="server" ActiveViewIndex="0">
                                <asp:View ID="uxConsultarEmpleado" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="LabelTipoConsulta" runat="server" Text="Introduzca Tipo de Consulta" />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTipoBusqueda" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlTipoBusqueda_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Busqueda por Cedula</asp:ListItem>
                                                    <asp:ListItem Value="2">Busqueda por Nombre</asp:ListItem>
                                                    <asp:ListItem Value="3">Busqueda por Cargo</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="uxBotonAceptar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View runat="server" ID="vwConsultarPorCedula">
                                    <table>
                                        <tr>
                                            <td>
                                                Cambiar el tipo de Busqueda
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Cambiar" ID="btnCambiar" OnClick="btnCambiar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Introduzca Cedula:
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="uxCedulaCon"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button runat="server" ID="btnSubmit1" Text="Buscar" OnClick="btnSubmit1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View runat="server" ID="vwConsultarPorNombre">
                                    <table>
                                        <tr>
                                            <td>
                                                Cambiar el tipo de Busqueda
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Cambiar" ID="btnCambiar2" OnClick="btnCambiar2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Introduzca Nombre:
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="uxNombreCon"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button runat="server" ID="btnSubmit2" Text="Buscar" OnClick="btnSubmit2_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View runat="server" ID="vwConsultarPorCargo">
                                    <table>
                                        <tr>
                                            <td>
                                                Cambiar el tipo de Busqueda
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Cambiar" ID="btnCambiar3" OnClick="btnCambiar3_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Introduzca Cargo:
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlSeleccionCargo" OnSelectedIndexChanged="ddlSeleccionCargo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="uxCargaGrid" runat="server">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvwConsultarEmpleado" runat="server" AllowPaging="True" DataSourceID="gvwObjectConsultarEmpleado"
                                                    AutoGenerateColumns="False" DataKeyNames="Id" AutoGenerateSelectButton="True"
                                                    Width="95%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10" 
                                                    onselectedindexchanged="gvwConsultarEmpleado_SelectedIndexChanged1">
                                                    <Columns>
                                                             <asp:BoundField HeaderText="Cedula" DataField="Cedula" SortExpression="Cedula"  />
                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
                                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
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
                                <asp:View ID="uxModificarEmpleado" runat="server">
                                    <asp:Label runat="server" ID="lbId" Visible="false" />
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
                                                    <asp:TextBox ID="uxSueldoBase" runat="server"></asp:TextBox><br />
                                                    <asp:Label ID="lbRangoSueldo" Visible="false" runat="server"></asp:Label>
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
                                                    <asp:DropDownList ID="uxCargoEmpleado" runat="server" OnSelectedIndexChanged="uxCargoEmpleado_SelectedIndexChanged">
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
                                                    <b>Dirección</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Ciudad
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uxCiudad" runat="server"></asp:TextBox>
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
                                                    Avenida
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uxAvenida" runat="server"></asp:TextBox>
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
                                                    Calle
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uxCalle" runat="server"></asp:TextBox>
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
                                                    Urbanización
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uxUrbanizacion" runat="server"></asp:TextBox>
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
                                                    Edificio o Casa
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="uxEdificio" runat="server"></asp:TextBox>
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
                                                    Piso o Apartamento
                                                </td>
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
                                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:View>
                            </asp:MultiView>
                            </form>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <pp:Objectcontainerdatasource runat= "server" ID = "gvwObjectConsultarEmpleado" DataObjectTypeName = "Core.LogicaNegocio.Entidades.Empleado"
		 />
</asp:Content>
