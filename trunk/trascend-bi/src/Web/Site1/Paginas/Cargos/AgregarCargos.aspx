<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarCargos.aspx.cs" Inherits="Paginas_Cargos_AgregarCargos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Cargos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarCargos.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarCargos.aspx" >Consultar<span></span></a></li> 
    <li><a href="EliminarCargos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarCargos.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
        
          <div class="features_overview_right"> 
            <h3>Agregar Cargo</h3>
            <p class="large">Introduzca la informacón a continuación</p>
              <form id="Form1" runat="server">
            <p class="large">
               
                           <table style="width:100%">
                               <tr>
                                   <td>Nombre:</td>
                                   <td><asp:TextBox ID="uxNombre" runat="server"></asp:TextBox></td>
                                   
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="uxNombre" 
                                        ErrorMessage="<%$ Resources:DSU, FaltaNombreCargo%>" Font-Size="Smaller" Display="Static" />
                                    </td>
                               </tr>
                               <tr>
                                   <td>Descripcion:</td>
                                   <td><asp:TextBox ID="uxDescripcion" runat="server"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Sueldo Mínimo:</td>
                                   <td>
                                       <asp:TextBox ID="uxSueldoMinimo" runat="server"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Sueldo Máximo</td>
                                   <td>
                                       <asp:TextBox ID="uxSueldoMaximo" runat="server"></asp:TextBox>
                                   </td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Vigencia de Sueldo:</td>
                                   <td><asp:TextBox ID="uxVigenciaSueldo" runat="server"></asp:TextBox></td>
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
                
            
                </p> 
              </form>
          </div> 
        </div> 
 
        
 
        
				
								</div> 
				
			</div> 
		</div> 
</asp:Content>
