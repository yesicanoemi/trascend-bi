<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AdministrarCargos.aspx.cs" Inherits="Paginas_Cargos_AdministrarCargos"
    Title="Administrar Cargos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="Form1" runat="server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Cargos</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarCargos.aspx">Agregar<span></span></a></li>
                    <li><a href="AdministrarCargos.aspx" class="active">Administrar<span></span></a></li>
                    <li><a href="TablaCargos.aspx">Tabla de Inflacion<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3>
                            Administrar cargos</h3>
                        <p class="large">
                            Seleccione el nombre del cargo que desea gestionar</p>
                        <p class="large">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        Nombre:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="uxNombre" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" OnClick="uxBotonBuscar_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descripcion:
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox TextMode="MultiLine" ID="uxDescripcion" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sueldo Mínimo:
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="uxSueldoMinimo" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sueldo Máximo
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="uxSueldoMaximo" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Vigencia de Sueldo:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxVigenciaSueldo" runat="server" TabIndex="63" ReadOnly="True"></asp:TextBox>
                                        <asp:Image ID="uxImgFechaNac" runat="server" ImageUrl="~/Images/calendario.png" />
                                    </td>
                                    <td>
                                        <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                            ID="uxceFechaNac" Format="dd/MM/yyyy" TargetControlID="uxVigenciaSueldo" PopupButtonID="uxImgFechaNac">
                                        </AjaxControlToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="uxBotonGuardar" runat="server" Text="Guardar" OnClick="uxBotonGuardar_Click" />
                                    </td>
                                    <td>
                                    </td>
                                    <td align="left"><asp:Button ID="uxBotonEliminar" runat="server" Text="Eliminar" OnClick="uxBotonEliminar_Click" /></td>
                                </tr>
                            </table>
                        </p>
                        <center>
                            <asp:Label ID="uxLabelError" runat="server" Visible="False" ForeColor="#CC0000"></asp:Label></center>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
