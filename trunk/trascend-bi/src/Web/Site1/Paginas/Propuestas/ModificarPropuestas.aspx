<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarPropuestas.aspx.cs" Inherits="Paginas_Propuestas_ModificarPropuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Propuestas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarPropuestas.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarPropuestas.aspx">Consultar<span></span></a></li> 
    <li><a href="EliminarPropuestas.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarPropuestas.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Modificar Propuesta</h3> 
                    <p class="large">
                         <form id="Form1" action="#" runat="server">
                        <table>
                            <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Buscar por:" /></td>
                                <td><asp:DropDownList ID="opcion1" runat="server" 
                                        onselectedindexchanged="opcion1_SelectedIndexChanged">
                                    <asp:ListItem>Propuesta En Espera</asp:ListItem>                                    
                                  
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelSeleccion" runat="server" Text = "Seleccione" Visible = "false" /></td>
                                <td><asp:DropDownList ID="uxSeleccion" runat="server" Visible="false">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" /></td>
                            </tr>
                            <tr>
                                <td>Indique Parámetro de busqueda</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar2" runat="server" Text="Aceptar" Visible="False" 
                                        onclick="uxBotonAceptar2_Click" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelTitulo" runat="server" Text = "Titulo" Visible ="False"  /></td>
                                <td><asp:TextBox ID="TextBoxTituloPropuesta" runat="server" Visible ="False" /></td>    
                            </tr>  
                            <tr>
                                <td><asp:Label ID="LabelVersion" runat="server" Text = "Version" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxVersionPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelFechaFirma" runat="server" Text = "Fecha de la Firma" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxFechaFirmaPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelReceptor" runat="server" Text = "Nombre del Receptor" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxReceptorPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelCargo" runat="server" Text = "Cargo" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxCargoPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelFechaIn" runat="server" Text = "Fecha Inicio" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxFechaInP" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelFechaFin" runat="server" Text = "Fecha Fin" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxFechaFinP" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelTotalH" runat="server" Text = "Total Horas" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxTotalHP" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelMonto" runat="server" Text = "Monto" Visible ="False" /></td>
                                <td><asp:TextBox ID="TextBoxMontoP" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelEquipo" runat="server" Text = "Equipo de Trabajo" Visible ="False" /></td>
                                <td><asp:Listbox ID="ListEquipoP" runat="server" Visible ="False" /></td>
                            </tr>
                              <tr>
                                <td>&nbsp;</td>
                                 <td><asp:Button ID="BotonModificar" runat="server" Text="Aceptar" Visible = "false"
                                        onclick="BotonModificar_Click" /></td>
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
