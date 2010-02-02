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
    public class ConsultarGastoAnual : Comando<Core.LogicaNegocio.Entidades.Gasto>
    {
        private Core.LogicaNegocio.Entidades.Gasto gasto;

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarGastoAnual'.</summary>

        public ConsultarGastoAnual()
        { }

        public ConsultarGastoAnual(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            this.gasto = gasto;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarGastoAnual'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Gasto> Ejecutar(string anio)
        {

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            IList<Core.LogicaNegocio.Entidades.Gasto> _gasto = iDAOReporte.GastosAnuales(anio);

            return _gasto;
        }

        #endregion

    }
}