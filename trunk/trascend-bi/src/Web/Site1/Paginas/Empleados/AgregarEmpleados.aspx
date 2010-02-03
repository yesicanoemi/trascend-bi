<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true"
    CodeFile="AgregarEmpleados.aspx.cs" Inherits="Paginas_Empleados_AgregarEmpleados" %>

<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>


<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav">
        <div class="content">
            <div class="sub-heading">
                <h2>
                    Empleados</h2>
            </div>
            <div class="subnav-container">
                <ul id="subnav">
                    <li><a href="AgregarEmpleados.aspx" class="active">Agregar<span></span></a></li>
                    <li><a href="ConsultarEmpleados.aspx">Consultar<span></span></a></li>
                    <li><a href="EliminarEmpleados.aspx">Eliminar<span></span></a></li>
                    <li><a href="ModificarEmpleados.aspx">Modificar<span></span></a></li>
                </ul>
            </div>
            <div class="sub-content">
                <div class="features_overview">
                    <div class="features_overview">
                        <div class="features_overview_right">
                            <h3>
                                Agregar Empleados</h3>
                            
                            <p class="large">
                            <p class="large">Introduzca la Información del Empleado</p>
                            </p>
                           <form id="form1" runat="server">
                            
            <asp:MultiView ID="uxMultiViewPropuesta" runat="server" ActiveViewIndex="0">
                            
                            <asp:View ID="ViewAgregarPropuesta" runat="server">
	                        
	                         
	                        
                              
                              <p class="large">
                              <asp:Label Font-Size="Large" ID="LabelMensajeError" runat="server" Visible="false"></asp:Label>
                                      
                              </p>
	  
          <p class="large">
          
               <table style="width:100%;">
                                <tr>
                                  <td align="center" colspan="2">
                                    
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" 
                                                   Visible="false" />
                                           </ContentTemplate>
                                       </asp:UpdatePanel>
                                       
                                   </td>
                                </tr>
                                <tr>
                                  <td align="center" colspan="2">
                                    
                                   </td>
                                </tr>
                                    <tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Nombre:
                                           
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxNombreEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxNombreEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNombreEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <AjaxControlToolkit:FilteredTextBoxExtender  runat="server" ID="FilteredTextBoxExtender6" TargetControlID="uxNombreEmpleado" FilterType="LowercaseLetters, 
                                            UppercaseLetters"></AjaxControlToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Apellido:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxApellidoEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxApellidoEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaApellidoEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <AjaxControlToolkit:FilteredTextBoxExtender  runat="server" ID="FilteredTextBoxExtender7" TargetControlID="uxApellidoEmpleado" FilterType="LowercaseLetters, 
                                            UppercaseLetters"></AjaxControlToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>C.I.:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxCedulaEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxCedulaEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaCIEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            
                                            <asp:RegularExpressionValidator Display="Static" ID="RegularExpressionValidator1"
                                                runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoNumCedula%>"
                                                ControlToValidate="uxCedulaEmpleado" ValidationExpression="<%$Resources:DSU, ERFormatoNumCedula%>"
                                                Font-Size="Smaller">
                                            </asp:RegularExpressionValidator>
                                               
                                            <AjaxControlToolkit:FilteredTextBoxExtender  runat="server" ID="FilteredTextBoxExtender8" TargetControlID="uxAvenida" FilterType="LowercaseLetters, 
                                            UppercaseLetters,Custom" ValidChars="' '"></AjaxControlToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
<tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Numero de Cuenta:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxNumCuentaEmpleado" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxNumCuentaEmpleado"
                                                ErrorMessage="<%$ Resources:DSU, FaltaNumCuentaEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <asp:RegularExpressionValidator Display="Static" ID="RegularExpressionValidator2"
                                                runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoNumCuentaEmpleado%>"
                                                ControlToValidate="uxNumCuentaEmpleado" ValidationExpression="<%$Resources:DSU, ERNumCuentaEmpleado%>"
                                                Font-Size="Smaller">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Cargo:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="uxCargoEmpleado" AutoPostBack="true" runat="server" OnSelectedIndexChanged="uxCargoEmpleado_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colpsaon="2" style="height:30px">
                                            
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Sueldo Base:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxSueldoBase" Enabled="false" runat="server"></asp:TextBox><br /><asp:Label ID="lbRangoSueldo" Visible="false" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="uxSueldoBase"
                                                ErrorMessage="<%$ Resources:DSU, FaltaSueldoEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <AjaxControlToolkit:FilteredTextBoxExtender  runat="server" ID="FilteredTextBoxExtender9" TargetControlID="uxSueldoBase" FilterType="Numbers"></AjaxControlToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
									<tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Fecha de Nacimiento:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="uxFechaNac" runat="server" TabIndex="63"></asp:TextBox>
                                            <asp:Image ID="uxImgFechaNac" runat="server" ImageUrl="~/Images/calendario.png" />
                                        </td>
                                        <td>
                                            <AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server"
                                                ID="uxceFechaNac" Format="dd/MM/yy" TargetControlID="uxFechaNac" PopupButtonID="uxImgFechaNac">
                                            </AjaxControlToolkit:CalendarExtender>
                                        
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxFechaNac"
                                                ErrorMessage="<%$ Resources:DSU, FaltaFechaNacEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td colspan="2" align="center">
                            <asp:Button ID="uxBotonSiguiente" runat="server" Text="Siguiente" OnClick = "uxBotonSiguiente_Click" />
                       </td>
                   </tr>             
                   
               </table>
                   </br>
                   </br>
                   </br>
                   </br>
                   </br>
                              <asp:UpdatePanel ID="up2" runat="server" >
                              <ContentTemplate>
                                  <uc1:DialogoError ID="uxDialogoError" runat="server"  />
                                  <br />
                              </ContentTemplate>
                            </asp:UpdatePanel> 
                   </br>
                   </br>
                   </br>
                   </asp:View> 
                   
                   
       <asp:View ID="ViewEquipoPropuesta" runat="server">
           
           <p class="large">
               <table style="width:150%;">
               
                                    <tr>
                                        <td colspan="2">
                                            <b>Dirección</b>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2">&nbsp;</td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <span style="color: #FF0000">*</span>Ciudad                                     <td>
                                            <asp:TextBox ID="uxCiudad" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxCiudad"
                                                ErrorMessage="<%$ Resources:DSU, FaltaCiudadEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <AjaxControlToolkit:FilteredTextBoxExtender runat="server" ID="ajFiltered1" TargetControlID="uxCiudad" FilterType="LowercaseLetters, 
                                            UppercaseLetters,Custom" ValidChars="' '"></AjaxControlToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td><span style="color: #FF0000">*</span>Avenida</td>
                                        <td>
                                            <asp:TextBox ID="uxAvenida" runat="server" Enabled=true></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxAvenida"
                                                ErrorMessage="<%$ Resources:DSU, FaltaAvenidaEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td><span style="color: #FF0000">*</span>Calle</td>
                                        <td>
                                            <asp:TextBox ID="uxCalle" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxCalle"
                                                ErrorMessage="<%$ Resources:DSU, FaltaAvenidaEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td><span style="color: #FF0000">*</span>Urbanización</td>
                                        <td>
                                            <asp:TextBox ID="uxUrbanizacion" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxUrbanizacion"
                                                ErrorMessage="<%$ Resources:DSU, FaltaUrbEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            <AjaxControlToolkit:FilteredTextBoxExtender  runat="server" ID="FilteredTextBoxExtender3" TargetControlID="uxUrbanizacion" FilterType="LowercaseLetters, 
                                            UppercaseLetters,Custom" ValidChars="' '"></AjaxControlToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td><span style="color: #FF0000">*</span>Edificio o Casa</td>
                                        <td>
                                            <asp:TextBox ID="uxEdificio" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxEdificio"
                                                ErrorMessage="<%$ Resources:DSU, FaltaAvenidaEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td><span style="color: #FF0000">*</span>Piso o Apartamento</td>
                                        <td>
                                            <asp:TextBox ID="uxPiso" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2" align="left" style="height:30px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxPiso"
                                                ErrorMessage="<%$ Resources:DSU, FaltaAvenidaEmpleado%>" Font-Size="Smaller"
                                                Display="Static" />
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                    <td align="center">
                                       <asp:Button ID="uxBotonAtras" runat="server" Text="Atras" OnClick = "uxBotonAtras_Click" />
                                       
                                    <td align="left">
                                    <table border="3">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" OnClick="uxBotonAceptar_Click"/>
                                        </td>
                                        
                                        <td>
                                        &nbsp;
                                        </td>
                                    </tr>
                                      
                                      </table>
								    </td>
                                   
                                </tr>
                   </table>
                       
          </p>
          </asp:View>
          </asp:MultiView>
           
       </div> 
       <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                            <ContentTemplate>
                                                    <uc1:DialogoError ID="uxDialogoError1" runat="server" />
                                            </ContentTemplate>
                                      </asp:UpdatePanel>
        </div> 
	</div> 
	 
   </div> 
</div>
<pp:objectcontainerdatasource runat="server" ID="uxobjectEmpleado" DataObjectTypeName="Core.LogicaNegocio.Entidades.Persona" /> 
 
    </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
