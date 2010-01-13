<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarFacturas.aspx.cs" Inherits="Paginas_Facturas_AgregarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Facturas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarFacturas.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarFacturas.aspx" >Consultar<span></span></a></li> 
   
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
 
          <div class="features_overview_right"> 
            <h3>Agregar Facturas</h3>
            <p class="large">Introduzca la informacion a continuación</p> 
             <p class="large">
                <form id="Form1" runat="server">
                           <table style="width:100%;">
                               <tr>
                                   <td>Proyecto asociado: </td>
                                   <td>
                                       <asp:TextBox ID="uxProyectoAsociado" runat="server"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Titulo: </td>
                                   <td><asp:TextBox ID="uxTituloFactura" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Descripcion: </td>
                                   <td><asp:TextBox ID="uxDescripcionFactura" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>% del pago: </td>
                                   <td><asp:TextBox ID="uxPorcentaje" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Monto: </td>
                                   <td><asp:TextBox ID="uxMonto" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Fecha de Pago: </td>
                                   <td>
                                       <asp:TextBox ID="uxFechaPago" runat="server"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Estado(cobrado o por cobrar): </td>
                                   <td>
                                       <asp:DropDownList ID="uxEstado" runat="server">
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
