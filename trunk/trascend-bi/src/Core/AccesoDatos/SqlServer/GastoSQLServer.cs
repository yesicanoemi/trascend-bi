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
    class GastoSQLServer
    {


        #region Propiedades

        #endregion

        #region Constructor
        public GastoSQLServer()
        {
        }
        #endregion

        #region Conexion a Base de Datos

        private SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            String lista = conexiones[0].InnerText;
            SqlConnection connection = new SqlConnection(lista);
            connection.Open();

            return connection;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo encargado del llamado al procedimiento de insertarGasto de la base de datos.
        /// Este metodo inserta el gasto que no esta asociado a proyecto.
        /// </summary>
        /// <param name="gasto"></param>
        /// <returns></returns>

        public Gasto IngresarGasto(Gasto gasto)
        {
            Gasto _gasto = new Gasto();
            try
            {
                SqlParameter[] parametros = new SqlParameter[6];

                // Parametros

                parametros[0] = new SqlParameter("@estado", SqlDbType.VarChar);
                parametros[0].Value = gasto.Estado;

                parametros[1] = new SqlParameter("@monto", SqlDbType.Float);
                parametros[1].Value = gasto.Monto;

                parametros[2] = new SqlParameter("@fechaGasto", SqlDbType.DateTime);
                parametros[2].Value = gasto.FechaGasto;

                parametros[3] = new SqlParameter("@fechaIngreso", SqlDbType.DateTime);
                parametros[3].Value = gasto.FechaIngreso;

                parametros[4] = new SqlParameter("@tipo", SqlDbType.VarChar);
                parametros[4].Value = gasto.Tipo;

                parametros[5] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parametros[5].Value = gasto.Descripcion;

                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "InsertarGasto", parametros);

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return _gasto;
        }

        /// <summary>
        /// Metodo encargado del llamado al procedimiento de InsertarGastoPropuesta de la base de datos.
        /// Este metodo inserta un gasto asociado a un proyecto.
        /// </summary>
        /// <param name="gasto"></param>
        /// <returns></returns>

        public Gasto IngresarGastoPropuesta(Gasto gasto)
        {
            Gasto _gasto = new Gasto();
            try
            {
                SqlParameter[] parametros = new SqlParameter[7];

                parametros[0] = new SqlParameter("@estado", SqlDbType.VarChar);
                parametros[0].Value = gasto.Estado;

                parametros[1] = new SqlParameter("@monto", SqlDbType.Float);
                parametros[1].Value = gasto.Monto;

                parametros[2] = new SqlParameter("@fechaGasto", SqlDbType.DateTime);
                parametros[2].Value = gasto.FechaGasto;

                parametros[3] = new SqlParameter("@fechaIngreso", SqlDbType.DateTime);
                parametros[3].Value = gasto.FechaIngreso;

                parametros[4] = new SqlParameter("@tipo", SqlDbType.VarChar);
                parametros[4].Value = gasto.Tipo;

                parametros[5] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parametros[5].Value = gasto.Descripcion;

                parametros[6] = new SqlParameter("@version", SqlDbType.Int);
                parametros[6].Value = gasto.IdVersion;

                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "InsertarGastoPropuesta", parametros);

            }
            catch (SqlException e)
            {
                //System.Console.Write(e);
                _gasto.Codigo = -1;
            }

            return _gasto;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar el gasto de la base de datos accediendo al procedimiento EliminarGasto.
        /// </summary>
        /// <param name="gasto"></param>
        /// <returns></returns>

        public Gasto EliminarGasto(Gasto gasto)
        {
            Gasto _gasto = new Gasto();

            try
            {
                SqlParameter[] parametros = new SqlParameter[1];

                parametros[0] = new SqlParameter("@codigo", SqlDbType.Int);
                parametros[0].Value = gasto.Codigo;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "EliminarGasto", parametros);

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _gasto;
        }


        #endregion
    }
}

