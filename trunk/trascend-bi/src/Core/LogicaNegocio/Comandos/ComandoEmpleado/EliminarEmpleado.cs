using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class EliminarEmpleado : Comando<Empleado>
    {
        private Empleado empleado;
        private int _empleado2;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public EliminarEmpleado()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public EliminarEmpleado(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        public int Ejecutar()
        {
            EmpleadoSQLServer acceso = new EmpleadoSQLServer();
            _empleado2 = acceso.EliminarEmpleado(empleado);

            return _empleado2;
        }
        #endregion
    }
}
