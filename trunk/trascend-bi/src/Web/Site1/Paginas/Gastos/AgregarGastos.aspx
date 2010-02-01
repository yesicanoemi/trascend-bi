<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarGastos.aspx.cs" Inherits="Paginas_Gastos_AgregarGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
function actualizarEstadoDDLGasto(uxCheckProyectoGasto)
{
    var uxddlProyectoGasto = document.getElementById('<%= uxProyectosGasto.ClientID %>');
    
    if(uxCheckProyectoGasto.checked==true)
    {
        uxddlProyectoGasto.disabled=false;
    }
    if(uxCheckProyectoGasto.checked==false)
    {
        uxddlProyectoGasto.disabled=true;
    }

}</script>
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Gastos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarGastos.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarGastos.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarGastos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarGastos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
          
          <div class="features_overview_right"> 
           <h3>Agregar Gastos</h3>
            <p class="large">Introduzca la información a continuación</p> 
            <p class="large">
                <form id="uxFormGasto" runat="server">
                           <table style="width:100%;">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="LabelMensajeError" runat="server" Visible="true" Font-Bold="true" Font-Size="Large"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                           </table>
                           
                           <table  id="uxtabla" runat="server" style="width:100%;">
                               <tr>
                                   <td>Tipo: </td>
                                   <td><asp:DropDownList ID="uxTipoGasto" runat="server" 
                                           onselectedindexchanged="uxTipoGasto_SelectedIndexChanged">
                                       <asp:ListItem Value="0">Seleccionar...</asp:ListItem>
                                       <asp:ListItem>Almuerzo</asp:ListItem>
                                       <asp:ListItem>Cena</asp:ListItem>
                                       <asp:ListItem>Desayuno</asp:ListItem>
                                       <asp:ListItem>Obsequio</asp:ListItem>
                                       <asp:ListItem>Reunion</asp:ListItem>
                                       <asp:ListItem>Otro</asp:ListItem>
                                       </asp:DropDownList></td>
                               </tr>
                               <tr>
                               <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RangeValidator MaximumValue="Reunion" MinimumValue="Almuerzo" Display="Static" ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="<%$Resources:DSU, FaltaTipoGasto %>" ControlToValidate="uxTipoGasto"
                                    Font-Size="Smaller"></asp:RangeValidator>
                             
                                    </td>
                               </tr>
                               <tr>
                                   <td>Fecha del gasto: </td>
                                   <td>
                                       <asp:TextBox ID="uxFechaGasto" runat="server"></asp:TextBox>
                                       <asp:Image ID="uxImagenFechaGasto" runat="server" ImageUrl="~/Images/calendario.png" />
                                            
                                   </td>
                               </tr>
                               <tr>
                                   <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxFechaGast"
                                                Format="dd/MM/yy" TargetControlID="uxFechaGasto" PopupButtonID="uxImagenFechaGasto" >
                                            </AjaxControlToolkit:CalendarExtender></td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxFechaGasto"
                                                ErrorMessage="<%$ Resources:DSU, FaltaFecha%>" Font-Size="Smaller" Display="static" /></td>
                               </tr>
                                <tr>
                                   <td>Monto: </td>
                                   <td><asp:TextBox ID="uxMontoGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxMontoGasto"
                                                ErrorMessage="<%$ Resources:DSU, FaltaMontoGasto%>" Font-Size="Smaller" Display="static" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator3"
                                                runat="server" ErrorMessage="<%$Resources:DSU, ErrorFormatoMontoGasto%>"
                                                ControlToValidate="uxMontoGasto" ValidationExpression="<%$Resources:DSU, ErrorMontoGasto%>"
                                                Font-Size="Smaller">
                                            </asp:RegularExpressionValidator>
                                                </td>
                               </tr>
                                <tr>
                                   <td>Estado del gasto: </td>
                                   <td><asp:DropDownList ID="uxEstadoGasto" runat="server">
                                       <asp:ListItem Value="0">Seleccionar...</asp:ListItem>
                                       <asp:ListItem>Aceptado</asp:ListItem>
                                       <asp:ListItem>Cancelado</asp:ListItem>
                                       <asp:ListItem>Pagado</asp:ListItem>
                                       </asp:DropDownList></td>
                               </tr>
                               <tr>
                               <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RangeValidator MaximumValue="Pagado" MinimumValue="Aceptado" Display="Static" ID="RangeValidator1" runat="server"
                                    ErrorMessage="<%$Resources:DSU, FaltaEstadoGasto %>" ControlToValidate="uxEstadoGasto"
                                    Font-Size="Smaller"></asp:RangeValidator>
                             
                                    </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Descripcion:</td>
                                   <td><asp:TextBox TextMode="MultiLine" ID="uxDescripcionGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxDescripcionGasto"
                                                ErrorMessage="<%$ Resources:DSU, FaltaDescripcionGasto%>" Font-Size="Smaller" Display="static" /></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Asociado a un proyecto:
                                       <asp:CheckBox ID="uxCheckProyectoGasto" runat="server" 
                                           onClick="actualizarEstadoDDLGasto(this);" 
                                           oncheckedchanged="uxCheckProyectoGasto_CheckedChanged1" />
                                            
                                    </td>
                                   <td>
                                    <asp:ListBox ID="uxProyectosGasto" runat="server" Rows="4" SelectionMode="Multiple" ></asp:ListBox>
                                       
                                    </td>
                                </tr>
                                 <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                            onclick="uxBotonAceptar_Click" />
                                           
                                   </td>
                                </tr>
                            </table>
                 </form>
                               </p> 
            
          </div> 
        </div> 
 </div> 
				
			</div> 
		</div> 
</asp:Content>
