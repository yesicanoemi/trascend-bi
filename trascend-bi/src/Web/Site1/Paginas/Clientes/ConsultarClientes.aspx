<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarClientes.aspx.cs" Inherits="Paginas_Clientes_ConsultarClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="ajaxToolkit"%>
<%@ Register Src="~/ControlesBase/DialogoError.ascx" TagName="DialogoError" TagPrefix="uc1" %>
<%@ Register Src="~/ControlesBase/MensajeInformacion.ascx" TagName="MensajeInformacion" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Clientes</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarClientes.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarClientes.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarClientes.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarClientes.aspx" >Modificar<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar Clientes</h3> 
                   
                    
                    
                    <asp:MultiView runat="server" ID="uxMultiViewConsultar" ActiveViewIndex="0">
                        
                        
                        <asp:View ID="uxViewBuscar" runat="server"> 
                        
                        
                                  <p>Introduzca los campos según su tipo de búsqueda</p> 
                                    
                                    <br />
                                    
                                    <table width="">
                                          <tr>  
                                            <td align="right">
                                                <asp:RadioButtonList ID="uxRbCampoBusqueda" runat="server" Width="194px"  
                                                    onselectedindexchanged="uxRbCampoBusqueda_SelectedIndexChanged" 
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="1" Text="Nombre de Cliente"></asp:ListItem> 
                                                    <asp:ListItem Value="2" Text="Rif"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            
                                             <td align="center">
                                              
                                                <table>
                                                   <tr>
                                                        
                                                        <td align="center"><asp:Label ID="uxRifCliente" runat="server" Visible="false"  ontextchanged="uxRifCliente_TextChanged" 
                                                        Text="RIF del Cliente"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                   
                                                        <td align="center">
                                                            <asp:TextBox ID="uxConsultaRif" MaxLength=11 runat="server" Visible="false" 
                                                                Width="120px" ></asp:TextBox>
                                                             
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
					 CompletionListCssClass="list" 
                                            CompletionListHighlightedItemCssClass="hoverlistitem" 
                                            CompletionListItemCssClass="listitem" CompletionSetCount="1"
					 MinimumPrefixLength="1" 
                                            ServiceMethod="GetSuggestionsClienteRif" 
                                            ServicePath="../../SuggestionNames.asmx" TargetControlID="uxConsultaRif" 
                                            UseContextKey="false"></ajaxToolkit:AutoCompleteExtender>
                                                        </td>
                                                        
                                                    </tr>
                                                     <tr>
                                                        
                                                        <td align="center"><asp:Label ID="uxNombreCliente" runat="server" Visible="false" Text="Nombre del Cliente"></asp:Label></td>
                                                    </tr>

                                                    <tr>
                                                                                    <td><asp:TextBox ID="uxValor" runat="server" ontextchanged="uxValor_TextChanged" Visible="false"
                                        Width="150px"></asp:TextBox></td>
                                             </tr>
                                             <tr>
                                             <td>                                        
                                             <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                          					 CompletionListCssClass="list" 
                                            CompletionListHighlightedItemCssClass="hoverlistitem" 
                                            CompletionListItemCssClass="listitem" CompletionSetCount="1"
				                        	 MinimumPrefixLength="1" 
                                            ServiceMethod="GetSuggestionsClienteNombre" 
                                            ServicePath="../../SuggestionNames.asmx" TargetControlID="uxValor" 
                                            UseContextKey="false"></ajaxToolkit:AutoCompleteExtender>
                                                                               
                                        </td>
                                        </tr>
                                        <tr>       
                                                    <td>
                                                       <br />
                                                        <br />
                                                        <br />

                                                    </td>
                                          </tr>
                                              
                                            
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="uxBotonBuscar" runat="server" onclick="uxBotonBuscar_Click" 
                                                                Visible="false"    Text="Buscar" ValidationGroup="valBusquedaNombre"  />
                                                            </td>
                                                        </tr>
                                                   
                                            </table>
                                            
                                            
                                          
                                              <uc2:MensajeInformacion ID="uxMensajeInformacion" runat="server" Visible="false" />
                                              
                                               
                                                  </td>
                                         </tr> 
                                          <tr>
                                              <td align="right" colspan="2">
                                                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                      <ContentTemplate>
                                                          <uc2:MensajeInformacion ID="uxMensajeInformacion0" runat="server" 
                                                              Visible="false" />
                                                      </ContentTemplate>
                                                  </asp:UpdatePanel>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                              </td>
                                              <td align="center">
                                                  <br />
                                                   <br />
                                                  <asp:GridView ID="uxGridCliente" runat="server" AllowPaging="True" 
                                                      AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="rif" 
                                                      Font-Names="Verdana" Font-Size="Small" onrowdatabound="uxGridView_RowDataBound" 
                                                      OnSelectedIndexChanging="SelectCliente" Width="100%">
                                                      <RowStyle HorizontalAlign="Center" />
                                                      <Columns>
                                                          <asp:BoundField DataField="rif" HeaderText="Rif" />
                                                          <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                                          <asp:BoundField DataField="areanegocio" HeaderText="Area de Negocio" />
                                                      </Columns>
                                                      <EmptyDataTemplate>
                                                          <center>
                                                              <span>No Data Papa</span>
                                                          </center>
                                                      </EmptyDataTemplate>
                                                  </asp:GridView>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <br />
                                                  <asp:UpdatePanel ID="up2" runat="server">
                                                      <ContentTemplate>
                                                          <uc1:DialogoError ID="uxDialogoError0" runat="server" />
                                                      </ContentTemplate>
                                                  </asp:UpdatePanel>
                                                  <br />
                                                  <br />
                                                  <br />
                                                  <br />
                                                  <br />
                                              </td>
                                          </tr>
                                          </td>
                    
                        </table>
                     
                        </asp:View>
                        <asp:View ID="uxViewMostrar" runat="server">
                           
                           <table>
                         <tr>
                                <td>
                                <asp:DetailsView ID="uxMuestraCliente" datasourceid="uxObjectConsultaCliente"
                                datakeynames="rif" Runat="server" AutoGenerateRows="False"  HeaderText="Datos de Cliente"
                                 Width="275px" CellPadding="4" ForeColor="White" Font-Size="Small" 
                                        GridLines="None" Font-Names="Verdana" Font-Color="White"  >     
                                    <headerstyle backcolor="#FFBC40"            forecolor="White" Font-Bold="True" 
                                        HorizontalAlign="Center"/>

                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />

                                  <Fields>
                                                        <asp:BoundField HeaderText="Rif" DataField="rif" ReadOnly="True"/> 
                                                        <asp:BoundField HeaderText="Nombre Cliente" DataField="nombre" ReadOnly="True"/>
                                                        <asp:BoundField HeaderText="Area de Negocio" DataField="areanegocio" ReadOnly="True"/>  
                                                                                                                
                                                   
                                  </Fields>
                                    <EditRowStyle BackColor="#EFF3FB" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:DetailsView>
                                
                                    <asp:DetailsView ID="uxMuestraDireccion" Runat="server" 
                                        AutoGenerateRows="False" CellPadding="4" datakeynames="calle" 
                                        datasourceid="uxObjectConsultaDireccion" DefaultMode="Edit" ForeColor="White" 
                                        GridLines="None" HeaderText="Direccion" font-size="Small"
                                        onpageindexchanging="uxMuestraDireccion_PageIndexChanging" Width="275px" 
                                        Font-Names="Verdana">
                                        <headerstyle backcolor="#FFBC40" Font-Bold="True" forecolor="White" 
                                            HorizontalAlign="Center" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <Fields>
                                            <asp:BoundField DataField="avenida" HeaderText="Avenida" ReadOnly="True" />
                                            <asp:BoundField DataField="urbanizacion" HeaderText="Urbanizacion" 
                                                ReadOnly="True" />
                                            <asp:BoundField DataField="edif_casa" HeaderText="Edificio/Casa" 
                                                ReadOnly="True" />
                                            <asp:BoundField DataField="oficina" HeaderText="Oficina" ReadOnly="True" />
                                            <asp:BoundField DataField="ciudad" HeaderText="Ciudad" ReadOnly="True" />
                                        </Fields>
                                        <EditRowStyle BackColor="#EFF3FB" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:DetailsView>
                                    <br />
                                    <asp:GridView ID="uxMuestraTelefono" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigoarea" 
                                        DataSourceID="uxObjectConsultaTelefono" Font-Names="Verdana"
                                        Font-Size="Small" ForeColor="#333333" GridLines="Both" Width="275px" 
                                        HorizontalAlign="Center">
                                        <RowStyle BackColor="#EFF3FB" ForeColor="White" Font-Bold="True" HorizontalAlign="Center"/>
                                        <headerstyle backcolor="#33CCCC" Font-Bold="True" forecolor="#33CCCC" />
                                        <Columns>
                                            <asp:BoundField DataField="tipo" HeaderText="Tipo de Telefono" ReadOnly="True" />
                                            <asp:BoundField DataField="codigoarea" HeaderText="Codigo" 
                                                ReadOnly="True" />
                                            <asp:BoundField DataField="numero" HeaderText="Numero" ReadOnly="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            <center>
                                                <span>No tiene telefonos cargados</span>
                                            </center>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#0066FF" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                
                                </td>
                                   <td>&nbsp;</td>
                          </tr>
                          <tr>
                             
                              <td></td>  
                              
                               <td>    
                                   &nbsp;</td> 
                           </tr>  
                          
                                   </table>
                                
                                <caption>
                                    <br />
                                    <%--<asp:UpdatePanel ID="up2" runat="server">
                                        <ContentTemplate>
                                            <uc1:DialogoError ID="uxDialogoError" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </caption>
                                
                                
                        </asp:View>
                       
                   </asp:MultiView>     
                    

                     <br />

                 </div> 
             
                      
                     
              </div>
                      
                      

        </div> 
				
			</div> 
		</div> 
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaDireccion" DataObjectTypeName="Core.LogicaNegocio.Entidades.Direccion" />
		
		<pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaCliente" DataObjectTypeName="Core.LogicaNegocio.Entidades.Cliente" /> 
        
        <pp:objectcontainerdatasource runat="server" ID="uxObjectConsultaTelefono" DataObjectTypeName="Core.LogicaNegocio.Entidades.TelefonoTrabajo" />  
        
    </form>
        
    </form>
</asp:Content>

