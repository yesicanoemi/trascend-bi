using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Contrato;
using Presentador.Gasto.Vistas;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Aplicacion;
using System.Web.UI.HtmlControls;

public partial class Paginas_Gastos_ModificarGastos : PaginaBase, IModifcarGasto
{
    private ModificarGastoPresenter _presenter;
   // private ConsultarGastoPresenter _presenter2;

    #region Propiedades de la Pagina

    public Label LTipoConsulta
    {
        get { return LabelTipoConsulta; }
        set { LabelTipoConsulta = value; }
    }

    public Label LabelInfo
    {
        get { return uxLabelInfo; }
        set {uxLabelInfo = value;}
    }

    public Label LIdVersion
    {
        get { return uxIdVersion; }
        set { uxIdVersion = value; }
    }

    public MultiView ModificarGasto
    {
        get { return uxModificar; }
        set { throw new System.NotImplementedException(); }
    }

    public TextBox BusquedaConsulta
    {
        get { return uxBusquedaConsulta; }
        set { uxBusquedaConsulta = value; }
    }

    public TextBox FechaIngreso
    {
        get { return uxFechaIngreso; }
        set { uxFechaIngreso = value; }    
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

    public TextBox DescripcionGasto
    {
        get { return uxDescripcionGasto; }
        set { uxDescripcionGasto = value; }
    }

    public TextBox FechaGasto2
    {
        get { return uxFechaGasto2; }
        set { uxFechaGasto2 = value; }
    }

    public TextBox MontoGasto
    {
        get { return uxMontoGasto; }
        set { uxMontoGasto = value; }
    }

    public TextBox EstadoGasto
    {
        get { return uxEstadoGasto; }
        set { uxEstadoGasto = value; }
    }

    public TextBox TipoGasto
    {
        get { return uxTipoGasto; }
        set { uxTipoGasto = value; }
    }

    public Label MensajeError
    {
        get { return LabelMensajeError; }
        set { LabelMensajeError = value; }
    }

    public Label CodigoGasto
    {
        get { return uxCodigoGasto; }
        set { uxCodigoGasto = value; }

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

  /*  public HtmlTable TablaSeleccionGrid
    {
        get { return uxTablaSeleccion; }
        set { uxTablaSeleccion = value; }
    }
    public HtmlTable TablaConsultaParametro
    {
        get { return uxTablaParametros; }
        set { uxTablaParametros = value; }
    }*

   public HtmlTable TablaCliente
    {
        get { return uxTablaCliente; }
        set { uxTablaCliente = value; }
    }

    public HtmlTable TablaModificar
    {
        get { return uxmodi; }
        set { uxmodi = value; }
    }*/


    #endregion

      
    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 23)
            {
                i = usuario.PermisoUsu.Count;

                //aqui va la instancia del presentador
                _presenter = new ModificarGastoPresenter(this);
             //   _presenter2 = new ConsultarGastoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }

    #region Eventos

    
  /*  protected void SeleccionarModificarGasto(object sender, GridViewSelectEventArgs e)
    {
        uxBotonAceptar.Enabled = true;
        _presenter.uxObjectModificarGastoSelecting(uxModificarGasto.DataKeys[e.NewSelectedIndex].Value.ToString());

    }*/
    
    protected void uxCheckProyectoGasto_CheckedChanged1(object sender, EventArgs e)
    {

    }

    protected void uxProyectosGasto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presenter.ModificarGasto();
    }  
    
    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {

        _presenter.BuscarInformacion();

    }

    protected void uxModificarGasto(object sender, GridViewSelectEventArgs e)
    {
        _presenter.busquedaparametrizado2(int.Parse(uxConsultaGasto.DataKeys[e.NewSelectedIndex].Value.ToString()), "Propuesta");
    }

    protected void parametrizado(object sender, GridViewSelectEventArgs e)
    {

        _presenter.busquedaparametrizado(int.Parse(uxGridParamCoincidente.DataKeys[e.NewSelectedIndex].Value.ToString()), "Propuesta");
    }

    protected void parametrizadocliente(object sender, GridViewSelectEventArgs e)
    {
        _presenter.busquedaparametrizado(-1, uxGridCliente.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void verseleccion(object sender, EventArgs e)
    {
        _presenter.verseleccion();
    }


    #endregion
    
}
