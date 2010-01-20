<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo3b.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo3b" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>


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
  <li><a href="ReportesEquipo3b.aspx" class="active">Facturas Emitidas<span></span></a></li>
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
            <h3>Reporte Equipo #3 (Facturas Emitidas)</h3> 
            <p>&nbsp;</p>
            
            
            <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Fecha inicio"></asp:Label>
                    
                    <asp:TextBox ID="uxFechaInicio" runat="server"></asp:TextBox>
                   
                    <asp:Image ID="uxFechaInicioImg" runat="server" ImageUrl="~/Images/calendario.png" />
                    
                    <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxInicio"
                                        Format="dd/MM/yyyy" TargetControlID="uxFechaInicio" PopupButtonID="uxFechaInicioImg" >
                    </AjaxControlToolkit:CalendarExtender>                      
                                        
                    
                </td>
                
               
            </tr>
            <tr>
                 <td>
                   
                    <asp:Label ID="Label4" runat="server" Text="Fecha fin"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="uxFechaFin" runat="server"></asp:TextBox>
                    <asp:Image ID="uxFechaFinImg" runat="server" ImageUrl="~/Images/calendario.png" />
                    
                    <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="CalendarExtender2"
                                        Format="dd/MM/yyyy" TargetControlID="uxFechaFin" PopupButtonID="uxFechaFinImg" >
                    </AjaxControlToolkit:CalendarExtender>
                 
                </td>
                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                        onclick="uxBotonAceptar_Click" /></td>
             </tr>
                     <tr>
                          <td>
                             <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                          </td>
                     </tr>
            <tr></tr>
            <tr></tr>
            <tr></tr>
            <tr></tr>
            
             <tr>
             <td>

             <asp:GridView runat="server" ID="uxReporteFactura3b" AutoGenerateColumns="false"
                           PageSize="10" onrowdatabound="uxGridView_RowDataBound" Width="150%">
             
             <RowStyle HorizontalAlign="Center" />              
             
             <Columns>
                                            
                <asp:BoundField HeaderText="Id Factura" DataField="Numero"/> 
                <asp:BoundField HeaderText="Título" DataField="Titulo" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Fecha" DataField="Fechaingreso" />
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                <asp:TemplateField HeaderText="Propuesta" AccessibleHeaderText="Propuesta">
                    <ItemTemplate>
                    <asp:Label ID="lblTotal42" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.Prop.titulo") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                                            
             </Columns>
                                                
            </asp:GridView>
            
             
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
    </div> 
</div>  

			</div> 
		</div> 
		                <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                        <uc1:DialogoError ID="uxDialogoError" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
    </form>
    <pp:objectcontainerdatasource runat="server" ID="uxObjectReporte3b" DataObjectTypeName="Core.LogicaNegocio.Entidades.Factura" /> 
</asp:Content>
