<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarGastos.aspx.cs" Inherits="Paginas_Gastos_AgregarGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Gastos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarGastos.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarGastos.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarGastos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarGastos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
          
          <div class="features_overview_right"> 
           <h3>Agregar Gastos</h3>
            <p class="large">Introduzca la informacón a continuación</p> 
            <p class="large">
                <form id="Form1" action="#" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>Nombre de Gasto: </td>
                                   <td>
                                       <asp:TextBox ID="uxNombreGasto" runat="server"></asp:TextBox> 
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Descripcion: </td>
                                   <td><asp:TextBox ID="uxDescripcionGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Fecha del gasto: </td>
                                   <td>
                                       <asp:Calendar ID="uxFechaGasto" runat="server"></asp:Calendar>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Monto: </td>
                                   <td><asp:TextBox ID="uxMontoGasto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Proyecto asociado: </td>
                                   <td><asp:TextBox ID="uxProuectoAsociado" runat="server" Enabled="false"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Nombre del proyecto: </td>
                                   <td><asp:TextBox ID="uxNombreProyecto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Propuesta: </td>
                                   <td>
                                       <asp:DropDownList ID="uxPropuesta" runat="server">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Estado del gasto: </td>
                                   <td>
                                       <asp:DropDownList ID="uxEstadoGasto" runat="server">
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
