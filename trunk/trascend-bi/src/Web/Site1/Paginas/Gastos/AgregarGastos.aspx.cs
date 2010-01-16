using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Vistas;
using Presentador.Propuesta.Vistas;
using Presentador.Gasto.Contrato;

public partial class Paginas_Gastos_AgregarGastos : System.Web.UI.Page, IIngresarGasto
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

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentadorGasto = new IngresarGastoPresenter(this);
    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentadorGasto.ingresarGasto();
    }
    protected void uxCheckProyectoGasto_CheckedChanged(object sender, EventArgs e)
    {
        //_presentadorPropuesta.BuscarPorTitulo
    }
}
