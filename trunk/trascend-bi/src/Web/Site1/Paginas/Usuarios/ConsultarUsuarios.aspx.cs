using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;

public partial class Paginas_Usuarios_ConsultarUsuarios : System.Web.UI.Page,IConsultarUsuario
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

    public Label NombreU
    {
        get { return uxUsuario; }
        set { uxUsuario = value; }
    }

    public Label NombreEmpleado
    {
        get { return uxNombreE; }
        set { uxNombreE = value; }
    }

    public Label ApellidoEmpleado
    {
        get { return uxApellidoE; }
        set { uxApellidoE = value; }
    }

    public Label StatusUsuario
    {
        get { return uxStatusU; }
        set { uxStatusU = value; }
    }

    #endregion


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
