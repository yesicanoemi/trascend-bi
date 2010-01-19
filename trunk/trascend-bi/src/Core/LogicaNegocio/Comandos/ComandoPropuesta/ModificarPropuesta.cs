using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class ModificarPropuesta : Comando<Propuesta>
    {
        private Propuesta propuesta;

        #region Constructor

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ModificarPropuesta()
        {
        }

        /// <summary>
        /// Constructor de la clase que recibe la entidad propuesta como parametro 
        /// </summary>
        /// <param name="entidad"></param>
        public ModificarPropuesta(Propuesta entidad)
        {
            propuesta = entidad;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que implementa la ejecución del comando Modificar Propuesta
        /// </summary>
        public Propuesta Ejecutar()
        {
            Propuesta _propuesta;
            PropuestaSQLServer conex = new PropuestaSQLServer();
            _propuesta = conex.ModificarPropuesta(propuesta);
            return _propuesta;
        }
        #endregion
    }
}

