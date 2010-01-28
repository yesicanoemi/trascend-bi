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
                                                AutoGenerateColumns="False" DataKeyNames="login" AutoGenerateSelectButton="True"
                                                Width="150%" Font-Names="Verdana" Font-Size="Smaller" 
                                                OnSelectedIndexChanging="SelectContacto" 
                                                    onrowdatabound="uxGridView_RowDataBound">
                                                    
                                                    <RowStyle HorizontalAlign="Center" />  
                                                    
                                                    <Columns>
                                            
                                                        <asp:BoundField HeaderText="Nombre" DataField="Login" />
                                                        <asp:BoundField HeaderText="Apellido" DataField="Nombre" />
                                                        <asp:BoundField HeaderText="Teléfono" DataField="Apellido" />  
                                                        
                                                    </Columns>
    
                                                 </asp:GridView>
                                            </td>
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

