﻿using System;
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

        public Gasto IngresarGasto(Gasto gasto)
        {
            Gasto _gasto = new Gasto();
            try
            {
                SqlParameter[] parametros = new SqlParameter[7];

                // Parametros
                parametros[0] = new SqlParameter("@codigo", SqlDbType.Int);
                parametros[0].Value = gasto.Codigo;

                parametros[1] = new SqlParameter("@estado", SqlDbType.VarChar);
                parametros[1].Value = gasto.Estado;

                parametros[2] = new SqlParameter("@monto", SqlDbType.Float);
                parametros[2].Value = gasto.Monto;

                parametros[3] = new SqlParameter("@fechaGasto", SqlDbType.DateTime);
                parametros[3].Value = gasto.FechaGasto;

                parametros[4] = new SqlParameter("@fechaIngreso", SqlDbType.DateTime);
                parametros[4].Value = gasto.FechaIngreso;

                parametros[5] = new SqlParameter("@tipo", SqlDbType.VarChar);
                parametros[5].Value = gasto.Tipo;
                
                parametros[6] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parametros[6].Value = gasto.Descripcion;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "InsertarGasto", parametros);

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return _gasto;
        }

        /*public Gasto ConsultarGasto(Gasto gasto)
        {
            Gasto _gasto = new Gasto();

            try
            {
                SqlParameter parametros = new SqlParameter[5];

                parametros[0] = new SqlParameter("@codigo", SqlDbType.Int);
                parametros[0].Value = gasto.Codigo;

                parametros[1] = new SqlParameter("@estado", SqlDbType.Int);
                parametros[1].Value = gasto.Estado;

                parametros[2] = new SqlParameter("@monto", SqlDbType.Float);
                parametros[2].Value = gasto.Monto;

                parametros[3] = new SqlParameter("@fechaGasto", SqlDbType.DateTime);
                parametros[3].Value = gasto.FechaGasto;

                parametros[5] = new SqlParameter("@tipo", SqlDbType.VarChar);
                parametros[5].Value = gasto.Tipo;

                parametros[6] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parametros[6].Value = gasto.Descripcion;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarGasto", parametros);

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _gasto;
        }*/

        #endregion
    }
}
