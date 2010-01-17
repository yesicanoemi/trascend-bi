<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="TablaCargos.aspx.cs" Inherits="Paginas_Cargos_TablaCargos" Title="Tabla de cargos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <form id="form1" runat="server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Cargos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarCargos.aspx">Agregar<span></span></a></li> 
  <li><a href="AdministrarCargos.aspx" >Administrar<span></span></a></li> 
  <li><a href="TablaCargos.aspx" class="active">Tabla<span></span></a></li>
</ul> 
						
				</div> 
				
				
				<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Tabla de cargos</h3> 
                    <p class="large">
                        lol
                        
                    </p>
                     <p class="large">
                         Inflación:
                         <asp:TextBox ID="uxInflacion" runat="server"></asp:TextBox>
                         %&nbsp;
                         <asp:Button ID="uxBotonCargar" runat="server" Text="Cargar" />
                        
                    </p>
                     <p class="large">
                         <asp:GridView ID="uxTablaSueldos" runat="server">
                         </asp:GridView>
                        
                    </p> 
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
    </form>
</asp:Content>
