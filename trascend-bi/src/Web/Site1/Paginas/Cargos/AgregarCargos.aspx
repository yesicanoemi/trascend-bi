<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AgregarCargos.aspx.cs" Inherits="Paginas_Cargos_AgregarCargos" Title="Agregar Cargos" %>

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
                    <li><a href="AgregarCargos.aspx" class="active">Agregar<span></span></a></li>
                    <li><a href="AdministrarCargos.aspx">Administrar<span></span></a></li>
                    <li><a href="TablaCargos.aspx">Tabla de Inflacion<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3>
                            Agregar Cargo</h3>
                        <p class="large">
                            Introduzca la informacón a continuación</p>
                        <p class="large">
                            <table style="width: 100%">
                                <tr>
                                    <td colspan="2" align="center"><asp:Label ID="uxLabelError" CssClass="campos" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nombre:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxNombre" runat="server"></asp:TextBox><asp:Label ID="Label1" CssClass="campos" runat="server">*</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <AjaxControlToolkit:FilteredTextBoxExtender ID="fteNombre" runat="server" TargetControlID="uxNombre"
                                            FilterType="UppercaseLetters, LowercaseLetters, Numbers, Custom" ValidChars="' '" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="uxNombre"
                                            ErrorMessage="El campo no puede ser vacío" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descripcion:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxDescripcion" runat="server"></asp:TextBox><asp:Label ID="Label2" CssClass="campos" runat="server">*</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <AjaxControlToolkit:FilteredTextBoxExtender ID="ftbDescripcion" runat="server" TargetControlID="uxDescripcion"
                                            FilterType="LowercaseLetters, UppercaseLetters, Numbers, Custom" ValidChars=".:,;()' '" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="uxDescripcion"
                                            ErrorMessage="El campo no puede ser vacío" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sueldo Mínimo:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxSueldoMinimo" runat="server" AutoPostBack="true"
                                            OnTextChanged="uxSueldoMinimo_TextChanged"></asp:TextBox><asp:Label ID="Label3" CssClass="campos" runat="server">*</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <AjaxControlToolkit:FilteredTextBoxExtender ID="fteSueldoMinimo" runat="server" TargetControlID="uxSueldoMinimo"
                                            FilterType="Numbers" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvSueldoMinimo" runat="server" ControlToValidate="uxSueldoMinimo"
                                            ErrorMessage="El campo no puede ser vacío" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sueldo Máximo
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxSueldoMaximo" runat="server" AutoPostBack="true"
                                            OnTextChanged="uxSueldoMaximo_TextChanged"></asp:TextBox><asp:Label ID="Label4" CssClass="campos" runat="server">*</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <AjaxControlToolkit:FilteredTextBoxExtender ID="fteSueldoMaximo" runat="server" TargetControlID="uxSueldoMaximo"
                                            FilterType="Numbers" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rvfSueldoMaximo" runat="server" ControlToValidate="uxSueldoMaximo"
                                            ErrorMessage="El campo no puede ser vacío" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Vigencia de Sueldo:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="uxVigenciaSueldo" runat="server" TabIndex="63" CausesValidation="False"></asp:TextBox>
                                        <asp:Image ID="uxImgFechaNac" runat="server" ImageUrl="~/Images/calendario.png" /><asp:Label CssClass="campos" ID="Label5" runat="server">*</asp:Label>
                                    </td>
                                    <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                        ID="uxceFechaNac" Format="dd/MM/yyyy" TargetControlID="uxVigenciaSueldo" PopupButtonID="uxImgFechaNac">
                                    </AjaxControlToolkit:CalendarExtender>
                                </tr>
                                <AjaxControlToolkit:FilteredTextBoxExtender ID="ftbvigencia" runat="server" TargetControlID="uxVigenciaSueldo"
                                    FilterType="Custom, Numbers" ValidChars="/" />
                                <tr>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvVigencia" runat="server" ControlToValidate="uxVigenciaSueldo"
                                            ErrorMessage="El campo no puede ser vacío" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    <asp:Label runat="server" ID="label14" CssClass="campos" Text="<%$ Resources:DSU, CampoObligatorio%>"></asp:Label> 
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
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
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </p>
                        <asp:GridView ID="uxVistaCargo" runat="server" AutoGenerateColumns="false" CellPadding="10"
                            CellSpacing="5" OnRowDataBound="uxVistaCargo_RowDataBound">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField ItemStyle-HorizontalAlign="Justify" HeaderText="Cargo" DataField="Nombre" />
                                <asp:BoundField HeaderText="Sueldo Minimo" DataField="Descripcion" />
                                <asp:BoundField HeaderText="Sueldo Minimo" DataField="SueldoMinimo" />
                                <asp:BoundField HeaderText="Sueldo Maximo" DataField="SueldoMaximo" />
                                <asp:TemplateField HeaderText="Fecha Ingreso">
                                    <ItemTemplate>
                                        <%# FormatearFecha((DateTime)Eval("Vigencia")) %></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
