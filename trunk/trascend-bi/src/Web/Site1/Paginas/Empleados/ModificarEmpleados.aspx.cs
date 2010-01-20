﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Empleado.Vistas;
using Presentador.Empleado.Contrato;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Empleados_ModifcarEmpleados : PaginaBase,IModificarEmpleado
{
   
    private ModificarEmpleadoPresenter _presentador;
    #region Propiedades
    #region Dialogos
    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }
    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        throw new NotImplementedException();
    }

    public void PintarInformacion(string mensaje, string estilo)
    {
        throw new NotImplementedException();
    }
    #endregion
    #region Informacion Basica

    public TextBox NombreEmpleado
    {
        get { return uxNombreEmpleado; }
        set { uxNombreEmpleado = value; }
    }
    public GridView GridViewConsultarEmpleado
    {
        get { return gvwConsultarEmpleado; }
        set { throw new System.NotImplementedException(); }
    }
    public ObjectContainerDataSource GetOCConsultarEmp
    {
        get { return gvwObjectConsultarEmpleado; }
        set { gvwObjectConsultarEmpleado = value; }
    }
    public DropDownList ComboCargos
    {
        get { return uxCargoEmpleado; }
        set { uxCargoEmpleado = value; }
    }
    public DropDownList ComboBusqueda
    {
        get { return ddlTipoBusqueda; }
        set { ddlTipoBusqueda = value; }
    }
    public DropDownList SeleccionCargo
    {
        get { return ddlSeleccionCargo; }
        set { ddlSeleccionCargo = value; }
    }
    public TextBox NombreEmpleadoBus
    {
        get { return uxNombreCon; }
        set { uxNombreCon = value; }
    }

    public TextBox CedulaEmpleadoBus
    {
        get { return uxCedulaCon; }
        set { uxCedulaCon = value; }
    }

    public TextBox ApellidoEmpleado
    {
        get { return uxApellidoEmpleado; }
        set { uxApellidoEmpleado = value; }
    }

    public TextBox CedulaEmpleado
    {
        get { return uxCedulaEmpleado; }
        set { uxCedulaEmpleado = value; }
    }

    public TextBox CuentaEmpleado
    {
        get { return uxNumCuentaEmpleado; }
        set { uxNumCuentaEmpleado = value; }
    }

    public TextBox SueldoEmpleado
    {
        get { return uxSueldoBase; }
        set { uxSueldoBase = value; }
    }

    public TextBox FechaNacEmpleado
    {
        get { return uxFechaNac; }
        set { uxFechaNac = value; }
    }
    public string RangoSueldo
    {
        get { return lbRangoSueldo.Text; }
        set { lbRangoSueldo.Text = value; }
    }
    public string Id
    {
        get { return lbId.Text; }
        set { lbId.Text = value; }
    }
    public bool RangoVisible
    {
        get { return lbRangoSueldo.Visible; }
        set { lbRangoSueldo.Visible = value; }
    }
    public TextBox AvenidaEmpleado
    {
        get { return uxAvenida; }
        set { uxAvenida = value; }
    }

    public TextBox CalleEmpleado
    {
        get { return uxCalle; }
        set { uxCalle = value; }
    }

    public TextBox CiudadEmpleado
    {
        get { return uxCiudad; }
        set { uxCiudad = value; }
    }

    public TextBox PisoEmpleado
    {
        get { return uxPiso; }
        set { uxPiso = value; }
    }

    public TextBox EdificioEmpleado
    {
        get { return uxEdificio; }
        set { uxEdificio = value; }
    }

    public TextBox UrbanizacionEmpleado
    {
        get { return uxUrbanizacion; }
        set { uxUrbanizacion = value; }
    }

    public TextBox FechaIngresoEmpleado
    {
        get { return uxFechaIngreso; }
        set { uxFechaIngreso = value; }
    }

    public TextBox FechaEgresoEmpleado
    {
        get { return uxFechaEgreso; }
        set { uxFechaEgreso = value; }
    }
    public MultiView MultiViewEmpleado
    {
        get { return uxMultiViewEmpleado ; }
        set { uxMultiViewEmpleado = value; }
    }
    #endregion

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _presentador.ConsultarCargos();
        }
        else
        {
            
        }
    }
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.ModificarEmpleado();
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 15)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new  ModificarEmpleadoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        _presentador.ConsultarEmpleado();
    }
    protected void uxCargoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.ConsultarSueldos();
    }
    protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.CambiarVista(Int32.Parse(ddlTipoBusqueda.SelectedValue));
    }
    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        _presentador.CambiarVista(0);
    }
    protected void btnCambiar2_Click(object sender, EventArgs e)
    {
        _presentador.CambiarVista(0);
    }
    protected void btnCambiar3_Click(object sender, EventArgs e)
    {
        _presentador.CambiarVista(0);
    }
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        _presentador.ConsultarEmpleado();
    }
    protected void btnSubmit2_Click(object sender, EventArgs e)
    {
        _presentador.ConsultarEmpleado();
    }
    protected void ddlSeleccionCargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.ConsultarEmpleado();
    }
    protected void gvwConsultarEmpleado_SelectedIndexChanged1(object sender, EventArgs e)
    {
        _presentador.Consultar();
    }
}
