using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Empleado.Contrato;
using Presentador.Empleado.Vistas;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Empleados_ConsultarEmpleados : PaginaBase, IConsultarEmpleado
{
    private  ConsultarEmpleadoPresenter _presenter;
    
    private Empleado _empleado;

    protected const string paginaConsulta = "~/Paginas/Empleados/ConsultarEmpleados.aspx";
    
    #region Propiedades de la Pagina
    public RadioButtonList opcion
    {
        get { return opcion1; } 
        set { opcion1 = value; }
    }

    /*public DropDownList SeleccionCargo
    {
        get { return uxSeleccion; }
        set { uxSeleccion = value; }
    }*/
    
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
    public TextBox ParametroCedula
    {
        get { return uxParametroCedula; }
        set { uxParametroCedula = value; }

    }

    /*public Label LabelSelec
    {
        get { return LabelSeleccion; }
        set { LabelSeleccion = value; }
    }
    public Label LabelParametro
    {
        get { return LabelParametroB; }
        set { LabelParametroB = value; }
    }*/

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

    public Label LabelDirCalle
    {
        get { return uxDirCalleEmp; }
        set { uxDirCalleEmp = value; }
    }

    public Label LabelDirAve
    {
        get { return uxDirAveEmp; }
        set { uxDirAveEmp = value; }
    }

    public Label LabelDirUrb
    {
        get { return uxDirUrbEmp; }
        set { uxDirUrbEmp = value; }
    }

    public Label LabelDirEdifCasa
    {
        get { return uxDirEdCasaEmp; }
        set { uxDirEdCasaEmp = value; }
    }

    public Label LabelDirPisoApto
    {
        get { return uxDirPisAptoEmp; }
        set { uxDirPisAptoEmp = value; }
    }

    public Label LabelDirCiudad
    {
        get { return uxDirCiudadEmp; }
        set { uxDirCiudadEmp = value; }
    }

    public Label LabelCargo
    {
        get { return uxCargoEmp; }
        set { uxCargoEmp = value; }
    }

    public DropDownList drowListaCargo
    {
        get { return listaCargo; }
        set { listaCargo= value;}
    }
    public Button Aceptar
    {
        get { return uxBotonAceptar; }
        set { uxBotonAceptar = value; }
    }

    public Label LabelSueldoBase
    {
        get { return uxSueldoBase; }
        set { uxSueldoBase = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario = new Core.LogicaNegocio.Entidades.Usuario();
                       usuario = (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

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
    
     protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        _presenter.uxObjectConsultaUsuariosSelecting
            (int.Parse(uxConsultarEmpleado.DataKeys[e.NewSelectedIndex].Value.ToString()));

        

    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
    #region comentado no se usa el habilitador y desabilitador de boton y label
       // if(opcion1.SelectedIndex == 0)//Busqueda por cedula
        //{
           /* LabelParametroB.Text = "Introduzca Cedula:";
            LabelParametroB.Visible = true;
            uxParametro.Visible = true;
            uxBotonBuscar.Visible = true;
            LabelSeleccion.Visible = false;
            uxSeleccion.Visible = false;
            uxBotonBuscar2.Visible = false;*/
        //}
        //if (opcion1.SelectedIndex == 1)//Busqueda por Nombre
        //{
           /* LabelParametroB.Text = "Introduzca Nombre:";
            LabelParametroB.Visible = true;
            uxParametro.Visible = true;
            uxBotonBuscar.Visible = true;
            LabelSeleccion.Visible = false;
            uxSeleccion.Visible = false;
            uxBotonBuscar2.Visible = false;*/
        //}
        //if (opcion1.SelectedIndex == 2)//Busqueda por cargo
        //{
            /*LabelParametroB.Visible = false;
            uxParametro.Visible = false;
            uxBotonBuscar.Visible = false;
            LabelSeleccion.Visible = true;
            uxSeleccion.Visible = true;
            uxBotonBuscar2.Visible = true;*/
        //}
         //_presenter.BotonSeleccionTipo();
    #endregion
        
        _presenter.BotonAccionConsulta();
    
    }

    protected void uxRbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presenter.ChangedSearch();
    }

    /*protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presenter.BotonAccionConsulta();
        
    }*/

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _presenter.ConsultarCargos();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(paginaConsulta);
    }
}

