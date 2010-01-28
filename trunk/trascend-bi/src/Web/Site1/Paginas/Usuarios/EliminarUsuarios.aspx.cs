using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using System.Web.SessionState;
using Microsoft.Practices.Web.UI.WebControls;


public partial class Paginas_Usuarios_EliminarUsuarios : PaginaBase, IEliminarUsuario
{
    private EliminarUsuarioPresenter _presentador;

    #region Propiedades

    public TextBox Login
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }
    
    public MultiView MultiViewEliminar
    { 
        get { return uxMultiViewEliminar;}
        set { uxMultiViewEliminar = value;}
    }

    public GridView GridViewConsultarEliminarUsuario 
    {
        get { return uxConsultaEliminarUsuario;}
        set { uxConsultaEliminarUsuario=value;} 
    }
    public ObjectContainerDataSource GetObjectContainerConsultaEliminarUsuario 
    {
        get { return uxObjectConsultaEliminarUsuario;}
        set { uxObjectConsultaEliminarUsuario=value;} 
    }
    #endregion

    #region InformacionBasica
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

    public void PintarInformacionBotonAceptar(string mensaje, string estilo)
    {
        //uxMensajeInformacionBotonAceptar.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisibleBotonAceptar
    {
       get { return uxMensajeInformacionBotonAceptar.Visible; }
       set { uxMensajeInformacionBotonAceptar.Visible = value; }
    }

    #endregion

    #endregion
    /* public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }*/
    #region Metodos
    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 32)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new EliminarUsuarioPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }
    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        
        _presentador.uxObjectConsultaEliminarUsuarioSelecting
                               (GridViewConsultarEliminarUsuario.DataKeys[e.NewSelectedIndex].Value.ToString());
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







