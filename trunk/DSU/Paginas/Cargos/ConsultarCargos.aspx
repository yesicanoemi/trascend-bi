﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" Inherits="Paginas_Cargos_ConsultarCargos" Codebehind="ConsultarCargos.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Cargos</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarCargos.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarCargos.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarCargos.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarCargos.aspx" >Modificar<span></span></a></li>
</ul> 
	</div> 
    	<div class="sub-content"> 
             <div class="features_overview"> 
                 <div class="features_overview_right"> 
                    <h3>Consultar cargos</h3> 
                    <p class="large">
                        
                        
                    </p> 
                 </div> 
              </div>
        </div> 
	</div> 
</div> 
</asp:Content>

