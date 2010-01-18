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
            <p class="large">Introduzca la informacón a continuación</p> 
            <p class="large">
                <form id="uxFormGasto" runat="server">
                           <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelMensajeError" runat="server" Visible="false"/>
                                    </td>
                                </tr>
                           </table>
                           <table style="width:100%;">
                               <tr>
                                   <td>Tipo: </td>
                                   <td><asp:TextBox ID="uxTipoGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               
                                <tr>
                                   <td>Descripcion: </td>
                                   <td><asp:TextBox ID="uxDescripcionGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxDescripcionGasto"
                                                ErrorMessage="<%$ Resources:DSU, FaltaDescripcionGasto%>" Font-Size="Smaller" Display="static" /></td>
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
                                                ErrorMessage="<%$ Resources:DSU, FaltaMontoGasto%>" Font-Size="Smaller" Display="static" /></td>
                               </tr>
                                <tr>
                                   <td>Estado del gasto: </td>
                                   <td><asp:TextBox ID="uxEstadoGasto" runat="server"></asp:TextBox></td>
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
                                       <asp:DropDownList ID="uxProyectosGasto" runat="server" Enabled="false" 
                                           onselectedindexchanged="uxProyectosGasto_SelectedIndexChanged">
                                       </asp:DropDownList>
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
