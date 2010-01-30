using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ControlesBase_MensajeInformacion : System.Web.UI.UserControl
{
    private string _mensaje;

    private string _estilo;

    private bool _visible;

    public string Mensaje
    {
        get { return _mensaje; }
        set
        {
            _mensaje = value;
            labelMensaje.Text = _mensaje;
        }
    }

    public string Estilo
    {
        set
        {
            _estilo = value;
            labelMensaje.CssClass = _estilo;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public void PintarControl(string mensaje, string estilo)
    {
        Mensaje = mensaje;
        Estilo = estilo;
    }
}
