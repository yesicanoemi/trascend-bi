using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultaCargo
    {
        private IList<string> _cargo;
        #region Constructor
        public ConsultaCargo(IList<string> entidad)
        {
            _cargo = entidad;
        }
        #endregion

        #region Metodos
        public IList<string> Ejecutar()
        {
            ReporteSQLServer acceso = new ReporteSQLServer();
            _cargo = acceso.ObtenerCargo();
            return _cargo;
        }
        #endregion
    }
}
