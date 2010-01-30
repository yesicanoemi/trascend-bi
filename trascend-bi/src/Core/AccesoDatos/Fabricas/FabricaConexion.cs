using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Conexiones;

namespace Core.AccesoDatos.Fabricas
{
    public class FabricaConexion
    {
        /// <summary>
        /// Retornar la conexion de SQL Server
        /// </summary>
        /// <returns>El objeto que realiza la conexion</returns>
        public IConexion getConexionSQLServer()
        {
            return new ConexionSQLServer();
        }

        /// <summary>
        /// Retornar la conexion de Oracle
        /// </summary>
        /// <returns>El objeto que realiza la conexion</returns>
        public IConexion getConexionOracle()
        {
            return new ConexionOracle();
        }
    }
}
