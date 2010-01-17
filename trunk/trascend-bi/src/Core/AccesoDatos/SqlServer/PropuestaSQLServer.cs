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
using System.Net;

namespace Core.AccesoDatos.SqlServer
{
    /// <summary>
    /// Clase en la que se realiza la Conexion con la Base de Datos.
    /// </summary>
    public class PropuestaSQLServer
    {
        List<Propuesta> ListaPropuesta = new List<Propuesta>();

        #region Constructor
        public PropuestaSQLServer()
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
        /// Metodo para Ingresar Propuesta a la base de datos
        /// </summary>
        /// <param name="propuesta">Entidad Propuesta</param>
        /// <returns></returns>
        public Propuesta IngresarPropuesta(Propuesta propuesta)
        {
            //Propuesta _propuesta = new Propuesta();

            SqlParameter[] arparmsP = new SqlParameter[2];

            SqlParameter[] ParamV = new SqlParameter[6];

            DateTime fechaingreso = DateTime.Now;

            //Se definen los parametros
            arparmsP[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);

            arparmsP[0].Value = propuesta.Titulo;

            arparmsP[1] = new SqlParameter("@MontoTotal", SqlDbType.Float);

            arparmsP[1].Value = propuesta.MontoTotal;

            int result = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarPropuesta", arparmsP);

            DbDataReader conexion = SqlHelper.ExecuteReader(GetConnection(), "ConsultarIdPropuesta");

            if (conexion.Read())
            {
                int IdPropuesta;

                IdPropuesta = (int)conexion["maximo"];

                ParamV[0] = new SqlParameter("@Version", SqlDbType.Int);

                ParamV[0].Value = propuesta.Version;

                ParamV[1] = new SqlParameter("@FechaFirma", SqlDbType.DateTime);

                ParamV[1].Value = propuesta.FechaFirma;

                ParamV[2] = new SqlParameter("@FechaIngreso", SqlDbType.DateTime);

                ParamV[2].Value = fechaingreso;

                ParamV[3] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);

                ParamV[3].Value = propuesta.FechaInicio;

                ParamV[4] = new SqlParameter("@FechaFin", SqlDbType.DateTime);

                ParamV[4].Value = propuesta.FechaFin;

                ParamV[5] = new SqlParameter("@IdPropuesta", SqlDbType.DateTime);

                ParamV[5].Value = IdPropuesta;

                int result2 = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarVersion", ParamV);
            }


            return propuesta;


        }
        
        /// <summary>
        /// Metodo para consultar las propuestas
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns>Lista de Propuesta</returns>
        public IList<Propuesta> ConsultarPropuesta()
        {
            try
            {
                DbDataReader conexion = SqlHelper.ExecuteReader( GetConnection(), "ConsultarPropuesta" );
                int i = 0;

                while ( conexion.Read() )
                {

                     Propuesta _Propuesta    = new Propuesta();
                    _Propuesta.Titulo        = ( string )conexion["Titulo"];
                    _Propuesta.Version       = ( string )conexion["NumeroVersion"].ToString();
                    _Propuesta.FechaFirma    = ( DateTime )conexion["FechaFirma"];
                    _Propuesta.FechaInicio   = ( DateTime )conexion["FechaInicio"];
                    _Propuesta.FechaFin      = ( DateTime )conexion["FechaFin"];
                    _Propuesta.MontoTotal    = float.Parse(conexion["Monto"].ToString());
                    _Propuesta.Id            = ( int )conexion["IdPropuesta"];
                    _Propuesta.EquipoTrabajo = BuscarEmpleado(_Propuesta.Id);

                    #region Busqueda del Receptor
                    int j = 0;
                    List<string> ListR = new List<string>();
                    ListR = BuscarReceptor(_Propuesta.Id);
                    for (j = 0; j < ListR.Count; j++)
                    {
                        _Propuesta.NombreReceptor = ListR.ElementAt(j);
                        j++;
                        _Propuesta.ApellidoReceptor = ListR.ElementAt(j);
                        j++;
                        _Propuesta.CargoReceptor = ListR.ElementAt(j);
                    }

                    #endregion
                    ListaPropuesta.Insert( i, _Propuesta );
                    i++;

                }

                return ListaPropuesta;
            }
            catch ( SqlException e )
            {
                throw new Exception( e.ToString() );
            }
        }

        /// <summary>
        /// Metodo para consultar las propuestas ordenadas por fecha de inicio
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public IList<Propuesta> ConsultarPropuestaOrdenadoPorEmision()
        {

            DbDataReader conexion = SqlHelper.ExecuteReader(GetConnection(), "ConsultarPropuesta");
            int i = 0;

            while (conexion.Read())
            {

                 Propuesta _Propuesta  =  new Propuesta();
                _Propuesta.Titulo      = ( string )conexion["Titulo"];
                _Propuesta.Version     = ( string )conexion["NumeroVersion"].ToString();
                _Propuesta.FechaFirma  = ( DateTime )conexion["FechaFirma"];
                _Propuesta.FechaInicio = ( DateTime )conexion["FechaInicio"];
                _Propuesta.FechaFin    = ( DateTime )conexion["FechaFin"];
                _Propuesta.MontoTotal  = float.Parse(conexion["Monto"].ToString());
                _Propuesta.Id          = ( int )conexion["IdPropuesta"];

                ListaPropuesta.Insert(i, _Propuesta);
                i++;

            }

            return ListaPropuesta;
        }

