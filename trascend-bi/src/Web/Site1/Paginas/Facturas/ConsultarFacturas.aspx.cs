using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_ConsultarFacturas : PaginaBase, IConsultarFactura
{

    ConsultarFacturaPresenter _presenter;

    #region Propiedades
    public RadioButtonList ParametroBox
    {
        get { return this.uxParametroBox; }
        set { uxParametroBox = value; }
    }

    public TextBox ParametroTexto
    { 
        get { return this.uxParametroTexto; }
        set { uxParametroTexto = value; } 
    }

    public MultiView MultiViewFacturas 
    {
        get { return this.uxMultiViewFactura; }
        set { throw new System.NotImplementedException(); } 
    }

    public Label TituloPropuesta
    {
        get { return this.lbTituloPropuesta; }
        set { lbTituloPropuesta = value; }
    }

    public Label MontoTotal
    {
        get { return this.lbMontoTotal; }
        set { lbMontoTotal = value; }
    }
    
    public GridView TablaFacturas 
    {
        get { return this.uxTablaFacturas; }
        set { uxTablaFacturas = value; }
    }
    
    public Label Titulo 
    {
        get { return this.lbTitulo; }
        set { lbTitulo = value; }
    }
    
    public Label Descripcion 
    {
        get { return this.lbDescripcion; }
        set { lbDescripcion = value; } 
    }
    
    public Label Porcentaje 
    {
        get { return this.lbPorcentaje; }
        set { lbPorcentaje = value; } 
    }

    public Label FechaIngreso 
    {
        get { return this.lbFechaIngreso; }
        set { lbFechaIngreso = value; } 
    }
    
    public Label FechaPago 
    {
        get { return this.lbFechaPago; }
        set { lbFechaPago = value; }
    }

    public Label Estado 
    { 
        get { return this.lbEstado; }
        set { lbEstado = value; }
    }

    public void Pintar(string mensaje)
    {
        this.lbMensaje.Text = mensaje;
    }

    public bool MensajeVisible
    {
        get { return lbMensaje.Visible; }
        set { lbMensaje.Visible = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Page_Init(object sender, EventArgs e)
    {
       

        MultiViewFacturas.Visible = false;
        ParametroTexto.Visible = false;
        btBotonBuscar.Visible = false;

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == 13)
                {
                    i = usuario.PermisoUsu.Count;

                    _presenter = new ConsultarFacturaPresenter(this);

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

    //protected void uxConsultarxNombreProp_Click(object sender, EventArgs e)
    //{
    //    if (Page.IsValid == true)
    //    {
    //        // if (uxTituloPropuesta.Text == "propuesta1")

    //        _presenter.OnBotonAceptar();

    //        /*else
    //        {
    //            Response.Redirect();
    //        }*/

    //    }
    //}

    public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }

    
    protected void btBotonBuscar_Click(object sender, EventArgs e)
    {
        if (ParametroTexto.Text.Equals(""))
        {
            Pintar("Debe introducir un parametro de busqueda");
            MensajeVisible = true;
        }
        else
        {
            if (ParametroBox.SelectedValue == "1")
            {
                _presenter.CargarTabla();
               

            }
            if (ParametroBox.SelectedValue == "2")
            {
                _presenter.CargarDatos();
                
            }
        }

    }
    protected void uxTablaFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");

    }

    protected string FormatearFecha(DateTime fecha)
    {
        return _presenter.FormatearFechaParaMostrar(fecha);
    }

    protected void uxParametroBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ParametroTexto.Visible = true;
        btBotonBuscar.Visible = true;
    }
}
