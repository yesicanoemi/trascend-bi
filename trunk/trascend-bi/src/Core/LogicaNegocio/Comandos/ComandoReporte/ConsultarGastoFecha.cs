using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultarGastoFecha : Comando<Gasto>
    {
        private DateTime _fechainicio;

        private DateTime _fechafin;

        private IList<Gasto> _listagasto;

        #region Constructor
        public ConsultarGastoFecha(DateTime fechaini, DateTime fechafin)
        {
            _fechainicio = fechaini;
            _fechafin = fechafin;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Se encarga de instanciar a SQLServer el cual se encargara de la conexion con la base de datos
        /// </summary>
        /// <returns>Retorna una lista de tipo gasto que contiene todos los gastos 
        /// realizados dentro de dos fechas</returns>
        public IList<Gasto> Ejecutar()
        {

            ReporteSQLServer acceso = new ReporteSQLServer();
            _listagasto = acceso.ConsultarGastoFecha(_fechainicio, _fechafin);

            return _listagasto;
        }
        #endregion
    }

}