        /// <summary>
        /// Metodo que consulta las propuestas que Tiene Versiones en espera
        /// de Aprobacion o Rechazo
        /// </summary>
        /// <returns>Lista de Propuestas que cumplen con la condicion</returns>
        public IList<Propuesta> ConsultarPropuestaEnEspera()
        {
            try
            {
                DbDataReader conexion = SqlHelper.ExecuteReader
                    ( GetConnection(), "ConsultarPropuestaEspera" );

                int i = 0;

                while ( conexion.Read() )
                {

                    Propuesta _Propuesta     = new Propuesta();
                    _Propuesta.Titulo        = ( string )conexion["Titulo"];
                    _Propuesta.Version       = ( string )conexion["NumeroVersion"].ToString();
                    _Propuesta.FechaFirma    = ( DateTime )conexion["FechaFirma"];
                    _Propuesta.FechaInicio   = ( DateTime )conexion["FechaInicio"];
                    _Propuesta.FechaFin      = ( DateTime )conexion["FechaFin"];
                    _Propuesta.MontoTotal    = float.Parse(conexion["Monto"].ToString());
                    _Propuesta.Id            = ( int )conexion["IdPropuesta"];
                    _Propuesta.EquipoTrabajo = BuscarEmpleado( _Propuesta.Id );

                    #region Busqueda del Receptor

                    int j = 0;
                    List<string> ListR = new List<string>();

                    ListR = BuscarReceptor(_Propuesta.Id);

                    for (j = 0; j < ListR.Count; j++)
                    {
                        _Propuesta.NombreReceptor = ListR.ElementAt(j);
                        j++;
                        _Propuesta.ApellidoReceptor = ListR.ElementAt(j);
                        j++;
                        _Propuesta.CargoReceptor = ListR.ElementAt(j);
                    }

                    #endregion

                    ListaPropuesta.Insert( i, _Propuesta );
                    i++;

                }

                return ListaPropuesta;
            }
            catch ( SqlException e )
            {
                throw new Exception( e.ToString() );
            }
        }
        /// <summary>
        /// Metodo que se encarga de buscar Los empleados de una propuesta en específico
        /// </summary>
        /// <returns></returns>
        private List<Empleado> BuscarEmpleado( int IdPropuesta )
        {
            
            List<Empleado> ListaEmpleado = new List<Empleado>();

            try
            {
                SqlParameter ParamIdPropuesta = new SqlParameter();
                ParamIdPropuesta = new SqlParameter( "@IdPropuesta", SqlDbType.Int );
                ParamIdPropuesta.Value = IdPropuesta;

                DbDataReader conexionempleado =
                    SqlHelper.ExecuteReader
                    ( GetConnection(), "ConsultarEmpleadoVersion", ParamIdPropuesta );

                int j = 0;
                while ( conexionempleado.Read() )
                {
                    Empleado empleado = new Empleado();
                    empleado.Nombre   = ( string )conexionempleado["Nombre"];

                    ListaEmpleado.Insert( j, empleado );
                    j++;
                }

                return ListaEmpleado;

            }
            catch ( SqlException e )
            {
                throw new Exception( e.ToString() );
            }
         
        }
        
        /// <summary>
        /// Metodo que consulta el Receptor de la propuesta
        /// </summary>
        /// <param name="IdPropuesta"> Se envia el id de la propuesta</param>
        /// <returns>Retorna una lista de string que contiene los 3 campos Nombre Apellido y Receptor
        /// la lista es de tipo string ya que no existe la entidad receptor como tal</returns>
        private List<string> BuscarReceptor( int IdPropuesta )
        {
            List<string> ListaReceptor = new List<string>();

            try
            {
                SqlParameter ParamIdPropuestaR = new SqlParameter();

                ParamIdPropuestaR = new SqlParameter("@IdPropuesta", SqlDbType.Int);

                ParamIdPropuestaR.Value = IdPropuesta;
                DbDataReader conexionReceptor =
                    SqlHelper.ExecuteReader
                        ( GetConnection(), "ConsultarReceptorVersion", ParamIdPropuestaR );

                while ( conexionReceptor.Read( ))
                {
                    ListaReceptor.Add( (string)conexionReceptor["NombreReceptor"] );
                    ListaReceptor.Add( (string)conexionReceptor["Apellido"] );
                    ListaReceptor.Add( (string)conexionReceptor["Nombre"] );
                }
                return ListaReceptor;
            }
            catch (SqlException e)
            {
                throw new Exception( e.ToString() );
            }
        }

        /// <summary>
        /// Metodo que Consulta Las Propuestas Y Eliminarlas
        /// </summary>
        /// <param name="ListaRecibida">Recibe una Lista que contiene 
        /// el nombre de la propuesta a eliminar si la lista esta vacia consulta
        /// las propuestas a eliminar, si esta llena elimina la propuesta que contiene la lista</param>
        /// <returns>Lista de propuestas a ser eliminadas</returns>
        public IList<string> ListaEliminar( List<string> ListaRecibida )
        {
            if ( ListaRecibida.Count == 0 )
            {
                try
                {
                    DbDataReader conexion = SqlHelper.ExecuteReader
                            ( GetConnection(), "ConsultarPropuestaEliminar" );
                    List<string> lista = new List<string>();


                    while ( conexion.Read() )
                    {
                        lista.Add( (string)conexion["Titulo"] );
                    }
                    return lista;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.ToString());
                }
            }
            else
            {
                try
                {
                    string TituloParam = ListaRecibida.ElementAt(0);
                    SqlParameter titulo = new SqlParameter();
                    titulo = new SqlParameter("@Titulo", SqlDbType.VarChar);
                    titulo.Value = TituloParam;
                    int result = SqlHelper.ExecuteNonQuery(GetConnection(), "UpdateEstadoPropuesta", titulo);
                    return ListaRecibida;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.ToString());
                }
            }
        }

#endregion
    }
}
