<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="EliminarGastos.aspx.cs" Inherits="Paginas_Gastos_EliminarGastos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
	    <div class="content"> 
		    <div class="sub-heading"> 
			    <h2>Gastos</h2> 
			</div> 
			<div class="subnav-container"> 
                <ul id="subnav"> 
                    <li><a href="AgregarGastos.aspx">Agregar<span></span></a></li> 
                    <li><a href="ConsultarGastos.aspx">Consultar<span></span></a></li> 
                    <li><a href="EliminarGastos.aspx" class="active">Eliminar<span></span></a></li> 
                    <li><a href="ModificarGastos.aspx" >Modificar<span></span></a></li>
                </ul> 
			</div> 
			<div class="sub-content"> 
                <div class="features_overview"> 
                    <div class="features_overview_right"> 
                        <h3>Eliminar Gasto</h3> 
                        <p class="large">Busqueda del Gasto</p>
                        <form id="form1" action="#" runat="server">		                  
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="LabelMensajeError" runat="server" Visible="false" Font-Bold="true" Font-Size="Large"/>
                                  		            <table id="uxTablaInicio" runat="server">
		                <tr>		                    
		                    <td><asp:Label ID="LabelTipoConsulta" runat="server" Font-Names="Verdana" Text="Seleccion el tipo de Consulta a realizar: " /></td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>
		                <tr>
		                    <td>&nbsp;</td>
		                    <td></td>
		                    <td>&nbsp;</td>	
		                    <td>&nbsp;</td>                    
		                </tr>    
		                    <tr>
		                    <td>
                                <asp:RadioButtonList  ID="uxCheckOpcionBuscar" runat="server" 
                                    Font-Size="X-Small" TextAlign="Left" Height="51px" Width="174px" 
                                    Onselectedindexchanged="verseleccion" AutoPostBack="true"  >                                    
                                    <asp:ListItem Value="0">Propuesta</asp:ListItem>
                                    <asp:ListItem Value="1">Cliente</asp:ListItem>
                                    <asp:ListItem Value="2">Fecha de Consumo</asp:ListItem>
                                </asp:RadioButtonList>
      
                            </td>
                            
		                    <td align="left">
		                        <asp:Label ID="uxLabelInfo" runat="server" Font-Names="Verdana" />
                                <asp:TextBox ID="uxBusquedaConsulta" runat="server"  Visible ="false" Height="19px" 
                                    Width="139px" ></asp:TextBox>
		                         <asp:Image ID="uxFechaInicioImg" runat="server" 
                                    ImageUrl="~/Images/calendario.png" Height="16px" Width="16px" Visible="false" />
		                        <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxInicio"
                                        Format="dd/MM/yyyy" TargetControlID="uxBusquedaConsulta" PopupButtonID="uxFechaInicioImg" >
                                </AjaxControlToolkit:CalendarExtender>
                           </td>
		                    <td>&nbsp;</td>
		                    </tr>
		                    <tr>
		                    <td></td>
		                    <td><asp:Button ID="uxBotonBuscarDatos" Text="Buscar" runat="server" Visible="false" onclick="uxBotonBuscar_Click" /></td>
		                    
		                </tr>		                		                
		                <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>	                    
		                </tr>   
		            </table>
		            </td>
		             </tr>
		            <table id="uxTablaParametros" runat="server" visible="false">
		                <tr>
		                    <td><h3><asp:GridView ID="uxGridParamCoincidente" runat="server" AllowPaging="True" DataSourceID="uxObjectParamCoinci"
                                                AutoGenerateColumns="false" DataKeyNames="ID" AutoGenerateSelectButton="true"  OnSelectedIndexChanging="parametrizado"
                                                Width="130%" Font-Names="Verdana" Font-Size="X-Small">
                                                
                                                <Columns>
                                                
                                                        <asp:BoundField HeaderText="Coincidencias" DataField="Titulo"/>   
                                                                                                             
                                                </Columns>
                                                <EmptyDataTemplate>
                                                        <center>
                                                            <span>No hay data cargada</span>
                                                        </center>
                                                </EmptyDataTemplate>            
                                                
                            </asp:GridView>
			                    </h3></td>
			            </tr>
			            <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>		                			         
			            <tr>
			                <td colspan="2">
			                    &nbsp;</td>
			            </tr>
		            </table>
		            <table id="uxTablaCliente" runat="server" visible="false">
		                 <tr>
		                    <td><h3><asp:GridView ID="uxGridCliente" runat="server" AllowPaging="True" DataSourceID="uxObjectCliente"
                                                AutoGenerateColumns="false" DataKeyNames="nombre" AutoGenerateSelectButton="true"  OnSelectedIndexChanging="parametrizadocliente"
                                                Width="130%" Font-Names="Verdana" Font-Size="X-Small">
                                                
                                                <Columns>
                                                
                                                        <asp:BoundField HeaderText="Rif" DataField="rif"/>
                                                        <asp:BoundField HeaderText="Nombre" DataField="nombre"/>   
                                                                                                             
                                                </Columns>
                                                <EmptyDataTemplate>
                                                        <center>
                                                            <span>No hay data cargada</span>
                                                        </center>
                                                </EmptyDataTemplate>                                                
                            </asp:GridView>
			                    </h3></td>
			            </tr>
			            <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>		                			         
			            <tr>
			                <td colspan="2">
			                    &nbsp;</td>
			            </tr>
			            
		            </table>		
		            <table id="uxTablaSeleccion" runat="server" visible = "false">         
			                <tr>
			                    <td colspan="2">
			                        <asp:GridView ID="uxEliminarGasto" runat="server" AllowPaging="True" DataSourceID="uxObjectEliminarGasto"
                                                    AutoGenerateColumns="false" DataKeyNames="codigo" AutoGenerateSelectButton="true"
                                                    Width="130%" Font-Names="Verdana" Font-Size="X-Small" OnSelectedIndexChanging="uxEliminarGasto_SelectedIndexChanged">
                                                                                     
                                                <Columns>
                                                    <asp:BoundField HeaderText="Codigo" DataField="codigo" />                                                                                           
                                                    <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                                                    <asp:BoundField HeaderText="Estado" DataField="estado" />
                                                    <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />  
                                                    <asp:BoundField HeaderText="Monto" DataField="monto" />                                                         
                                                    <asp:BoundField HeaderText="Fecha Gasto" DataField="fechaGasto" />
                                                </Columns>
                                                
                                                <EmptyDataTemplate>
                                                    <center>
                                                        <span>No hay data cargada</span>
                                                    </center>
                                                </EmptyDataTemplate>                                                 
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
<pp:objectcontainerdatasource runat="server" ID="uxObjectParamCoinci" DataObjectTypeName="Core.LogicaNegocio.Entidades.Propuesta" />
<pp:objectcontainerdatasource runat="server" ID="uxObjectCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 	 
<pp:objectcontainerdatasource runat="server" ID="uxObjectEliminarGasto" DataObjectTypeName="Core.LogicaNegocio.Entidades.Gasto" /> 	 
</asp:Content>
