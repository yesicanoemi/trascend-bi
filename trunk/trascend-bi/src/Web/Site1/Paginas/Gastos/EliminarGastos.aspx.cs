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

    public TextBox BusquedaConsulta
    {
        get { return uxBusquedaConsulta; }
        set { uxBusquedaConsulta = value; }
    }
    public RadioButtonList CheckOpcionBuscar
    {
        get { return uxCheckOpcionBuscar; }
        set { uxCheckOpcionBuscar = value; }
    }
    public Button BotonBuscarDatos
    {
        get { return uxBotonBuscarDatos; }
        set { uxBotonBuscarDatos = value; }
    }
    public GridView GridViewConsultaGasto
    {
        get { return uxEliminarGasto; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaGasto
    {
        get { return uxObjectEliminarGasto; }
        set { uxObjectEliminarGasto = value; }
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
        _presenter.BuscarInformacion();
    }    

    protected void uxEliminarGasto_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        _presenter.eliminarGasto (int.Parse(uxEliminarGasto.DataKeys[e.NewSelectedIndex].Value.ToString()));
    }

    #endregion


}
