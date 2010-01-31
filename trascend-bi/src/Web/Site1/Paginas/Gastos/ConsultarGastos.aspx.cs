using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Contrato;
using Presentador.Gasto.Vistas;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

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

    public GridView GridViewParametro
    {
        get { return uxGridParamCoincidente; }
        set { throw new System.NotImplementedException(); }
    }

    public GridView GridViewCliente
    {
        get { return uxGridCliente; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaGasto
    {
        get { return uxObjectConsultaGasto; }
        set { uxObjectConsultaGasto = value; }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaGastoSeleccion
    {
        get { return uxObjectParamCoinci; }
        set { uxObjectParamCoinci = value; }
    }

    public ObjectContainerDataSource GetObjectContainerCliente
    {
        get { return uxObjectCliente; }
        set { uxObjectCliente = value; }
    }

    public HtmlTable TablaSeleccionGrid
    {
        get { return uxTablaSeleccion; }
        set { uxTablaSeleccion = value; }
    }
    public HtmlTable TablaConsultaParametro
    {
        get { return uxTablaParametros; }
        set { uxTablaParametros = value; }
    }

    public HtmlTable TablaCliente
    {
        get { return uxTablaCliente; }
        set { uxTablaCliente = value; }
    }

    public HtmlTable TablaInicio
    {
        get { return uxTablaInicio; }
        set { uxTablaInicio = value; }
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
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void parametrizado(object sender, GridViewSelectEventArgs e)
    {
        
        _presenter.busquedaparametrizado(int.Parse(uxGridParamCoincidente.DataKeys[e.NewSelectedIndex].Value.ToString()),"Propuesta");
    }

    protected void parametrizadocliente(object sender, GridViewSelectEventArgs e)
    {
        _presenter.busquedaparametrizado(-1,uxGridCliente.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void verseleccion(object sender, EventArgs e) 
    {
        _presenter.verseleccion();
    }
    protected void GastoDetallado(object sender, GridViewSelectEventArgs e)
    {
        _presenter.GastoDetalle(int.Parse(uxConsultaGasto.DataKeys[e.NewSelectedIndex].Value.ToString()));
    }
}
