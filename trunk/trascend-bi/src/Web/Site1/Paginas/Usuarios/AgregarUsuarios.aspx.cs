﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Usuarios_AgregarUsuarios : System.Web.UI.Page, IAgregarUsuario
{

    #region PropiedadesPaginas

    private AgregarUsuarioPresenter _presentador;

    protected const string paginaConsulta = "~/Paginas/Usuarios/AgregarUsuario.aspx";

    #endregion



    #region Informacion Basica

    public TextBox NombreUsuario
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public TextBox ContrasenaUsuario
    {
        get { return uxContrasena; }
        set { uxLogin = value; }
    }


    public MultiView MultiViewAgregar
    {
        get { return uxMultiViewAgregar; }
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
    /// <summary>
    /// Metodo q retorna el nombre del empleado a buscar
    /// </summary>
    public TextBox EmpleadoBuscar
    {
        get { return uxNombreEmpleadoBuscar; }
        set { uxNombreEmpleadoBuscar = value; }
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

    public Label CedulaEmp
    {
        get { return uxCedula; }
        set { uxCedula = value; }
    }

    public Label StatusEmp
    {
        get { return uxStatusE; }
        set { uxStatusE = value; }
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

   
    #endregion

    protected void SelectEmpleados(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaUsuarioSelecting
                            (uxConsultaEmpleado.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new AgregarUsuarioPresenter(this);
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

    public void CambiarPagina()
    {
        Response.Redirect(paginaConsulta);

    }

}
