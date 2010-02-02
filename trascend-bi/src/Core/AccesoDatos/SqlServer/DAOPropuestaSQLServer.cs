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
using System.Net;
using Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;

namespace Core.AccesoDatos.SqlServer
{
    /// <summary>
    /// Clase en la que se realiza la Conexion con la Base de Datos.
    /// </summary>
    public class DAOPropuestaSQLServer: IDAOPropuesta
    {
        IConexion _conexion = new FabricaConexion().getConexionSQLServer();

        #region Propiedades
        List<Propuesta> ListaPropuesta = new List<Propuesta>();
        #endregion

        #region Constructor

        //Constructor de la clase PropuestaSQLServer

        public DAOPropuestaSQLServer()
        {

        }
        #endregion

        /* #region Conexion

        //Metodo que realiza la Conexion con el manejador de base de datos

        private SqlConnection GetConnection()
        {
            try
            {

            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            string lista = conexiones[0].InnerText;

            SqlConnection connection = new SqlConnection(lista);

            connection.Open();

            return connection;
            }
            catch (SqlException e)
            {
                throw new ConsultarPropuestaBDException("Conexión a la BD Fallida", e);
            }
            catch (Exception e)
            {
                throw new ConsultarPropuestaBDException("Conexión Xml No Encontrada", e);
            }
        }
        #endregion */

        #region Metodos

        /// <summary>
        /// Metodo para Ingresar Propuesta a la base de datos
        /// </summary>
        /// <param name="propuesta">Entidad Propuesta</param>
        /// <returns></returns>
        public Propuesta IngresarPropuesta(Propuesta propuesta,IList<string[]> listaequipo)
        {
            try
              {
            SqlParameter[] arparmsP = new SqlParameter[2];

            SqlParameter[] ParamV = new SqlParameter[6];

            SqlParameter[] ParamR = new SqlParameter[3];

            SqlParameter[] Parametros = new SqlParameter[1];

            //Ingresar Propuesta

            DateTime fechaingreso = DateTime.Now;

            //Se definen los parametros

            arparmsP[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);

            arparmsP[0].Value = propuesta.Titulo;

            arparmsP[1] = new SqlParameter("@MontoTotal", SqlDbType.Float);

            arparmsP[1].Value = propuesta.MontoTotal;

            int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "IngresarPropuesta", arparmsP);

            // Consulta IdPropuesta

            DbDataReader conexion = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarIdPropuesta");

            if (conexion.Read())
            {

                int IdPropuesta;


                IdPropuesta = (int)conexion["maximo"];


                //Insert Version

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

                int result2 = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "IngresarVersion", ParamV);

            }
              else
                 throw new IngresarPropuestaBDException();

            //Consultar el Id del Cargo

            Parametros[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);

            Parametros[0].Value = propuesta.CargoReceptor;

            DbDataReader conex2 = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarIdCargo",
                Parametros);

