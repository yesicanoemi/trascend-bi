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

                        factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

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

                        factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

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

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarFacturaID", arParms);

                if (reader.Read())
                {
                    factura.Numero = (int)reader["NumeroFactura"];

                    factura.Titulo = (string)reader["Titulo"];

                    factura.Descripcion = (string)reader["Descripcion"];

                    factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

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

        public IList<Factura> ConsultarFacturasxEstado(DateTime desde, DateTime hasta, Boolean cobradas)
        {
            try
            {
                DbDataReader reader;

                if(cobradas)
                    reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarFacturasCobradas");
                else
                    reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarFacturasNoCobradas");
               
                Factura factura;
                Propuesta propuesta;
                IList<Factura> listaFacturas = null;

                while (reader.Read())
                {
                    factura = new Factura();

                    factura.Numero = int.Parse(reader["NumeroFactura"].ToString());
                    factura.Titulo = reader["Titulo"].ToString();
                    factura.Descripcion = reader["Descripcion"].ToString();
                    factura.Estado = reader["Estado"].ToString();
                    factura.Fechapago = DateTime.Parse(reader["Fecha"].ToString());
                    factura.Fechaingreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                    propuesta = new Propuesta();
                    propuesta.Titulo = reader["NombrePropuesta"].ToString();
                    factura.Prop = propuesta;

                    listaFacturas.Add(factura);
                }
                return listaFacturas;
            }
            catch (SqlException e)
            {
                return null;
            }
        
        }

        public Factura IngresarFactura(Factura factura)
        {

            IList<Propuesta> propuestas = ConsultarPropuesta();

            Boolean valido = false;
            try
            {
                foreach (Propuesta propuestaAux in propuestas)
                {
                    if (propuestaAux.Id == factura.Prop.Id)
                    {
                        SqlParameter[] arparms = new SqlParameter[7];

                        arparms[0] = new SqlParameter("@titulo", SqlDbType.VarChar);
                        arparms[0].Value = factura.Titulo;

                        arparms[1] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                        arparms[1].Value = factura.Descripcion;

                        arparms[2] = new SqlParameter("@porcentaje", SqlDbType.Float);
                        arparms[2].Value = factura.Procentajepagado;

                        arparms[3] = new SqlParameter("@fecha", SqlDbType.SmallDateTime);
                        arparms[3].Value = factura.Fechapago.ToShortDateString();

                        arparms[4] = new SqlParameter("@fechaingreso", SqlDbType.SmallDateTime);
                        arparms[4].Value = factura.Fechaingreso.ToShortDateString();

                        arparms[5] = new SqlParameter("@estado", SqlDbType.VarChar);
                        arparms[5].Value = factura.Estado;

                        arparms[6] = new SqlParameter("@idpropuesta", SqlDbType.Int);
                        arparms[6].Value = factura.Prop.Id;

                        int result = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarFactura", arparms);

                        valido = true;
                    }
                }
            }catch (SqlException e)
            {
                System.Console.Write(e);
            }

            if (valido == false)
                return new Factura();
            else 
                return factura;
        }

        public IList<Factura> ConsultarFacturas()
        {
            IList<Factura> facturas = new List<Factura>();

            try
            {
                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarFacturas");
                

                int i = 0;

                while (reader.Read())
                {
                    Factura factura = new Factura();

                    factura.Numero = (int)reader["NumeroFactura"];

                    factura.Titulo = (string)reader["Titulo"];

                    factura.Descripcion = (string)reader["Descripcion"];

                    factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

                    factura.Fechapago = (DateTime)reader["Fecha"];

                    factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                    factura.Estado = (string)reader["Estado"];

                    //factura.Prop = propuesta;

                    facturas.Insert(i, factura);
                    i++;

                }

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
                return new List<Factura>();
            }

            return facturas;
        }

        #endregion

    }
}
