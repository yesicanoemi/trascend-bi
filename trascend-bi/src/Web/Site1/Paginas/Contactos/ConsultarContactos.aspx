﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarContactos.aspx.cs" Inherits="Paginas_Contactos_ConsultarContactos" %>
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
                  <li><a href="ConsultarContactos.aspx" class="active">Consultar<span></span></a></li> 
                    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
                  <li><a href="ModificarContactos.aspx" >Modificar<span></span></a></li>
                </ul> 
						
			</div> 
				
		    <div class="sub-content"> 
                
                   <div class="features_overview"> 
                        
                        <div class="features_overview_right"> 
                            
                            <h3>Consultar Contacto</h3> 
                            
                                <form id="Form3" action="#" runat="server">
                                
                                <asp:MultiView ID="uxMultiViewConsultar" runat="server" ActiveViewIndex="0">
                          
                                <asp:View ID="ViewConsulta" runat="server">
                                
                                  <p>Introduzca los campos según su tipo de búsqueda</p> 
                                    
                                    <br />
                                    
                                    <table width="100%">
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
                                                <td><b>Nombre de Contacto:</b></td>
                                                <td><asp:Label ID="uxNombreC" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                       
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                       
                                            <tr>
                                                <td><b>Apellido de Contacto:</b></td>
                                                <td><asp:Label ID="uxApellidoC" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                       
                                            <tr>
                                                <td><b>Área de negocio:</b></td>
                                                <td><asp:Label ID="uxArea" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                       
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        
                                            <tr>
                                                <td><b>Cargo:</b></td>
                                                <td><asp:Label ID="uxCargo" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                             <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>Teléfono 1:</b></td>
                                                <td><asp:Label ID="uxTelefono1" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>Tipo teléfono:</b></td>
                                                <td><asp:Label ID="uxTipoTlf1" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>Teléfono 2:</b></td>
                                                <td><asp:Label ID="uxTelefono2" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>Tipo teléfono:</b></td>
                                                <td><asp:Label ID="uxTipoTlf2" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>Cliente:</b></td>
                                                <td><asp:Label ID="uxCliente" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                             
                                                <td align="center"><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                                        onclick="uxBotonAceptar_Click" /></td>
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
