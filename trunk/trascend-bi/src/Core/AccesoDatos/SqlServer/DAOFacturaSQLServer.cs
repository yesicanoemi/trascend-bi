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
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;

namespace Core.AccesoDatos.SqlServer
{
    public class DAOFacturaSQLServer : IDAOFactura
    {
       

        #region Constructor
        public DAOFacturaSQLServer()
        {
        }
        #endregion

        #region conexion
        public SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connectionSQLServer");

            #region Identificacion de computadora

            string _lista = conexiones[0].InnerText;

            String directorio = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

            string[] lines = directorio.Split('\\');

            String nombreComputadora = lines.ElementAt<String>(0);

            string lista = "Data Source=" + nombreComputadora + "\\SQLEXPRESS;" + _lista;

            #endregion

            SqlConnection connection = new SqlConnection(lista);

            connection.Open();

            return connection;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Metodo que recibe una propuesta y se encarga de buscar las facturas de esa
        /// propuesta por su nombre
        /// </summary>
        /// <param name="propuesta">Propuesta con el nombre </param>
        /// <returns>Lista con las facturas correspondientes a la propuesta</returns>
        public IList<Factura> ConsultarFacturasNomPro(Propuesta propuesta)
        {

            IList<Propuesta> propuestas = ConsultarPropuesta();

            List<Factura> facturas = new List<Factura>();

            try
            {
                foreach (Propuesta propuestaAux in propuestas)
                {
                    if (propuesta.Titulo.Equals(propuestaAux.Titulo))
                    {
                        int i = 0;

                        SqlParameter[] arParms = new SqlParameter[1];

                        arParms[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);

                        arParms[0].Value = propuesta.Titulo;

                        DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                                "ConsultarFacturaNomPro", arParms);

                        while (reader.Read())
                        {
                            Factura factura = new Factura();

                            factura.Numero = int.Parse(reader["IdFactura"].ToString());

                            factura.Titulo = reader["Titulo"].ToString();

                            factura.Descripcion = reader["Descripcion"].ToString();

                            factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

                            factura.Fechapago = DateTime.Parse(reader["Fecha"].ToString());

                            factura.Fechaingreso = DateTime.Parse(reader["FechaIngreso"].ToString());

                            factura.Estado = reader["EstadoFactura"].ToString();

                            factura.Prop.Titulo = reader["TituloPropuesta"].ToString();

                            factura.Prop.MontoTotal = float.Parse(reader["Monto"].ToString());

                            facturas.Add(factura);

                            //reader.NextResult();

                            i++;

                        }

                        //if (facturas.Count == 0)
                        //    throw new ConsultarFacturaADException();
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ConsultarFacturaADException("Error de SQL consultando la factura por el nombre de la propuesta en la Base de Datos",e);
            }
            catch (ConsultarFacturaADException e)
            {
                throw new ConsultarFacturaADException("No se pudo realizar la consulta, se recibio un parametro de busqueda vacio, en este caso, el nombre de la propuesta", e);
            }
            catch (Exception e)
            {
                throw new ConsultarFacturaADException("Error consultando la factura por el ID de la propuesta en la Base de Datos", e);
            }

            return facturas;
        }

        /// <summary>
        /// Metodo que recibe una propuesta y se encarga de buscar las facturas de esa
        /// propuesta por su ID
        /// </summary>
        /// <param name="propuesta">Propuesta con el ID </param>
        /// <returns>Lista con las facturas correspondientes a la propuesta</returns>
        public IList<Factura> ConsultarFacturasIDPro(Propuesta propuesta)
        {

            IList<Propuesta> propuestas = ConsultarPropuesta();

            List<Factura> facturas = new List<Factura>();

            try
            {
                foreach (Propuesta propuestaAux in propuestas)
                {

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

                            factura.Numero = (int)reader["IdFactura"];

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
                        //if (facturas.Count == 0)
                        //    throw new ConsultarFacturaADException();
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ConsultarFacturaADException("Error de SQL consultando la factura por el ID de la propuesta  en la Base de Datos", e);
            }
            catch (ConsultarFacturaADException e)
            {
                throw new ConsultarFacturaADException("No se pudo realizar la consulta, se recibio un parametro de busqueda vacio, en este caso, el ID la propuesta", e);
            }
            catch (Exception e)
            {
                throw new ConsultarFacturaADException("Error consultando la factura por el ID de la propuesta  en la Base de Datos", e);
            }

            return facturas;
        }

        /// <summary>
        /// Metodo que consulta las propuestas
        /// </summary> 
        /// <returns>Lista con las propuestas</returns>
        public IList<Propuesta> ConsultarPropuesta()
        {
            int estado = 1;
            return new DAOPropuestaSQLServer().ConsultarPropuesta(estado);
        }

        /// <summary>
        /// Metodo que recibe una factura con su ID y la busca en la BD
        /// </summary>
        /// <param name="factura">Factura a buscar </param>
        /// <returns>Factura encontrada</returns>
        public Factura ConsultarFacturaID(Factura factura)
        {
            try
            {

                factura.Prop = new Propuesta();

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@IdFactura", SqlDbType.Int);

                arParms[0].Value = factura.Numero;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarFacturaID", arParms);

                if (reader.Read())
                {
                    factura.Numero = int.Parse(reader["IdFactura"].ToString());

                    factura.Titulo = reader["Titulo"].ToString();

                    factura.Descripcion = reader["Descripcion"].ToString();

                    factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

                    factura.Fechapago = DateTime.Parse(reader["Fecha"].ToString());

                    factura.Fechaingreso = DateTime.Parse(reader["FechaIngreso"].ToString());

                    factura.Estado = reader["EstadoFactura"].ToString();

                    factura.Prop.Titulo = reader["TituloPropuesta"].ToString();

                    factura.Prop.MontoTotal = float.Parse(reader["Monto"].ToString());

                }
                else
                    throw new ConsultarFacturaADException();

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
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ConsultarFacturaADException("Error de SQL consultando las propuestas con el fin de utilizarlas para facturas en la Base de Datos", e);
            }
            catch (ConsultarFacturaADException e)
            {
                throw new ConsultarFacturaADException("No se consiguio la factura", e);
            }
            catch (Exception e)
            {
                throw new ConsultarFacturaADException("Error consultando las propuestas con el fin de utilizarlas para facturas en la Base de Datos", e);
            }
            return factura;
        }

        /// <summary>
        /// Metodo utilizado para generar una lista de facturas parametrizada por un rango de fechas
        /// y por el tipo de factura
        /// </summary>
        /// <param name="desde">Fecha Inicial(DateTime)</param>
        /// <param name="hasta">Fecha fin(DateTime)</param>
        /// <param name="cobradas">Si la factura es de tipo "cobrada" true;
        /// Si es de tipo "por cobrar" false</param>
        /// <returns>Una lista de facturas</returns>
        public IList<Factura> ConsultarFacturasPorEstado(DateTime desde, DateTime hasta, Boolean cobradas)
        {
            try
            {
                DbDataReader reader;

                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@Fecha1", SqlDbType.SmallDateTime);
                arParms[0].Value = desde;
                arParms[1] = new SqlParameter("@Fecha2", SqlDbType.SmallDateTime);
                arParms[1].Value = hasta;

                if(cobradas)
                    reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarFacturasCobradas", arParms);
                else
                    reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarFacturasPorCobrar", arParms);
               
                Factura factura;
                Propuesta propuesta;
                IList<Factura> listaFacturas = new List<Factura>();
                DateTime fecha;

                while (reader.Read())
                {
                    factura = new Factura();

                    factura.Numero = int.Parse(reader["IdFactura"].ToString());
                    factura.Titulo = reader["Titulo"].ToString();
                    factura.Descripcion = reader["Descripcion"].ToString();
                    factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());
                    fecha = DateTime.Parse(reader["Fecha"].ToString());
                    factura.Fechapago = DateTime.Parse(fecha.ToShortTimeString());
                    fecha = DateTime.Parse(reader["FechaIngreso"].ToString());
                    factura.Fechaingreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                    factura.Estado = reader["Estado"].ToString();
                    propuesta = new Propuesta();
                    propuesta.Titulo = reader["NombrePropuesta"].ToString();
                    propuesta.MontoTotal = float.Parse(reader["Monto"].ToString());
                    factura.Prop = propuesta;

                    listaFacturas.Add(factura);
                }
                return listaFacturas;
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ConsultarFacturaADException("Error de SQL consultando las facturas por estado en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarFacturaADException("Error consultando las facturas por estado en la Base de Datos", e);
            }
        
        }

        /// <summary>
        /// Metodo que recibe una factura y la ingresa en la BD
        /// </summary>
        /// <param name="factura">Factura a ingresar </param>
        /// <returns>Factura a ingresar</returns>
        public Factura IngresarFactura(Factura factura)
        {

            //IList<Propuesta> propuestas = ConsultarPropuesta();

            try
            {
                //foreach (Propuesta propuestaAux in propuestas)
                //{
                    //if (propuestaAux.Id == factura.Prop.Id)
                    //{
                        SqlParameter[] arparms = new SqlParameter[7];

                        arparms[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);
                        arparms[0].Value = factura.Titulo;

                        arparms[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                        arparms[1].Value = factura.Descripcion;

                        arparms[2] = new SqlParameter("@Porcentaje", SqlDbType.Float);
                        arparms[2].Value = factura.Procentajepagado;

                        arparms[3] = new SqlParameter("@Fecha", SqlDbType.SmallDateTime);
                        arparms[3].Value = factura.Fechapago.ToShortDateString();

                        arparms[4] = new SqlParameter("@FechaIngreso", SqlDbType.SmallDateTime);
                        arparms[4].Value = factura.Fechaingreso.ToShortDateString();

                        arparms[5] = new SqlParameter("@Estado", SqlDbType.VarChar);
                        arparms[5].Value = factura.Estado;

                        arparms[6] = new SqlParameter("@TituloPropuesta", SqlDbType.VarChar);
                        arparms[6].Value = factura.Prop.Id;

                        int result = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarFactura", arparms);

                    //}
                //}
                        return factura;
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.InsertarFacturaADException("Error de SQL insertando factura en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new InsertarFacturaADException("Error insertando factura en la Base de Datos", e);
            }
        }

        /// <summary>
        /// Metodo que consulta las facturas de la BD
        /// </summary>
        /// <returns>Una lista con las facturas de la BD</returns>
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

                    factura.Numero = (int)reader["IdFactura"];

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
                if (facturas.Count == 0)
                    throw new ConsultarFacturaADException();

            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ConsultarFacturaADException("Error de SQL consultando una factura en la Base de Datos", e);
            }
            catch (ConsultarFacturaADException e)
            {
                throw new ConsultarFacturaADException("No se encontraron facturas", e);
            }
            catch (Exception e)
            {
                throw new ConsultarFacturaADException("Error consultando una factura en la Base de Datos", e);
            }

            return facturas;
        }

        /// <summary>
        /// Metodo que recibe una factura y la la modifica en la BD
        /// en este caso modifica el detalle de cobro
        /// </summary>
        /// <param name="factura">Factura a modificar </param>
        /// <returns>Factura modificada</returns>
        public Factura UpdateFactura(Factura factura)
        {
            bool valido = false;
            try
            {               
                SqlParameter[] arparms = new SqlParameter[1];

                arparms[0] = new SqlParameter("@NumeroFactura", SqlDbType.Int);
                arparms[0].Value = factura.Numero;

                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "UpdateFactura", arparms);

                valido = true;                   
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ModificarFacturaADException("Error de SQL modificando una factura en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ModificarFacturaADException("Error modificando una factura en la Base de Datos", e);
            }

            if (valido)
                return factura;
            else
                return new Factura();
        }

        public Factura ModificarEstadoFactura(Factura factura)
        {
            bool valido = false;
            try
            {
                SqlParameter[] arparms = new SqlParameter[2];

                arparms[0] = new SqlParameter("@IdFactura", SqlDbType.Int);
                arparms[0].Value = factura.Numero;

                arparms[1] = new SqlParameter("@Estado", SqlDbType.VarChar);
                arparms[1].Value = factura.Estado;

                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "ModificarEstadoFactura", arparms);

                valido = true;
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos.ModificarFacturaADException("Error de SQL modificando una factura en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new ModificarFacturaADException("Error modificando una factura en la Base de Datos", e);
            }

            if (valido)
                return factura;
            else
                return new Factura();
        }


        #endregion

    }
}
