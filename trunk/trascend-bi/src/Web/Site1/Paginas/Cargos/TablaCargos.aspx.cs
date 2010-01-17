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
    private int width;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new InflacionCargoPresenter(this);
        width = 0;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        this.Inflacion.Text = "0";
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
    protected void uxBotonCargar_Click(object sender, EventArgs e)
    {
        _presenter.CargarTabla();
    }

    protected void uxTablaSueldos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string s = e.Row.DataItem.ToString();

            if (s.Length > width)
            {
                width = s.Length;
                uxTablaSueldos.Columns[0].ItemStyle.Width = s.Length;
                uxTablaSueldos.Columns[0].ItemStyle.Wrap = false;
            }
        }

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }
}
