﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Inherits="Paginas_Gastos_ModificarGastos" Codebehind="ModificarGastos.aspx.cs" %>

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
                    <p class="large">
                        
                        
                    </p> 
                 </div> 
              </div>
        </div> 
			</div> 
		</div> 
</asp:Content>
