﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageHeader.master" AutoEventWireup="true" CodeFile="ConsultarEmpleados.aspx.cs" Inherits="Paginas_Empleados_ConsultarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <div class="container subnav"> 
			<div class="content"> 
				<div class="sub-heading"> 
					<h2>Empleados</h2> 
				</div> 
				<div class="subnav-container"> 
				
					<ul id="subnav"> 
  <li><a href="AgregarEmpleados.aspx">Agregar<span></span></a></li> 
  <li><a href="ConsultarEmpleados.aspx" class="active">Consultar<span></span></a></li> 
    <li><a href="EliminarEmpleados.aspx" >Eliminar<span></span></a></li> 
  <li><a href="ModificarEmpleados.aspx" >Modificar<span></span></a></li>
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

