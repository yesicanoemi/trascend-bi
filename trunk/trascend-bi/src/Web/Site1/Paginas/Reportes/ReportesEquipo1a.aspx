<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo1a.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Reportes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
      <li><a href="ReportesEquipo1a.aspx" class="active">Paquete Anual<span></span></a></li> 
  <li><a href="ReportesEquipo1b.aspx" >Total Anual<span></span></a></li>
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
            <h3>Reporte Equipo #1 (Paquete Anual Por Empleado)</h3>
            <p>&nbsp;</p>
            <form id="fomr1" runat="server">
            <table style="width: 100%">
            <tr>
                <td>
                    <asp:radiobuttonlist id="uxradioButton" runat="server">
                      <asp:listitem id="Cedula" runat="server" value="Cedula" />
                      <asp:listitem id="Nombre" runat="server" value="Nombre" />
                    </asp:radiobuttonlist>
                </td>
                <td>
                    <asp:TextBox ID="uxTextBoxBusqueda" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" OnClick="BuscarClick"/>
                </td>
            </tr>
            </table>
            </form>
            
                      
             
                                
                 
            
         </div>     </div> 
</div>  
				
			</div> 
		</div> 
  
</asp:Content>
