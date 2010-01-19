using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Entidades;

public partial class Paginas_Clientes_ConsultarClientes : PaginaBase, IConsultarCliente
{
    private ConsultarClientePresentador _presentador;

    private Cliente _cliente;

    #region propiedades basicas

    public DropDownList opcion
    {
        get { return opcion1; }
        set { opcion1 = value; }
    }
    public DropDownList SeleccionOpcion
    {
        get { return uxSeleccion; }
        set { uxSeleccion = value; }
    }
    public DropDownList SeleccionAreaCliente
    {
        get { return uxSeleccionAreaCliente; }
        set { uxSeleccionAreaCliente = value; }
    }
    public Label TipoConsulta
    {
        get { return LabelTipoConsulta; }
        set { LabelTipoConsulta = value; }
    }
    public Label Seleccion
    {
        get { return LabelSeleccion; }
        set { LabelSeleccion = value; }
    }
    public Label SeleccionArea
    {
        get { return LabelSeleccionAreaCliente; }
        set { LabelSeleccionAreaCliente = value; }
    }
    public Label Rif
    {
        get { return LabelRif; }
        set { LabelRif = value; }
    }
    public Label RifCliente
    {
        get { return LabelRifCliente; }
        set { LabelRifCliente = value; }
    }
    public Label Nombre
    {
        get { return LabelNombre; }
        set { LabelNombre = value; }
    }
    public Label NombreCliente
    {
        get { return LabelNombreCliente; }
        set { LabelNombreCliente = value; }
    }
    public Label CalleAvenida
    {
        get { return LabelCalleAvenida; }
        set { LabelCalleAvenida = value; }
    }
    public Label CalleAvenidaCliente
    {
        get { return LabelCalleAvenidaCliente; }
        set { LabelCalleAvenidaCliente = value; }
    }
    public Label Urbanizacion
    {
        get { return LabelUrbanizacion; }
        set { LabelUrbanizacion = value; }
    }
    public Label UrbanizacionCliente
    {
        get { return LabelUrbanizacionCliente; }
        set { LabelUrbanizacionCliente = value; }
    }
    public Label EdificioCasa
    {
        get { return LabelEdificioCasa; }
        set { LabelEdificioCasa = value; }
    }
    public Label EdificioCasaCliente
    {
        get { return LabelEdificioCasaCliente; }
        set { LabelEdificioCasaCliente = value; }
    }
    public Label PisoApartamento
    {
        get { return LabelPisoApartamento; }
        set { LabelPisoApartamento = value; }
    }
    public Label PisoApartamentoCliente
    {
        get { return LabelPisoApartamentoCliente; }
        set { LabelPisoApartamento = value; }
    }
    public Label Ciudad
    {
        get { return LabelCiudad; }
        set { LabelCiudad = value; }
    }
    public Label CiudadCliente
    {
        get { return LabelCiudadCliente; }
        set { LabelCiudadCliente = value; }
    }
    public Label Telefono
    {
        get { return LabelTelefono; }
        set { LabelTelefono = value; }
    }
    public Label CodTelefonoCliente
    {
        get { return LabelCodTeleClien; }
        set { LabelCodTeleClien = value; }
    }
    public Label TelefonoCliente
    {
        get { return LabelTelefonoTrabajoCliente; }
        set { LabelTelefonoTrabajoCliente = value; }
    }
    public Label AreaNegocio
    {
        get { return LabelAreaNegocio; }
        set { LabelAreaNegocio = value; }
    }
    public Label AreaNegocioCliente
    {
        get { return LabelAreaNegocioCliente; }
        set { LabelAreaNegocioCliente = value; }
    }
    public Label Contacto
    {
        get { return LabelContacto; }
        set { LabelContacto = value; }
    }
    public ListBox ContactoCliente
    {
        get { return ListContactoCliente; }
        set { ListContactoCliente = value; }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        #region trejo
        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 6)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ConsultarClientePresentador(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
        #endregion


    }


    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        uxBotonAceptar.Visible = false;
        uxBotonAceptar2.Visible = true;
        _presentador.BotonSeleccionTipo();
    }

    protected void uxBotonAceptar2_Click(object sender, EventArgs e)
    {
        uxBotonAceptar2.Visible = false;

        if (_presentador.opcionBusqueda() == 0)
        {
            _presentador.BotonAccionConsultaNombre();

        }

        else if (_presentador.opcionBusqueda() == 1)
        {

            _presentador.BotonSeleccionCliente();

            uxBotonAceptar3.Visible = true;
        }

    }

    protected void uxBotonAceptar3_Click(object sender, EventArgs e)
    {

        _presentador.BotonAccionConsulta();
        uxBotonAceptar3.Visible = false;
    }
    protected void opcion1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


}

