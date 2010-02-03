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

public partial class Paginas_Reportes_ReportesEquipo1 : PaginaBase, IReporteEquipo1a
{
    PresentadorReporteEquipo1a _presentador;

    #region Propiedades

    public RadioButtonList RadioButton
    {
        get { return uxradioButton; }
        set { uxradioButton = value; }
    }

    public TextBox TextBoxBusqueda
    {
        get { return uxTextBoxBusqueda; }
        set { uxTextBoxBusqueda = value; }
    }

    public GridView GridViewReportePaquete1a
    {
        get { return uxReportePaquete1a; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerObjectReporte1a
    {
        get { return uxObjectReporte1a; }
        set { uxObjectReporte1a = value; }
    }

    public GridView GridViewConsultarEmpleado
    {
        get { return uxConsultarEmpleado; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetOCConsultarEmp
    {
        get { return uxObjectConsultarEmpleado; }
        set { uxObjectConsultarEmpleado = value; }
    }

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

    #region Métodos

    protected void BuscarClick(object sender, EventArgs e)
    {
        _presentador.OnBotonAceptar();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 33)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new PresentadorReporteEquipo1a(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }

    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    protected void SelectEmpleado(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaUsuariosSelecting
            (int.Parse(uxConsultarEmpleado.DataKeys[e.NewSelectedIndex].Value.ToString()));

    }

    #endregion
}
