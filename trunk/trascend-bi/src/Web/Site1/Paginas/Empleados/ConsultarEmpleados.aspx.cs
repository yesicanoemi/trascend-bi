using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Empleado.Contrato;
using Presentador.Empleado.Vistas;
using Core.LogicaNegocio.Entidades;

public partial class Paginas_Empleados_ConsultarEmpleados : PaginaBase, IConsultarEmpleado
{
    private  ConsultarEmpleadoPresenter _presenter;
    private Empleado _empleado;
    
    #region Propiedades de la Pagina
    public DropDownList opcion
    {
        get { return opcion1; } 
        set { opcion1 = value; }
    }
    public DropDownList SeleccionOpcion
    {
        get { return uxSeleccion; }
        set { uxSeleccion = value; }
    }
    public Label LabelSelec
    {
        get { return LabelSeleccion; }
        set { LabelSeleccion = value; }
    }
    public Label LabelTipoC
    {
        get { return LabelTipoConsulta; }
        set { LabelTipoConsulta = value; }
    }

    public Label LabelCI
    {
        get { return LabelCedulaEmpleado; }
        set { LabelCedulaEmpleado = value; }
    }
    public Label LabelNombre
    {
        get { return LabelNombreEmpleado; }
        set { LabelNombreEmpleado = value; }
    }
    public Label LabeApellido
    {
        get { return LabelApellidoEmpleado; }
        set { LabelApellidoEmpleado = value; }
    }
    public Label LabeNumCuenta
    {
        get { return LabelNumCuentaEmpleado; }
        set { LabelNumCuentaEmpleado = value; }
    }
    public Label LabeFechaNac
    {
        get { return LabelFechaNacEmpleado; }
        set { LabelFechaNacEmpleado = value; }
    }
    public Label LabelEstado
    {
        get { return LabelEstadoEmpleado; }
        set { LabelEstadoEmpleado = value; }
    }

    public Label LabelDireccion
    {
        get { return LabelDirEmpleado; }
        set { LabelDirEmpleado = value; }
    }

    public Label LabelCargo
    {
        get { return LabelCargoEmpleado; }
        set { LabelCargoEmpleado = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 14)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new ConsultarEmpleadoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }
    
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        uxBotonAceptar.Visible = false;
        uxBotonAceptar2.Visible = true;
        _presenter.BotonSeleccionTipo();
    }
    protected void uxBotonAceptar2_Click(object sender, EventArgs e)
    {
        _presenter.BotonAccionConsulta();
    }
}
