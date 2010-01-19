<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarClientes.aspx.cs" Inherits="Paginas_Clientes_ConsultarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Clientes</h3> 
                    <p class="large">
                        <form id="Form1" action="#" runat="server">
                        <table>
                            <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Introduzca Tipo de Consulta" /></td>
                                <td><asp:DropDownList ID="opcion1" runat="server" 
                                        onselectedindexchanged="opcion1_SelectedIndexChanged">
                                    <asp:ListItem>Nombre</asp:ListItem>
                                    <asp:ListItem>Area de Negocio</asp:ListItem>                                    
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelSeleccion" runat="server" Text = "Seleccione" Visible = "false" /></td>
                                <td><asp:DropDownList ID="uxSeleccion" runat="server" Visible="false">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelSeleccionAreaCliente" runat="server" Text = "Seleccione" Visible = "false" /></td>
                                <td><asp:DropDownList ID="uxSeleccionAreaCliente" runat="server" Visible="false">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" 
                                        onclick="uxBotonAceptar_Click" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar2" runat="server" Text="Aceptar" Visible="False" 
                                        onclick="uxBotonAceptar2_Click" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="uxBotonAceptar3" runat="server" Text="Aceptar" Visible="False" 
                                        onclick="uxBotonAceptar3_Click" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelRif" runat="server" Text = "Rif" Visible ="False"  /></td>
                                <td><asp:Label ID="LabelRifCliente" runat="server" Visible ="False" /></td>    
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelNombre" runat="server" Text = "Nombre" Visible ="False" /></td>
                                <td><asp:Label ID="LabelNombreCliente" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelCalleAvenida" runat="server" Text = "Calle/Avenida" Visible ="False" /></td>
                                <td><asp:Label ID="LabelCalleAvenidaCliente" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelUrbanizacion" runat="server" Text = "Urbanizacion" Visible ="False" /></td>
                                <td><asp:Label ID="LabelUrbanizacionCliente" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelEdificioCasa" runat="server" Text = "Edificio/Casa" Visible ="False" /></td>
                                <td><asp:Label ID="LabelEdificioCasaCliente" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelPisoApartamento" runat="server" Text = "Piso/Apartamento" Visible ="False" /></td>
                                <td><asp:Label ID="LabelPisoApartamentoCliente" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelCiudad" runat="server" Text = "Ciudad" Visible ="False" /></td>
                                <td><asp:Label ID="LabelCiudadCliente" runat="server" Visible ="False" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelTelefono" runat="server" Text = "Telefono" Visible ="False" /></td>
                                <td><asp:Label ID="LabelCodTeleClien" runat="server" Width="40" Visible ="False" /> <asp:Label ID="LabelTelefonoTrabajoCliente" runat="server" Width="150" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelAreaNegocio" runat="server" Text = "Area de Negocio" Visible ="False" /></td>
                                <td><asp:Label ID="LabelAreaNegocioCliente" runat="server" Visible ="False" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelContacto" runat="server" Text = "Contacto" Visible ="False" /></td>
                                <td><asp:Listbox ID="ListContactoCliente" runat="server" Visible ="False" /></td>
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

