<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarClientes.aspx.cs" Inherits="Paginas_Clientes_ConsultarClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Clientes</h3> 
                    <p class="large">
                    <asp:MultiView runat="server" ID="uxMultiViewConsultar" ActiveViewIndex="0">
                        <asp:View ID="uxViewBuscar" runat="server"> 
                        <form id="Form1" action="#" runat="server">
                        <table>
                            <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Introduzca Tipo de Consulta" /></td>
                            </tr>
                            <tr>
                                <td><asp:DropDownList ID="opcion1" runat="server">
                                    <asp:ListItem>Nombre</asp:ListItem>
                                    <asp:ListItem>Area de Negocio</asp:ListItem>                                    
                                    </asp:DropDownList></td>
                                    
                                <td><asp:TextBox ID="uxValor" runat="server" ontextchanged="uxValor_TextChanged"> </asp:TextBox></td>
                                    <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                 TargetControlID="uxValor"
                                                 CompletionInterval="1000"
                                                 CompletionSetCount="20"
                                                 UseContextKey="false"
                                                 MinimumPrefixLength="1" 
                                                 ServiceMethod="GetSuggestionsClienteNombre"
                                                 DelimiterCharacters="; ,"
                                                 ServicePath="../../SuggestionNames.asmx"
                                                 EnableCaching="true"
                                                 CompletionListCssClass="completionList"
                                                 CompletionListHighlightedItemCssClass="itemHighlighted"
                                                 CompletionListItemCssClass="listItem">
                                              </AjaxControlToolkit:AutoCompleteExtender>
                                     
                                
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" /></td>
                            </tr>
                            
                        </table>
                        </form>
                        </asp:View>
                        <asp:View ID="uxViewMostrar" runat="server">
                            <form runat="server">
                                <asp:GridView ID="uxMuestra" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaCliente"
                                                AutoGenerateColumns="False" DataKeyNames="IdCliente" AutoGenerateSelectButton="true"
                                                Width="100%" Font-Names="Verdana" Font-Size="Smaller" onrowdatabound="uxTablaClientes_RowDataBound" >
                                                 <RowStyle HorizontalAlign="Center" />  
                                                    
                                                     <RowStyle HorizontalAlign="Center" />  
                                                     
                                                    <Columns>
                                            
                                                        <asp:BoundField HeaderText="Rif" DataField="rif" /> 
                                                        <asp:BoundField HeaderText="Nombre Cliente" DataField="Nombre" />
                                                        <asp:BoundField HeaderText="Area de Negocio" DataField="AreaNegocio" />                                                         
                                                         
                                                       
                                                        
                                                    </Columns>
                                </asp:GridView>
                                </form>
                        </asp:View>
                        <asp:View ID="uxDetalle" runat="server">
                            <form runat="server">
                                
                            
                            </form>
                        
                        </asp:View>
                   </asp:MultiView>     
                    </p> 
                 </div> 
              </div>
        </div> 
				
			</div> 
		</div> 
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 

</asp:Content>

