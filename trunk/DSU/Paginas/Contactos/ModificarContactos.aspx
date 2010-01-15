<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Inherits="Paginas_Contactos_ModificarContactos" Codebehind="ModificarContactos.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Contactos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarContactos.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarContactos.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarContactos.aspx"  class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Modificar Contacto</h3> 
                    <p class="large">
                        
                        
                        Busqueda por Nombre</p>
                     <form id="Form3" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>Nombre: </td>
                                   <td><asp:TextBox ID="uxModificarNombreContacto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Apellido: </td>
                                   <td><asp:TextBox ID="uxModificarApellidoContacto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Cedula</td>
                                   <td>
                                       <asp:TextBox ID="uxModificarCedulaContacto" runat="server"></asp:TextBox>
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
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Table ID="uxTablaResultados" runat="server" >
                                        </asp:Table>
                                    </td>
                                </tr>
                           </table>
                     </form>
                     
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>

