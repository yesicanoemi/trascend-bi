<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ModificarContactos.aspx.cs" Inherits="Paginas_Contactos_ModificarContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Contactos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarContactos.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarContactos.aspx">Consultar<span></span></a></li> 
    <li><a href="EliminarContactos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarContactos.aspx" class="active">Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
			<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Modificar Contacto</h3> 
                     <p class="large">
                        
                        
                         Busquedas por Cedula</p>
                        <form id="Form3" action="#" runat="server">
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
                                   <td><asp:TextBox ID="uxApellidoContacto" runat="server"></asp:TextBox>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                        </form>
                 </div>
              </div>
        </div>
			</div>
		</div>
    </form>
</asp:Content>
