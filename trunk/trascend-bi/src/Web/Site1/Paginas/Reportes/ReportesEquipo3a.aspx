<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo3a.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo3a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
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
  <li><a href="ReportesEquipo3a.aspx" class="active">Gastos Anuales<span></span></a></li> 
  <li><a href="ReportesEquipo3b.aspx" >Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo6a.aspx" >Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo6b.aspx" >Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo8a.aspx" >Total Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo8b.aspx" >Total Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo8c.aspx" >Total Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo9a.aspx" >Propuestas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo9b.aspx" >Total de Propuestas Emitidas<span></span></a></li>
</ul> 
						
				</div> 
				
				<div class="sub-content"> 
    <div class="features_overview"> 
        <div class="features_overview_rightUser"> 
            <h3>Reporte Equipo #3 (Gasto Anuales)</h3> 
            <p>&nbsp;</p>
            <span style="text-align:center; font-size:smal; color:Red">
                <asp:Label ID="uxAviso" runat="server" Visible="false"></asp:Label>
            </span>
              <p>&nbsp;</p>
            <table class="solotablasuser" style="width: 100%">
            <tr><td><asp:Label runat="server" ID="uxLabelAnio" Text="<%$ Resources:DSU, SeleccioneAnio %>">"></asp:Label></td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:DropDownList ID="uxAnios" runat="server">
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
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RangeValidator MaximumValue="2010" MinimumValue="2000" Display="Static" ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="<%$Resources:DSU, FaltaAnioReportes %>" ControlToValidate="uxAnios"
                                    Font-Size="Smaller"></asp:RangeValidator>
                             
                    </td>
               </tr>
               <tr><td>&nbsp;</td></tr>
               <tr>
                    
                    
                    <td align="center">
                        <asp:Button ID="uxBotonConsultar_Click" runat="server" Text="<%$ Resources:DSU, Buscar %>" 
                          onclick="uxBotonConsulta_Click" />
                          
                    </td>
                   
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                
            </table>
            
         </div> 
      <table class="solotablasuser" runat="server">
      <tr>
      <td>
        <asp:GridView runat="server" ID="uxReporteGastos3a"  AutoGenerateColumns="false" 
                        DataKeyNames="Codigo" AllowPaging="True" Width="500px" PageSize="10" ShowFooter="true"
                        DataSourceID="uxObjectReporte3a">
             <Columns>
                <asp:BoundField ItemStyle-HorizontalAlign="center" HeaderText="Id Gasto" DataField="Codigo" />
                <asp:BoundField ItemStyle-HorizontalAlign="center" HeaderText="Fecha" DataField="fechaGasto" />
                <asp:BoundField ItemStyle-HorizontalAlign="center" HeaderText="Tipo" DataField="tipo" />
                <asp:BoundField ItemStyle-HorizontalAlign="center" HeaderText="Monto" DataField="Monto" />
             </Columns>
        </asp:GridView>
        </td>
      </tr>
      <tr>
        <td>
        <br />
        <asp:Label ID="uxLabelTotal" runat="server" Text="Total Gastos en el Año:" Visible="false"></asp:Label>
        <asp:Label ID="uxTotal" runat="server" Text="" Visible="false"></asp:Label>
        </td></tr>
     </table>
          <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div> 
</div>  

				
			</div> 
		</div> 
    <pp:objectcontainerdatasource runat="server" ID="uxObjectReporte3a" DataObjectTypeName="Core.LogicaNegocio.Entidades.Gasto" />
    </form>
    </asp:Content>
