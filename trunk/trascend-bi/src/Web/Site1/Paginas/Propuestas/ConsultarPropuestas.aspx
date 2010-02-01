<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarPropuestas.aspx.cs" Inherits="Paginas_Propuestas_ConsultarPropuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Propuestas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarPropuestas.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarPropuestas.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarPropuestas.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarPropuestas.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
		<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Propuesta</h3>
                    &nbsp;
                    <p class="large"><asp:Label Font-Size="Large" ID="Labelerror" runat="server" Visible="false"></asp:Label></p> 
                    <p class="large">
                    <form id="Form1" action="#" runat="server">
                    
                    <asp:MultiView ID="uxMultiViewPropuesta" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewConsultarPropuesta" runat="server">
                    
                        <table>
                            <tr>
                                <td><asp:Label ID="LabelTipoConsulta" runat="server" Text = "Busqueda de la Propuesta" Font-Size="Medium" /></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="uxOpcionCheckBox" runat="server" Text = "Realizar consulta por:" Font-Bold="true" />
                                    &nbsp;</td>
                                <td>
                                <asp:TextBox ID="uxParametro" runat="server" Visible="true"></asp:TextBox>
                                <asp:TextBox ID="uxParametroRif" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:RadioButtonList id="uxListaOpciones" runat="server" Width="365px" 
                                        onselectedindexchanged="uxListaOpciones_SelectedIndexChanged1" AutoPostBack="true">
                                        <asp:ListItem Value="1">Nombre Propuesta</asp:ListItem>
                                        <asp:ListItem Value="3">Rif Cliente</asp:ListItem>
                                        <asp:ListItem Value="4">Nombre Cliente</asp:ListItem>
                                    </asp:RadioButtonList>
                                    &nbsp;
                                </td>
                                <td align="center"> &nbsp;
                                <asp:Button ID="uxBotonAceptar" runat="server" Text="Buscar" 
                                        onclick="uxBotonAceptar_Click" />
                                </td>
                           </tr>
                           <tr><td>&nbsp;</td></tr>
                           <tr><td>&nbsp;</td></tr>
                           <tr>
                           
                                  <td><asp:GridView runat = "server" ID="uxPropuestaConsultada" DataSourceID="uxObject" AutoGenerateColumns = "false" 
                                    DataKeyNames = "ID" AutoGenerateSelectButton="true" AllowPaging = "true" PageSize = "8" ShowFooter = "true" Width = "400" OnSelectedIndexChanging = "Consult"  >
                                        <Columns>
                                                
                                                <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                                                 <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText="    "  />
                                                <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                                                 <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText="    "  />
                                                <asp:BoundField HeaderText="Monto"  DataField="MontoTotal"   />
                
                                        </Columns>
                                         <EmptyDataTemplate>
                                                    <!--<center>
                                                        <asp:Label ID="LabelVacio" runat="server" Text = "No hay data cargada" Font-Bold="true" />
                                                    </center>-->
                                                </EmptyDataTemplate>            
            
                                    </asp:GridView>
                                    <asp:Label ID="LabelVacio" runat="server" Text = "No hay data cargada" Font-Bold="true" Visible="false" />
                                </td>
                           </tr>
                           </table>
                           </asp:View>
                           <asp:View ID="ViewConsultarPropuestaDetalle" runat="server">
                           <table style="width:100%;">
                           
                           <tr>
                           <td></td>
                           </tr>
             
            
                           
                            <tr>
                                <td><asp:Label ID="LabelTitulo" runat="server" Text = "Titulo:" Font-Bold="true" /></td>
                                <td><asp:Label ID="LabelTituloPropuesta" runat="server" Font-Bold="true" /></td>    
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelVersion" runat="server" Text = "Ultima version:" /></td>
                                <td><asp:Label ID="LabelVersionPropuesta" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelFechaFirma" runat="server" Text = "Fecha de la Firma:" Font-Bold="true" /></td>
                                <td><asp:Label ID="LabelFechaFirmaPropuesta" runat="server" Font-Bold="true" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelReceptor" runat="server" Text = "Nombre del Receptor:" /></td>
                                <td><asp:Label ID="LabelReceptorPropuesta" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelCargo" runat="server" Text = "Cargo:" Font-Bold="true" /></td>
                                <td><asp:Label ID="LabelCargoPropuesta" runat="server" Font-Bold="true" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelFechaIn" runat="server" Text = "Fecha Inicio:" /></td>
                                <td><asp:Label ID="LabelFechaInP" runat="server" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelFechaFin" runat="server" Text = "Fecha Fin:" Font-Bold="true" /></td>
                                <td><asp:Label ID="LabelFechaFinP" runat="server" Font-Bold="true" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelTotalH" runat="server" Text = "Total Horas:" /></td>
                                <td><asp:Label ID="LabelTotalHP" runat="server" /></td>
                            </tr>
                             <tr>
                                <td><asp:Label ID="LabelMonto" runat="server" Text = "Monto:" Font-Bold="true" /></td>
                                <td><asp:Label ID="LabelMontoP" runat="server" Font-Bold="true" /></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="LabelEquipo" runat="server" Text = "Equipo de Trabajo:" /></td>
                                <td><asp:Listbox ID="ListEquipoP" runat="server" Enabled="false" /></td>
                            </tr>
                        </table>
                        <!--<asp:GridView runat = "server" ID="uxPropuestaMuestra" DataSourceID="uxObject2" AutoGenerateColumns = "false" 
                                    DataKeyNames = "ID" AutoGenerateSelectButton="false" AllowPaging = "true" PageSize = "8" ShowFooter = "true" Width = "400" >
                                        <Columns>
                                                
                                                <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                                                <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                                                <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText=" Ult Version"  DataField="Version"   />
                                                <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText=" Firma"  DataField="FechaFirma"   />
                                                <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText=" Receptor"  DataField="nombreReceptor"   />
                                                
                                                <asp:BoundField HeaderText=""  DataField="apellidoReceptor"   />
                                                <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText=" Fecha Inicio"  DataField="fechaInicio"   />
                                                <asp:BoundField />
                                                <asp:BoundField />
                                                <asp:BoundField HeaderText=" Fecha Fin"  DataField="fechaFin"   />
                
                                        </Columns>
                                         <EmptyDataTemplate>
                                                    <center>
                                                        <span>No hay data cargada</span>
                                                    </center>
                                                </EmptyDataTemplate>             
            
                                    </asp:GridView>
                             <table>
                             
                                    <tr>
                                    <td></td>
                                    <td></td>
                                    </tr>
                             
                                    <tr>
                                <td><asp:Label ID="LabelEquipos" runat="server" Text = "Equipo de Trabajo" Visible ="False" /></td>
                                <td><asp:Listbox ID="ListEquipos" runat="server" Visible ="False" /></td>
                            </tr>   
                                    
                             </table>-->
                             </asp:View>
                             </asp:MultiView>      
                     </form>
                         <pp:objectcontainerdatasource runat="server" ID="uxObject" DataObjectTypeName="Core.LogicaNegocio.Entidades.Propuesta" />
                         <pp:objectcontainerdatasource runat="server" ID="uxObject2" DataObjectTypeName="Core.LogicaNegocio.Entidades.Propuesta" />
                    </p> 
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>

