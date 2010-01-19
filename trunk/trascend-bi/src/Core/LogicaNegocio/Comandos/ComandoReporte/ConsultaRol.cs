using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultaRol
    {
        private IList<string> _rol;
        #region Constructor
        public ConsultaRol(IList<string> entidad)
        {
            _rol = entidad;
        }
        #endregion

        #region Metodos
        public IList<string> Ejecutar(DateTime FechaI, DateTime FechaF)
        {
            ReporteSQLServer acceso = new ReporteSQLServer();
            _rol = acceso.ObtenerRol(FechaI, FechaF);
            return _rol;
        }
        #endregion
    }
}
