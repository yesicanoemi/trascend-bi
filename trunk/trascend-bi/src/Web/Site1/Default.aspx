<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>DSU</title>
        <link href="Estilos/base.css" rel="stylesheet" type="text/css" />
        <link href="Estilos/type.css" rel="stylesheet" type="text/css" />
        <link href="Estilos/reset.css" rel="stylesheet" type="text/css" />  
    </head>

<body id="interior">
    <form id="form1" runat="server">
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
                    <div class="features_overview_right"> 
                        <h3>Inicio de Sesion</h3>
                                <p class="large">
                                
                                <asp:Label ID="uxNombreLogin" runat="server" Text="Nombre de usuario"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="uxLogin" runat="server" Width="150px"></asp:TextBox><br />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxLogin" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreUsuario%>" Font-Size="Smaller" Display="Static" />
                            
    
                                

                                <br />
                                <br />
                                <asp:Label ID="uxNombreContrasena" runat="server" Text="Contrasena"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                <asp:TextBox ID="uxContrasena" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="uxContrasena" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaContrasena%>"  />
                                
                                <br />
                                
                                <br />
                                <br />
                                <asp:Button ID="uxBotonAceptar" runat="server" Text="Aceptar" OnClick="uxBotonAceptar_Click"/>
                                
                              
                    </p>
                           
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
 </form>
</body>
</html>
