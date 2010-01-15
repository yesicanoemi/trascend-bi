using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class Ingresar : Comando<Empleado>
    {
        private Empleado empleado;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Ingresar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Ingresar(Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        public void Ejecutar()
        {
            Empleado _empleado = null;
            EmpleadoSQLServer bd = new EmpleadoSQLServer();
            _empleado = bd.Ingresar(empleado);
        }
        #endregion
    }
}
