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
    class ReporteSQLServer
    {
        #region Propiedades

        #endregion

        #region Constructor

        public ReporteSQLServer()
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

        #region Metodos

    
        /// <summary>
        /// Metodo para el reporte de facturas emitidas en un rango de fechas
        /// </summary>
        /// <param name="entidad">fechas de entidad Factura</param>
        /// <returns>Objeto Factura</returns>
     
        public IList<Core.LogicaNegocio.Entidades.Factura> 
                                                FacturasEmitidas(Factura entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Factura> factura =
                                                new List<Core.LogicaNegocio.Entidades.Factura>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@FechaIngreso1", SqlDbType.SmallDateTime);

                arParms[0].Value = entidad.Fechaingreso.ToShortDateString();

                arParms[1] = new SqlParameter("@FechaIngreso2", SqlDbType.SmallDateTime);

                arParms[1].Value = entidad.Fechapago.ToShortDateString();

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "FacturasEmitidas", arParms);

                while (reader.Read())
                {
                    Factura _factura = new Factura();

                    Propuesta _propuesta = new Propuesta();

                    _factura.Numero = (int)reader["NumeroFactura"];

                    _factura.Titulo = (string)reader["Titulo"];

                    _factura.Descripcion = (string)reader["Descripcion"];

                    _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                    _factura.Estado = (string)reader["Estado"];

                    //_propuesta.Titulo = (string)reader["Titulo"];

                    //_factura.Prop.Titulo = _propuesta.Titulo;

                    factura.Add(_factura);
                }

                return factura;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return factura;

        }

        #endregion

    }
}
