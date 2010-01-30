using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultarEmpleadoCargoAnual : Comando<Core.LogicaNegocio.Entidades.Cargo>
    {
        #region Propiedades

        private string cargo;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'FacturasEmitidas'.</summary>

        public ConsultarEmpleadoCargoAnual()
        { }

        public ConsultarEmpleadoCargoAnual(string cargo)
        {
            this.cargo = cargo;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'FacturasEmitidas'.</summary>

        public Cargo Ejecutar()
        {
            
            ReporteSQLServer bd = new ReporteSQLServer();

            Cargo _cargo = bd.ConsultarEmpleadoCargoAnual(cargo);

            return _cargo;
        }

        #endregion

    }
}