<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Inherits="Paginas_Reportes_ReportesEquipo1" Codebehind="ReportesEquipo1a.aspx.cs" %>

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
            <table style="width: 100%">
                <tr>
                    <form id="fomr1" runat="server">
                    <td>C.I.:<asp:TextBox ID="uxCedula" runat="server" ValidationGroup="validarCedula"></asp:TextBox>
                    <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxCedula"
                                                ErrorMessage="<%$ Resources:DSU, FaltaCIEmpleado%>" Font-Size="Smaller"
                                                Display="Static" ValidationGroup="validarCedula" /></td>
                    
                    <td><br />
                        <br />
                        <br />
                        <asp:Button ID="uxBotonAceptar1" runat="server" Text="Buscar" ValidationGroup="validarCedula" /></td>
                    
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    
                    <td>Nombre:<asp:TextBox ID="uxNombre" runat="server" ValidationGroup="validarNombre"></asp:TextBox>
                    <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxNombre"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreEmpleado%>" Font-Size="Smaller"
                                                Display="Static" ValidationGroup="validarNombre"/>
                    </td>
                    <td><br />
                        <br />
                        <br /> 
                        <asp:Button ID="uxBotonAceptar2" runat="server" Text="Buscar" ValidationGroup="validarNombre"/></td>
                    </form>
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
  
</asp:Content>
