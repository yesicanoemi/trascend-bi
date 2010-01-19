using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Contrato;
using Presentador.Gasto.Vistas;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Gastos_EliminarGastos : PaginaBase, IEliminarGasto
{
    private EliminarGastoPresenter _presenter;

    #region Propiedades de la Pagina

    public Label LTipoConsulta
    {
        get { return LabelTipoConsulta; }
        set { LabelTipoConsulta = value; }
    }

    public DropDownList TipoConsulta
    {
        get { return uxTipoConsulta; }
        set { uxTipoConsulta = value; }
    }

    public Label LSeleccion
    {
        get { return LabelSeleccion; }
        set { LabelSeleccion = value; }
    }

    public DropDownList SeleccionDato
    {
        get { return uxSeleccion; }
        set { uxSeleccion = value; }
    }

    public Label LFechaGasto
    {
        get { return LabelFechaGasto; }
        set { LabelFechaGasto = value; }
    }

    public TextBox FechaGasto
    {
        get { return uxFechaGasto; }
        set { uxFechaGasto = value; }
    }

    public GridView GridViewEliminarGasto
    {
        get { return uxEliminarGasto; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerEliminarGasto
    {
        get { return uxObjectEliminarGasto; }
        set { uxObjectEliminarGasto = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 24)
            {
                i = usuario.PermisoUsu.Count;

                //aqui va la instancia del presentador
                _presenter = new EliminarGastoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }

    #region Eventos

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        uxBotonBuscar.Enabled = false;
        int opcion = _presenter.OpcionSeleccion();

        if ((opcion == 0) || (opcion == 1))
        {
            uxBotonBuscar2.Enabled = true;
        }
        if (opcion == 2)
        {
            uxBotonBuscar3.Enabled = true;
        }
    }
    protected void uxBotonBuscar2_Click(object sender, EventArgs e)
    {
        uxBotonBuscar2.Enabled = false;
        _presenter.BuscarInformacion();
    }
    protected void uxBotonBuscar3_Click(object sender, EventArgs e)
    {
        uxBotonBuscar3.Enabled = false;
        _presenter.BuscarInformacion();
    }

    /*
    protected void EliminarGasto(object sender, GridViewSelectEventArgs e)
    {
        _presenter.eliminarGasto(uxEliminarGasto.DataKeys[e.NewSelectedIndex].Value.ToString());

    }    
    */

    protected void uxEliminarGasto_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        _presenter.eliminarGasto(int.Parse(uxEliminarGasto.DataKeys[e.NewSelectedIndex].Value.ToString()));
    }

    #endregion



}
