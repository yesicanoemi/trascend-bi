using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cargo.Contrato;
using Presentador.Cargo.Vistas;

public partial class Paginas_Cargos_TablaCargos : System.Web.UI.Page , IInflacionCargo
{
    private InflacionCargoPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new InflacionCargoPresenter(this);
    }

    public TextBox Inflacion
    {
        get { return uxInflacion; }
        set { uxInflacion = value; }
    }

    public GridView TablaSueldos
    {
        get { return uxTablaSueldos; }
        set { uxTablaSueldos = value; }
    }
}
