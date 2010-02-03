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
    private ModificarClientePresenter _presentador;

    // private Cliente _cliente;

    #region propiedades



    public TextBox IdCliente
    {
        get { return uxIdCliente; }
        set { uxIdCliente = value; }
    }

    public TextBox Valor
    {
        get { return uxValor; }
        set { uxValor = value; }
    }

    public Label LabelNombreCliente
    {
        get { return uxNombreCliente; }
        set { uxNombreCliente = value; }
    }

    public TextBox ConsultaRif
    {
        get { return uxConsultaRif; }
        set { uxConsultaRif = value; }
    }

    public Label RifCliente
    {
        get { return uxRifCliente; }
        set { uxRifCliente = value; }
    }

    public Button BotonBuscar
    {
        get { return uxBotonBuscar; }
        set { uxBotonBuscar = value; }
    }

    public Button BotonVolver
    {
        get { return uxBotonVolver; }
        set { uxBotonVolver = value; }
    }

    public GridView GridCliente
    {
        get { return uxGridCliente; }
        set { uxGridCliente = value; }
    }

    public TextBox rifCliente
    {
        get { return uxRif; }
        set { uxRif = value; }
    }

    public TextBox NombreCliente
    {
        get { return uxNombreCliente0; }
        set { uxNombreCliente0 = value; }
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


    #region Información

    public void PintarInformacion(string mensaje, string estilo)
    {
        uxMensajeInformacion0.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisible
    {
        get { return uxMensajeInformacion0.Visible; }
        set { uxMensajeInformacion0.Visible = value; }
    }


    public void PintarInformacion2(string mensaje, string estilo)
    {
        uxMensajeInformacion1.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisible2
    {
        get { return uxMensajeInformacion1.Visible; }
        set { uxMensajeInformacion1.Visible = value; }
    }

    #endregion


    #region Diálogo

    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError0.Pintar(codigo, mensaje, actor, detalles);
    }

    public bool DialogoVisible
    {
        get { return uxDialogoError0.Visible; }
        set { uxDialogoError0.Visible = value; }
    }

    #endregion


    public ObjectContainerDataSource GetObjectContainerConsultaCliente
    {
        get { return uxObjectConsultaCliente; }
        set { uxObjectConsultaCliente = value; }
    }


    public MultiView MultiViewConsulta
    {
        get { return uxMultiViewConsultar; }
        set { uxMultiViewConsultar = value; }
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
        #region Permisologia
        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 6)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ModificarClientePresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
        #endregion
    }


    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {

        _presentador.OnBotonBuscar();



    }
    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }



    protected void SelectCliente(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaClienteSelecting(uxGridCliente.DataKeys[e.NewSelectedIndex].Value.ToString());
    }



    protected void ClienteGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        _presentador.uxObjectConsultaClienteDeleting(uxGridCliente.DataKeys[e.RowIndex].Value.ToString());

    }





    protected void uxRbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.CampoBusqueda_Selected();
    }


    protected void uxMuestra_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        //_presentador.metodoEnPresendator(int.Parse(uxMuestra.DataKeys[e.NewSelectedIndex].Value.ToString()));

    }

    /* protected void uxTablaClientes_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.DataItem != null)
         {
             string s = e.Row.DataItem.ToString();

             if (s.Length > width)
             {
                 width = s.Length;
                
            //     uxMuestra.Rows[0].ItemStyle.Width = s.Length;
              //   uxMuestra.Rows[0].ItemStyle.Wrap = false;
             }
         }

         if (e.Row.RowIndex % 2 == 0)
             e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
     }

     */

    protected void uxValor_TextChanged(object sender, EventArgs e)
    {

    }


    protected void uxMuestraDireccion_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void uxMuestraCliente_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.ActualizarCliente();
    }
    protected void uxDesactivarCliente_Click(object sender, EventArgs e)
    {
        _presentador.DesactivarCliente();
    }
}

