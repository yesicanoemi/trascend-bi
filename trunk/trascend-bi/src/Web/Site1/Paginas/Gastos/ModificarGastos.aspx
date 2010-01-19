<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Title="Modificar Gasto" CodeFile="ModificarGastos.aspx.cs" Inherits="Paginas_Gastos_ModificarGastos" %>

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
                   <li><a href="AgregarGastos.aspx">Agregar<span></span></a></li> 
                    <li><a href="ConsultarGastos.aspx">Consultar<span></span></a></li> 
                    <li><a href="EliminarGastos.aspx" >Eliminar<span></span></a></li> 
                    <li><a href="ModificarGastos.aspx" class="active">Modificar<span></span></a></li>
                </ul> 
			</div> 
			<div class="sub-content"> 
                <div class="features_overview"> 
                    <div class="features_overview_right"> 
                        <h3>Modificar Gasto</h3> 
                        <p class="large">Busqueda del Gasto</p>
                         <form id="form1" runat="server">
			                            
                            <asp:MultiView ID="uxModificarMultiView" runat="server" ActiveViewIndex="0">
                            
                            <asp:View ID="ViewConsultaVista1" runat="server">
                            <table>
                                <tr>
		                            <td><asp:Label ID="LabelTipoConsulta" runat="server" Text="Realizar Consulta: " /></td>
		                            <td><asp:DropDownList ID="uxTipoConsulta" runat="server">
		                                    <asp:ListItem>Por Propuesta</asp:ListItem>
		                                    <asp:ListItem>Por tipo de Gasto</asp:ListItem>
		                                    <asp:ListItem>Por Fecha de gasto</asp:ListItem>
		                                </asp:DropDownList></td>
		                            <td>&nbsp;</td>
		                            <td><asp:Button ID="uxBotonBuscar" Text="Buscar" runat="server" 
                                            onclick="uxBotonBuscar_Click" /></td>
		                        </tr>
		                        <tr>
        		                    <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
        		                </tr>
		                        <tr>
		                            <td><asp:Label ID="LabelSeleccion" runat="server" Text="Seleccione: " Enabled="false"/></td>
		                            <td><asp:DropDownList ID="uxSeleccion" runat="server" Enabled="false"></asp:DropDownList></td>
        		                    <td>&nbsp;</td>
		                            <td><asp:Button ID="uxBotonBuscar2" Text="Buscar" runat="server" Enabled="false" 
                                                    onclick="uxBotonBuscar2_Click" /></td>
		                        </tr>
        		                <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                        </tr>
		                        <tr>
		                            <td><asp:Label ID="LabelFechaGasto" Text="Indique Fecha:" runat="server" Enabled="false" /></td>
		                            <td><asp:TextBox ID="uxFechaGasto" runat="server" Enabled="false"></asp:TextBox>
		                                <asp:Image ID="uxImagenFechaGasto" runat="server" ImageUrl="~/Images/calendario.png"/></td>
		                            <td>&nbsp;</td>
		                            <td><asp:Button ID="uxBotonBuscar3" Text="Buscar" runat="server" Enabled="false" 
                                                onclick="uxBotonBuscar3_Click"/></td>		        
		                        </tr>
        		                <tr>
		                            <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxMsjFechaGasto"
                                                        Format="dd/MM/yy" TargetControlID="uxFechaGasto" PopupButtonID="uxImagenFechaGasto" >
                                        </AjaxControlToolkit:CalendarExtender></td>                             
        		                </tr>		                      		                
        		                <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
        		                    <td>&nbsp;</td>
		                        </tr>
		                        <tr>
			                        <td colspan="2">
			                        <asp:GridView ID="uxModificarGasto" runat="server" AllowPaging="True" DataSourceID="uxObjectModificarGasto"
                                                        AutoGenerateColumns="false" DataKeyNames="codigo" AutoGenerateSelectButton="true"
                                                        Width="130%" Font-Names="Verdana" Font-Size="X-Small" onrowdatabound="uxGridView_RowDataBound" 
                                                        OnSelectedIndexChanging="SeleccionarModificarGasto">
                                                
                                                        <Columns>
                                                                <asp:BoundField HeaderText="Codigo" DataField="codigo" />
                                                                <asp:BoundField HeaderText="Estado" DataField="estado" />                                            
                                                                <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                                                                <asp:BoundField HeaderText="Estado" DataField="estado" />
                                                                <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />  
                                                                <asp:BoundField HeaderText="Monto" DataField="monto" />                                                         
                                                                <asp:BoundField HeaderText="Fecha Gasto" DataField="fechaGasto" />
                                                                <asp:BoundField HeaderText="Fecha Ingreso" DataField="fechaIngreso" />
                                                        </Columns>
                                                        
                                                        <EmptyDataTemplate>
                                                                <center>
                                                                    <span>No hay data cargada</span>
                                                                </center>
                                                        </EmptyDataTemplate>                                                 
                                        </asp:GridView>
			                        </td>
			                    </tr>                                
                            </table>
                            </asp:View>
                            
                            <asp:View ID="ViewConsultaVista2" runat="server">        		            
        		            
        		                <table style="width:100%;">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="LabelMensajeError" runat="server" Visible="false" Font-Bold="true" Font-Size="Large"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                           </table>
                           <table style="width:100%;">
                               <tr>
                                   <td>Tipo: </td>
                                   <td><asp:TextBox ID="uxTipoGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxTipoGasto"
                                                ErrorMessage="<%$ Resources:DSU, FaltaTipoGasto%>" Font-Size="Smaller" Display="static" /></td>
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
                                       <asp:TextBox ID="uxFechaGasto2" runat="server"></asp:TextBox>
                                       <asp:Image ID="uxImagenFechaGasto2" runat="server" ImageUrl="~/Images/calendario.png" />
                                            
                                   </td>
                               </tr>
                               <tr>
                                   <td><AjaxControlToolkit:CalendarExtender CssClass="ajax__calendar" Animated="true" runat="server" ID="uxMsjFechaGastos"
                                                Format="dd/MM/yy" TargetControlID="uxFechaGastos" PopupButtonID="uxImagenFechaGastos" >
                                       </AjaxControlToolkit:CalendarExtender></td>
                                   <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxFechaGastos"
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
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Modificar" 
                                            onclick="uxBotonAceptar_Click" />                                           
                                   </td>
                                </tr>
                            </table>
        		            </asp:View>                     
                            </asp:MultiView>
                        </form>                        
                    </div> 
                </div>
            </div> 
        </div>
    </div>	
<pp:objectcontainerdatasource runat="server" ID="uxObjectModificarGasto" DataObjectTypeName="Core.LogicaNegocio.Entidades.Gasto" /> 	 
                         
                    </asp:Content>

