<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="ReportesEquipo9a.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Reportes</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="ReportesEquipo1a.aspx">Paquete Anual<span></span></a></li>
                    <li><a href="ReportesEquipo1b.aspx">Total Anual<span></span></a></li>
                    <li><a href="ReportesEquipo2a.aspx">Total de Horas Anuales <span></span></a></li>
                    <li><a href="ReportesEquipo2b.aspx">Gastos<span></span></a></li>
                    <li><a href="ReportesEquipo3a.aspx">Gastos Anuales<span></span></a></li>
                    <li><a href="ReportesEquipo3b.aspx">Facturas Emitidas<span></span></a></li>
                    <li><a href="ReportesEquipo6a.aspx">Facturas Cobradas<span></span></a></li>
                    <li><a href="ReportesEquipo6b.aspx">Facturas Por Cobrar<span></span></a></li>
                    <li><a href="ReportesEquipo8a.aspx">Total Facturas Emitidas<span></span></a></li>
                    <li><a href="ReportesEquipo8b.aspx">Total Facturas Cobradas<span></span></a></li>
                    <li><a href="ReportesEquipo8c.aspx">Total Facturas Por Cobrar<span></span></a></li>
                    <li><a href="ReportesEquipo9a.aspx" class="active">Propuestas Emitidas<span></span></a></li>
                    <li><a href="ReportesEquipo9b.aspx">Total de Propuestas Emitidas<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview_right">
                        <h3>
                            Reporte Equipo #9 (Propuestas Emitidas)</h3>
                        <p class="large" style="font-size: small;">
                            Introduzca dos fechas</p>
                        <p class="large">
                            <asp:Label ID="lbMensaje" runat="server" Visible="false" ForeColor="Red" Font-Size="Medium"></asp:Label>
                        </p>
                        <br />
                        <br />
                        <table style="width: 100%; height: 150%;">
                            <tr>
                                <td>
                                    <span style="color: #FF0000">*</span>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha inicio"></asp:Label>
                                    <asp:TextBox ID="uxFechaInicio" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:Image ID="uxFechaInicioImg" runat="server" ImageUrl="~/Images/calendario.png" />
                                    <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                        ID="uxInicio" Format="dd/MM/yyyy" TargetControlID="uxFechaInicio" PopupButtonID="uxFechaInicioImg">
                                    </AjaxControlToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxFechaInicio"
                                        ErrorMessage="<%$ Resources:DSU, FaltaFecha%>" Font-Size="Smaller" Display="None" />
                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxFechaInicio" FilterType="Numbers, Custom"
                                        ValidChars="/" ID="FilteredTextBoxExtender1" runat="server" />
                                    <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                        TargetControlID="RequiredFieldValidator1" />
                                </td>
                            </tr>
                        
                            <tr>
                                <td>
                                    <span style="color: #FF0000">*</span>
                                    <asp:Label ID="Label4" runat="server" Text="Fecha fin"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="uxFechaFin" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:Image ID="uxFechaFinImg" runat="server" ImageUrl="~/Images/calendario.png" />
                                    <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                        ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="uxFechaFin" PopupButtonID="uxFechaFinImg">
                                    </AjaxControlToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxFechaFin"
                                        ErrorMessage="<%$ Resources:DSU, FaltaFecha%>" Font-Size="Smaller" Display="None" />
                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxFechaFin" FilterType="Numbers, Custom"
                                        ValidChars="/" ID="FilteredTextBoxExtender2" runat="server" />
                                    <AjaxControlToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                        TargetControlID="RequiredFieldValidator2" />
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="Aceptar" OnClick="Button3_Click" />
                                </td>
                            </tr>
                            </table>
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
                            <br />
                    <br />
                    <br />
                            <table>
                            <asp:GridView Width="150%" ID="GridView1" runat="server" 
                            AutoGenerateRows="false" AutoGenerateColumns="false" OnRowDataBound="uxGridView1_RowDataBound">
                            <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField HeaderText="Titulo" DataField="Titulo" runat="server"></asp:BoundField>
                                    <asp:BoundField HeaderText="Version" DataField="Version" runat="server"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Fecha Firma" ItemStyle-Width="14%" runat="server">
                                    <ItemTemplate>
                                        <%# FormatearFecha((DateTime)Eval("FechaFirma")) %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Receptor" ItemStyle-Width="14%" DataField="NombreReceptor" runat="server"></asp:BoundField>
                                    <asp:BoundField HeaderText="Cargo" DataField="CargoReceptor" runat="server"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Fecha Fin" ItemStyle-Width="14%" runat="server">
                                    <ItemTemplate>
                                        <%# FormatearFecha((DateTime)Eval("FechaInicio")) %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Fin" ItemStyle-Width="14%" runat="server">
                                    <ItemTemplate>
                                        <%# FormatearFecha((DateTime)Eval("FechaFin")) %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Monto" DataField="MontoTotal" runat="server"></asp:BoundField >
                                </Columns>
                            </asp:GridView>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
