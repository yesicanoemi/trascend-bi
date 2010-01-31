<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarClientes.aspx.cs" Inherits="Paginas_Clientes_ConsultarClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

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
                   
                    
                    
                    <form id="Form3" action="#" runat="server">
                    
                    <asp:MultiView runat="server" ID="uxMultiViewConsultar" ActiveViewIndex="0">
                        
                        
                        <asp:View ID="uxViewBuscar" runat="server"> 
                        
                        
                                  <p>Introduzca los campos según su tipo de búsqueda</p> 
                                    
                                    <br />
                                    
                                    <table width="">
                                          <tr>  
                                            <td align="right">
                                                <asp:RadioButtonList ID="uxRbCampoBusqueda" runat="server" Width="194px"  
                                                    onselectedindexchanged="uxRbCampoBusqueda_SelectedIndexChanged" 
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="1" Text="Nombre de Cliente"></asp:ListItem> 
                                                    <asp:ListItem Value="2" Text="Rif"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            
                                             <td align="center">
                                              
                                                <table>
                                                   <tr>
                                                        
                                                        <td align="center"><asp:Label ID="uxRifCliente" runat="server" Visible="false" Text="RIF del Cliente"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                   
                                                        <td align="center">
                                                            <asp:TextBox ID="uxConsultaRif" MaxLength=11 runat="server" Visible="false" Width="100" >
                                                            </asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>
                                                     <tr>
                                                        
                                                        <td align="center"><asp:Label ID="uxNombreCliente" runat="server" Visible="false" Text="Nombre del Cliente"></asp:Label></td>
                                                    </tr>

                                                    <tr>
                                                                                    <td><asp:TextBox ID="uxValor" runat="server" ontextchanged="uxValor_TextChanged" Visible="false"
                                        Width="150px"></asp:TextBox></td>
                                             </tr>
                                             <tr>
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
                                        </tr>
                                        <tr>       
                                                    <td>
                                                       <br />
                                                        <br />
                                                        <br />

                                                    </td>
                                          </tr>
                                              
                                            
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="uxBotonBuscar" runat="server" onclick="uxBotonBuscar_Click" 
                                                                Visible="false"    Text="Buscar" ValidationGroup="valBusquedaNombre" />
                                                            </td>
                                                        </tr>
                                                   
                                            </table>
                                            
                                            
                                          
                                              <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                                 <tr>                      

                                    <td>

                                        
                                        
                                        
                                        

                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                
                                        
                                        
                                        
                                                <br />
                                                <br />
                                            </td>
                                     
                                
                              
                                </td>
                            </tr>
                            
                        </table>
                     
                        </asp:View>
                        <asp:View ID="uxViewMostrar" runat="server">
                           
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
                                
                                                                 <asp:DetailsView ID="uxMuestraTelefono" 
                                    datasourceid="uxObjectConsultaTelefono" HeaderText="Telefonos"
                                datakeynames="codigoarea" Runat="server" AutoGenerateRows="False" DefaultMode="Edit"  
                                 Width="306px">  <headerstyle backcolor="#c60"            forecolor="White"/>
                                  <Fields>
                                                        <asp:BoundField HeaderText="Codigo de Area" DataField="codigoarea" ReadOnly="True"/> 
                                                        <asp:BoundField HeaderText="Tipo" DataField="tipo" ReadOnly="True"/>
                                                        <asp:BoundField HeaderText="Numero" DataField="numero" ReadOnly="True"/>
                                                       
                                  </Fields>
                                </asp:DetailsView>
                                
                                
                                <br />
                                <asp:UpdatePanel ID="up2" runat="server">
                                    <ContentTemplate>
                                        <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                
                        </asp:View>
                       
                   </asp:MultiView>     
                    
                     </form>
                 </div> 
             
                      
                     
              </div>
                      
        </div> 
				
			</div> 
		</div> 
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaDireccion" DataObjectTypeName="Core.LogicaNegocio.Entidades.Direccion" />
		
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 
        
        <pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaTelefono" DataObjectTypeName="Core.LogicaNegocio.Entidades.TelefonoTrabajo" />  
</asp:Content>

