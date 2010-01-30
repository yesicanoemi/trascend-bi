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
        private DateTime _FechaI;
        private DateTime _FechaF;
        #region Constructor
        public ConsultaRol(DateTime FechaI,DateTime FechaF)
        {
            _FechaI = FechaI;
            _FechaF = FechaF;
        }
        #endregion

        #region Metodos
        public IList<string> Ejecutar()
        {
            ReporteSQLServer acceso = new ReporteSQLServer();
            _rol = acceso.ObtenerRol(_FechaI, _FechaF);
            return _rol;
        }
        #endregion
    }
}
