<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarContactos.aspx.cs" Inherits="Paginas_Contactos_AgregarContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Contactos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarContactos.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarContactos.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarContactos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
 
          <div class="features_overview_right"> 
           <h3>Agregar Contactos de Clientes</h3>
            <p class="large">Introduzca la informacón a continuación</p>  
            <p class="large">
                <form id="Form1" action="#" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>Nombre: </td>
                                   <td><asp:TextBox ID="uxNombreContacto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Apellido: </td>
                                   <td><asp:TextBox ID="uxApellidoContacto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Cargo: </td>
                                   <td>
                                       <asp:DropDownList ID="uxCargoContacto" runat="server">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Area de negocio: </td>
                                   <td>
                                       <asp:DropDownList ID="uxAreaNegocio" runat="server">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Telefono de Oficina: </td>
                                   <td><asp:TextBox ID="uxTelfOficina" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Telefono de Celular: </td>
                                   <td><asp:TextBox ID="uxTelfCelular" runat="server"></asp:TextBox></td>
                               </tr>
                                 <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Cliente al que pertenece: </td>
                                   <td>
                                       <asp:DropDownList ID="uxCliente" runat="server">
                                       </asp:DropDownList>
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
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" />
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
