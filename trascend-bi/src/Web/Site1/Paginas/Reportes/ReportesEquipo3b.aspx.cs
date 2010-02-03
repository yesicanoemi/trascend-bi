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

public partial class Paginas_Reportes_ReportesEquipo3b : PaginaBase, IReporteFacturasEmitidas
{

    #region Propiedades

    private ReporteFaturasEmitidasPresenter _presentador;

    private ReporteFaturasEmitidasPresenter _presenter;

    #region Propiedades del Diálogo

    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError.Pintar(codigo, mensaje, actor, detalles);
    }

    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }

    #endregion

    #region Información

    public void PintarInformacion(string mensaje, string estilo)
    {
        uxMensajeInformacion.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisible
    {
        get { return uxMensajeInformacion.Visible; }
        set { uxMensajeInformacion.Visible = value; }
    }

    #endregion

    #endregion
    
    #region Informacion Basica

    public GridView GridViewReporteFactura3b
    {
        get { return uxReporteFactura3b; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerReporteFactura3b
    {
        get { return uxObjectReporte3b; }
        set { uxObjectReporte3b = value; }
    }

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

    #endregion

    #region Métodos

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                   (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        Core.LogicaNegocio.Entidades.Permiso _permiso = new
                                Core.LogicaNegocio.Entidades.Permiso();

        _presenter = new ReporteFaturasEmitidasPresenter();

        _permiso = _presenter.ConsultarIdPermiso();

        int idPermiso = _permiso.IdPermiso;
       

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == idPermiso)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ReporteFaturasEmitidasPresenter(this);

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

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }

    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    #endregion
}
