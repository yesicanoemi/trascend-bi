using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Empleado.Contrato;
using Presentador.Empleado.Vistas;

public partial class Paginas_Empleados_AgregarEmpleados : System.Web.UI.Page, IAgregarEmpleado
{
    private AgregarEmpleadoPresenter _presentador;
    #region Propiedades
    #region Dialogos
    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }
    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError.Pintar(codigo, mensaje, actor, detalles);
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

    public string RangoSueldo
    {
        get { return lbRangoSueldo.Text; }
        set { lbRangoSueldo.Text = value; }
    }

    public bool RangoVisible
    {
        get { return lbRangoSueldo.Visible; }
        set { lbRangoSueldo.Visible = value; }
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

    public DropDownList ComboCargos
    {
        get { return uxCargoEmpleado; }
        set { uxCargoEmpleado = value; }
    }
    #endregion

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new AgregarEmpleadoPresenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _presentador.ConsultarCargos();
        }

    }
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.IngresarEmpleado();
    }
    protected void uxCargoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.ConsultarSueldos(); 
    }
}
