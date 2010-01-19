<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ReportesEquipo6b.aspx.cs" Inherits="Paginas_Reportes_ReportesEquipo6b" %>
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
 <li><a href="ReportesEquipo6b.aspx" class="active">Facturas Por Cobrar<span></span></a></li>
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
            <h3>Reporte Equipo #6 (Facturas Por Cobrar)</h3> 
            <p>&nbsp;</p>
            
            
             <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Fecha inicio"></asp:Label>
                    
                    <asp:TextBox ID="uxFechaInicio" runat="server"></asp:TextBox>
                   
                    <asp:Image ID="uxFechaInicioImg" runat="server" ImageUrl="~/Images/calendario.png" />
                    
                    <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxInicio"
                                        Format="dd/MM/yy" TargetControlID="uxFechaInicio" PopupButtonID="uxFechaInicioImg" >
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
                                        Format="dd/MM/yy" TargetControlID="uxFechaFin" PopupButtonID="uxFechaFinImg" >
                    </AjaxControlToolkit:CalendarExtender>
                 
                </td>
                <td><asp:Button ID="Button3" runat="server" Text="Aceptar" 
                        onclick="Button3_Click" /></td>
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
        <asp:GridView ID="uxGridView" runat="server" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="449px" AutoGenerateColumns=false CellSpacing="20">
            <Columns>
                <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                <asp:BoundField HeaderText="Porcentaje pagado" DataField="Procentajepagado" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:TemplateField HeaderText="Fecha Factura"><ItemTemplate><%# FormatearFecha((DateTime)Eval("FechaIngreso")) %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Propuesta" AccessibleHeaderText="Propuesta">
                    <ItemTemplate>
                    <asp:Label ID="lblTotal42" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.Prop.titulo") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField> 
                <asp:TemplateField HeaderText="Monto" AccessibleHeaderText="Monto">
                    <ItemTemplate>
                    <asp:Label ID="lblTotal42" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.Prop.montoTotal") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>   
            </Columns>
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
    </div> 
</div>  

			</div> 
		</div> 
    </form>
</asp:Content>
