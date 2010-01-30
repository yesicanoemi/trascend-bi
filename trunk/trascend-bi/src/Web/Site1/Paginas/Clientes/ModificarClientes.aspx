<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarClientes.aspx.cs" Inherits="Paginas_Clientes_ModificarClientes" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>
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
  <li><a href="ConsultarClientes.aspx">Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Modificar Clientes</h3> 
                    <p class="large">
                               
                        <form id="Form1" action="#" runat="server">
                        
                            <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                          
                                     <p>Introduzca los campos según su tipo de búsqueda</p> 
                                    
                               
                                    
                    
                                    <table width="100%">
                                          <tr>  
                                            <td align="right">
                                                <asp:RadioButtonList ID="uxRbCampoBusqueda" runat="server" Font-Size="Small" 
                                                    RepeatDirection="Horizontal" RepeatLayout="Flow" 
                                         TextAlign="Left"  Width="262px" 
                                                    onselectedindexchanged="uxRbCampoBusqueda_SelectedIndexChanged" 
                                                    AutoPostBack="true" Height="90px">
                                                    <asp:ListItem Value="1" Text="Nombre"></asp:ListItem> 
                                                    <asp:ListItem Value="2" Text="Area De Negocio"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                           
                                        
                                            <td align="center">
                                               <asp:TextBox ID="uxNombreCliente" runat="server" ontextchanged="uxNombreCliente_TextChanged"> </asp:TextBox></td>
                                    <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                 TargetControlID="uxNombreCliente"
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
                                                
                                                
                                                     </td>  
                                            </td>  
                                            <td align="left">

                                                <asp:Button ID="uxBotonBuscar" runat="server" onclick="uxBotonBuscar_Click" 
                                                    Text="Buscar" Visible="false" />

                                            </td>
                                        </tr>
                                        
                                          <tr>
                                            <td>
                                                <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                                            </td>
                                            <td><asp:RequiredFieldValidator ID="uxRequiredFieldValidator" runat="server" 
                                                ControlToValidate="uxLogin" Visible="false"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreCliente%>" Font-Size="Smaller" Display="Static" />
                                            </td>

                                        </tr>
                                        
                                        </table>
                                           		            
        		            <table style="width:100%;">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="LabelMensajeError" runat="server" Visible="false" Font-Bold="true" Font-Size="Large"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                           </table>
                                </asp:View>
                                  <asp:View ID="ViewCliente" runat="server">

                                    <p class="large">Datos del Cliente</p>                    

                                    <form id="uxFormConsultarCliente">
                                        <table style="width:100%;">
                               <tr>
                                   <td>Rif: </td>
                                   <td><asp:TextBox ID="uxRif" runat="server" Enabled="false"></asp:TextBox></td>
                               </tr>
                                <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>        		               
		                        </tr>
                               <tr>
                                   <td>Nombre: </td>
                                   <td><asp:TextBox ID="uxNombre" runat="server" Enabled="false"></asp:TextBox></td>
                               </tr>
                                 <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>        		               
		                        </tr>
                               <tr>
                                   <td>Area de Negocio: </td>
                                   <td><asp:TextBox ID="uxAreaNegocio" runat="server" Enabled="false"></asp:TextBox></td>
                               </tr> 
                                      
                                        </table>
                                   </form>
                                 </asp:View>
                                   
                            </asp:MultiView>
                        </form>
                    </p> 
                 </div> 
              </div>
        </div> 
				
				
				
			</div> 
		</div> 
</asp:Content>
