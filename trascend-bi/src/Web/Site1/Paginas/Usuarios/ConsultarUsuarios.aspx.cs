﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Aplicacion;
using Core.LogicaNegocio.Excepciones;

public partial class Paginas_Usuarios_ConsultarUsuarios : PaginaBase, IConsultarUsuario
{

    #region Propiedades

    private ConsultarUsuarioPresenter _presentador;

    private ConsultarUsuarioPresenter _presenter;

    protected const string paginaConsulta = "~/Paginas/Usuarios/ConsultarUsuarios.aspx";


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

    public Label AsteriscoStatus
    {
        get { return uxAsteriscoStatus; }
        set { uxAsteriscoStatus = value; }
    }

    /*public Label AsteriscoLogin
    {
        get { return uxAsteriscoLogin; }
        set { uxAsteriscoLogin = value; }
    }*/

    public Label NombreUsuarioLabel
    {
        get { return uxLoginLabel; }
        set { uxLoginLabel = value; }
    }

    public Label StatusDdLLabel
    {
        get { return uxStatusDdLLabel; }
        set { uxStatusDdLLabel = value; }
    }

    public TextBox NombreUsuario
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public DropDownList StatusDdL
    {
        get { return uxStatusDdL; }
        set { uxStatusDdL = value; }
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

    public CheckBoxList CBLAgregar
    {
        get { return uxCBLAgregar; }
        set { uxCBLAgregar = value; }
    }

    public CheckBoxList CBLConsultar
    {
        get { return uxCBLConsultar; }
        set { uxCBLConsultar = value; }
    }

    public CheckBoxList CBLModificar
    {
        get { return uxCBLModificar; }
        set { uxCBLModificar = value; }
    }

    public CheckBoxList CBLEliminar
    {
        get { return uxCBLEliminar; }
        set { uxCBLEliminar = value; }
    }

    public CheckBoxList CBLReporte
    {
        get { return uxCBLReporte; }
        set { uxCBLReporte = value; }
    }

    public RadioButtonList RbCampoBusqueda
    {
        get { return uxRbCampoBusqueda; }
        set { uxRbCampoBusqueda = value; }
    }

    public Button BotonBuscar
    {
        get { return uxBotonBuscar; }
        set { uxBotonBuscar = value; }
    }

    public RequiredFieldValidator ValidarNombreVacio
    {
        get { return uxRequiredFieldValidator; }
        set { uxRequiredFieldValidator = value; }
    }

    public RequiredFieldValidator ValidarNoSeleccion
    {
        get { return uxRequiredFieldValidator2; }
        set { uxRequiredFieldValidator2 = value; }
    }

    #endregion

    #region Métodos

    protected void PageChangingUsuarios(object sender, GridViewPageEventArgs e)
    {

    }

    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaUsuarioSelecting
                            (uxConsultaUsuario.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        Core.LogicaNegocio.Entidades.Permiso _permiso = new
                               Core.LogicaNegocio.Entidades.Permiso();

        _presenter = new ConsultarUsuarioPresenter();

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

                    _presentador = new ConsultarUsuarioPresenter(this);

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
            Response.Redirect(paginaDefault);
            //throw new PermisoException("No posee privilegios para ver esta pagina", a);
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonAceptar();
    }
    
    protected void uxBotonRegresar_Click(object sender, EventArgs e)
    {
        _presentador.onBotonRegresar();
        //Response.Redirect("~/Paginas/Usuarios/ModificarUsuarios.aspx");

    }
    public void CambiarPagina()
    {
        Response.Redirect(paginaConsulta);

    }

    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    

    protected void uxRbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.CampoBusqueda_Selected();
    }

    #endregion
}