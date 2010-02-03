<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo1a.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo1" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

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
            
            <span style="text-align:center; font-size:smal; color:Red">
             <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
             </span> 
             
            <form id="fomr1" runat="server">
            <table style="width: 150%">
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
            <tr>
            <td>
            
            <asp:GridView ID="uxConsultarEmpleado" runat="server" AllowPaging="True" 
                    DataSourceID="uxObjectConsultarEmpleado" AutoGenerateColumns="False" 
                    DataKeyNames ="ID" AutoGenerateSelectButton="True" Visible="false"
                    Width="95%" Font-Names="Verdana" Font-Size="Smaller" PageSize = "10"
                    OnSelectedIndexChanging="SelectEmpleado">
                <columns>
                    <asp:BoundField HeaderText="Cedula" DataField="Cedula" SortExpression="Cedula"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                </columns>
         
 
       </asp:GridView>
       
       
       
            <asp:GridView runat="server" ID="uxReportePaquete1a" AutoGenerateColumns="false" Visible="false"
                           PageSize="10" onrowdatabound="uxGridView_RowDataBound" Width="500px">
             
             <RowStyle HorizontalAlign="Center" />              
             
             <Columns>
                                            
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/> 
                
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                               
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                
                <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
                
                <asp:BoundField HeaderText="Sueldo Máximo Anual" DataField="SueldoBase" />
                
                <asp:BoundField HeaderText="Sueldo Mínimo Anual" DataField="Cedula" />
                                                        
             </Columns>
                                                
            </asp:GridView>
            </td>
            </tr>
            </table>
            
                <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                        <uc1:DialogoError ID="uxDialogoError" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
            
                      
             
                                
                 
            
         </div>     </div> 
</div>  
				
			</div> 
		</div> 
		<pp:Objectcontainerdatasource runat= "server" ID = "uxObjectConsultarEmpleado" DataObjectTypeName = "Core.LogicaNegocio.Entidades.Empleado"/> 
		 <pp:objectcontainerdatasource runat="server" ID="uxObjectReporte1a" DataObjectTypeName="Core.LogicaNegocio.Entidades.Empleado" /> 
  
</asp:Content>
