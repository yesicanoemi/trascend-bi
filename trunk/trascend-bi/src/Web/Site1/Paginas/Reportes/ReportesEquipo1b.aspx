<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo1b.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo1b" %>

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
  <li><a href="ReportesEquipo1b.aspx" class="active">Total Anual<span></span></a></li>
  <li><a href="ReportesEquipo2a.aspx" >Total de Horas Anuales <span></span></a></li>
  <li><a href="ReportesEquipo2b.aspx" >Gastos<span></span></a></li>
  <li><a href="ReportesEquipo3a.aspx" >Gastos Anuales<span></span></a></li> 
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
        <div class="features_overview_right"> 
            <h3>Reporte Equipo #1 (Total Anual Por Paquetes de Empleados)</h3> 
            <p>&nbsp;</p>
             <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Cargo" runat="server" Text="Cargo"></asp:Label>
                    
                    <asp:DropDownList ID="uxCargo" runat="server">
                    </asp:DropDownList>
                    
                    
                </td>
                
               
            </tr>
            <tr>
              
                <td><asp:Button ID="uxAceptar" runat="server" Text="Aceptar" OnClick="uxAceptar_Click"/></td>
             </tr>
              <tr>
                <td>
                     <asp:Table ID="uxTablaSolucion" runat="server" GridLines="Both"
                                     CellSpacing="30" CellPadding="30" BorderColor="Black">
                                    </asp:Table>
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
        <br />
        <br />
        <br />
    </div> 
</div>  
				
			</div> 
		</div> 
    </form>
</asp:Content>
