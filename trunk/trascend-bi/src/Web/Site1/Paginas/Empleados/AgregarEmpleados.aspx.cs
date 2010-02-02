using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Empleado.Contrato;
using Presentador.Empleado.Vistas;

public partial class Paginas_Empleados_AgregarEmpleados : PaginaBase, IAgregarEmpleado
{
    private AgregarEmpleadoPresenter _presentador;
    #region Propiedades
    
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

    public DropDownList ComboCargos
    {
        get { return uxCargoEmpleado; }
        set { uxCargoEmpleado = value; }
    }
    
   /* public Label MensajeError
    {
        get { return LabelMensajeError; }
        set { LabelMensajeError = value; }
    }*/
    public MultiView MultiViewPropuesta
    {
        get { return uxMultiViewPropuesta; }
        set { throw new System.NotImplementedException(); }
    }
    #endregion

    #endregion

    public void Mensaje(string msg)
    {
       // MensajeError.Text = msg;
        //MensajeError.Visible = true;
        //Label lbl = new Label();
        //lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        //Page.Controls.Add(lbl); 
    }
    #region Propiedades del Dialogo

    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError.Pintar(codigo, mensaje, actor, detalles);
    }

    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }

    public void PintarInformacion(string mensaje, string estilo)
    {
        uxMensajeInformacion.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisible
    {
        get { return uxMensajeInformacion.Visible; }
        set { uxMensajeInformacion.Visible = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 13)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new AgregarEmpleadoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

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

        MultiViewPropuesta.ActiveViewIndex = 0;
    }
    
    protected void uxCargoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.ConsultarSueldos(); 
    }
    
    protected void uxBotonSiguiente_Click(object sender, EventArgs e)
    {
        MultiViewPropuesta.ActiveViewIndex = 1;
    }
    
    protected void uxBotonAtras_Click(object sender, EventArgs e)
    {
        MultiViewPropuesta.ActiveViewIndex = 0;
    }
}
