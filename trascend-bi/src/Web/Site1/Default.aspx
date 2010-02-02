<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>DSU</title>
        <link href="Estilos/base.css" rel="stylesheet" type="text/css" />
        <link href="Estilos/type.css" rel="stylesheet" type="text/css" />
        <link href="Estilos/reset.css" rel="stylesheet" type="text/css" />  
        <link href="Estilos/Otros.css" rel="stylesheet" type="text/css" />  
    </head>

<body id="interior">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div id="header_full">	
    <div id="global_header">
	    <div id="header_main">
	        <h1 id="logo"><a href="#">dsu</a></h1>
	        <div id="interior_white_bg">
	            <div id="interior_container">
	            <div id="interior_end_container_subnav">
	            <div class="container subnav"> 
	             
	            <div class="content"> 
	        <div class="sub-content"> 
                <div class="features_overview"> 
                    <div class="features_overview_rightUser"> 
                        <h3>Inicio de Sesion</h3>
                                <p class="large"><p>
                                 
                                <table class="SoloTablasUser">
                                    <tr>
                                        <td><span style="color:#FF0000"><asp:Label ID="uxNombreLogin1" runat="server" Text="<%$ Resources:DSU, Asterisco%>">
                                        </asp:Label></span><asp:Label ID="uxNombreLogin" runat="server" Text="<%$ Resources:DSU, Login%>"></asp:Label></td>
                                        <td><asp:TextBox ID="uxLogin" runat="server" Width="150px"></asp:TextBox><br /></td>
                                        <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxLogin" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                           </td>
                                    </tr>
                                     <tr><td>&nbsp;</td></tr>
                                    <tr>
                               
                                <td><span style="color:#FF0000"><asp:Label ID="Label1" runat="server" Text="<%$ Resources:DSU, Asterisco%>">
                                        </asp:Label></span><asp:Label ID="uxNombreContrasena" runat="server" Text="<%$ Resources:DSU, Contrasena%>"></asp:Label></td>

                                <td><asp:TextBox ID="uxContrasena" runat="server" Width="150px" TextMode="Password"></asp:TextBox></td>
                                
                                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="uxContrasena" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaContrasena%>"  Font-Size="Smaller"/></td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                            
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td><asp:Button ID="uxBotonAceptar" runat="server" Text="<%$ Resources:DSU, Aceptar%>" OnClick="uxBotonAceptar_Click"/>
                                </td>
                                </tr>
                                </table>
                               <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                                
                              
                     </div>
                </div>
            </div>
                        </div>
            </div>
        </div>
    </div>
</div>
        </div>
    </div>
</div>
    <asp:UpdatePanel ID="up2" runat="server">
        <ContentTemplate>
            <uc1:DialogoError ID="uxDialogoError" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
 </form>
</body>
</html>
