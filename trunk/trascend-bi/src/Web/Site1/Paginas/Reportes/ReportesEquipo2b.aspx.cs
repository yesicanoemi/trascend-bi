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

public partial class Paginas_Reportes_ReportesEquipo2b : PaginaBase, IReporteGastoFecha
{
    private ReporteGastoFechaPresenter _presentador;
    private DateTime _fechaini;
    private DateTime _fechafin;

    #region Propiedades
    public TextBox FechaInicio
    {
        get { return uxFechaInicio; }
        set { uxFechaInicio = value; }
    }

    public TextBox FechaFin
    {
        get { return uxFechaFin; }
        set { uxFechaFin = value; }
    }

    public GridView GridViewGastoFecha
    {
        get { return uxReporteGastoFecha; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource ObtenerValorDataSource
    {
        get { return uxobject; }
        set { uxobject = value; }
    }
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 36)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ReporteGastoFechaPresenter(this);

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

    protected void uxAceptar_Click(object sender, EventArgs e)
    {
        uxAceptar.Visible = true;

        _presentador.ConsultarGastoFecha(_fechaini, _fechafin);

    }
}
