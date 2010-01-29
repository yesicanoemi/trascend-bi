<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarContactos.aspx.cs" Inherits="Paginas_Contactos_ConsultarContactos" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

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
                                                    <asp:ListItem Value="1" Text="Nombre/Apellido de Contacto"></asp:ListItem> 
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
                                                            <asp:TextBox ID="uxConsultaCodigoContacto" MaxLength=4 runat="server" Visible="false" Width="40">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="uxConsultaApellidoContacto" runat="server" Visible="false">
                                                            </asp:TextBox>
                                                            
                                                            <asp:TextBox ID="uxConsultaTelefonoContacto" runat="server" Visible="false">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </table>
                                                
                                                <asp:DropDownList ID="uxConsultaClienteContacto" runat="server" Visible="false" 
                                                    DataTextField="IdContacto" DataValueField="IdContacto" AutoPostBack="false">
                                                </asp:DropDownList>
                                                
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
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
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
                                                <td><b>Teléfono:</b></td>
                                                <td><asp:Label ID="uxTelefono" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td><b>Tipo teléfono:</b></td>
                                                <td><asp:Label ID="uxTipoTlf" runat="server" Text=""></asp:Label></td>
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

