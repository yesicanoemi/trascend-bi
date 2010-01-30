using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Reportes.Contrato;
using Presentador.Reportes.Vistas;




public partial class Paginas_Reportes_ReportesEquipo3a : PaginaBase, IReporteGastoAnual
{
    #region Propiedades

    private ReporteGastoAnualPresenter _presentador;

    #endregion

    #region Informacion Basica

    public GridView GridViewReporteGastos3a
    {
        get { return uxReporteGastos3a; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerReporteGastos3a
    {
        get { return uxObjectReporte3a; }
        set { uxObjectReporte3a = value; }
    }


    public DropDownList AnioGasto
    {
        get { return uxAnios; }
        set { uxAnios = value; }
    }

    public Label TotalGastos
    {
        get { return uxTotal; }
        set { uxTotal = value; }
    }

    #endregion


    public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
           (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 37)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ReporteGastoAnualPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonConsulta_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }
}

