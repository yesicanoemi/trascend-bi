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

    public GridView GridViewConsultaUsuario
    {
        get { return uxConsultaUsuario; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaUsuario
    {
        get { return uxObjectConsultaUsuario; }
        set { uxObjectConsultaUsuario = value; }
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

    #region Metodos

    protected void PageChangingUsuarios(object sender, GridViewPageEventArgs e)
    {
        //_presentador.CargarAgenciasCobro();
        //uxConsultaEmpleado.PageIndex = e.NewPageIndex;
    }

    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaUsuarioSelecting(uxConsultaUsuario.DataKeys[e.NewSelectedIndex].Value.ToString());
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
    
    #endregion

}
