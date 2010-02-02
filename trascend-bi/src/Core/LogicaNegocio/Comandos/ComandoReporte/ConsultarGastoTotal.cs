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
    public class ConsultarGastoTotal : Comando<Core.LogicaNegocio.Entidades.Gasto>
    {
        private Core.LogicaNegocio.Entidades.Gasto gasto;

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarGastoAnual'.</summary>

        public ConsultarGastoTotal()
        { }

        public ConsultarGastoTotal(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            this.gasto = gasto;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarGastoTotal'.</summary>

        public float Ejecutar(string anio)
        {


            //ReporteSQLServer bd = new ReporteSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            float _gasto = iDAOReporte.TotalGastosAnuales(anio);

   
            return _gasto;
        }

        #endregion

    }
}