﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Empleado.Vistas;
using Presentador.Empleado.Contrato;

public partial class Paginas_Empleados_ModifcarEmpleados : System.Web.UI.Page,IModificarEmpleado
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

    public TextBox DireccionEmpleado
    {
        get { return uxDireccion; }
        set { uxDireccion = value; }
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
    #endregion

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.ModificarEmpleado();
    }
}
