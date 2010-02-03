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

    private ReporteGastoAnualPresenter _presenter;

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
    public Label TotalGastosLabel
    {
        get { return uxLabelTotal; }
        set { uxLabelTotal = value; }
    }
    public Label Aviso
    {
        get { return uxAviso; }
        set { uxAviso = value; }
    }
    
    #endregion

    #region Metodos
    public void Mensaje(string msg)
    {
        uxAviso.Visible = true;
        uxAviso.Text = msg;  
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
           (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        Core.LogicaNegocio.Entidades.Permiso _permiso = new
            Core.LogicaNegocio.Entidades.Permiso();

        _presenter = new ReporteGastoAnualPresenter();

        _permiso = _presenter.ConsultarIdPermiso();

        int idPermiso = _permiso.IdPermiso;
            

        bool permiso = false;
        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == idPermiso)
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
        catch (Exception a)
        {
            if (permiso == false)
            { Response.Redirect(paginaSinPermiso); }
            else
            { Response.Redirect(paginaDefault); }

        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonConsulta_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }
    protected void uxReporteGastos3a_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    protected void uxReporteGastos3a_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion
}

