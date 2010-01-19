<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarGastos.aspx.cs" Inherits="Paginas_Gastos_ConsultarGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<div class="container subnav"> 
    <div class="content"> 
        <div class="sub-heading"> 
            <h2>Gastos</h2> 
		</div> 
		<div class="subnav-container"> 
		    <ul id="subnav"> 
		        <li><a href="AgregarGastos.aspx">Agregar<span></span></a></li> 
		        <li><a href="ConsultarGastos.aspx" class="active">Consultar<span></span></a></li> 
		        <li><a href="EliminarGastos.aspx" >Eliminar<span></span></a></li> 
		        <li><a href="ModificarGastos.aspx" >Modificar<span></span></a></li>
		    </ul> 
		 </div> 		
		 <div class="sub-content"> 
		    <div class="features_overview"> 
		        <div class="features_overview_right"> 
		            <h3>Consultar Gasto</h3>
		            <p class="large">Busqueda del Gasto</p>
		            <form id="form1" action="#" runat="server">
		            <table>
		                <tr>
		                    <td><asp:Label ID="LabelTipoConsulta" runat="server" Text="Realizar Consulta: " /></td>
		                    <td><asp:DropDownList ID="uxTipoConsulta" runat="server">
		                            <asp:ListItem>Por Propuesta</asp:ListItem>
		                            <asp:ListItem>Por tipo de Gasto</asp:ListItem>
		                            <asp:ListItem>Por Fecha de gasto</asp:ListItem>
		                        </asp:DropDownList></td>
		                    <td>&nbsp;</td>
		                    <td><asp:Button ID="uxBotonBuscar" Text="Buscar" runat="server" 
                                            onclick="uxBotonBuscar_Click" /></td>
		                </tr>
		                <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td&nbsp;td>
		                </tr>
		                <tr>
		                    <td><asp:Label ID="LabelSeleccion" runat="server" Text="Seleccione: " Enabled="false"/></td>
		                    <td><asp:DropDownList ID="uxSeleccion" runat="server" Enabled="false"></asp:DropDownList></td>
		                    <td>&nbsp;</td>
		                    <td><asp:Button ID="uxBotonBuscar2" Text="Buscar" runat="server" Enabled="false" 
                                            onclick="uxBotonBuscar2_Click" /></td>
		                </tr>
		                <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>
		                <tr>
		                    <td><asp:Label ID="LabelFechaGasto" Text="Indique Fecha:" runat="server" Enabled="false" /></td>
		                    <td><asp:TextBox ID="uxFechaGasto" runat="server" Enabled="false"></asp:TextBox>
		                        <asp:Image ID="uxImagenFechaGasto" runat="server" ImageUrl="~/Images/calendario.png"/></td>
		                    <td>&nbsp;</td>
		                    <td><asp:Button ID="uxBotonBuscar3" Text="Buscar" runat="server" Enabled="false" 
                                            onclick="uxBotonBuscar3_Click"/></td>		        
		                </tr>
		                <tr>
		                    <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxMsjFechaGasto"
                                                Format="dd/MM/yy" TargetControlID="uxFechaGasto" PopupButtonID="uxImagenFechaGasto" >
                                </AjaxControlToolkit:CalendarExtender></td>                             
		                </tr>
		                <tr>
		                    <td><h3>Datos del Gasto</h3></td>
			            </tr>
			            <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>			         
			            <tr>
			                <td colspan="2">
			                    <asp:GridView ID="uxConsultaGasto" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaGasto"
                                                AutoGenerateColumns="false" DataKeyNames="codigo" AutoGenerateSelectButton="false"
                                                Width="130%" Font-Names="Verdana" Font-Size="X-Small">
                                                
                                                <Columns>
                                                        <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                                                        <asp:BoundField HeaderText="Estado" DataField="estado" />                                            
                                                        <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                                                        <asp:BoundField HeaderText="Estado" DataField="estado" />
                                                        <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />  
                                                        <asp:BoundField HeaderText="Monto" DataField="monto" />                                                         
                                                        <asp:BoundField HeaderText="Fecha Gasto" DataField="fechaGasto" />
                                                        <asp:BoundField HeaderText="Fecha Ingreso" DataField="fechaIngreso" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                        <center>
                                                            <span>No hay data cargada</span>
                                                        </center>
                                                </EmptyDataTemplate>                                                 

<HeaderStyle Font-Size="Small"></HeaderStyle>
                                </asp:GridView>
			                </td>
			            </tr>
		            </table>
		            </form>                                           
                </div> 
            </div>
         </div> 				
    </div>
</div>
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaGasto" DataObjectTypeName="Core.LogicaNegocio.Entidades.Gasto" /> 	 
</asp:Content>




