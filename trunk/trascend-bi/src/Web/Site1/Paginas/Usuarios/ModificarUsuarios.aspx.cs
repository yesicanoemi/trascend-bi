using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Usuarios_ModificarUsuarios : System.Web.UI.Page, IModificarUsuario
{

    #region Propiedades

    private ModificarUsuarioPresenter _presentador;

    #endregion

    #region Informacion Basica

    public TextBox NombreUsuario
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public MultiView MultiViewModificar
    {
        get { return uxMultiViewModificar; }
        set { throw new System.NotImplementedException(); }
    }

    public GridView GridViewConsultarModificarUsuario
    {
        get { return uxConsultaModificarUsuario; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaModificarUsuario
    {
        get { return uxObjectConsultaModificarUsuario; }
        set { uxObjectConsultaModificarUsuario = value; }
    }

    public Label NombreUsu
    {
        get { return uxNombreU; }
        set { uxNombreU = value; }
    }

    public Label NombreEmp
    {
        get { return uxNombreEmp; }
        set { uxNombreEmp = value; }
    }

    public Label ApellidoEmp
    {
        get { return uxApellidoEmp; }
        set { uxApellidoEmp = value; }
    }

    public Label UsuarioU
    {
        get { return uxStatusU; }
        set { uxStatusU = value; }
    }

    #endregion

    protected void PageChangingUsuarios(object sender, GridViewPageEventArgs e)
    {
        //_presentador.CargarAgenciasCobro();
        //uxConsultaEmpleado.PageIndex = e.NewPageIndex;
    }

    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaModificarUsuarioSelecting(uxConsultaModificarUsuario.DataKeys[e.NewSelectedIndex].Value.ToString());
    }



    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new ModificarUsuarioPresenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }


    #region Miembros de IModificarUsuario

    #endregion
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonAceptar();
    }


    #region Get y Set CheckBox

    /*public CheckBox CbAgregarCargo
    {
        get { return uxcb; }
        set { uxCb = value; }
    }


    */
    #endregion
}
