<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarPropuestas.aspx.cs" Inherits="Paginas_Propuestas_ConsultarPropuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Propuestas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarPropuestas.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarPropuestas.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarPropuestas.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarPropuestas.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
		<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Propuesta</h3> 
                    <p class="large">
                    <form id="Form1" action="#" runat="server">
                        <table>
                            <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Introduzca Tipo de Consulta" /></td>
                                <td><asp:DropDownList ID="opcion1" runat="server" 
                                        onselectedindexchanged="opcion1_SelectedIndexChanged">
                                    <asp:ListItem>Propuesta Version En Espera</asp:ListItem>
                                    <asp:ListItem>Propuesta Version Aprobada</asp:ListItem>
                                    <asp:ListItem>Propuesta Version Rechazada</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelSeleccion" runat="server" Text = "Seleccione" Visible = "false" /></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelParametro" runat="server" Text = "Introduzca Parametro" Visible = "false"  /></td>
                                <td><asp:DropDownList ID="uxSeleccion" runat="server" Visible="false">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar2" runat="server" Text="Aceptar" Visible="False" 
                                        onclick="uxBotonAceptar2_Click" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelTitulo" runat="server" Text = "Titulo" Visible ="False"  /></td>
                                <td><asp:Label ID="LabelTituloPropuesta" runat="server" Visible ="False" /></td>    
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelVersion" runat="server" Text = "Version" Visible ="False" /></td>
                                <td><asp:Label ID="LabelVersionPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelFechaFirma" runat="server" Text = "Fecha de la Firma" Visible ="False" /></td>
                                <td><asp:Label ID="LabelFechaFirmaPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelReceptor" runat="server" Text = "Nombre del Receptor" Visible ="False" /></td>
                                <td><asp:Label ID="LabelReceptorPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelCargo" runat="server" Text = "Cargo" Visible ="False" /></td>
                                <td><asp:Label ID="LabelCargoPropuesta" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelFechaIn" runat="server" Text = "Fecha Inicio" Visible ="False" /></td>
                                <td><asp:Label ID="LabelFechaInP" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelFechaFin" runat="server" Text = "Fecha Fin" Visible ="False" /></td>
                                <td><asp:Label ID="LabelFechaFinP" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelTotalH" runat="server" Text = "Total Horas" Visible ="False" /></td>
                                <td><asp:Label ID="LabelTotalHP" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelMonto" runat="server" Text = "Monto" Visible ="False" /></td>
                                <td><asp:Label ID="LabelMontoP" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelEquipo" runat="server" Text = "Equipo de Trabajo" Visible ="False" /></td>
                                <td><asp:Listbox ID="ListEquipoP" runat="server" Visible ="False" /></td>
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

