using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class FacturasEmitidas : Comando<Core.LogicaNegocio.Entidades.Factura>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Factura factura;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'FacturasEmitidas'.</summary>

        public FacturasEmitidas()
        { }

        public FacturasEmitidas(Core.LogicaNegocio.Entidades.Factura factura)
        {
            this.factura = factura;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'FacturasEmitidas'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Factura> Ejecutar()
        {

            //ReporteSQLServer bd = new ReporteSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            IList<Core.LogicaNegocio.Entidades.Factura> _factura = iDAOReporte.FacturasEmitidas(factura);

            return _factura;
        }

        #endregion

    }
}
