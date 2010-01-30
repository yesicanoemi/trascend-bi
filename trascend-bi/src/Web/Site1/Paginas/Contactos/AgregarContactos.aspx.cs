﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_AgregarContactos : PaginaBase, IAgregarContacto
{
    private AgregarPresentador _presentador;


    public TextBox TextBoxNombreContacto
    {
        get { return uxNombreContacto; }
        set { uxNombreContacto = value; }
    }

    public TextBox TextBoxApellidoContacto
    {
        get { return uxApellidoContacto; }
        set { uxApellidoContacto = value; }
    }

    public TextBox TextBoxCargoContacto
    {
        get { return uxCargoContacto; }
        set { uxCargoContacto = value; }
    }

    public TextBox TextBoxAreaNegocio
    {
        get { return uxAreaNegocio; }
        set { uxAreaNegocio = value; }
    }

    public TextBox TextBoxTelfOficina
    {
        get { return uxTelfOficina; }
        set { uxTelfOficina = value; }
    }

    public TextBox TextBoxTelfCelular
    {
        get { return uxTelfCelular; }
        set { uxTelfCelular = value; }
    
    }

    public TextBox TextBoxCodOficina
    {
        get { return uxCodOficina; }
        set { uxCodCel = value; }
    }

    public TextBox TextBoxCodCelular
    {
        get { return uxCodCel; }
        set { uxCodCel = value; }
    }

    public CheckBox CheckBoxFax
    {
        get { return uxFax; }
        set { uxFax = value; }
    }

    public DropDownList DropDownClientes
    {
        get { return uxDropDownClientes; }
        set { uxDropDownClientes = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 9)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new AgregarPresentador(this);
                _presentador.LlenarClientes();

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }


}