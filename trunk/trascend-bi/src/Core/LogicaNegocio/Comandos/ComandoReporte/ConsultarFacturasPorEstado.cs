using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultarFacturasPorEstado : Comando<Factura>
    {
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private bool _tipo;
        public ConsultarFacturasPorEstado(DateTime FechaInicio, DateTime FechaFin, bool tipo)
        {
            this._FechaInicio = FechaInicio;
            this._FechaFin = FechaFin;
            this._tipo = tipo;
 
        }

        public IList<Factura> Ejecutar()
        {

            IList<Factura> listaFacturas;
            FacturaSQLServer bd = new FacturaSQLServer();
            listaFacturas = bd.ConsultarFacturasPorEstado(_FechaInicio,_FechaFin,_tipo);
            return listaFacturas;

        }
    }
}
