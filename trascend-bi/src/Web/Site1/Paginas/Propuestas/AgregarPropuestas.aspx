﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarPropuestas.aspx.cs" Inherits="Paginas_Propuestas_AgregarPropuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
   
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Propuestas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarPropuestas.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarPropuestas.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarPropuestas.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarPropuestas.aspx" >Modificar<span></span></a></li>
</ul> 
</div> 
<div class="sub-content"> 
   <div class="features_overview"> 
       <div class="features_overview_right"> 
          <h3>Agregar Propuesta</h3>
          
    <form id="form1" runat="server">
    <asp:MultiView ID="uxMultiViewPropuesta" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewAgregarPropuesta" runat="server">
      <p class="large">Introduzca la información a continuación</p>  
          <p class="large">
          
               <table style="width:100%;">
                   <tr>
                       <td> Titulo:</td>
                       <td><asp:TextBox ID="uxTitulo" runat="server"></asp:TextBox>
                       <span style="color: #FF0000">(*)</span></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="uxTitulo" 
                                ErrorMessage="<%$ Resources:DSU, FaltaTituloPropuesta%>" Font-Size="Smaller" Display="Static" />
                       </td>
                   </tr>
                   <tr>
                       <td>Version:</td>
                       <td><asp:TextBox ID="uxVersion" runat="server"></asp:TextBox>
                       <span style="color: #FF0000">(*)</span></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="uxVersion" 
                                ErrorMessage="<%$ Resources:DSU, FaltaVersionPropuesta%>" Font-Size="Smaller" Display="Static" />
                       <asp:RegularExpressionValidator Display="Static" ID="RegularExpressionValidator2"
                                                runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoVersion%>"
                                                ControlToValidate="uxVersion" ValidationExpression="<%$Resources:DSU, ERVersion%>"
                                                Font-Size="Smaller">
                                            </asp:RegularExpressionValidator>
                       </td>
                   </tr>
                   <tr>
                  
                       <td>Fecha de firma:</td>
                       <td>
                           <asp:TextBox ID="uxFechaFirma" runat="server"></asp:TextBox>
                           <asp:Image ID="uxImagenFechaFirma" runat="server" ImageUrl="~/Images/calendario.png" />            
                       </td>
                      
                   </tr>
                   
                   <tr>
                       <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uuxFechaFir"
                                                Format="dd/MM/yy" TargetControlID="uxFechaFirma" PopupButtonID="uxImagenFechaFirma" >
                                            </AjaxControlToolkit:CalendarExtender></td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Nombre del receptor:</td>
                       <td><asp:TextBox ID="uxNombreReceptor" runat="server"></asp:TextBox>
                       <span style="color: #FF0000">(*)</span></td>
                   </tr>
                   <tr>
                       <td> &nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="uxNombreReceptor" 
                                ErrorMessage="<%$ Resources:DSU, FaltaNombreReceptorPropuesta%>" Font-Size="Smaller" Display="Static" />
                       </td>
                   </tr>
                   <tr>
                       <td>Apellido del receptor:</td>
                       <td><asp:TextBox ID="uxApellidoReceptor" runat="server"></asp:TextBox>
                       <span style="color: #FF0000">(*)</span></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="uxApellidoReceptor" 
                                ErrorMessage="<%$ Resources:DSU, FaltaApellidoReceptorPropuesta%>" Font-Size="Smaller" Display="Static" />
                       </td>
                   </tr>
                   <tr>
            
                       <td>Cargo del receptor:</td>
                       <td>
                           <asp:DropDownList ID="uxCargoReceptor" runat="server"  >
                                       </asp:DropDownList>
                                       <span style="color: #FF0000">(*)</span>
                       </td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                   <td>&nbsp;</td>
                   <td>
                   <asp:Button ID="uxBotonSiguiente" runat="server" Text="Siguiente" OnClick = "uxBotonSiguiente_Click" /></td>
                   </tr>             
                   
                   </table>
                   </p>
                   </asp:View>
       <asp:View ID="ViewEquipoPropuesta" runat="server">
           <p class="large">Introduzca la informacion del equipo</p>  
           <p class="large">
               <table style="width:150%;">
               
                   <tr>
                       <td>Fecha de inicio:</td>
                       <td>
                           <asp:TextBox ID="uxFechaInicio" runat="server"></asp:TextBox>
                            <asp:Image ID="uxImagenFechaInicio" runat="server" ImageUrl="~/Images/calendario.png" />
                            <span style="color: #FF0000">(*)</span>
                       </td>
                   </tr>
                   <tr>
                       <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxFechaIni"
                                                Format="dd/MM/yy" TargetControlID="uxFechaInicio" PopupButtonID="uxImagenFechaInicio" >
                                            </AjaxControlToolkit:CalendarExtender></td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="uxFechaInicio" 
                                ErrorMessage="<%$ Resources:DSU, FaltaFechaInicioPropuesta%>" Font-Size="Smaller" Display="Static" />
                       </td>
                   </tr>
                   <tr>
                       <td>Fecha fin:</td>
                       <td>
                           <asp:TextBox ID="uxFechaFin" runat="server"></asp:TextBox>
                           <asp:Image ID="uxImagenFechaFin" runat="server" ImageUrl="~/Images/calendario.png" />
                            <span style="color: #FF0000">(*)</span>
                       </td>
                   </tr>
                   <tr>
                       <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxFechaF"
                                                Format="dd/MM/yy" TargetControlID="uxFechaFin" PopupButtonID="uxImagenFechaFin" >
                                            </AjaxControlToolkit:CalendarExtender></td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="uxFechaFin" 
                                ErrorMessage="<%$ Resources:DSU, FaltaFechaFinPropuesta%>" Font-Size="Smaller" Display="Static" />
                       </td>
                   </tr>
                   
                   <tr>
                       <td>Rol</td>
                       <td><asp:TextBox ID="Rol1" runat="server"></asp:TextBox>
                       <span style="color: #FF0000">(*)</span></td>
                       </tr>
                        <tr>
                       <td></td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="Rol1" 
                                ErrorMessage="<%$ Resources:DSU, FaltaRolEquipo1%>" Font-Size="Smaller" Display="Static" /></td>
                       </tr>
                        <tr>
                       <td>Equipo de trabajo:</td>
                       <td><span style="color: #FF0000">(*)</span>
                       <asp:CheckBoxList id="uxEquipo" Width="400px" runat="server"/>
                       </td>
                       </tr>
                        <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                       </tr>
                       
                   <tr>
                       <td>Total horas:</td>
                       <td>
                           <asp:TextBox ID="uxTotalHoras" runat="server"></asp:TextBox>
                           <span style="color: #FF0000">(*)</span>
                       </td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="uxTotalHoras" 
                                ErrorMessage="<%$ Resources:DSU, FaltaTotalHorasPropuesta%>" Font-Size="Smaller" Display="Static" />
                               
                       </td>
                   </tr>
                   
                    <tr>
                    <td>Monto Total:</td>
                     <td>
                           <asp:TextBox ID="uxMontoTotal" runat="server"></asp:TextBox>
                           <span style="color: #FF0000">(*)</span>
                       </td>
                      
                   </tr>
                   <tr>
                   <td>&nbsp;</td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="uxMontoTotal" 
                                ErrorMessage="<%$ Resources:DSU, FaltaMontoPropuesta%>" Font-Size="Smaller" Display="Static" />
                                <asp:RegularExpressionValidator Display="Static" ID="RegularExpressionValidator1"
                                                runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoMonto%>"
                                                ControlToValidate="uxMontoTotal" ValidationExpression="<%$Resources:DSU, ERMonto%>"
                                                Font-Size="Smaller">
                                            </asp:RegularExpressionValidator>
                       </td>
                   </tr>
                    <tr>
                       <td></td>
                       <td></td>
                       </tr>
                        <tr>
                       <td></td>
                       <td></td>
                       </tr>
                   <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>
                                       <asp:Button ID="uxBotonAtras" runat="server" Text="Atras" OnClick = "uxBotonAtras_Click" /></td>
                                   <td>
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" OnClick = "uxBotonAceptar_Click" /></td>
                                   
                                </tr>
                   </table>
                          
          </p>
          </asp:View>
          </asp:MultiView>
           
       </div> 
        </div> 
	</div> 
   </div> 
</div>
<pp:objectcontainerdatasource runat="server" ID="uxobjectEmpleado" DataObjectTypeName="Core.LogicaNegocio.Entidades.Persona" /> 
 
    </form>
 
</asp:Content>