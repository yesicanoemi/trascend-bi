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
    class DAOFacturaSQLServer
    {
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

        public Factura IngresarFactura(Factura factura)
        {
            return new Factura(); //por ahora
        }

        public IList<Factura> ConsultarFacturas()
        {
            return new List<Factura>();
        }

        public Factura ConsultarFacturaID(Factura factura)
        {            
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NumeroFactura", SqlDbType.VarChar);

                arParms[0].Value = "%" + factura.Numero + "%";

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarFacturaID", arParms);

                if (reader.Read())
                {
                    factura.Numero = (int)reader["NumeroFactura"];

                    factura.Titulo = (string)reader["Titulo"];

                    factura.Descripcion = (string)reader["Descripcion"];

                    factura.Procentajepagado = (float)reader["Porcentaje"];

                    factura.Fechapago = (DateTime)reader["Fecha"];

                    factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                    factura.Estado = (string)reader["Estado"];

                    factura.Prop.Id = (int)reader["IdPropuesta"];
                }

                return factura;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return factura;        
        }

    }
}