            if (conex2.Read())
            {
                int IdCargo;

                IdCargo = (int)conex2["IdCargo"];

                // Ingresar Receptor

                ParamR[0] = new SqlParameter("@NombreReceptor", SqlDbType.VarChar);

                ParamR[0].Value = propuesta.NombreReceptor;

                ParamR[1] = new SqlParameter("@ApellidoReceptor", SqlDbType.VarChar);

                ParamR[1].Value = propuesta.ApellidoReceptor;

                ParamR[2] = new SqlParameter("@IdCargo", SqlDbType.Int);

                ParamR[2].Value = IdCargo;

                int result3 = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "IngresarReceptor", ParamR);
            }

             else
               throw new IngresarPropuestaBDException();

            //Ingresar Equipo
            foreach (string[] nombre in listaequipo)
            {
                //for (int i = 0; i < listaequipo.Count; i++)
                //{
                    string Nombre = nombre.ElementAt(0);
                    string Apellido = nombre.ElementAt(1);
                    SqlParameter[] Param = new SqlParameter[2];
                    Param[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);

                    Param[0].Value = Nombre;

                    Param[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);

                    Param[1].Value = Apellido;

                    DbDataReader conex3 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                        "ConsultarIdEmpleado", Param);

                    if (conex3.Read())
                    {
                        int IdEmpleado;

                        IdEmpleado = (int)conex3["IdEmpleado"];

                        DbDataReader conex4 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                            "ConsultarIdVersion");

                        if (conex4.Read())
                        {

                            int IdVersion;

                            IdVersion = (int)conex4["maximo"];

                            SqlParameter[] Param2 = new SqlParameter[4];

                            Param2[0] = new SqlParameter("@IdEmpleado", SqlDbType.Int);

                            Param2[0].Value = IdEmpleado;

                            Param2[1] = new SqlParameter("@IdVersion", SqlDbType.Int);

                            Param2[1].Value = IdVersion;

                            Param2[2] = new SqlParameter("@Rol", SqlDbType.VarChar);

                            Param2[2].Value = propuesta.Rol1;

                            Param2[3] = new SqlParameter("@HorasParticipadas", SqlDbType.Int);

                            Param2[3].Value = propuesta.TotalHoras;

                            int result3 = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                "IngresarEquipo", Param2);
                            //i++;

                        }
                        else
                            throw new IngresarPropuestaBDException();

                    }
                    else
                        throw new IngresarPropuestaBDException();
                //}
            }
            
       }
                 
          catch (SqlException e)
          {
              throw new IngresarPropuestaBDException("Error Ingresando en la Base de datos",e);           
          }
          catch (Exception e)
          {
              throw new IngresarPropuestaBDException("Error ingresando Propuesta", e);
          }
            return propuesta;
           }


        /// <summary>
        /// Metodo Anterior de Consulta de Propuesta Usado Por Factura y Gasto
        /// </summary>
        /// <param name="estado">Estado Aprobada de La Version</param>
        /// <returns>Lista de Propeusta con version Aprobada</returns>
        public IList<Propuesta> ConsultarPropuesta(int estado)
        {
            try
            {
                SqlParameter EstadoP = new SqlParameter();

                EstadoP = new SqlParameter("@Estado", SqlDbType.Int);

                EstadoP.Value = estado;

                DbDataReader conexion = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarPropuesta", EstadoP);
                int i = 0;

                while (conexion.Read())
                {

                    Propuesta _Propuesta = new Propuesta();
                    _Propuesta.Titulo = (string)conexion["Titulo"];
                    _Propuesta.Version = (string)conexion["NumeroVersion"].ToString();
                    _Propuesta.FechaFirma = (DateTime)conexion["FechaFirma"];
                    _Propuesta.FechaInicio = (DateTime)conexion["FechaInicio"];
                    _Propuesta.FechaFin = (DateTime)conexion["FechaFin"];
                    _Propuesta.MontoTotal = float.Parse(conexion["Monto"].ToString());
                    _Propuesta.Id = (int)conexion["IdPropuesta"];
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
                    ListaPropuesta.Insert(i, _Propuesta);
                    i++;

                }

                return ListaPropuesta;

            }
            catch (SqlException e)
            {
                throw new ConsultarPropuestaBDException("Error En acceso a Base de Datos", e);
            }
        }

        /// <summary>
        /// Metodo para consultar las propuestas
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns>Lista de Propuesta</returns>
        public IList<Propuesta> ConsultarPropuestaNueva(int Opcion, string parametro)
        {
            try
            {
                SqlParameter ParametroBusqueda = new SqlParameter();

                ParametroBusqueda = new SqlParameter("@Parametro", SqlDbType.VarChar);

                ParametroBusqueda.Value = parametro;
                DbDataReader conexion = null;

                if (Opcion == 1) // Nombre de la Propuesta
                {
                     conexion = SqlHelper.ExecuteReader
                        (_conexion.GetConnection(), "CPNombre", ParametroBusqueda);  
                }
                if (Opcion == 2) // Id de la Propuesta
                {
                    conexion = SqlHelper.ExecuteReader
                       (_conexion.GetConnection(), "CpIdProp", ParametroBusqueda);
                }
                if (Opcion == 3)// Rif Cliente
                {
                     conexion = SqlHelper.ExecuteReader
                        (_conexion.GetConnection(), "CPCliente", ParametroBusqueda);
                }
                if (Opcion == 4)// Id Cliente
                {
                     conexion = SqlHelper.ExecuteReader
                        (_conexion.GetConnection(), "CpNomCli", ParametroBusqueda);
                }
                int i = 0;
                    while (conexion.Read())
                    {

                        Propuesta _Propuesta = new Propuesta();
                        _Propuesta.Titulo = (string)conexion["Titulo"];
                        _Propuesta.Version = (string)conexion["NumeroVersion"].ToString();
                        _Propuesta.FechaFirma = (DateTime)conexion["FechaFirma"];
                        _Propuesta.FechaInicio = (DateTime)conexion["FechaInicio"];
                        _Propuesta.FechaFin = (DateTime)conexion["FechaFin"];
                        _Propuesta.MontoTotal = float.Parse(conexion["Monto"].ToString());
                        _Propuesta.Id = (int)conexion["IdPropuesta"];
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
                        ListaPropuesta.Insert(i, _Propuesta);
                        i++;

                    }

                    return ListaPropuesta;
                
            }
            catch (SqlException e)
            {
                throw new ConsultarPropuestaBDException("Error En acceso a Base de Datos", e);
            }
        }

        /// <summary>
        /// Metodo para consultar las propuestas ordenadas por fecha de inicio
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public IList<Propuesta> ConsultarPropuestaOrdenadoPorEmision()
        {

            DbDataReader conexion = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarPropuesta");
            int i = 0;

            while (conexion.Read())
            {

                Propuesta _Propuesta = new Propuesta();
                _Propuesta.Titulo = (string)conexion["Titulo"];
                _Propuesta.Version = (string)conexion["NumeroVersion"].ToString();
                _Propuesta.FechaFirma = (DateTime)conexion["FechaFirma"];
                _Propuesta.FechaInicio = (DateTime)conexion["FechaInicio"];
                _Propuesta.FechaFin = (DateTime)conexion["FechaFin"];
                _Propuesta.MontoTotal = float.Parse(conexion["Monto"].ToString());
                _Propuesta.Id = (int)conexion["IdPropuesta"];

                ListaPropuesta.Insert(i, _Propuesta);
                i++;

            }

            return ListaPropuesta;
        }

        /// <summary>
        /// Metodo que se encarga de buscar Los empleados de una propuesta en específico
        /// </summary>
        /// <returns></returns>
        private List<Empleado> BuscarEmpleado(int IdPropuesta)
        {

            List<Empleado> ListaEmpleado = new List<Empleado>();

            try
            {
                SqlParameter ParamIdPropuesta = new SqlParameter();
                ParamIdPropuesta = new SqlParameter("@IdPropuesta", SqlDbType.Int);
                ParamIdPropuesta.Value = IdPropuesta;

                DbDataReader conexionempleado =
                    SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleadoVersion", ParamIdPropuesta);

                int j = 0;
                while (conexionempleado.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.Nombre = (string)conexionempleado["Nombre"];

                    ListaEmpleado.Insert(j, empleado);
                    j++;
                }

                return ListaEmpleado;

            }
            catch (SqlException e)
            {
                throw new ConsultarPropuestaBDException("Erron en Acceso a Bd", e);
            }
            catch (Exception e)
            {
                throw new ConsultarPropuestaBDException
                    ("Error En Consulta de Empleado En Propuesta", e);
            }

        }

        /// <summary>
        /// Metodo que consulta el Receptor de la propuesta
        /// </summary>
        /// <param name="IdPropuesta"> Se envia el id de la propuesta</param>
        /// <returns>Retorna una lista de string que contiene los 3 campos Nombre Apellido y Receptor
        /// la lista es de tipo string ya que no existe la entidad receptor como tal</returns>
        private List<string> BuscarReceptor(int IdPropuesta)
        {
            List<string> ListaReceptor = new List<string>();

            try
            {
                SqlParameter ParamIdPropuestaR = new SqlParameter();

                ParamIdPropuestaR = new SqlParameter("@IdPropuesta", SqlDbType.Int);

                ParamIdPropuestaR.Value = IdPropuesta;
                DbDataReader conexionReceptor =
                    SqlHelper.ExecuteReader
                        (_conexion.GetConnection(), "ConsultarReceptorVersion", ParamIdPropuestaR);

                while (conexionReceptor.Read())
                {
                    ListaReceptor.Add((string)conexionReceptor["NombreReceptor"]);
                    ListaReceptor.Add((string)conexionReceptor["Apellido"]);
                    ListaReceptor.Add((string)conexionReceptor["Nombre"]);
                }
                return ListaReceptor;
            }
            catch (SqlException e)
            {
                throw new Exception("Error En Acceso a Bd", e);
            }
            catch (Exception e)
            {
                throw new ConsultarPropuestaBDException
                    ("Error En Consulta de Receptor de Propuesta", e);
            }
        }

        /// <summary>
        /// Metodo que Consulta Las Propuestas Y Eliminarlas
        /// </summary>
        /// <param name="ListaRecibida">Recibe una Lista que contiene 
        /// el nombre de la propuesta a eliminar si la lista esta vacia consulta
        /// las propuestas a eliminar, si esta llena elimina la propuesta que contiene la lista</param>
        /// <returns>Lista de propuestas a ser eliminadas</returns>
        public IList<string> ListaEliminar(List<string> ListaRecibida)
        {
            if (ListaRecibida.Count == 0)
            {
                try
                {
                    DbDataReader conexion = SqlHelper.ExecuteReader
                            (_conexion.GetConnection(), "ConsultarPropuestaEliminar");
                    List<string> lista = new List<string>();


                    while (conexion.Read())
                    {
                        lista.Add((string)conexion["Titulo"]);
                    }
                    return lista;
                }
                catch (SqlException e)
                {
                    throw new Exception("Error en Acceso a Bd", e);
                }
                catch (Exception e)
                {
                    throw new EliminarPropuestaBDException("No Existen Objeto Propuesta a Eliminar", e);
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
                    int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "UpdateEstadoPropuesta", titulo);
                    return ListaRecibida;
                }
                catch (SqlException e)
                {
                    ListaRecibida = null;
                    throw new Exception("Error Durante Ejecucion de Instruccion a la BD", e);
                }
            }
        }

         /// <summary>
        /// Metodo que consulta las propuestas activas que tienen versiones en espera
        /// se trae la ultima version en espera
        /// </summary>
        /// <returns></returns>
        public IList<Propuesta> ConsultarPropuestaAModificar()
        {
            try
            {
                DbDataReader conexion = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarPropuestasVersiones");

                int i = 0;

                while (conexion.Read())
                {

                    Propuesta _Propuesta = new Propuesta();
                    _Propuesta.Titulo = (string)conexion["Titulo"];
                    _Propuesta.Version = (string)conexion["NumeroVersion"].ToString();
                    _Propuesta.FechaFirma = (DateTime)conexion["FechaFirma"];
                    _Propuesta.FechaInicio = (DateTime)conexion["FechaInicio"];
                    _Propuesta.FechaFin = (DateTime)conexion["FechaFin"];
                    _Propuesta.MontoTotal = float.Parse(conexion["Monto"].ToString());
                    _Propuesta.Id = (int)conexion["IdPropuesta"];
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

                    ListaPropuesta.Insert(i, _Propuesta);
                    i++;

                }

                return ListaPropuesta;
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }


        /// <summary>
        /// Metodo para modificar propuesta
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        /// 
        public Propuesta ModificarPropuesta(Propuesta PropuestaRecibida)
        {

            SqlParameter[] arparmsP = new SqlParameter[2];

            SqlParameter[] ParamV = new SqlParameter[6];

            DateTime fechaingreso = DateTime.Now;

            //Se definen los parametros
            arparmsP[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);

            arparmsP[0].Value = PropuestaRecibida.Titulo;

            arparmsP[1] = new SqlParameter("@MontoTotal", SqlDbType.Float);

            arparmsP[1].Value = PropuestaRecibida.MontoTotal;

            int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "UpdatePropuesta", arparmsP);

            ParamV[0] = new SqlParameter("@Version", SqlDbType.Int);

            ParamV[0].Value = PropuestaRecibida.Version;

            ParamV[1] = new SqlParameter("@FechaFirma", SqlDbType.DateTime);

            ParamV[1].Value = PropuestaRecibida.FechaFirma;

            ParamV[2] = new SqlParameter("@FechaIngreso", SqlDbType.DateTime);

            ParamV[2].Value = fechaingreso;

            ParamV[3] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);

            ParamV[3].Value = PropuestaRecibida.FechaInicio;

            ParamV[4] = new SqlParameter("@FechaFin", SqlDbType.DateTime);

            ParamV[4].Value = PropuestaRecibida.FechaFin;

            int result2 = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarPropuesta", ParamV);

            return PropuestaRecibida;
        }
        
        #endregion
    }
}