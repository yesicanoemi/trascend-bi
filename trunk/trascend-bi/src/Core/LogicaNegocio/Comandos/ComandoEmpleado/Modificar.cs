using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class Modificar : Comando<Empleado>
    {
        private Empleado empleado;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Modificar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Modificar(Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        public int Ejecutar()
        {
            int _resultado= 0;
            EmpleadoSQLServer bd = new EmpleadoSQLServer();
            _resultado = bd.Modificar(empleado);
            return _resultado;
        }
        #endregion
    }
}
