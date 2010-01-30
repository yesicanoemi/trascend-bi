<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarClientes.aspx.cs" Inherits="Paginas_Clientes_AgregarClientes" %>

<%@ Register Src="../../ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
                  <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
          <div class="features_overview_right"> 
            <h3>Agregar Clientes</h3>
            <p class="large">Introduzca la informacón a continuación</p> 
            <p class="large">
                           <table style="width:100%;">
                               <tr>
                                   <td><span style="color: #FF0000">* </span>RIF:</td>
                                   <td>
                                       <asp:DropDownList ID="DropDownList_uxRif" runat="server" Width="40px">
                                           <asp:ListItem Value="0">--</asp:ListItem>
                                           <asp:ListItem Value="J">J</asp:ListItem>
                                           <asp:ListItem Value="G">G</asp:ListItem>
                                           <asp:ListItem Value="V">V</asp:ListItem>
                                           <asp:ListItem Value="E">E</asp:ListItem>
                                       </asp:DropDownList>
                                       &nbsp;&nbsp; -<asp:TextBox ID="uxRif" runat="server" MaxLength="9" Width="87px"></asp:TextBox>&nbsp;<span style="color: #FF0000"> </span><AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxRif" >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxRif"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" />
                                                
                                   </td>
                               </tr>
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Nombre:</td>
                                   <td><asp:TextBox ID="uxNombreCliente" runat="server" MaxLength="32"></asp:TextBox>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxNombreCliente"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" /></td>
                               </tr>
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Calle/Avenida</td>
                                   <td><asp:TextBox ID="uxAvenidaCalle" runat="server" MaxLength="32"></asp:TextBox>&nbsp;
                                       <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxAvenidaCalle"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" />
                                   </td>
                               </tr></td>
                               </tr>
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Urbanización</td>
                                   <td><asp:TextBox ID="uxUrbanizacion" runat="server" MaxLength="32"></asp:TextBox>&nbsp;
                                       </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxUrbanizacion"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" />
                                  </td>
                               </tr>
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Edificio/Casa</td>
                                   <td><asp:TextBox ID="uxEdificioCasa" runat="server" MaxLength="32"></asp:TextBox>&nbsp;
                                       </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxEdificioCasa"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" />
                                   </td>
                               </tr>
                                <tr>
                                   <td><span style="color: #FF0000">* </span>Piso/Apartamento</td>
                                   <td><asp:TextBox ID="uxPisoApartamento" runat="server" MaxLength="20"></asp:TextBox>&nbsp;
                                       </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxPisoApartamento"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" /></td>
                               </tr>
                                 <tr>
                                   <td><span style="color: #FF0000">* </span>Ciudad:</td>
                                   <td><asp:TextBox ID="uxciudad" runat="server" MaxLength="32"></asp:TextBox>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxciudad"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" /></td>
                               </tr>
                <tr>
                                   <td><span style="color: #FF0000">* </span>Área de Negocio:</td>
                                   <td><asp:TextBox ID="uxAreaNegocioCliente" runat="server" MaxLength="35"></asp:TextBox>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxAreaNegocioCliente"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Static" /></td>
                               </tr>
                               
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Teléfono Trabajo:</td>
                                   <td><asp:TextBox ID="uxCodTrabajo" runat="server" Width="50px" MaxLength="10"></asp:TextBox>
                                       
                                       <span style="color: #FF0000"> <AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxCodTrabajo" ValidChars='+ ()' >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                           ControlToValidate="uxCodTrabajo" Display="None" 
                                           ErrorMessage="<%$Resources:DSU, ErrorFormatoCodTelefono %>" 
                                           ValidationExpression="<%$Resources:DSU, ERTelefono%>"></asp:RegularExpressionValidator>
                                       <AjaxControlToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender88" 
                                           runat="Server" TargetControlID="RegularExpressionValidator3" >
                                       </AjaxControlToolkit:ValidatorCalloutExtender>
                                       </span>
                                        <asp:TextBox ID="uxTelefonoTrabajo" runat="server" Width="90px" MaxLength="7" ></asp:TextBox>
                                       
                                       <span style="color: #FF0000">&nbsp; 
                                       <AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender7" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxTelefonoTrabajo" >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                       </span>
                                                         </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxAreaNegocioCliente"
                                                ErrorMessage="<%$ Resources:DSU, LLenarCampo%>" Font-Size="Smaller"
                                                Display="Dynamic" /></td>
                               </tr>
                               
                               
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Celular:</td>
                                   <td><asp:TextBox ID="uxCodCelular" runat="server" Width="50px" MaxLength="3"></asp:TextBox>
                                       
                                                         <AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender8" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxCodCelular" >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                       
                                       <span style="color: #FF0000"> 
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                           ControlToValidate="uxCodCelular" Display="None" 
                                           ErrorMessage="<%$Resources:DSU, ErrorFormatoCodTelefono %>" 
                                           ValidationExpression="<%$Resources:DSU, ERTelefono%>"></asp:RegularExpressionValidator>
                                       <AjaxControlToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender89" 
                                           runat="Server" TargetControlID="RegularExpressionValidator4" >
                                       </AjaxControlToolkit:ValidatorCalloutExtender>
                                        <asp:TextBox ID="uxTelefonoCelular" runat="server" Width="90px" MaxLength="7"></asp:TextBox>
                                       
                                       </span>
                                       <AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender9" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxTelefonoCelular" >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                       
                                                         </td>
                               </tr>
                                                    
                               
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                                    
                               
                               <tr>
                                   <td><span style="color: #FF0000">* </span>Fax:</td>
                                   <td><asp:TextBox ID="uxCodFax" runat="server" Width="50px" MaxLength="3"></asp:TextBox>
                                       
                                                         <AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender10" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxCodFax" >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                       
                                       <span style="color: #FF0000"> 
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                           ControlToValidate="uxCodFax" Display="None" 
                                           ErrorMessage="<%$Resources:DSU, ErrorFormatoCodTelefono %>" 
                                           ValidationExpression="<%$Resources:DSU, ERTelefono%>"></asp:RegularExpressionValidator>
                                       <AjaxControlToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender90" 
                                           runat="Server" TargetControlID="RegularExpressionValidator5" >
                                       </AjaxControlToolkit:ValidatorCalloutExtender>
                                        <asp:TextBox ID="uxTelefonoFax" runat="server" Width="90px" MaxLength="7"></asp:TextBox>
                                       
                                       </span>
                                       <AjaxControlToolkit:FilteredTextBoxExtender 
                                           ID="FilteredTextBoxExtender11" runat="server" FilterType="Custom, Numbers" 
                                           TargetControlID="uxTelefonoFax" >
                                       </AjaxControlToolkit:FilteredTextBoxExtender>
                                       
                                                         </td>
                               </tr>
                                                    
                               <tr>
                                   <td>&nbsp;</td>
                                   <td style="color: #FF0000">(*) Campos obligatorios</td>
                               </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>         &nbsp;</td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>
                                       <table style="width: 100%">
                                           <tr>
                                               <td>
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                           onclick="uxBotonAceptar_Click" />
                                               </td>
                                           </tr>
                                       </table>
                                    </td>
                                </tr>
                           </table>
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
                      <br />
                      <br />
                      <br />
                      <br />
                      <br />
                      <br />
                      <br />
                      <br />
                      <asp:UpdatePanel ID="up2" runat="server" >
                          <ContentTemplate>
                              <uc1:DialogoError ID="uxDialogoError" runat="server"  />
                          </ContentTemplate>
                      </asp:UpdatePanel>
        </div> 
 
        
 
 
        
				
								</div> 
				
			</div> 
		</div> 
                    </form>
            </asp:Content>
