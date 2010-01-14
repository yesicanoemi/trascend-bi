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
    public class ContactoSQLServer
    {
        #region Propiedades

        #endregion
        #region Constructor
        public ContactoSQLServer()
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
        /*
        public Contacto Ingresar(Contacto contacto)
        {   
            
            
        }
          */
        #endregion
    }
}
