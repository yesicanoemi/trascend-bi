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
    public class DAOClienteSQLServer
    {
        #region Propiedades

        #endregion
        #region Constructor
        public DAOClienteSQLServer()
        {
        }
        #endregion
        #region Conexion a Base de Datos
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
        #endregion
        #region Metodos
        
        public Cliente Ingresar(Cliente cliente)
        {
            Cliente _cliente = new Cliente();
            try
            { 

                SqlParameter[] arParms = new SqlParameter[8];
                // Parametros 
                arParms[0] = new SqlParameter("@rif", SqlDbType.Int);
                arParms[0].Value = cliente.Rif;
                arParms[1] = new SqlParameter("@nombreCliente", SqlDbType.VarChar);
                arParms[1].Value = cliente.Nombre;
                arParms[2] = new SqlParameter("@CalleAvenidadCliente", SqlDbType.VarChar);
                arParms[2].Value = cliente.CalleAvenidad;
                arParms[3] = new SqlParameter("@UrbanizacionCliente", SqlDbType.VarChar);
                arParms[3].Value = cliente.Urbanizacion;
                arParms[4] = new SqlParameter("@EdificioCasaCliente", SqlDbType.SmallDateTime);
                arParms[4].Value = cliente.EdificioCasa;
                arParms[5] = new SqlParameter("@PisoApartamentoCliente", SqlDbType.VarChar);
                arParms[5].Value = cliente.PisoApartamento;
                arParms[6] = new SqlParameter("@CiudadCliente", SqlDbType.VarChar);
                arParms[6].Value = cliente.Ciudad;
                arParms[7] = new SqlParameter("@AreaNegocioCliente", SqlDbType.VarChar);
                arParms[7].Value = cliente.AreaNegocio;
                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "InsertarCliente", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _cliente;

            
        }
         
        public int Modificar(Cliente cliente)
        {
            int resultado = 0;
            try
            {
                return resultado;
            }
            catch (SqlException e)
            {
            }
            return resultado;
        }
        #endregion
    }
}
