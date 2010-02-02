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
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            _rol = iDAOReporte.ObtenerRol(_FechaI, _FechaF);
            return _rol;
        }
        #endregion
    }
}
