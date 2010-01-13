<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarCargos.aspx.cs" Inherits="Paginas_Cargos_ConsultarCargos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Cargos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarCargos.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarCargos.aspx" class="active">Administrar<span></span></a></li> 
    <li><a href="EliminarCargos.aspx" >Eliminar<span></span></a></li> 

</ul> 
	</div> 
    	<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar cargos</h3> 
                    <p class="large"></p> 
                        <p>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <!-- CONSULTA -->
                                    <asp:View ID="ViewConsulta" runat="server">
                                    <form id="Form1" action="#" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td><asp:Label ID="uxNombreCargo" runat="server" Text="<%$Resources:DSU, NombreObligatorio%>"
                                                        ></asp:Label>&nbsp;</td>
                                                <td><asp:TextBox ID="uxNombreCargoConsulta" runat="server" Width="150px"
                                                    ValidationGroup="valRegistro"></asp:TextBox>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="uxNombreCargoConsulta"
                                                      Display="Static" ErrorMessage="<%$ Resources:DSU, FaltaNombre%>"
                                                      ValidationGroup="valRegistro" Font-Size="Smaller"/></td>
                                                <td>&nbsp;<asp:Button ID="uxBuscarNombreCargo" runat="server" Text="Buscar" OnClick="uxBuscarNombre_Click"
                                                    ValidationGroup="valRegistro" TabIndex="2" /></td>
                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                <td><asp:Label ID="uxNombreCargoRango" runat="server" Text="<%$Resources:DSU, RangoSueldoCargo%>"
                                                   ></asp:Label></td>
                                                <td><asp:DropDownList ID="uxRangoCargoConsulta" runat="server">
                                                        <asp:ListItem Value="0">Seleccionar...</asp:ListItem>
                                                        <asp:ListItem Value="1">10.000 BsF. - 8.500 BsF.</asp:ListItem>
                                                        <asp:ListItem Value="2">8.500 BsF. - 7.500 BsF.</asp:ListItem>
                                                        <asp:ListItem Value="3">7.500 BsF. - 5.000 BsF.</asp:ListItem>
                                                        <asp:ListItem Value="4">5.000 BsF. - 3.500 BsF.</asp:ListItem>
                                                        <asp:ListItem Value="5">3.500 BsF. - 2.500 BsF.</asp:ListItem>
                                                        <asp:ListItem Value="6">2.500 BsF. - 1.000 BsF.</asp:ListItem>
                                                       
                                                     </asp:DropDownList>
                                                 <!--Rango se puede obtener de los saldos de la base de datos -->
                                                 <!--<asp:DropDownList ID="uxRangoCargoConsulta1" runat="server" DataTextField="RangoCargo" DataValueField="Rango"
                                                    AutoPostBack="false" AppendDataBoundItems="True" TabIndex="3"></asp:DropDownList> -->
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RangeValidator MaximumValue="6" MinimumValue="1" ID="RegularExpressionValidator1" runat="server"
                                                        ErrorMessage="<%$Resources:DSU, SeleccioneRango %>" ControlToValidate="uxRangoCargoConsulta"
                                                        Font-Size="Smaller"></asp:RangeValidator>
                                                  </td>
                                                <td>&nbsp;<asp:Button ID="uxBuscarRangoCargo" runat="server" Text="Buscar"
                                                    OnClick="uxBuscarRango_Click" TabIndex="4" /></td>
                                            </tr>
                                            <tr>
                                            <td colspan="4">
                                            <!--
                                                <asp:GridView ID="uxConsultaUsuario" runat="server" AllowPaging="True" DataSourceID=""
                                                    AutoGenerateColumns="False" DataKeyNames="EntidadId" AutoGenerateSelectButton="True"
                                                    Width="100%" Font-Names="Verdana" Font-Size="Smaller" PageSize="10">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre DataField="nombreUsuario" />
                                                        <asp:BoundField HeaderText="Apellido" DataField="apellidoUsuario" />
                                                        <asp:BoundField HeaderText="Nombre de Usuario" DataField="nombredeUsuario" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <center>
                                                            <span>No hay data cargada </span>
                                                        </center>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>-->
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                                </asp:View>
        
                                <!-- MODIFICAR .-->
                                <asp:View ID="ViewModificar" runat="server">
                                
                                
                                </asp:View>
                         </asp:MultiView>
                        </p>
                 </div> 
              </div>
        </div> 
	</div> 
</div> 
</asp:Content>

