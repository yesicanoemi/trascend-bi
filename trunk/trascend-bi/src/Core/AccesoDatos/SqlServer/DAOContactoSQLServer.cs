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
        public Contacto Ingresar(Contacto contacto)
        {
            Contacto _contacto = new Contacto();
            try
            {

                SqlParameter[] arParms = new SqlParameter[6];
                // Parametros 
                arParms[0] = new SqlParameter("@CIContacto", SqlDbType.Int);
                arParms[0].Value = contacto.Cedula;
                arParms[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[1].Value = contacto.Nombre;
                arParms[2] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[2].Value = contacto.Apellido;
                arParms[3] = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);
                arParms[3].Value = contacto.AreaDeNegocio;
                arParms[4] = new SqlParameter("@Cargo", SqlDbType.SmallDateTime);
                arParms[4].Value = contacto.Cargo;
                
                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "InsertarContacto", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _contacto;

        }
        #endregion
    }
}
