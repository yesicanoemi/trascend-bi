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
    public class ReporteAnualPorPaquetesEmpleadoId : Comando<Core.LogicaNegocio.Entidades.Empleado>
    {
                #region Propiedades

        private Core.LogicaNegocio.Entidades.Empleado empleado;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarContactoxId'.</summary>

        public ReporteAnualPorPaquetesEmpleadoId()
        { }

        public ReporteAnualPorPaquetesEmpleadoId(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ReporteAnualPorPaquetesEmpleadoId'.
        /// </summary>

        public Core.LogicaNegocio.Entidades.Empleado Ejecutar()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado2 =
                                            new Core.LogicaNegocio.Entidades.Empleado();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOReporte iDAOReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            empleado2 = iDAOReporte.ReporteAnualPorPaquetesEmpleadoId(empleado);

            return empleado2;
        }

        #endregion    
    }
}
