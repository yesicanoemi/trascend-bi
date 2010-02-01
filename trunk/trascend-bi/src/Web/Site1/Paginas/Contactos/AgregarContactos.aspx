<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarContactos.aspx.cs" Inherits="Paginas_Contactos_AgregarContactos" %>
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
  <li><a href="AgregarContactos.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarContactos.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarContactos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
 
          <div class="features_overview_right"> 
           <h3>Agregar Contactos de Clientes</h3>
            <p class="large">Introduzca la informacón a continuación</p>  
            <p class="large"> </p>
         
                <form id="Form1" runat="server">
                           
                           <asp:Label ID="Label1" 
                                           style="left:593px; POSITION: absolute; TOP: 149px; color:Red" 
                               runat="server">
                                        <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false"/>
                                     </asp:Label>
                           
                           <table style="width:100%;">
                               <tr>
                                   <td>Nombre: </td>
                                   <td>
                                        <asp:TextBox ID="uxNombreContacto" runat="server"></asp:TextBox>
                                         <br />
                                         <asp:RequiredFieldValidator ID="uxValidatorNombre" runat="server" 
                                        ControlToValidate="uxNombreContacto" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreContacto%>" Font-Size="Smaller" Display="Static" />
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Apellido: </td>
                                   <td>
                                        <asp:TextBox ID="uxApellidoContacto" runat="server"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="uxValidatorApellido" runat="server" 
                                        ControlToValidate="uxApellidoContacto" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaApellidoContacto%>" Font-Size="Smaller" Display="Static" />
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Cargo: </td>
                                   <td>
                                       <asp:TextBox ID="uxCargoContacto" runat="server">
                                       </asp:TextBox>
                                       <br />
                                        <asp:RequiredFieldValidator ID="uxValidatorCargo" runat="server" 
                                        ControlToValidate="uxCargoContacto" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaCargoContacto%>" Font-Size="Smaller" Display="Static" />
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Area de negocio: </td>
                                   <td>
                                       <asp:TextBox ID="uxAreaNegocio" runat="server">
                                       </asp:TextBox>
                                        <br />
                                       <asp:RequiredFieldValidator ID="uxValidatorArea" runat="server" 
                                        ControlToValidate="uxAreaNegocio" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaAreaContacto%>" Font-Size="Smaller" Display="Static" />
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Telefono de Oficina: </td>
                                   <td>
                                        <asp:TextBox ID="uxCodOficina" runat="server" Width="40"></asp:TextBox>
                                        <asp:TextBox ID="uxTelfOficina" runat="server" Width="150"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="uxValidatorCodOficina" runat="server" 
                                        ControlToValidate="uxCodOficina" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaCodTelefono%>" Font-Size="Smaller" Display="Static" />
                                        
                                        <asp:RequiredFieldValidator ID="uxValidatorTelfOficina" runat="server" 
                                        ControlToValidate="uxTelfOficina" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNumTelefono%>" Font-Size="Smaller" Display="Static" />
                                   </td>
                               </tr>
                               <tr>
                                   <td></td>
                                   <td>
                                       <br />
                                                         </td>
                               </tr>
                               <tr>
                                   <td>Telefono de Celular: </td>
                                   <td>
                                        <asp:TextBox ID="uxCodCel" runat="server" Width="40"></asp:TextBox>
                                        <asp:TextBox ID="uxTelfCelular" runat="server" Width="150"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="uxValidatorCodCel" runat="server" 
                                        ControlToValidate="uxCodCel" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaCodTelefono%>" Font-Size="Smaller" Display="Static" />
                                        
                                        <asp:RequiredFieldValidator ID="uxValidatorNumTelf" runat="server" 
                                        ControlToValidate="uxTelfCelular" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNumTelefono%>" Font-Size="Smaller" Display="Static" />
                                   </td>
                               </tr>
                               <tr>
                                   <td> Cliente: 
                                       
                                   </td>
                                   <td>
                                        
                                       <br />
                                        
                                       <asp:TextBox ID="uxValor" runat="server" ontextchanged="uxValor_TextChanged" Visible="true"> </asp:TextBox>
                                       
                                       <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                 TargetControlID="uxValor"
                                                 CompletionSetCount="20"
                                                 MinimumPrefixLength="1" 
                                                 ServiceMethod="GetSuggestionsClienteNombre"
                                                 DelimiterCharacters="; ,"
                                                 ServicePath="../../SuggestionNames.asmx">
                                              </AjaxControlToolkit:AutoCompleteExtender>
                                              
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxValor" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreCliente%>" Font-Size="Smaller" Display="Static" />
                                              
                                                
                                       
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" />
                                    </td>
                                </tr>
                           </table>
                           
                            <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                        <uc1:DialogoError ID="uxDialogoError" runat="server" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                           
                    </form>
            
            
    <!--        </p> -->
            
          </div> 
        </div> 
       </div> 
				
			</div> 
		</div> 
</asp:Content>
