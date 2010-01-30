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

public partial class Paginas_Gastos_ModificarGastos : PaginaBase, IModifcarGasto
{
    private ModificarGastoPresenter _presenter;

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
    public GridView GridViewModificarGasto
    {
        get { return uxModificarGasto; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerModificarGasto
    {
        get { return uxObjectModificarGasto; }
        set { uxObjectModificarGasto = value; }
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

    public DropDownList PropuestaAsociada
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

    public Label CodigoGasto
    {
        get { return uxCodigoGasto; }
        set { uxCodigoGasto = value; }

    }    

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

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }

    #region Eventos

    
    protected void SeleccionarModificarGasto(object sender, GridViewSelectEventArgs e)
    {
        uxBotonAceptar.Enabled = true;
        _presenter.uxObjectModificarGastoSelecting(uxModificarGasto.DataKeys[e.NewSelectedIndex].Value.ToString());

    }
    
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

    #endregion
    
}
