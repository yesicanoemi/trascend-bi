using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cliente.ClienteInterface;
using Presentador.Cliente.ClientePresentador;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;




public partial class Paginas_Clientes_AgregarClientes : System.Web.UI.Page,IAgregarCliente
{
    #region Propiedades
    private AgregarClientePresentador _presentador;
    
    #endregion

    #region Informacion Basica se guardan las variables

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

    public DropDownList CiudadCliente
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
        get {return uxTelefonoTrabajo;}
        set { uxTelefonoTrabajo = value; }
    }

    public TextBox CodigoTrabajoCliente
    {
        get { return uxCodTrabajo; }
        set { uxCodTrabajo = value; }
    }
    
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new AgregarClientePresentador(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.IngersarCliente();
        //esponse.Redirect(paginaPrueba);
        
    }

}
