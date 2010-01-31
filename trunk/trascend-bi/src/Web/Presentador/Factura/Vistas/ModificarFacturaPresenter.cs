using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio;

namespace Presentador.Factura.Vistas
{
    public class ModificarFacturaPresenter
    {

        IModificarFactura _vista;
        Core.LogicaNegocio.Entidades.Propuesta _propuesta;
        Core.LogicaNegocio.Entidades.Factura _factura;

        public ModificarFacturaPresenter(IModificarFactura vista)
        {
            _vista = vista;
        }
    }
        
}








/*factura.Procentajepagado = Int32.Parse(_vista.Porcentaje.Text);
                factura.Fechaingreso = ConvertirToFecha(_vista.FechaIngreso.Text);
                factura.Fechapago = ConvertirToFecha(_vista.FechaPagoFact.Text);
                factura.Titulo = _vista.TituloFactura.Text;
                factura.Descripcion = _vista.Descripcion.Text;
                factura.Estado = _vista.Estado.Text;*/