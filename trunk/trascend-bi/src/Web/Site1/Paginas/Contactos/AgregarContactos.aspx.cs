using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_AgregarContactos : PaginaBase, IAgregarContacto
{

    #region Propiedades

    private AgregarPresentador _presentador;

    protected const string paginaConsulta = "~/Paginas/Contactos/AgregarContactos.aspx";


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

    public TextBox Valor
    {
        get { return uxValor; }
        set { uxValor = value; }
    }

    public Button InsertarOtroC
    {
        get { return uxInsertarOtroC; }
        set { uxInsertarOtroC = value; }
    }

    public Button Insertar
    {
        get { return uxBotonAceptar; }
        set { uxBotonAceptar = value; }
    }

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

    public void PintarInformacion2(string mensaje, string estilo)
    {
        uxMensajeInformacion2.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisible2
    {
        get { return uxMensajeInformacion.Visible; }
        set { uxMensajeInformacion2.Visible = value; }
    }

    #endregion

    #region Diálogo

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



    #endregion


    #region Métodos


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {

        _presentador.Onclick();
    }

    protected void uxInsertarOtroC_Click(object sender, EventArgs e)
    {
        _presentador.NuevaInsercion();
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == 9)
                {
                    i = usuario.PermisoUsu.Count;

                    _presentador = new AgregarPresentador(this);


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

        }
    }

    protected void uxValor_TextChanged(object sender, EventArgs e)
    {

    }

    #endregion

}
