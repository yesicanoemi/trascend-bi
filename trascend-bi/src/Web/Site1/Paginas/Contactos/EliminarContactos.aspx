<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="EliminarContactos.aspx.cs" Inherits="Paginas_Contactos_EliminarContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Contactos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarContactos.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarContactos.aspx">Consultar<span></span></a></li> 
    <li><a href="EliminarContactos.aspx" class="active">Eliminar<span></span></a></li> 
  <li><a href="ModificarContactos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Eliminar Contacto</h3> 
                    <p class="large">
                        
                        
                    </p> 
                     <asp:MultiView ID="uxMultiViewEliminar" runat="server" ActiveViewIndex="0">
                     <asp:View ID="uxViewBusquedaEliminar" runat="server">
                        <form id="Form3" runat="server">
                               <table style="width:100%;">
                                   <tr>
                                       <td>Nombre: </td>
                                       <td>
                                            <asp:TextBox ID="uxConsultaNombreContacto" runat="server"></asp:TextBox>
                                            <asp:CheckBox ID="uxCheckBoxNombre" runat="server" />
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>&nbsp;</td>
                                       <td>&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>Apellido: </td>
                                       <td>
                                            <asp:TextBox ID="uxConsultaApellidoContacto" runat="server"></asp:TextBox>
                                            <asp:CheckBox ID="uxChecBoxApellido" runat="server" />
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>&nbsp;</td>
                                       <td>&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>Telefono</td>
                                       <td>
                                            <asp:TextBox ID="uxConsultaCodigoContacto" runat="server" Width="40"></asp:TextBox>
                                            <asp:TextBox ID="uxConsultaTelefonoContacto" runat="server" Width="150"></asp:TextBox>
                                           <asp:CheckBox ID="uxCheckBoxTelefono" runat="server" />
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
                                           <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" onclick="Aceptar_Click"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp</td>
                                        <asp:Table ID="uxTablaResultado" runat="server" GridLines="Both"
                                         CellSpacing="30" CellPadding="30" BorderColor="Black" BorderStyle="Solid" 
                                            BorderWidth="1px">
                                        </asp:Table>
                                        <br />
                                    </tr>
                                    <tr>
                                        <td>&nbsp</td>
                                        <td>&nbsp</td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="uxLabelBusqueda" runat="server" Text="Elija su opcion: " Visible= "false"></asp:Label>
                                            <asp:TextBox ID="uxTextBoxOpcion" runat="server" Visible="false"></asp:TextBox>  </td>
                                        <td align= "center"> 
                                            <asp:Button ID="uxBotonBuscar" runat="server" Text="Buscar" OnClick="BuscarClick" Visible="false"/>
                                        </td>
                                    </tr>
                               </table>
                         </form>
                     </asp:View>
                     <asp:View ID="View1" runat="server">
                      <form id="form2" runat="server" >
                      <table style="width:100%;">
                          <tr>
                            <td>
                                Confirmacion:
                            </td>
                            <td>
                               &nbsp
                            </td>
                           </tr>
                           <tr>
                                        Esta seguro que quiere elminar a: 
                                       <asp:Label ID="uxLabelConfirmacion" runat="server" Text=" "></asp:Label> <br />
                                       <asp:Button ID="uxBotonEliminar" runat="server" Text="Eliminar" OnClick="ConfirmarClick" />
                                   </tr>
                        </table>
                      </form>
                     </asp:View>
                     </asp:MultiView>
                 </div> 
              </div>
        </div> 
				
			</div> 
		</div> 
</asp:Content>
