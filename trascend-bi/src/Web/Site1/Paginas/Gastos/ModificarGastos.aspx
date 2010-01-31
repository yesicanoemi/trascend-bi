<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Title="Modificar Gasto" CodeFile="ModificarGastos.aspx.cs" Inherits="Paginas_Gastos_ModificarGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
                     

    <div class="container subnav"> 
	    <div class="content"> 
		    <div class="sub-heading"> 
			    <h2>Gastos</h2> 
			</div> 
			<div class="subnav-container"> 
			    <ul id="subnav"> 
                   <li><a href="AgregarGastos.aspx">Agregar<span></span></a></li> 
                    <li><a href="ConsultarGastos.aspx">Consultar<span></span></a></li> 
                    <li><a href="EliminarGastos.aspx" >Eliminar<span></span></a></li> 
                    <li><a href="ModificarGastos.aspx" class="active">Modificar<span></span></a></li>
                </ul> 
			</div> 
			<div class="sub-content"> 
                <div class="features_overview"> 
                    <div class="features_overview_right"> 
                        <h3>Modificar Gasto</h3> 
                        <p class="large">Busqueda del Gasto</p>
                         <form id="form1" runat="server">
                        <asp:MultiView ID = "uxModificar"  runat="server" ActiveViewIndex="0">
                        
			                <asp:View ID="uxConsultar" runat="server">
			                
			                <table>
		                        <tr>		                    
		                            <td><asp:Label ID="LabelTipoConsulta" runat="server" Text="Realizar Consulta: " /></td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                        </tr>
		                        <tr>
        		                    <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>	
		                            <td>&nbsp;</td>                    
		                        </tr>    
		                        <tr>
		                            <td>
                                        <asp:RadioButtonList ID="uxCheckOpcionBuscar" runat="server" 
                                         Font-Size="X-Small" Height="51px" Width="257px"  >                                    
                                                <asp:ListItem Value="0">Propuesta</asp:ListItem>
                                                <asp:ListItem Value="1">Cliente</asp:ListItem>
                                                
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>&nbsp;</td>
		                            <td><asp:TextBox ID="uxBusquedaConsulta" runat="server"></asp:TextBox></td>
		                            <td>&nbsp;</td>
        		                    <td><asp:Button ID="uxBotonBuscarDatos" Text="Buscar" runat="server" onclick="uxBotonBuscar_Click" /></td>
		                        </tr>		                		                
		                        <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>	                    
		                </tr>
		               
		            
                              
		                <tr>
		                    <td><h3>Parametros Coincidentes<asp:GridView ID="uxGridParamCoincidente" runat="server" AllowPaging="True" DataSourceID="uxObjectParamCoinci"
                                                AutoGenerateColumns="false" DataKeyNames="ID" AutoGenerateSelectButton="true"  OnSelectedIndexChanging="parametrizado"
                                                Width="130%" Font-Names="Verdana" Font-Size="X-Small">
                                                
                                                <Columns>
                                                
                                                        <asp:BoundField HeaderText="Coincidencias" DataField="Titulo"/>   
                                                                                                             
                                                </Columns>
                                                
                            </asp:GridView>
			                    </h3></td>
			            </tr>
			            <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>		                			         
			            <tr>
			                <td colspan="2">
			                    &nbsp;</td>
			            </tr>
		            </table>
		            </asp:View>
		            
		                    <asp:View ID="uxCliente" runat="server">
		              <table>
		                 <tr>
		                    <td><h3><asp:GridView ID="uxGridCliente" runat="server" AllowPaging="True" DataSourceID="uxObjectCliente"
                                                AutoGenerateColumns="false" DataKeyNames="Nombre" AutoGenerateSelectButton="true"  OnSelectedIndexChanging="parametrizadocliente"
                                                Width="130%" Font-Names="Verdana" Font-Size="X-Small">
                                                
                                                <Columns>
                                                
                                                        <asp:BoundField HeaderText="Rif" DataField="rif"/>
                                                        <asp:BoundField HeaderText="Nombre" DataField="nombre"/>   
                                                                                                             
                                                </Columns>
                                                
                            </asp:GridView>
			                    </h3></td>
			            </tr>
			            <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>		                			         
			            <tr>
			                <td colspan="2">
			                    &nbsp;</td>
			            </tr>
		            </table>
		            </asp:View>
		            
		                    <asp:View ID="uxSeleccion" runat="server">
		            <table>
		                <tr>
		                    <td><h3>Datos del Gasto<asp:GridView ID="uxConsultaGasto" runat="server" AllowPaging="True" DataSourceID="uxObjectConsultaGasto"
                                                AutoGenerateColumns="false" DataKeyNames="codigo" AutoGenerateSelectButton="true"
                                                Width="158%" Font-Names="Verdana" Font-Size="X-Small" OnSelectedIndexChanging="uxModificarGasto">
                                                
                                                <Columns>
                                                                <asp:BoundField HeaderText=""  />
                                                                <asp:BoundField HeaderText="Estado" DataField="estado" />                                            
                                                                <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                                                                <asp:BoundField HeaderText="Estado" DataField="estado" />
                                                                <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />  
                                                                <asp:BoundField HeaderText="Monto" DataField="monto" />                                                         
                                                                <asp:BoundField HeaderText="Fecha Gasto" DataField="fechaGasto" />
                                                                <asp:BoundField HeaderText="" />
                                                </Columns>
                                                           
                            </asp:GridView>
			                    </h3></td>
			            </tr>
			            <tr>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                    <td>&nbsp;</td>
		                </tr>		                			         
			            <tr>
			                <td colspan="2">
			                    &nbsp;</td>
			            </tr>
		            </table> 
		            </asp:View>   		          
		            
        		            <asp:View ID="uxError" runat="server">
        		            <table  style="width:100%;">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="LabelMensajeError" runat="server" Visible="true" Font-Bold="true" Font-Size="Large"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                           </table>
                           </asp:View>
                       
                            <asp:View ID="uxfinal" runat="server"> 
                           <table>
                               <tr>
                                   <td>Codigo: </td>
                                   <td><asp:Label ID="uxCodigoGasto" runat="server"  Enabled="false"/></td>
                               </tr>
                               <tr>
		                            <td>&nbsp;</td>
		                            <td>&nbsp;</td>        		               
		                        </tr>
                               <tr>
                                   <td>Tipo: </td>
                                   <td><asp:TextBox ID="uxTipoGasto" runat="server" Enabled="true"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Descripcion: </td>
                                   <td><asp:TextBox ID="uxDescripcionGasto" runat="server" Enabled="true"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Fecha del gasto: </td>
                                   <td>
                                       <asp:TextBox ID="uxFechaGasto2" runat="server" Enabled="true"></asp:TextBox>
                                       <asp:Image ID="uxImagenFechaGasto2" runat="server" ImageUrl="~/Images/calendario.png"/>                                            
                                   </td>
                               </tr>
                               <tr>
                                   
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Fecha de Ingreso: </td>
                                   <td>
                                       <asp:TextBox ID="uxFechaIngreso" runat="server" Enabled="true"></asp:TextBox>
                                       <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/calendario.png"/>                                            
                                   </td>
                               </tr>
                               <tr>
                                   
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Monto: </td>
                                   <td><asp:TextBox ID="uxMontoGasto" runat="server" Enabled="true"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                                <tr>
                                   <td>Estado del gasto: </td>
                                   <td><asp:TextBox ID="uxEstadoGasto" runat="server" Enabled="true"></asp:TextBox></td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                               </tr>
                               <tr>
                                   <td>Version: </td>
                                   <td><asp:Label ID="uxIdVersion" runat="server"  Enabled="false"/></td>
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
                                       <asp:Button ID="uxBotonAceptar" runat="server" Text="Modificar" Enabled="true"
                                            onclick="uxBotonAceptar_Click" />                                           
                                   </td>
                                </tr>
                            </table>
                            </asp:View>
                           
                                 </asp:MultiView> 		            
                        </form>                        
                    </div> 
                </div>
            </div> 
        </div>
    </div>	
<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaGasto" DataObjectTypeName="Core.LogicaNegocio.Entidades.Gasto" />
<pp:objectcontainerdatasource runat="server" ID="uxObjectParamCoinci" DataObjectTypeName="Core.LogicaNegocio.Entidades.Propuesta" />
<pp:objectcontainerdatasource runat="server" ID="uxObjectCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 	 
</asp:Content>

