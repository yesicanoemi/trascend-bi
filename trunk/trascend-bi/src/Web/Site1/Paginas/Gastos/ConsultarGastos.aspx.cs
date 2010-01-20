using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Contrato;
using Presentador.Gasto.Vistas;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Gastos_ConsultarGastos : PaginaBase, IConsultarGasto
{
    private ConsultarGastoPresenter _presenter;

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
        get { return uxConsultaGasto; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaGasto
    {
        get { return uxObjectConsultaGasto; }
        set { uxObjectConsultaGasto = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 22)
            {
                i = usuario.PermisoUsu.Count;

                //instancia del presentador
                _presenter = new ConsultarGastoPresenter(this);

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
    
    #endregion    
    
}
