<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarClientes.aspx.cs" Inherits="Paginas_Clientes_ConsultarClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>
<%@ Register Src="../../ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>

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
                                <td colspan="2"><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Seleccione e introduzca parámetro de búsqueda de Cliente" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td><asp:DropDownList ID="opcion1" runat="server" Width="120px">
                                    <asp:ListItem>Nombre</asp:ListItem>
                                    <asp:ListItem>R.I.F</asp:ListItem>                                    
                                    </asp:DropDownList></td>
                                    
                                <td><asp:TextBox ID="uxValor" runat="server" ontextchanged="uxValor_TextChanged" 
                                        Width="150px"></asp:TextBox></td>
                                    <td>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            CompletionInterval="1000" CompletionListCssClass="completionList" 
                                            CompletionListHighlightedItemCssClass="itemHighlighted" 
                                            CompletionListItemCssClass="listItem" CompletionSetCount="20" 
                                            DelimiterCharacters="; ," EnableCaching="true" MinimumPrefixLength="1" 
                                            ServiceMethod="GetSuggestionsClienteNombre" 
                                            ServicePath="../../SuggestionNames.asmx" TargetControlID="uxValor" 
                                            UseContextKey="false">
                                        </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                     
                                
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" ValidationGroup="valBusquedaNombre" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                        ControlToValidate="uxValor" Display="None" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaParametroBusqueda%>" 
                                        ValidationGroup="valBusquedaNombre" />
                                    
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" 
                                        runat="Server" TargetControlID="RequiredFieldValidator9" />
                                </td>
                            </tr>
                            
                        </table>
                        </form>
                        </asp:View>
                        <asp:View ID="uxViewMostrar" runat="server">
                            <form runat="server">
                                <asp:DetailsView ID="uxMuestraCliente" datasourceid="uxObjectConsultaCliente"
                                datakeynames="rif" Runat="server" AutoGenerateRows="False" DefaultMode="Edit"  HeaderText="Datos de Cliente"
                                 Width="275px">     <headerstyle backcolor="Navy"            forecolor="White"/>

                                  <Fields>
                                                        <asp:BoundField HeaderText="Rif" DataField="rif" ReadOnly="True"/> 
                                                        <asp:BoundField HeaderText="Nombre Cliente" DataField="nombre" ReadOnly="True"/>
                                                        <asp:BoundField HeaderText="Area de Negocio" DataField="areanegocio" ReadOnly="True"/>        
                                  </Fields>
                                </asp:DetailsView>
                                
                                <asp:DetailsView ID="uxMuestraDireccion" datasourceid="uxObjectConsultaDireccion" HeaderText="Direccion"
                                datakeynames="calle" Runat="server" AutoGenerateRows="False" DefaultMode="Edit"  
                                 Width="275px">  <headerstyle backcolor="Navy"            forecolor="White"/>
                                  <Fields>
                                                        <asp:BoundField HeaderText="Avenida" DataField="avenida" ReadOnly="True"/> 
                                                        <asp:BoundField HeaderText="Urbanizacion" DataField="urbanizacion" ReadOnly="True"/>
                                                        <asp:BoundField HeaderText="Edificio/Casa" DataField="edif_casa" ReadOnly="True"/>  
                                                        <asp:BoundField HeaderText="Oficina" DataField="oficina" ReadOnly="True"/> 
                                                        <asp:BoundField HeaderText="Ciudad" DataField="ciudad" ReadOnly="True"/>      
                                  </Fields>
                                </asp:DetailsView>
                                
                                <br />
                                <asp:UpdatePanel ID="up2" runat="server">
                                    <ContentTemplate>
                                        <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                </form>
                        </asp:View>
                        <asp:View ID="uxDetalle" runat="server">
                            <form runat="server">
                                
                            
                            </form>
                        
                        </asp:View>
                   </asp:MultiView>     
                    </p> 
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
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaDireccion" DataObjectTypeName="Core.LogicaNegocio.Entidades.Direccion" />
		
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 
        
        <pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaTelefono" DataObjectTypeName="Core.LogicaNegocio.Entidades.Telefono" />  
</asp:Content>

