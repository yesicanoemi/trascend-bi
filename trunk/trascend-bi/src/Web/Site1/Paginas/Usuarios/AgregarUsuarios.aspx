<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarUsuarios.aspx.cs" Inherits="Paginas_Usuarios_AgregarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<!-- 

<asp:MultiView ID="uxMultiViewAgregar" runat="server" ActiveViewIndex="-1">

</asp:MultiView> 

-->

<form id="form1" runat="server">
<div class="container subnav"> 
<div class="content"> 
<div class="sub-heading"> 
<h2>Usuarios</h2> 
</div> 
<div class="subnav-container"> 

<ul id="subnav"> 
<li><a href="AgregarUsuarios.aspx" class="active">Agregar<span></span></a></li> 
<li><a href="ConsultarUsuarios.aspx" >Consultar<span></span></a></li> 
<li><a href="EliminarUsuarios.aspx" >Eliminar<span></span></a></li> 
<li><a href="ModificarUsuarios.aspx" >Modificar<span></span></a></li>
</ul> 

</div> 


<div class="sub-content"> 




<div class="features_overview"> 
<div class="features_overview_right"> 
<h3>Agregar Usuarios</h3>
<p class="large">Introduzca la informacón a continuación</p>  
<form action="#">
<p class="large">

<table style="width:100%;">
<tr>
<td>Nombre:</td>
<td><asp:TextBox ID="uxNombre" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;</td>
<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
ControlToValidate="uxNombre" 
ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
</td>
</tr>
<tr>
<td>Apellido:</td>
<td><asp:TextBox ID="uxApellido" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;</td>
<td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
ControlToValidate="uxApellido" 
ErrorMessage="<%$ Resources:DSU, FaltaApellidoUsuario%>" Font-Size="Smaller" Display="Static" />
</td>
</tr>
<tr>
<td>Nombre de Usuario:</td>
<td><asp:TextBox ID="uxUsername" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;</td>
<td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
ControlToValidate="uxUsername" 
ErrorMessage="<%$ Resources:DSU, FaltaUserName%>" Font-Size="Smaller" Display="Static" />
</td>
</tr>
<tr>
<td>Contraseña:</td>
<td><asp:TextBox ID="uxPassword" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;</td>
<td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
ControlToValidate="uxPassword" 
ErrorMessage="<%$ Resources:DSU, FaltaContrasenaUsuario%>" Font-Size="Smaller" Display="Static" />
</td>
</tr>
<tr>
<td>Tipo de Usuario:</td>
<td><asp:DropDownList ID="uxTipoUsuario" runat="server">
</asp:DropDownList></td>
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


</p>
</form> 

</div>



</div> 



</div> 

</div> 
</div> 
</form>
</asp:Content>
