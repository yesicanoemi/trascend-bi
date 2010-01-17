<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo8b.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo8b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Reportes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
    <li><a href="ReportesEquipo1a.aspx">Paquete Anual<span></span></a></li> 
  <li><a href="ReportesEquipo1b.aspx" >Total Anual<span></span></a></li>
  <li><a href="ReportesEquipo2a.aspx" >Total de Horas Anuales <span></span></a></li>
  <li><a href="ReportesEquipo2b.aspx" >Gastos<span></span></a></li>
  <li><a href="ReportesEquipo3a.aspx" >Gastos Anuales<span></span></a></li> 
  <li><a href="ReportesEquipo3b.aspx" >Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo6a.aspx" >Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo6b.aspx" >Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo8a.aspx" >Total Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo8b.aspx" class="active">Total Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo8c.aspx" >Total Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo9a.aspx" >Propuestas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo9b.aspx" >Total de Propuestas Emitidas<span></span></a></li>
</ul> 
						
				</div> 
			<div class="sub-content"> 
    <div class="features_overview"> 
        <div class="features_overview_right"> 
            <h3>Reporte Equipo #8 (Total Facturas Cobradas)</h3> 
            <p>&nbsp;</p>
            <form id="Form1" runat="server">
             <table style="width: 100%">
                <tr>
                    <td>
                          <asp:DropDownList ID="uxAnios" runat="server" 
                              onselectedindexchanged="uxAnios_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccionar...</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" 
                                           onclick="uxBotonBuscar_Click" />
                    </td>
                </tr>
                   <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RangeValidator MaximumValue="2010" MinimumValue="2000" Display="Static" ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="<%$Resources:DSU, FaltaAnioReportes %>" ControlToValidate="uxAnios"
                                    Font-Size="Smaller"></asp:RangeValidator>
                             
                    </td>
                </tr>
            </table>
          
         </div> 
         <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="uxFacturasCobradas" runat="server" 
            onselectedindexchanged="uxFacturasCobradas_SelectedIndexChanged" DataSourceID="uxObjectReporte8b">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
         </form>
    </div> 
</div>  

			</div> 
		</div> 
		<pp:objectcontainerdatasource runat="server" ID="uxObjectReporte8b" DataObjectTypeName="Core.LogicaNegocio.Entidades.Factura" /> 

</asp:Content>
