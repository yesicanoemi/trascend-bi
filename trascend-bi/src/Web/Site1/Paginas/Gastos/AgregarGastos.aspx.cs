using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Vistas;
using Presentador.Propuesta.Vistas;
using Presentador.Gasto.Contrato;

public partial class Paginas_Gastos_AgregarGastos : PaginaBase, IIngresarGasto
{
    private IngresarGastoPresenter _presentadorGasto;


    #region Informacion Basica

    public TextBox DescripcionGasto
    {
        get { return uxDescripcionGasto; }
        set { uxDescripcionGasto = value; }
    }

    public TextBox FechaGasto
    {
        get { return uxFechaGasto; }
        set { uxFechaGasto = value; }
    }

    public TextBox MontoGasto
    {
        get { return uxMontoGasto; }
        set { uxMontoGasto = value; }
    }

    public DropDownList EstadoGasto
    {
        get { return uxEstadoGasto; }
        set { uxEstadoGasto = value; }
    }

    public DropDownList TipoGasto
    {
        get { return uxTipoGasto; }
        set { uxTipoGasto = value; }
    }

    public ListBox PropuestaAsociada
    {
        get { return uxProyectosGasto; }
        set { uxProyectosGasto = value; }
    }

    public CheckBox AsociarPropuestaGasto
    {
        get { return uxCheckProyectoGasto; }
        set { uxCheckProyectoGasto = value; }
    }

    public Label MensajeError
    {
        get { return LabelMensajeError; }
        set { LabelMensajeError = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 21)
            {
                i = usuario.PermisoUsu.Count;

                _presentadorGasto = new IngresarGastoPresenter(this);
                
                _presentadorGasto.BuscarPropuesta();

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
        _presentadorGasto.ingresarGasto();
    }
    protected void uxProyectosGasto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void uxTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void uxEstadoGasto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void uxCheckProyectoGasto_CheckedChanged1(object sender, EventArgs e)
    {
        if (uxCheckProyectoGasto.Checked)
            uxProyectosGasto.Enabled = false;
    }
}
