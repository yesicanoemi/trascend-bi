<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="AgregarFacturas.aspx.cs" Inherits="Paginas_Facturas_AgregarFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Facturas</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarFacturas.aspx" class="active">Agregar<span></span></a></li> 
  <li><a href="ConsultarFacturas.aspx" >Consultar<span></span></a></li> 
  <li><a href="ModificarFacturas.aspx" >Modificar<span></span></a></li> 
   
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
 
        				
				
 
                  <div class="features_overview"> 
         
 
          <div class="features_overview_right"> 
            <h3>Agregar Facturas</h3>
            <p class="large">Introduzca la informacion de la propuesta a buscar:</p>
            <div>
                <table width="448">
                    <asp:radiobuttonlist id="uxRadioButton" runat="server" TextAlign ="Right">

                      <asp:listitem id="PorNombre" runat="server" value="Buscar por Nombre" />

                      <asp:listitem id="PorID" runat="server" value="Buscar por ID" />

                    </asp:radiobuttonlist>

                </table>
                
                
                
                <asp:TextBox ID="uxBusqueda" runat="server"></asp:TextBox>
                <asp:Button ID="uxBusquedaBoton"
                    runat="server" Text="Buscar" onclick="uxBusquedaBoton_Click" />
                    
                    
                
                
            </div>
              <asp:Label ID="Label1" runat="server" Text="Propuestas:" Font-Bold="True"></asp:Label>
            <div>
            <asp:GridView ID="uxGridPropuesta" runat="server"
                AutoGenerateColumns="false"
                         cellpadding="10"
                         cellspacing="5" >
                         <RowStyle HorizontalAlign="Center" />
                         <Columns >
                                   <asp:BoundField HeaderText="ID" DataField="ID" />
                                   <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                                   <asp:BoundField HeaderText="Monto Total" DataField="MontoTotal" />                                                         
                         </Columns>
                         <EmptyDataTemplate>
                               <center>
                                    <span>No hay data cargada</span>
                               </center>
                         </EmptyDataTemplate>   
                </asp:GridView>
 
                </div>
                
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Facturas Emitidas:" 
                        Font-Bold="True"></asp:Label>
                </div>
                
                <div>
                <asp:GridView ID="uxGridFacturas" runat="server"
                AutoGenerateColumns="false"
                         cellpadding="10"
                         cellspacing="5" Font-Size=Smaller>
                         
                         <Columns >
                                   <asp:BoundField HeaderText="Numero Factura" DataField="Numero" />
                                   <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                                   <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />       
                                   <asp:BoundField HeaderText="Porcentaje Pagado" DataField="Procentajepagado" />                                    
                                   <asp:BoundField HeaderText="Fecha de Ingresp" DataField="Fechaingreso" /> 
                                   <asp:BoundField HeaderText="Fecha de Pago" DataField="Fechapago" /> 
                                   <asp:BoundField HeaderText="Estado" DataField="Estado"/> 
                                                                                     
                         </Columns>
                         <EmptyDataTemplate>
                               <center>
                                    <span>No hay data cargada</span>
                               </center>
                         </EmptyDataTemplate>    
                </asp:GridView>
                  </div>
                  <div>
                <asp:Label ID="Label3" runat="server" Text="Porcentaje Pagado: "></asp:Label>
             
              <asp:Label ID="uxLabelPorcentajePagado" runat="server" Text=""></asp:Label>
              </div>
              <div>
                <asp:Label ID="Label4" runat="server" Text="Total Pagado: "></asp:Label>
             
              <asp:Label ID="uxLabelTotalPagado" runat="server" Text=""></asp:Label>
              </div>
              
              <div>
                <asp:Label ID="Label5" runat="server" Text="Porcentaje Restante: "></asp:Label>
             
              <asp:Label ID="uxLabelPorcentajeRestante" runat="server" Text=""></asp:Label>
              </div>
              <div>
                <asp:Label ID="Label7" runat="server" Text="Monto Restante: "></asp:Label>
             
              <asp:Label ID="uxLabelMontoRestante" runat="server" Text=""></asp:Label>
              </div>
                  
                  <table>
                  <tr><th> 
                      <asp:Label ID="Label6" runat="server" Text="Fecha: "></asp:Label><asp:Label ID="uxFechaEmision"
                          runat="server" Text=""></asp:Label></th><th>
                          <asp:Label ID="Label8" runat="server" Text="Numero de Factura: "></asp:Label> 
                              <asp:Label ID="uxNumeroFactura" runat="server" Text=""></asp:Label></th></tr>
                              
                              <tr><th> 
                      <asp:Label ID="Label10" runat="server" Text="Introduzca los Siguientes Datos:" 
                                      Font-Bold="True"></asp:Label> </th><th>
                          </th></tr>
                           <tr><th> 
                      <asp:Label ID="Label9" runat="server" Text="Tìtulo:"></asp:Label> </th><th>
                          <asp:TextBox ID="uxTitulo" runat="server"></asp:TextBox></th></tr>
                          <tr><th> 
                      <asp:Label ID="Label11" runat="server" Text="Descripción:"></asp:Label> </th><th>
                          <asp:TextBox ID="uxDescripcion" runat="server"></asp:TextBox></th></tr>
                          <tr><th> 
                      <asp:Label ID="Label12" runat="server" Text="Porcentaje a Pagar:"></asp:Label> </th><th>
                          <asp:TextBox ID="uxPorcentajeAPagar" runat="server" 
                                      ontextchanged="uxPorcentajeAPagar_TextChanged"></asp:TextBox></th></tr>
                          <tr><th> 
                      <asp:Label ID="Label13" runat="server" Text="Fecha de Pago:"></asp:Label> </th><th>
                          <asp:TextBox ID="uxFechaPago" runat="server"></asp:TextBox></th></tr>
                          <tr><th> 
                      <asp:Label ID="Label14" runat="server" Text="Estado:"></asp:Label> </th><th>
                          <asp:TextBox ID="uxEstado" runat="server" ontextchanged="uxEstado_TextChanged"></asp:TextBox></th></tr>
                          <tr><th> 
                              <asp:Label ID="Label15" runat="server" Text="Monto a Pagar: "></asp:Label>
                                  <asp:Label ID="uxMontoCalculado" runat="server" Text=""></asp:Label>
                       </th><th>
                           <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
                          </th></tr>
                  </table>
              
              
          </div> 
        </div> 
	</div> 
				
			</div> 
		</div> 
    </form>
</asp:Content>
