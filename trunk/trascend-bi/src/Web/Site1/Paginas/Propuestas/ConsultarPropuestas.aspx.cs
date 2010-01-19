using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Propuesta.Contrato;
using Presentador.Propuesta.Vistas;
using Core.LogicaNegocio.Entidades;

public partial class Paginas_Propuestas_ConsultarPropuestas : PaginaBase, IConsultarPropuesta
{
    private ConsultarPropuestaPresentador _presenter;
    private Propuesta _propuesta;
    // private Cliente _cliente;
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
    public Label LabelT
    {
        get { return LabelTitulo; }
        set { LabelTitulo = value; }
    }
    public Label LabelTP
    {
        get { return LabelTituloPropuesta; }
        set { LabelTituloPropuesta = value; }
    }
    public Label LabelV
    {
        get { return LabelVersion; }
        set { LabelVersion = value; }
    }
    public Label LabelVP
    {
        get { return LabelVersionPropuesta; }
        set { LabelVersionPropuesta = value; }
    }
    public Label LabelFFirm
    {
        get { return LabelFechaFirma; }
        set { LabelFechaFirmaPropuesta = value; }
    }
    public Label LabelFFirmP
    {
        get { return LabelFechaFirmaPropuesta; }
        set { LabelFechaFirmaPropuesta = value; }
    }
    public Label LabelRecep
    {
        get { return LabelReceptor; }
        set { LabelReceptor = value; }
    }
    public Label LabelRecepP
    {
        get { return LabelReceptorPropuesta; }
        set { LabelReceptorPropuesta = value; }
    }
    public Label LabelCarg
    {
        get { return LabelCargo; }
        set { LabelCargo = value; }
    }
    public Label LabelCargP
    {
        get { return LabelCargoPropuesta; }
        set { LabelCargoPropuesta = value; }
    }
    public Label LabelFechaI
    {
        get { return LabelFechaIn; }
        set { LabelFechaIn = value; }
    }
    public Label LabelFechaIP
    {
        get { return LabelFechaInP; }
        set { LabelFechaInP = value; }
    }
    public Label LabelFechaFi
    {
        get { return LabelFechaFin; }
        set { LabelFechaFin = value; }
    }
    public Label LabelFechaFiP
    {
        get { return LabelFechaFinP; }
        set { LabelFechaFinP = value; }
    }
    public Label LabelTotalHoras
    {
        get { return LabelTotalH; }
        set { LabelTotalH = value; }
    }
    public Label LabelTotalHorasP
    {
        get { return LabelTotalHP; }
        set { LabelTotalHP = value; }
    }
    public Label LabelMont
    {
        get { return LabelMonto; }
        set { LabelMonto = value; }
    }
    public Label LabelMontP
    {
        get { return LabelMontoP; }
        set { LabelMontoP = value; }
    }
    public Label LabelEquip
    {
        get { return LabelEquipo; }
        set { LabelEquipo = value; }
    }
    public Label LabelParam
    {
        get { return LabelParametro; }
        set { LabelParametro = value; }
    }

    public ListBox ListaEmpleados
    {
        get { return ListEquipoP; }
        set { ListEquipoP = value; }
    }
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 26)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new ConsultarPropuestaPresentador(this);

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
    protected void opcion1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
