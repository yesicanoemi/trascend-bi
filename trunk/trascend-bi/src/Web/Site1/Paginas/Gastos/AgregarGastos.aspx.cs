using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Vistas;
using Presentador.Gasto.Contrato;

public partial class Paginas_Gastos_AgregarGastos : System.Web.UI.Page
{
    private IngresarGastoPresenter _presentador = new IngresarGastoPresenter();

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    _presentador = new IngresarGastoPresenter(this);
    //}

    //protected void Page_Load(object sender, EventArgs e)

    //protected void uxBotonAceptar_Click(object sender, EventArgs e)

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.ingresarGasto();
    }
}
