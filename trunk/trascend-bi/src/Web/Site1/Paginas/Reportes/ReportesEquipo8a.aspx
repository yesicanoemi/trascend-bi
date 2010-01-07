<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo8a.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo8" %>

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
  <li><a href="ReportesEquipo3a.aspx" >Gastos Anuales<span></span></a></li> 
  <li><a href="ReportesEquipo3b.aspx" >Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo6a.aspx" >Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo6b.aspx" >Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo8a.aspx" class="active">Total Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo8b.aspx" >Total Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo8c.aspx" >Total Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo9a.aspx" >Propuestas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo9b.aspx" >Total de Propuestas Emitidas<span></span></a></li>
</ul> 
						
				</div> 
				
				<div class="sub-content"> 
    <div class="features_overview"> 
        <div class="features_overview_right"> 
            <h3>Reporte Equipo #8 (Total Facturas Emitidas)</h3> 
            <p>&nbsp;</p>
            
            
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                         <asp:ListItem Value="0">Seleccionar...</asp:ListItem>
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2009</asp:ListItem>
                            <asp:ListItem>2008</asp:ListItem>
                            <asp:ListItem>2007</asp:ListItem>
                            <asp:ListItem>2006</asp:ListItem>
                            <asp:ListItem>2005</asp:ListItem>
                            <asp:ListItem>2004</asp:ListItem>
                            <asp:ListItem>2003</asp:ListItem>
                            <asp:ListItem>2002</asp:ListItem>
                            <asp:ListItem>2001</asp:ListItem>
                            <asp:ListItem>2000</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Button" />
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
    </div> 
</div>  

				
			</div> 
		</div> 
    </form>
</asp:Content>
