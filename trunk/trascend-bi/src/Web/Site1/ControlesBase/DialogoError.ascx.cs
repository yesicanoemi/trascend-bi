using System;
using System.Configuration;


public partial class ControlesBase_DialogoError : System.Web.UI.UserControl
{
    private string _codigoError;
    private string _mensajeError;
    private string _detalles;
    private string _actor;
    static private bool _debug = true;

    #region Propiedades

    public string CodigoError
    {
        get { return _codigoError; }
        set
        {
            _codigoError = "Error:   " + value;
            labelCodigo.Text = _codigoError;
        }
    }


    public string MensajeError
    {
        get { return _mensajeError; }
        set
        {
            _mensajeError = value;
            labelMensaje.Text = _mensajeError;
        }
    }


    private AjaxControlToolkit.ModalPopupExtender ModalPopup
    {
        get { return modalPopup; }
    }


    public string Detalle
    {
        get { return _detalles; }
        set
        {
            _detalles = value;
            detalles.Text = _detalles;
        }
    }


    public string Actor
    {
        get { return _actor; }
        set
        {
            _actor = value;
            labelActor.Text = _actor;
        }
    }

    #endregion

    /// <summary>
    /// Pintar el control
    /// </summary>
    public void Pintar()
    {
        if (!_debug)
        {
            detalles.Visible = false;
        }
        modalPopup.Show();
    }


    /// <summary>
    /// Sobrecarga de Pintar que pinta el control segun los parametros
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="mensaje"></param>
    /// <param name="detalles"></param>
    /// <param name="actor"></param>
    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        CodigoError = codigo;
        MensajeError = mensaje;
        Detalle = detalles;
        Actor = actor;
        Pintar();
    }
    public void Page_Load(object sender, EventArgs e)
    {

    }
}
