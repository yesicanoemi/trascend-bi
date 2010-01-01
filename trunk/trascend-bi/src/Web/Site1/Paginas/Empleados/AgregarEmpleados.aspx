<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarEmpleados.aspx.cs" Inherits="Paginas_Empleados_AgregarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Empleados</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarEmpleados.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarEmpleados.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarEmpleados.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarEmpleados.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
            <div class="features_overview"> 
                   <div class="features_overview_right"> 
            <h3>Agregar Empleados</h3>
            <p class="large">Introduzca la informacón a continuación</p> 
            <p class="large"></p>
                       <p class="large">
                        <form action="#" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>Nombre:</td>
                                   <td><asp:TextBox ID="uxNombreEmpleado" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Apellido:</td>
                                   <td><asp:TextBox ID="uxApellidoEmpleado" runat="server"></asp:TextBox></td>
                               </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                               <tr>
                                   <td>C.I.:</td>
                                   <td><asp:TextBox ID="uxCedulaEmpleado" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Numero de Cuenta:</td>
                                   <td><asp:TextBox ID="uxNumCuentaEmpleado" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Sueldo Base:</td>
                                   <td><asp:TextBox ID="uxSueldoBase" runat="server"></asp:TextBox></td>
                                </tr>
                                  <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Cargo:</td>
                                   <td>
                                       <asp:DropDownList ID="uxCargoEmpleado" runat="server">
                                       </asp:DropDownList>
                                   </td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Fecha de Nacimiento:</td>
                                   <td>
                                       <asp:Calendar ID="uxFechaNac" runat="server"></asp:Calendar>
                                   </td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Dirección de Habitación</td>
                                   <td><asp:TextBox ID="uxDireccion" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Fecha de Ingreso</td>
                                   <td>
                                       <asp:Calendar ID="uxFechaIngreso" runat="server"></asp:Calendar>
                                   </td>
                                </tr>
                                <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                </tr>
                                <tr>
                                   <td>Fecha de Egreso</td>
                                   <td>
                                       <asp:Calendar ID="uxFechaEgreso" runat="server"></asp:Calendar>
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
