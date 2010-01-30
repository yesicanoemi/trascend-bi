using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarE : Comando<Empleado>
    {
        #region Propiedades
        private IList<Persona> _Persona;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto de la Clase ConsultarE
        /// </summary>

        public ConsultarE()
        {

        }

        /// <summary>
        /// Constructor de la clase Consultar
        /// </summary>
        /// <param name="empleado">Entidad sobre la cual se aplicara el Comando</param>

        public ConsultarE(IList<Persona> persona)
        {
            _Persona = persona;
        }

        #endregion

        #region Metodos
        public IList<Persona> Ejecutar()
        {
            DAOEmpleadoSQLServer conex = new DAOEmpleadoSQLServer();
            _Persona = conex.ConsultarNombreApellido();

            return _Persona;
        }
        #endregion
    }
}
