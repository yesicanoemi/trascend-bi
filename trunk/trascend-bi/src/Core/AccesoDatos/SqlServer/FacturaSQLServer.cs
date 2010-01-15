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
    class FacturaSQLServer
    {
        #region conexion
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

        #region metodos

        public Factura IngresarFactura(Factura factura)
        {
            return new Factura(); //por ahora
        }

        public IList<Factura> ConsultarFacturasNomPro(Propuesta propuesta)
        {
            IList<Propuesta> propuestas = ConsultarPropuesta();

            List<Factura> facturas = new List<Factura>();

            foreach (Propuesta propuestaAux in propuestas)
            {
                if (propuesta.Titulo.Equals(propuestaAux.Titulo))
                {
                    int i = 0;

                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@titulo", SqlDbType.VarChar);

                    arParms[0].Value = propuesta.Titulo;

                    DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                            "ConsultarFacturaNomPro", arParms);

                    while (reader.Read())
                    {
                        Factura factura = new Factura();

                        factura.Numero = (int)reader["NumeroFactura"];

                        factura.Titulo = (string)reader["Titulo"];

                        factura.Descripcion = (string)reader["Descripcion"];

                        factura.Procentajepagado = (float)reader["Porcentaje"];

                        factura.Fechapago = (DateTime)reader["Fecha"];

                        factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                        factura.Estado = (string)reader["Estado"];

                        factura.Prop = propuesta;

                        facturas.Insert(i, factura);

                        //reader.NextResult();

                        i++;

                    }
                }
            }

            return facturas;
        }


        public IList<Factura> ConsultarFacturasIDPro(Propuesta propuesta)
        {
            IList<Propuesta> propuestas = ConsultarPropuesta();

            List<Factura> facturas = new List<Factura>();

            foreach (Propuesta propuestaAux in propuestas)
            {
                Console.WriteLine(propuestaAux.Id);

                if (propuesta.Id == propuestaAux.Id)
                {
                    int i = 0;

                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@idpropuesta", SqlDbType.Int);

                    arParms[0].Value = propuesta.Id;

                    DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                            "ConsultarFacturaIDPro", arParms);

                    while (reader.Read())
                    {
                        Factura factura = new Factura();

                        factura.Numero = (int)reader["NumeroFactura"];

                        factura.Titulo = (string)reader["Titulo"];

                        factura.Descripcion = (string)reader["Descripcion"];

                        factura.Procentajepagado = (float)reader["Porcentaje"];

                        factura.Fechapago = (DateTime)reader["Fecha"];

                        factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                        factura.Estado = (string)reader["Estado"];

                        factura.Prop = propuesta;

                        facturas.Insert(i, factura);
                        i++;

                    }
                }
            }

            return facturas;
        }


        public IList<Propuesta> ConsultarPropuesta()
        {
            return new PropuestaSQLServer().ConsultarPropuesta();
        }


        public Factura ConsultarFacturaID(Factura factura)
        {            
            try
            {
                factura.Prop = new Propuesta();

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NumeroFactura", SqlDbType.Int);

                arParms[0].Value = factura.Numero;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), CommandType.StoredProcedure,
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

                IList<Propuesta> propuestas = ConsultarPropuesta();

                List<Factura> facturas = new List<Factura>();

                foreach (Propuesta propuestaAux in propuestas)
                {
                    if (propuestaAux.Id == factura.Prop.Id)
                    {
                        factura.Prop = propuestaAux;
                    }
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
