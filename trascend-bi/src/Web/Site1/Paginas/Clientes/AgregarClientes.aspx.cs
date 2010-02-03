using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Presentador.Cliente.ClienteInterface;
//using Presentador.Cliente.ClientePresentador;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;

public partial class Paginas_Clientes_AgregarClientes : PaginaBase, IAgregarCliente
{
    private AgregarClientePresentador _presentador;

    #region Propiedades

    public Button InsertarOtro
    {
        get { return uxInsertarOtro; }
        set { uxInsertarOtro = value; }
    }

    public Button AgregarContactos
    {
        get { return uxAgregarContactos; }
        set { uxAgregarContactos = value; }
    }

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

    public Button Agregar
    {
        get { return uxBotonAceptar; }
        set { uxBotonAceptar = value; }
    }

    #endregion

    #region Propiedades del Dialogo

    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError.Pintar(codigo, mensaje, actor, detalles);
    }

    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }

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

    protected void Page_Init(object sender, EventArgs e)
    {
        #region agrego trejo
        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 5)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new AgregarClientePresentador(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
        #endregion

        //_presentador = new AgregarClientePresentador(this);

    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        //_presentador.IngersarCliente();
        _presentador.OnBotonIngresar();
        //esponse.Redirect(paginaPrueba);
    }

    protected void uxInsertarOtro_Click(object sender, EventArgs e)
    {
        _presentador.PrepararOtraInsercion();
    }
}
