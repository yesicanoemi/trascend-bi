using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Propuesta.Contrato;
using Presentador.Propuesta.Vistas;
using Core.LogicaNegocio.Entidades;

public partial class Paginas_Propuestas_ModificarPropuestas : PaginaBase, IModificarPropuesta
{
    private ModificarPropuestaPresentador _presenter;

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

    public TextBox TextBoxTP
    {
        get { return TextBoxTituloPropuesta; }
        set { TextBoxTituloPropuesta = value; }
    }

    public Label LabelV
    {
        get { return LabelVersion; }
        set { LabelVersion = value; }
    }

    public TextBox TextBoxVP
    {
        get { return TextBoxVersionPropuesta; }
        set { TextBoxVersionPropuesta = value; }
    }

    public Label LabelFFirm
    {
        get { return LabelFechaFirma; }
        set { LabelFechaFirma = value; }
    }

    public TextBox TextBoxFFirmP
    {
        get { return TextBoxFechaFirmaPropuesta; }
        set { TextBoxFechaFirmaPropuesta = value; }
    }

    public Label LabelRecep
    {
        get { return LabelReceptor; }
        set { LabelReceptor = value; }
    }

    public TextBox TextBoxRecepP
    {
        get { return TextBoxReceptorPropuesta; }
        set { TextBoxReceptorPropuesta = value; }
    }

    public Label LabelCarg
    {
        get { return LabelCargo; }
        set { LabelCargo = value; }
    }

    public TextBox TextBoxCargP
    {
        get { return TextBoxCargoPropuesta; }
        set { TextBoxCargoPropuesta = value; }
    }

    public Label LabelFechaI
    {
        get { return LabelFechaIn; }
        set { LabelFechaIn = value; }
    }

    public TextBox TextBoxFechaIP
    {
        get { return TextBoxFechaInP; }
        set { TextBoxFechaInP = value; }
    }

    public Label LabelFechaFi
    {
        get { return LabelFechaFin; }
        set { LabelFechaFin = value; }
    }

    public TextBox TextBoxFechaFiP
    {
        get { return TextBoxFechaFinP; }
        set { TextBoxFechaFinP = value; }
    }

    public Label LabelTotalHoras
    {
        get { return LabelTotalH; }
        set { LabelTotalH = value; }
    }

    public TextBox TextBoxTotalHorasP
    {
        get { return TextBoxTotalHP; }
        set { TextBoxTotalHP = value; }
    }

    public Label LabelMont
    {
        get { return LabelMonto; }
        set { LabelMonto = value; }
    }

    public TextBox TextBoxMontP
    {
        get { return TextBoxMontoP; }
        set { TextBoxMontoP = value; }
    }

    public Label LabelEquip
    {
        get { return LabelEquipo; }
        set { LabelEquipo = value; }
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
            if (usuario.PermisoUsu[i].IdPermiso == 27)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new ModificarPropuestaPresentador(this);

                permiso = true;

            }
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
        uxBotonAceptar2.Visible = false;
        BotonModificar.Visible = true;
        _presenter.BotonAccionConsulta();

    }
    protected void opcion1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BotonModificar_Click(object sender, EventArgs e)
    {
        BotonModificar.Visible = true;
        _presenter.AgregarVersion();
    }
}
