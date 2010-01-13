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
    public class EmpleadoSQLServer
    {
        #region Propiedades

        #endregion
        #region Constructor
        public EmpleadoSQLServer()
        {
        }
        #endregion 

        private SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            string lista = conexiones[0].InnerText;
            SqlConnection connection = new SqlConnection(lista);
            connection.Open();

            return connection;
        }

        #region Metodos
        public Empleado Ingresar(Empleado empleado)
        {
            Empleado _empleado = new Empleado();
            try
            {

                SqlParameter[] arParms = new SqlParameter[1];
                // @ProductID Input Parameter 
                // assign value = 1
                arParms[0] = new SqlParameter("@dina", SqlDbType.Int);
                arParms[0].Value = 1;
                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "ObtenerNombre");
                if (reader.Read())
                {
                    _empleado.Cedula = (int)reader["dina"];
                }
                return _empleado;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _empleado;

        }
        #endregion
    }
}
