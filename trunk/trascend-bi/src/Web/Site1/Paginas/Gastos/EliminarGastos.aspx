<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="EliminarGastos.aspx.cs" Inherits="Paginas_Gastos_EliminarGastos" %>

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
		                    <table>
		                <tr>		                    
		                    <td><asp:Label ID="LabelTipoConsulta" runat="server" Text="Realizar Consulta: " /></td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>
		                <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>	
		                    <td>&nbsp;</td>                    
		                </tr>    
		                    <tr>
	    	                    <td>
                                    <asp:RadioButtonList ID="uxCheckOpcionBuscar" runat="server" 
                                    Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow" 
                                    TextAlign="Left" AutoPostBack="True">                                    
                                        <asp:ListItem Value="0">Por Propuesta</asp:ListItem>
                                        <asp:ListItem Value="1">Por Tipo</asp:ListItem>
                                        <asp:ListItem Value="2">Por Estado</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>&nbsp;</td>
		                        <td><asp:TextBox ID="uxBusquedaConsulta" runat="server"></asp:TextBox></td>
		                        <td>&nbsp;</td>
	    	                    <td><asp:Button ID="uxBotonBuscarDatos" Text="Buscar" runat="server" onclick="uxBotonBuscar_Click" /></td>
    		                </tr>		                		                
        		                <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>	                    
        		                </tr>
		                    </table>
		                    
		                    <table>
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
			                        <asp:GridView ID="uxEliminarGasto" runat="server" AllowPaging="True" DataSourceID="uxObjectEliminarGasto"
                                                    AutoGenerateColumns="false" DataKeyNames="codigo" AutoGenerateSelectButton="true"
                                                    Width="130%" Font-Names="Verdana" Font-Size="X-Small" OnSelectedIndexChanging="uxEliminarGasto_SelectedIndexChanged">
                                                                                     
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
<pp:objectcontainerdatasource runat="server" ID="uxObjectEliminarGasto" DataObjectTypeName="Core.LogicaNegocio.Entidades.Gasto" /> 	 
</asp:Content>
