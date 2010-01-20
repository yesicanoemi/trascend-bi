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
                </asp:GridView>
 


                <asp:GridView ID="uxGridFacturas" runat="server"
                AutoGenerateColumns="false"
                         cellpadding="10"
                         cellspacing="5" >
                         
                         <Columns >
                                   <asp:BoundField HeaderText="Numero Factura" DataField="Numero" />
                                   <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                                   <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />       
                                   <asp:BoundField HeaderText="Porcentaje Pagado" DataField="Procentajepagado" />                                    
                                   <asp:BoundField HeaderText="Fecha de Ingresp" DataField="Fechaingreso" /> 
                                   <asp:BoundField HeaderText="Fecha de Pago" DataField="Fechapago" /> 
                                   <asp:BoundField HeaderText="Estado" DataField="Estado"/> 
                                                                                     
                         </Columns>
                </asp:GridView>
             
          </div> 
        </div> 
	</div> 
				
			</div> 
		</div> 
    </form>
</asp:Content>
