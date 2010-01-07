<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo9a.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo9" %>

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
 <li><a href="ReportesEquipo8a.aspx" >Total Facturas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo8b.aspx" >Total Facturas Cobradas<span></span></a></li>
 <li><a href="ReportesEquipo8c.aspx" >Total Facturas Por Cobrar<span></span></a></li>
 <li><a href="ReportesEquipo9a.aspx" class="active">Propuestas Emitidas<span></span></a></li>
 <li><a href="ReportesEquipo9b.aspx" >Total de Propuestas Emitidas<span></span></a></li>
</ul> 
						
				</div> 
			<div class="sub-content"> 
    <div class="features_overview"> 
        <div class="features_overview_right"> 
            <h3>Reporte Equipo #9 (Propuestas Emitidas)</h3> 
           <p>&nbsp;</p>
           
            
            <table style="width: 100%">
                <tr>
                    <td>
                        Fecha Inicio:
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fecha Fin:&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
