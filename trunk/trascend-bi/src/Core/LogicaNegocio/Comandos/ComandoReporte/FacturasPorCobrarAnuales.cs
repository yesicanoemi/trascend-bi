using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class FacturasPorCobrarAnuales : Comando<Core.LogicaNegocio.Entidades.Factura> //se puede poner solo Factura
    {
        private Core.LogicaNegocio.Entidades.Factura factura;
        #region Constructor
        /// <summary>Constructor de la clase 'FacturasPorCobrarAnuales'.</summary>
        public FacturasPorCobrarAnuales()
        { }
        public FacturasPorCobrarAnuales(Core.LogicaNegocio.Entidades.Factura factura)
        {
            this.factura = factura;
        }
        #endregion
        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'FacturasPorCobrarAnuales'.</summary>
        /// 
        public IList<Core.LogicaNegocio.Entidades.Factura> Ejecutar()
        {
            //ReporteSQLServer bd = new ReporteSQLServer();
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();
            IList<Core.LogicaNegocio.Entidades.Factura> _factura = iDAOReporte.ObtenerFacturasPorCobrar(factura);
            return _factura;
        }
        #endregion
    }
}
