<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Inherits="Paginas_Contactos_ConsultarContactos" Codebehind="ConsultarContactos.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Contactos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarContactos.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarContactos.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarContactos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Contacto</h3> 
                    <p class="large">
                        
                        
                        Busqueda por Nombre</p>
                     <form id="Form3" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>Nombre: </td>
                                   <td><asp:TextBox ID="uxConsultaNombreContacto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Apellido: </td>
                                   <td><asp:TextBox ID="uxConsultaApellidoContacto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Cedula</td>
                                   <td>
                                       <asp:TextBox ID="uxConsultaCedulaContacto" runat="server"></asp:TextBox>
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
                           </table>
                     </form>
                     
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>

