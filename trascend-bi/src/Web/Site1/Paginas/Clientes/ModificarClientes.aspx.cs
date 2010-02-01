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

    public TextBox rifCliente
    {
        get { return uxRif; }
        set { uxRif = value; }
    }

    public TextBox NombreCliente
    {
        get { return uxNombreCliente; }
        set { uxNombreCliente = value; }
    }

    public TextBox CalleAvenidaCliente
    {
        get { return uxAvenidaCalle; }
        set { uxAvenidaCalle = value; }
    }

    public TextBox UrbanizacionCliente
    {
        get { return uxUrbanizacion; }
        set { uxUrbanizacion = value; }
    }

    public TextBox EdificioCasaCliente
    {
        get { return uxEdificioCasa; }
        set { uxEdificioCasa = value; }
    }

    public TextBox PisoApartamentoCliente
    {
        get { return uxPisoApartamento; }
        set { uxPisoApartamento = value; }
    }

    public TextBox CiudadCliente
    {
        get { return uxciudad; }
        set { uxciudad = value; }
    }

    public TextBox AreaNegocioCliente
    {
        get { return uxAreaNegocioCliente; }
        set { uxAreaNegocioCliente = value; }
    }

    public TextBox TelefonoTrabajoCliente
    {
        get { return uxTelefonoTrabajo; }
        set { uxTelefonoTrabajo = value; }
    }

    public TextBox CodigoTrabajoCliente
    {
        get { return uxCodTrabajo; }
        set { uxCodTrabajo = value; }
    }

    public TextBox TelefonoCelular
    {
        get { return uxTelefonoCelular; }
        set { uxTelefonoCelular = value; }
    }

    public TextBox CodCelular
    {
        get { return uxCodCelular; }
        set { uxCodCelular = value; }
    }

    public TextBox TelefonoFax
    {
        get { return uxTelefonoFax; }
        set { uxTelefonoFax = value; }
    }

    public TextBox CodFax
    {
        get { return uxCodFax; }
        set { uxCodFax = value; }
    }

    public DropDownList TipoRif
    {
        get { return uxTipoRif; }
        set { uxTipoRif = value; }
    }

    public TextBox CampoBusqueda
    {
        get { return uxCampoBusqueda; }
        set { uxCampoBusqueda = value; }
    }

    public RadioButtonList RbCampoBusqueda
    {
        get { return uxRbCampoBusqueda; }
        set { uxRbCampoBusqueda = value; }
    }

    #endregion




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

        uxCampoBusqueda.Visible = true;
        uxCampoBusqueda.Visible = true;
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
