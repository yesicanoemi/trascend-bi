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
    public class FacturasCobradasAnuales : Comando<Core.LogicaNegocio.Entidades.Factura> //se puede poner solo Factura
    {
        private Core.LogicaNegocio.Entidades.Factura factura;

        #region Constructor
        /// <summary>Constructor de la clase 'FacturasCobradasAnuales'.</summary>
        public FacturasCobradasAnuales()
        {
        
        }

        public FacturasCobradasAnuales(Core.LogicaNegocio.Entidades.Factura factura)
        {
            this.factura = factura;
        }

        #endregion

        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'FacturasCobradasAnuales'.</summary>
        /// 
        public IList<Core.LogicaNegocio.Entidades.Factura> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            IList<Core.LogicaNegocio.Entidades.Factura> _factura = iDAOReporte.ObtenerFacturasCobradas(factura);
            
            return _factura;
        }

        #endregion
    }
}
