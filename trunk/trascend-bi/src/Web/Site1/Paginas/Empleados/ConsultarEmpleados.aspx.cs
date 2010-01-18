using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Empleado.Contrato;
using Presentador.Empleado.Vistas;
using Core.LogicaNegocio.Entidades;

public partial class Paginas_Empleados_ConsultarEmpleados : System.Web.UI.Page, IConsultarEmpleado
{
    private  ConsultarEmpleadoPresenter _presenter;
    private Empleado _empleado;
    
    #region Propiedades de la Pagina
    public DropDownList opcion
    {
        get { return opcion1; } 
        set { opcion1 = value; }
    }

    public DropDownList SeleccionCargo
    {
        get { return uxSeleccion; }
        set { uxSeleccion = value; }
    }
    
    public MultiView MultiViewConsultar
    {
        get { return uxMultiViewConsultar; }
        set { throw new System.NotImplementedException(); }
    }

    public GridView GridViewConsultarEmpleado
    {
        get { return uxConsultarEmpleado; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetOCConsultarEmp
    {
        get { return uxObjectConsultarEmpleado; }
        set { uxObjectConsultarEmpleado = value; }
    }

    public TextBox TextBoxParametro
    {
        get { return uxParametro; }
        set { uxParametro = value; }
    }

    public Label LabelSelec
    {
        get { return LabelSeleccion; }
        set { LabelSeleccion = value; }
    }
    public Label LabelParametro
    {
        get { return LabelParametroB; }
        set { LabelParametroB = value; }
    }

    public Label LabelCI
    {
        get { return uxCedEmp; }
        set { uxCedEmp = value; }
    }
    public Label LabelNombre
    {
        get { return uxNombreEmp; }
        set { uxNombreEmp = value; }
    }
    public Label LabelApellido
    {
        get { return uxApellidoEmp; }
        set { uxApellidoEmp = value; }
    }
    public Label LabelNumCuenta
    {
        get { return uxNumCuentaE; }
        set { uxNumCuentaE = value; }
    }
    public Label LabelFechaNac
    {
        get { return uxFecNacE; }
        set { uxFecNacE = value; }
    }
    public Label LabelEstado
    {
        get { return uxEstadoE; }
        set { uxEstadoE = value; }
    }

    public Label LabelDireccion
    {
        get { return uxDirEmp; }
        set { uxDirEmp = value; }
    }

    public Label LabelCargo
    {
        get { return uxCargoEmp; }
        set { uxCargoEmp = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        _presenter = new ConsultarEmpleadoPresenter(this);
    }
    
    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        _presenter.uxObjectConsultaUsuariosSelecting(uxConsultarEmpleado.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        if(opcion1.SelectedIndex == 0)//Busqueda por cedula
        {
            LabelParametroB.Text = "Introduzca Cedula:";
            LabelParametroB.Visible = true;
            uxParametro.Visible = true;
            uxBotonBuscar.Visible = true;
            LabelSeleccion.Visible = false;
            uxSeleccion.Visible = false;
            uxBotonBuscar2.Visible = false;
        }
        if (opcion1.SelectedIndex == 1)//Busqueda por Nombre
        {
            LabelParametroB.Text = "Introduzca Nombre:";
            LabelParametroB.Visible = true;
            uxParametro.Visible = true;
            uxBotonBuscar.Visible = true;
            LabelSeleccion.Visible = false;
            uxSeleccion.Visible = false;
            uxBotonBuscar2.Visible = false;
        }
        if (opcion1.SelectedIndex == 2)//Busqueda por cargo
        {
            LabelParametroB.Visible = false;
            uxParametro.Visible = false;
            uxBotonBuscar.Visible = false;
            LabelSeleccion.Visible = true;
            uxSeleccion.Visible = true;
            uxBotonBuscar2.Visible = true;
        }
         _presenter.BotonSeleccionTipo();
    }
    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presenter.BotonAccionConsulta();
        
    }
}
