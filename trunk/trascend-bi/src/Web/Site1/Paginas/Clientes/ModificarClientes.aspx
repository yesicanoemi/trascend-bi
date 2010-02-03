<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarClientes.aspx.cs" Inherits="Paginas_Clientes_ModificarClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx" >Consultar<span></span></a></li> 
 
  <li><a href="ModificarClientes.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Modificar Clientes</h3> 
                   
                    
                    
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
                                                            <asp:TextBox ID="uxConsultaRif" MaxLength=11 runat="server" Visible="false" 
                                                                Width="120px" ></asp:TextBox>
                                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                                                CompletionListCssClass="list" 
                                                                CompletionListHighlightedItemCssClass="hoverlistitem" 
                                                                CompletionListItemCssClass="listitem" CompletionSetCount="1" 
                                                                MinimumPrefixLength="1" ServiceMethod="GetSuggestionsClienteRif" 
                                                                ServicePath="../../SuggestionNames.asmx" TargetControlID="uxConsultaRif" 
                                                                UseContextKey="false">
                                                            </ajaxToolkit:AutoCompleteExtender>
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
                                            UseContextKey="false"></ajaxToolkit:AutoCompleteExtender>
                                                                               
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
                                                                Visible="false"    Text="Buscar" ValidationGroup="valBusquedaNombre"  />
                                                            </td>
                                                        </tr>
                                                   
                                            </table>
                                            
                                            
                                          
                                              <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                                              
                                               
                                                  </td>
                                         </tr> 
                                          <tr>
                                              <td align="right" colspan="2">
                                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                      <ContentTemplate>
                                                          <uc2:MensajeInformacion ID="uxMensajeInformacion1" runat="server" 
                                                              Visible="false" />
                                                      </ContentTemplate>
                                                  </asp:UpdatePanel>
                                              </td>
                                          </tr>
                                     <tr>
                                     <td></td>
                                     
                                                                          <td align="center">
                                         <asp:GridView ID="uxGridCliente" runat="server" AllowPaging="True" 
                                          AutoGenerateColumns="False" 
                                         DataKeyNames="rif" AutoGenerateSelectButton="True" 
                                         Width="70%" Font-Names="Verdana" Font-Size="Smaller"
                                         OnSelectedIndexChanging="SelectCliente"  onrowdeleting="ClienteGridView_RowDeleting"  

                                          onrowdatabound="uxGridView_RowDataBound" AutoGenerateDeleteButton="True">
                                        <RowStyle HorizontalAlign="Center" />  
                                        <Columns>
                                            <asp:BoundField HeaderText="Rif" DataField="rif" />
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                            <asp:BoundField HeaderText="Area de Negocio" DataField="areanegocio"/>
                                            
                                        </Columns>
                                                                    <EmptyDataTemplate>
                                            <center>
                                                <span>No Data Papa</span>
                                            </center>
                                        </EmptyDataTemplate>
                                    </asp:GridView> 
                                      
                                     </td>
                                     </tr>
                                     <tr>
                                    <td colspan="2">

                                        
                                        
                                        
                                        

                                <br />
                                                <asp:UpdatePanel ID="up2" runat="server">
                                                    <ContentTemplate>
                                                        <uc1:DialogoError ID="uxDialogoError0" runat="server" />
                                                    </ContentTemplate>
                                        </asp:UpdatePanel>
                                                <br />
                                                <br />
                                                <br />
                                                
                                        
                                        
                                        
                                                <br />
                                                <br />
                                                
                                                
                                            </td>

                                     </tr>
                           
                              
                                </td>
                            </tr>
                    
                        </table>
                     
                        </asp:View>
                        <asp:View ID="uxViewMostrar" runat="server">
                           
                            <table style="width: 100%;">
                                <tr>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <uc2:MensajeInformacion ID="uxMensajeInformacion0" runat="server" 
                                                Visible="false" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </tr>
                                 <tr> <td></td> <td align="center">
                                                    <asp:Button ID="uxDesactivarCliente" runat="server" onclick="uxDesactivarCliente_Click" 
                                                   Visible="true"     Text="Desactivar Cliente" ValidationGroup="ValidarCampos" />
                                                    <br />
                                                    <br />
                                                </td></tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>RIF:</td>
                                    <td>
                                        <asp:DropDownList ID="uxTipoRif" runat="server" Width="40px">
                                            <asp:ListItem Value="J">J</asp:ListItem>
                                            <asp:ListItem Value="G">G</asp:ListItem>
                                            <asp:ListItem Value="V">V</asp:ListItem>
                                            <asp:ListItem Value="E">E</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp; -<asp:TextBox ID="uxRif" runat="server" MaxLength="9" Width="87px"></asp:TextBox>
                                        &nbsp;<span style="color: #FF0000"> </span>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxRif"></ajaxToolkit:FilteredTextBoxExtender>
                                        <span style="color: #FF0000">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                            ControlToValidate="uxRif" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoRif %>" 
                                            ValidationExpression="<%$Resources:DSU, ERRif%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender91" 
                                            runat="Server" TargetControlID="RegularExpressionValidator6"></ajaxToolkit:ValidatorCalloutExtender>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="uxRif" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Nombre:</td>
                                    <td>
                                        <asp:TextBox ID="uxNombreCliente0" runat="server" MaxLength="32"></asp:TextBox>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="uxNombreCliente0" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Calle/Avenida</td>
                                    <td>
                                        <asp:TextBox ID="uxAvenidaCalle" runat="server" MaxLength="32"></asp:TextBox>
                                        &nbsp;
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                    ControlToValidate="uxAvenidaCalle" Display="Dynamic" 
                                                    ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                                    ValidationGroup="ValidarCampos" />
                                            </td>
                                        </tr>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Urbanización</td>
                                    <td>
                                        <asp:TextBox ID="uxUrbanizacion" runat="server" MaxLength="32"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="uxUrbanizacion" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Edificio/Casa</td>
                                    <td>
                                        <asp:TextBox ID="uxEdificioCasa" runat="server" MaxLength="32"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                            ControlToValidate="uxEdificioCasa" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Oficina</td>
                                    <td>
                                        <asp:TextBox ID="uxPisoApartamento" runat="server" MaxLength="20"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                            ControlToValidate="uxPisoApartamento" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Ciudad:</td>
                                    <td>
                                        <asp:TextBox ID="uxciudad" runat="server" MaxLength="32"></asp:TextBox>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                            ControlToValidate="uxciudad" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Área de Negocio:</td>
                                    <td>
                                        <asp:TextBox ID="uxAreaNegocioCliente" runat="server" MaxLength="35"></asp:TextBox>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                            ControlToValidate="uxAreaNegocioCliente" Display="Static" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000">* </span>Teléfono Trabajo:</td>
                                    <td>
                                        <asp:TextBox ID="uxCodTrabajo" runat="server" MaxLength="5" Width="55px"></asp:TextBox>
                                        <span style="color: #FF0000">
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxCodTrabajo" 
                                            ValidChars="+ ()"></ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                            ControlToValidate="uxCodTrabajo" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoCodTelefono %>" 
                                            ValidationExpression="<%$Resources:DSU, ERTelefono%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender88" 
                                            runat="Server" TargetControlID="RegularExpressionValidator3"></ajaxToolkit:ValidatorCalloutExtender>
                                        </span>
                                        <asp:TextBox ID="uxTelefonoTrabajo" runat="server" MaxLength="7" Width="85px"></asp:TextBox>
                                        <span style="color: #FF0000">&nbsp;
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxTelefonoTrabajo"></ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                            ControlToValidate="uxTelefonoTrabajo" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoNumTelf %>" 
                                            ValidationExpression="<%$Resources:DSU, ERNumTelf%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender92" 
                                            runat="Server" TargetControlID="RegularExpressionValidator7"></ajaxToolkit:ValidatorCalloutExtender>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                            ControlToValidate="uxCodTrabajo" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                            ControlToValidate="uxTelefonoTrabajo" Display="Dynamic" 
                                            ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller" 
                                            ValidationGroup="ValidarCampos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; Celular:</td>
                                    <td>
                                        <asp:TextBox ID="uxCodCelular" runat="server" MaxLength="5" Width="55px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxCodCelular" 
                                            ValidChars="+ ()"></ajaxToolkit:FilteredTextBoxExtender>
                                        <span style="color: #FF0000">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                            ControlToValidate="uxCodCelular" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoCodTelefono %>" 
                                            ValidationExpression="<%$Resources:DSU, ERTelefono%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender89" 
                                            runat="Server" TargetControlID="RegularExpressionValidator4"></ajaxToolkit:ValidatorCalloutExtender>
                                        <asp:TextBox ID="uxTelefonoCelular" runat="server" MaxLength="7" Width="85px"></asp:TextBox>
                                        </span>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxTelefonoCelular"></ajaxToolkit:FilteredTextBoxExtender>
                                        <span style="color: #FF0000">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                                            ControlToValidate="uxTelefonoCelular" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoNumTelf %>" 
                                            ValidationExpression="<%$Resources:DSU, ERNumTelf%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender93" 
                                            runat="Server" TargetControlID="RegularExpressionValidator8"></ajaxToolkit:ValidatorCalloutExtender>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; Fax:</td>
                                    <td>
                                        <asp:TextBox ID="uxCodFax" runat="server" MaxLength="5" Width="55px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxCodFax" 
                                            ValidChars="+ ()"></ajaxToolkit:FilteredTextBoxExtender>
                                        <span style="color: #FF0000">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                            ControlToValidate="uxCodFax" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoCodTelefono %>" 
                                            ValidationExpression="<%$Resources:DSU, ERTelefono%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender90" 
                                            runat="Server" TargetControlID="RegularExpressionValidator5"></ajaxToolkit:ValidatorCalloutExtender>
                                        <asp:TextBox ID="uxTelefonoFax" runat="server" MaxLength="7" Width="85px"></asp:TextBox>
                                        </span>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
                                            runat="server" FilterType="Custom, Numbers" TargetControlID="uxTelefonoFax"></ajaxToolkit:FilteredTextBoxExtender>
                                        <span style="color: #FF0000">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                                            ControlToValidate="uxTelefonoFax" Display="None" 
                                            ErrorMessage="<%$Resources:DSU, ErrorFormatoNumTelf %>" 
                                            ValidationExpression="<%$Resources:DSU, ERNumTelf%>" 
                                            ValidationGroup="ValidarCampos"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender94" 
                                            runat="Server" TargetControlID="RegularExpressionValidator9"></ajaxToolkit:ValidatorCalloutExtender>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td style="color: #FF0000">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <table style="width: 100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="uxBotonAceptar" runat="server" onclick="uxBotonAceptar_Click" 
                                                        Text="Modificar" ValidationGroup="ValidarCampos" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="uxBotonVolver" runat="server" 
                                                        PostBackUrl="~/Paginas/Clientes/DefaultClientes.aspx" Text="Volver" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:TextBox ID="uxIdCliente" runat="server" Visible="False"></asp:TextBox>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                                
                                <caption>
                                    <br />
                                    <%--<asp:UpdatePanel ID="up2" runat="server">
                                        <ContentTemplate>
                                            <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </caption>
                                
                                
                        </asp:View>
                       
                   </asp:MultiView>     
                    

                     <br />

                 </div> 
             
                      
                     
              </div>
                      
                      

        </div> 
				
			</div> 
		</div> 
		
		
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 
        
        
        
    </form>
        
    </form>
</asp:Content>

