using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Clientes_ModificarClientes : PaginaBase, IModificarCliente
{

    

    #region propiedades

    private ConsultarClientePresentador _presentador;

    #endregion



    /*

    #region Información Básica

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
        uxMensajeInformacionBotonAceptar.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisibleBotonAceptar
    {
        get { return uxMensajeInformacionBotonAceptar.Visible; }
        set { uxMensajeInformacionBotonAceptar.Visible = value; }
    }

    #endregion
     */ 

    public TextBox NombreCliente
    {
        get { return uxNombreCliente; }
        set { uxNombreCliente = value; }
    }

    public RadioButtonList RbCampoBusqueda
    {
        get { return uxRbCampoBusqueda; }
        set { uxRbCampoBusqueda = value; }
    }
 //   #endregion

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
            if (usuario.PermisoUsu[i].IdPermiso == 7)
            {
                i = usuario.PermisoUsu.Count;

                //Deben colocar aqui la instancia del presentador a usar 

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

        uxNombreCliente.Visible = true;
        uxBotonBuscar.Visible = true;
    }



    protected void uxRbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {

    }

    protected void uxNombreCliente_TextChanged(object sender, EventArgs e)
    {

    }
}
