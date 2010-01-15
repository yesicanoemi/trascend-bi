using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Xml;

namespace Core.AccesoDatos.SqlServer
{
    /// <summary>
    /// Clase en la que se realiza la Conexion con la Base de Datos.
    /// </summary>
    class PropuestaSQLServer
    {
        #region Constructor
        public PropuestaSQLServer()
        {

        }
        #endregion

        #region Conexion
        private SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            string lista = conexiones[0].InnerText;

            SqlConnection connection = new SqlConnection(lista);

            connection.Open();

            return connection;
        }
        #endregion

        /*
        /// <summary>
        /// Metodo para Ingresar Propuesta a la base de datos
        /// </summary>
        /// <param name="propuesta">Entidad Propuesta</param>
        /// <returns></returns>
        public Propuesta IngresarPropuesta(Propuesta propuesta)
        { 
        
        }
        
        public Propuesta ConsultarxNombre(Propuesta propuesta)
        { 
        
        }
       */
    }
}
