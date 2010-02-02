using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultarGastoFecha : Comando<Gasto>
    {
        #region Propiedades

        private DateTime _fechainicio;

        private DateTime _fechafin;

        private IList<Gasto> _listagasto;

        #endregion

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

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            _listagasto = iDAOReporte.ConsultarGastoFecha(_fechainicio, _fechafin);

            return _listagasto;
        }
        #endregion
    }

}
