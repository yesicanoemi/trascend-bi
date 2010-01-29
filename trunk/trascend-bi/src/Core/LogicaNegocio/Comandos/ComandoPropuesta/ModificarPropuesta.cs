using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

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
            //DAOPropuestaSQLServer conex = new DAOPropuestaSQLServer();
            //_propuesta = conex.ModificarPropuesta(propuesta);

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOPropuesta iDAOPropuesta = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOPropuesta();

            _propuesta = iDAOPropuesta.ModificarPropuesta(propuesta);

            return _propuesta;
        }
        #endregion
    }
}

