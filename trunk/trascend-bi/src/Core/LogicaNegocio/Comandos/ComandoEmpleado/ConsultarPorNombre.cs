using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarPorNombre : Comando<Empleado>
    {
        private Empleado empleado;
        private IList<Empleado> _empleado2;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarPorNombre()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarPorNombre(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        public IList<Empleado> Ejecutar()
        {
            EmpleadoSQLServer acceso = new EmpleadoSQLServer();
            _empleado2 = acceso.ConsultarPorTipoNombre(empleado);

            return _empleado2;
        }
        #endregion
    }
}
