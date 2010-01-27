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

        #region Constructor

        public ConsultarFacturasPorEstado(DateTime FechaInicio, DateTime FechaFin, bool tipo)
        {
            this._FechaInicio = FechaInicio;
            this._FechaFin = FechaFin;
            this._tipo = tipo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga del metodo ejecutar
        /// </summary>
        /// <returns>Una Lista de la entidad factura</returns>
        public IList<Factura> Ejecutar()
        {

            IList<Factura> listaFacturas;
            DAOFacturaSQLServer bd = new DAOFacturaSQLServer();
            listaFacturas = bd.ConsultarFacturasPorEstado(_FechaInicio,_FechaFin,_tipo);
            return listaFacturas;

        }

        #endregion
    }
}
