﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_AgregarFacturas : PaginaBase,IAgregarFactura
{
    AgregarFacturaPresenter _presenter;

    #region Propiedades

    public RadioButtonList RadioButtons
    {
        get { return this.uxRadioButton; }
        set { this.uxRadioButton = value; }
    }

    public TextBox PropuestaBuscar
    {
        get { return this.uxBusqueda; }
        set { this.uxBusqueda = value; }
    }

    public GridView ResultadoFacturas
    {
        get { return this.uxGridFacturas; }
        set { this.uxGridFacturas = value; }
    }

    public GridView ResultadoPropuesta
    {
        get { return this.uxGridPropuesta; }
        set { this.uxGridPropuesta = value; }
    }

    public Button BotonBusqueda
    {
        get { return this.uxBusquedaBoton; }
        set { this.uxBusquedaBoton = value; }
    }

    public Label MontoTotal
    {
        get { return this.uxLabelTotalPagado; }
        set { this.uxLabelTotalPagado = value; }
    }

    public Label PorcentajeTotal
    {
        get { return this.uxLabelPorcentajePagado; }
        set { this.uxLabelPorcentajePagado = value; }
    }

    public Label MontoFaltante
    {
        get { return this.uxLabelMontoRestante; }
        set { this.uxLabelMontoRestante = value; }
    }

    public Label PorcentajeFaltante
    {
        get { return this.uxLabelPorcentajeRestante; }
        set { this.uxLabelPorcentajeRestante = value; }
    }

    public Label FechaEmision
    {
        get { return this.uxFechaEmision; }
        set { this.uxFechaEmision = value; }
    }

    public Label NumeroFactura
    {
        get { return this.uxNumeroFactura; }
        set { this.uxNumeroFactura = value; }
    }

    public TextBox Titulo
    {
        get { return this.uxTitulo; }
        set { this.uxTitulo = value; }
    }

    public TextBox Descripcion
    {
        get { return this.uxDescripcion; }
        set { this.uxDescripcion = value; }
    }

    public TextBox PorcentajePagar
    {
        get { return this.PorcentajePagar; }
        set { this.PorcentajePagar = value; }
    }

    public TextBox FechaPago
    {
        get { return this.uxFechaPago; }
        set { this.uxFechaPago = value; }
    }

    public TextBox Estado
    {
        get { return this.Estado; }
        set { this.Estado = value; }
    }

    public TextBox MontoCalculado
    {
        get { return this.MontoCalculado; }
        set { this.MontoCalculado = value; }
    }


    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {


    }


    public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;


        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 17)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new AgregarFacturaPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }

    protected void uxBusquedaBoton_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }
    protected void uxEstado_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void uxPorcentajeAPagar_TextChanged(object sender, EventArgs e)
    {
        //int montoTotal = int.Parse(this.MontoTotal.Text);
        //int porcentaje = int.Parse(this.PorcentajePagar.Text);
        //this.MontoCalculado.Text = ((porcentaje * montoTotal) / 100).ToString();
    }
}
