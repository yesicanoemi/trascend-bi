using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using Microsoft.Practices.Web.UI.WebControls;


public partial class Paginas_Usuarios_ConsultarUsuarios : System.Web.UI.Page, IConsultarUsuario
{

    #region Propiedades

    private ConsultarUsuarioPresenter _presentador;

    #endregion

    #region Informacion Basica

    public TextBox NombreUsuario
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public MultiView MultiViewConsultar
    {
        get { return uxMultiViewConsultar; }
        set { throw new System.NotImplementedException(); }
    }

    public GridView GridViewConsultaEmpleado
    {
        get { return uxConsultaEmpleado; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaEmpleado
    {
        get { return uxObjectConsultaEmpleado; }
        set { uxObjectConsultaEmpleado = value; }
    }

    #endregion

    protected void PageChangingUsuarios(object sender, GridViewPageEventArgs e)
    {
        //_presentador.CargarAgenciasCobro();
        //uxConsultaEmpleado.PageIndex = e.NewPageIndex;
    }

    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaEmpleadoSelecting(uxConsultaEmpleado.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new ConsultarUsuarioPresenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }
}
