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
using System.Security.Principal;

namespace Core.AccesoDatos.SqlServer
{
    public class Conexion
    {
       

        #region Conexion a la Base de Datos

        public SqlConnection GetSqlServerConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connectionSQLServer");

            #region Identificacion de computadora

            string _lista = conexiones[0].InnerText;

            String directorio = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

            string[] lines = directorio.Split('\\');

            String nombreComputadora = lines.ElementAt<String>(0);

            string lista = "Data Source=" + nombreComputadora + "\\SQLEXPRESS;" + _lista;

            #endregion
           
            SqlConnection connection = new SqlConnection(lista);

            connection.Open();

            return connection;
        }

        #endregion
        
    }
}
