﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarContactos.aspx.cs" Inherits="Paginas_Contactos_ModificarContactos" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <div class="container subnav"> 
        
        <div class="content"> 
        
            <div class="sub-heading"> 
            
                <h2>Contactos</h2> 
            </div> 
            
            <div class="subnav-container"> 
				
                <ul id="subnav"> 
                  <li><a href="AgregarContactos.aspx">Agregar<span></span></a></li> 
                  <li><a href="ConsultarContactos.aspx">Consultar<span></span></a></li> 
                    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
                  <li><a href="ModificarContactos.aspx" class="active">Modificar<span></span></a></li>
                </ul> 
						
			</div> 
				
		    <div class="sub-content"> 
                
                   <div class="features_overview"> 
                        
                        <div class="features_overview_right"> 
                            
                            <h3>Modificar Contacto</h3> 
                            
                                <form id="Form3" action="#" runat="server">
                                
                                <uc2:MensajeInformacion ID="MensajeInformacion1" runat="server" Visible="false" />
                                
                                <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                                
                                  <p>Introduzca los campos según su tipo de búsqueda</p> 
                                    
                                    <br />
                                    
                                    <asp:Label ID="uxIdContactoH" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="uxIdClienteH" runat="server" Text="" Visible="false"></asp:Label>
                                    
                                    <table width="">
                                          <tr>  
                                            <td align="right">
                                                <asp:RadioButtonList ID="uxRbCampoBusqueda" runat="server" Width=""  
                                                    onselectedindexchanged="uxRbCampoBusqueda_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="1" Text="Nombre de Contacto"></asp:ListItem> 
                                                    <asp:ListItem Value="2" Text="Teléfono de Contacto"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Cliente"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                           
                                        
                                            <td align="center">
                                              
                                                <table>
                                                    <tr>
                                                   
                                                        <td align="right">
                                                            <asp:TextBox ID="uxConsultaNombreContacto" runat="server" Visible="false">
                                                            </asp:TextBox>
                                                            <asp:TextBox ID="uxConsultaCodigoContacto" MaxLength=3 runat="server" Visible="false" Width="40">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="uxConsultaApellidoContacto" runat="server" Visible="false">
                                                            </asp:TextBox>
                                                            
                                                            <asp:TextBox ID="uxConsultaTelefonoContacto" MaxLength=7 runat="server" Visible="false">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="center"><asp:Label ID="uxNombreContacto" runat="server" Visible="false" Text="Nombre del Contacto"></asp:Label></td>
                                                        <td align="center"><asp:Label ID="uxApellidoContacto" runat="server" Visible="false" Text="Apellido del Contacto"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                         <td align="right"><asp:Label ID="uxCodigo" runat="server" Visible="false" Text="Código<br>(Ej.212)"></asp:Label></td>
                                                        <td align="center"><asp:Label ID="uxTlf" runat="server" Visible="false" Text="Teléfono<br>(Ej. 2386546)"></asp:Label></td>
                                                    </tr>
                                                    
                                                    <tr align="center">
                                                        <td align="center">
                                                        <asp:RequiredFieldValidator ID="uxRequiredFieldValidator" runat="server" 
                                                            ControlToValidate="uxConsultaCodigoContacto" Visible="false"
                                                            ErrorMessage="<%$ Resources:DSU, FaltaCodigoTelefono%>" Font-Size="Smaller" Display="Static" />
                                                        </td>
                                                         <td align="center">
                                                            <asp:RequiredFieldValidator ID="uxRequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="uxConsultaTelefonoContacto" Visible="false"
                                                            ErrorMessage="<%$ Resources:DSU,FaltaTelfono%>" Font-Size="Smaller" Display="Static" />
                                                    </td> 
                                                   </tr>
                                                   
                                                  
                                                 <tr align="center">
                                                 <td align="center">
                                                        <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxConsultaTelefonoContacto" FilterType="Custom, Numbers"
                                                            ValidChars="<%$ Resources:DSU,ERFormatoTelefono%>" ID="FilteredTextBoxExtender1"
                                                            runat="server">
                                                        </AjaxControlToolkit:FilteredTextBoxExtender>
                                                     </td>  
                                                     
                                                      <td align="center">
                                                        <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxConsultaCodigoContacto" FilterType="Custom, Numbers"
                                                            ValidChars="<%$ Resources:DSU,ERFormatoCodigoTelefono%>" ID="FilteredTextBoxExtender2"
                                                            runat="server">
                                                        </AjaxControlToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                    
                                                   
                                                 </tr> 
                                                
                                            
                                                </table>
                                                
                                                 
                                                  <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                                                    
                                                
                                                <asp:Label ID="uxNombreCliente" runat="server" Visible="false" Text="Nombre del Cliente"></asp:Label>
                                                <asp:DropDownList ID="uxConsultaClienteContacto" runat="server" Visible="false" 
                                                    DataTextField="IdContacto" DataValueField="IdContacto" AutoPostBack="false">
                                                </asp:DropDownList>
                                                
                                                <asp:TextBox ID="uxValor" runat="server" ontextchanged="uxValor_TextChanged" Visible="false"> </asp:TextBox>
                                                 <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                 TargetControlID="uxValor"
                                                 CompletionSetCount="20"
                                                 MinimumPrefixLength="1" 
                                                 ServiceMethod="GetSuggestionsClienteNombre"
                                                 DelimiterCharacters="; ,"
                                                 ServicePath="../../SuggestionNames.asmx">
                                              </AjaxControlToolkit:AutoCompleteExtender>
                                              
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                
                                                <asp:Button ID="uxBotonBuscar" runat="server" onclick="uxBotonBuscar_Click" 
                                                            Text="Buscar" Visible="false" />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        

                                        
                                        <tr>
                                          
                                            <td colspan="2">
                                                <asp:GridView ID="uxConsultaContacto" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaContacto"
                                                AutoGenerateColumns="False" DataKeyNames="IdContacto" AutoGenerateSelectButton="True"
                                                Width="135%" Font-Names="Verdana" Font-Size="Smaller" 
                                                OnSelectedIndexChanging="SelectContacto" 
                                                    onrowdatabound="uxGridView_RowDataBound">
                                                    
                                                    <RowStyle HorizontalAlign="Center" />  
                                                    
                                                    <Columns>
                                            
                                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                        
                                                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                                                        
                                                        <asp:TemplateField HeaderText="Teléfono" AccessibleHeaderText="Telefono">
                                                        <ItemTemplate>
                                                            <asp:Label ID="L1" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.TelefonoDeTrabajo.Codigoarea") %>'></asp:Label>
                                                       
                                                            <asp:Label ID="L2" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.TelefonoDeTrabajo.Numero") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        </asp:TemplateField> 
                                                        
                                                        <asp:TemplateField HeaderText="Cliente" AccessibleHeaderText="Cliente">
                                                        <ItemTemplate>
                                                            <asp:Label ID="L1" runat="server" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.ClienteContac.Nombre") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        </asp:TemplateField> 
                                                        
                                                        
                                                        
                                                    </Columns>
    
                                                 </asp:GridView>
                                                 
                                                 
                                            </td>
                                        </tr>
                                        
                                                                              
                                       
                                        
                                    </table>
                                    
                                </asp:View>
                                
                                 <asp:View ID="ViewContacto" runat="server">
                        
                                    <p class="large">Datos del Contacto</p>  
                            
                                        <table style="width:100%;">
                                            
                                            <tr>
                                                <td><span style="color: #FF0000">* </span><b>Nombre de Contacto:</b></td>
                                                
                                                <td><asp:TextBox ID="uxNombreC" runat="server" Text=""></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr align="center">
                                            <td>&nbsp;</td>
                                                 <td align="center">
                                                    <asp:RequiredFieldValidator ID="uxRequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="uxNombreC" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreContacto%>" Font-Size="Smaller" Display="Static" />
                                                 </td>
                                            </tr>
                                            
                                            
                                            <tr>
                                                <td style="width:100%;"><span style="color: #FF0000">* </span><b>Apellido de Contacto:</b></td>
                                                
                                                <td><asp:TextBox ID="uxApellidoC" runat="server" Text=""></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                 <td align="center">
                                                    <asp:RequiredFieldValidator ID="uxRequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="uxApellidoC" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaApellidoContacto%>" Font-Size="Smaller" Display="Static" />
                                                 </td>
                                            </tr>
                                        
                                          
                                       
                                            <tr>
                                                <td><span style="color: #FF0000">* </span><b>Área de negocio:</b></td>
                                                
                                                <td><asp:TextBox ID="uxArea" runat="server" Text=""></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                                 <td align="center">
                                                    <asp:RequiredFieldValidator ID="uxRequiredFieldValidator5" runat="server" 
                                                        ControlToValidate="uxArea" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaAreaContacto%>" Font-Size="Smaller" Display="Static" />
                                                 </td>
                                            </tr>
                                       
                                         
                                            <tr>
                                                <td><span style="color: #FF0000">* </span><b>Cargo:</b></td>
                                                
                                                <td><asp:TextBox ID="uxCargo" runat="server" Text=""></asp:TextBox></td>
                                            </tr>
                                            
                                             <tr>
                                                <td>&nbsp;</td>
                                                 <td align="center">
                                                    <asp:RequiredFieldValidator ID="uxRequiredFieldValidator6" runat="server" 
                                                        ControlToValidate="uxCargo" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaCargoContacto%>" Font-Size="Smaller" Display="Static" />
                                                 </td>
                                            </tr>
                                            
                                            <tr>
                                                <td><span style="color: #FF0000">* </span><b>Teléfono 1:</b></td>
                                                
                                                <td><asp:TextBox ID="uxCodTelefono1" MaxLength=3 Width="40" runat="server" Text=""></asp:TextBox>
                                                <asp:TextBox ID="uxTelefono1" MaxLength=7 Width="100" runat="server" Text=""></asp:TextBox></td>
                                            </tr>
                                            
                                           <tr>
                                                <td>&nbsp;</td>
                                                 <td align="center">
                                                 
                                                    <asp:RequiredFieldValidator ID="uxRequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="uxCodTelefono1" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaCodigoTelefono%>" Font-Size="Smaller" Display="Static" />
                                                    
                                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxTelefono1" 
                                                        FilterType="Custom, Numbers"
                                                        ValidChars="<%$ Resources:DSU,ERFormatoTelefono%>" ID="FilteredTextBoxExtender3"
                                                        runat="server">
                                                    </AjaxControlToolkit:FilteredTextBoxExtender>
                                                  
                                                    <asp:RequiredFieldValidator ID="uxRequiredFieldValidator8" runat="server" 
                                                        ControlToValidate="uxTelefono1" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaNumTelefono%>" Font-Size="Smaller" Display="Static" />
                                                    
                                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxCodTelefono1" FilterType="Custom, Numbers"
                                                        ValidChars="<%$ Resources:DSU,ERFormatoCodigoTelefono%>" ID="FilteredTextBoxExtender4"
                                                        runat="server">
                                                    </AjaxControlToolkit:FilteredTextBoxExtender>
                                                
                                                 </td>
                                            </tr>
                                            
                                            <tr>
                                                <td><span style="color: #FF0000">* </span><b>Tipo teléfono:</b></td>
                                                <td>
                                                    <asp:DropDownList ID="uxTipoTlf1" runat="server" Width="90%">
                                                        <asp:ListItem Value="Trabajo" Selected="False" runat="server">Trabajo</asp:ListItem>
                                                        <asp:ListItem Value="Celular" Selected="False" runat="server">Celular</asp:ListItem>
                                                        <asp:ListItem Value="Fax" Selected="False" runat="server">Fax</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                
                                                <td><b>&nbsp; Teléfono 2:</b></td>
                                                <td><asp:TextBox ID="uxCodTelefono2" MaxLength=3 Width="40" runat="server" Text=""></asp:TextBox>
                                                <asp:TextBox ID="uxTelefono2" MaxLength=7 Width="100" runat="server" Text=""></asp:TextBox></td>
                   
                                            </tr>
                                            
                                          <tr>
                                                <td>&nbsp;</td>
                                                 <td align="center">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                        ControlToValidate="uxCodTelefono2" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaCodigoTelefono%>" Font-Size="Smaller" Display="Static" />
                                                    
                                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxTelefono2" 
                                                            FilterType="Custom, Numbers"
                                                            ValidChars="<%$ Resources:DSU,ERFormatoTelefono%>" ID="FilteredTextBoxExtender5"
                                                            runat="server">
                                                    </AjaxControlToolkit:FilteredTextBoxExtender>
                                                  
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                        ControlToValidate="uxTelefono2" Visible="false"
                                                        ErrorMessage="<%$ Resources:DSU, FaltaNumTelefono%>" Font-Size="Smaller" Display="Static" />
                                                    
                                                    <AjaxControlToolkit:FilteredTextBoxExtender TargetControlID="uxCodTelefono2" FilterType="Custom, Numbers"
                                                            ValidChars="<%$ Resources:DSU,ERFormatoCodigoTelefono%>" ID="FilteredTextBoxExtender6"
                                                            runat="server">
                                                    </AjaxControlToolkit:FilteredTextBoxExtender>
                                                
                                                 </td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>&nbsp; Tipo teléfono:</b></td>
                                                <td>
                                                    <asp:DropDownList ID="uxTipoTlf2" runat="server" Width="90%">
                                                        <asp:ListItem Value="Trabajo" Selected="False" runat="server">Trabajo</asp:ListItem>
                                                        <asp:ListItem Value="Celular" Selected="False" runat="server">Celular</asp:ListItem>
                                                        <asp:ListItem Value="Fax" Selected="False" runat="server">Fax</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>&nbsp; Cliente:</b></td>
                                                <td><asp:TextBox ID="uxCliente" runat="server" Enabled="false" Text=""></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                
                                            </tr>
                                                <td>&nbsp;</td>
                                              <tr>
                                              
                                                 <td>
                                                    <b>&nbsp; Los campos con </b><span style="color: #FF0000">* </span><b> son obligatorios</b>
                                                 </td>
                                            </tr>
                                            
                                             <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                             
                                                <td align="center"><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                                        onclick="uxBotonAceptar_Click"/></td>
                                                        
                                                <td align="center"><asp:Button ID="uxBotonCancelar" runat="server" Text="Cancelar" 
                                                        onclick="uxBotonCancelar_Click" /></td>
                                            </tr>
                                            
                                            </table>
                                            
                                            
                                    </asp:View>
                                
                            </asp:MultiView>
                                
                                
                                <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                        <uc1:DialogoError ID="uxDialogoError" runat="server" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                            
                            </form>
                     
                        </div> 
                    
                    </div>
                
                </div> 
			
			</div> 
		
		</div> 
		
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaContacto" DataObjectTypeName="Core.LogicaNegocio.Entidades.Contacto" /> 

</asp:Content>
