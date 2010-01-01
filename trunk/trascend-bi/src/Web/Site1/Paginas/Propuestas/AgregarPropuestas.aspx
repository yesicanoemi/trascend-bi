<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarPropuestas.aspx.cs" Inherits="Paginas_Propuestas_AgregarPropuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Propuestas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarPropuestas.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarPropuestas.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarPropuestas.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarPropuestas.aspx" >Modificar<span></span></a></li>
</ul> 
</div> 
<div class="sub-content"> 
   <div class="features_overview"> 
       <div class="features_overview_right"> 
          <h3>Agregar Propuesta</h3>
            <p class="large">Introduzca la informacón a continuación</p>  
          <p class="large">
            <form id="Form1" action="#" runat="server">
               <table style="width:100%;">
                   <tr>
                       <td>Titulos:</td>
                       <td><asp:TextBox ID="uxTitulo" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Version:</td>
                       <td><asp:TextBox ID="uxVersion" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Fecha de firma:</td>
                       <td>
                           <asp:Calendar ID="uxFechaFirma" runat="server"></asp:Calendar>
                       </td>
                   </tr>
                   
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Nombre del receptor:</td>
                       <td><asp:TextBox ID="uxNombreReceptor" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Apellido del receptor:</td>
                       <td><asp:TextBox ID="uxApellidoReceptor" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Cargo del receptor:</td>
                       <td>
                           <asp:DropDownList ID="uxCargoReceptor" runat="server">
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Fecha de inicio:</td>
                       <td>
                           <asp:Calendar ID="uxFechaInicio" runat="server"></asp:Calendar>
                       </td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Fecha fin:</td>
                       <td>
                          <asp:Calendar ID="uxFechaFin" runat="server"></asp:Calendar>
                       </td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Equipo de trabajo:</td>
                       <td>
                          /*Equipo #2 como prefiere que se ingrese el equipo de trabajo*/
                       </td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>Total horas:</td>
                       <td>
                           <asp:TextBox ID="uxTotalHoras" runat="server"></asp:TextBox>
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
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" /></td>
                                   
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
