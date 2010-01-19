using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarEmpleado : Comando<Empleado>
    {
        private Empleado empleado;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarEmpleado()
        { }

        /// <summary>Constructor de la clase 'Consultar Empleado'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarEmpleado(Empleado _empleado)
        {
            empleado = _empleado;
        }
        #endregion

        #region Metodos
        public Empleado Ejecutar()
        {
            EmpleadoSQLServer acceso = new EmpleadoSQLServer();
            empleado = acceso.ConsultarPorNomCedula(empleado);
            return empleado;
        }
        #endregion
    }
}