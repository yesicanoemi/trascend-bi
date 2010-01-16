using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class FacturasEmitidas : Comando<Core.LogicaNegocio.Entidades.Factura>
    {
        private Core.LogicaNegocio.Entidades.Factura factura;

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

            ReporteSQLServer bd = new ReporteSQLServer();

            IList<Core.LogicaNegocio.Entidades.Factura> _factura = bd.FacturasEmitidas(factura);

            return _factura;
        }

        #endregion

    }
}
