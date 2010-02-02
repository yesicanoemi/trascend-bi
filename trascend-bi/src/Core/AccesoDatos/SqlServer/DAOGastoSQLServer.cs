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
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Excepciones.Gasto.Acceso_a_Datos;

namespace Core.AccesoDatos.SqlServer
{
    class DAOGastoSQLServer: IDAOGasto
    {
        #region Propiedades
        IConexion _conexion = new FabricaConexion().getConexionSQLServer();
        Gasto _gasto = new Gasto();
        List<Gasto> _ListaGastos = new List<Gasto>();
        #endregion

        #region Constructor
        public DAOGastoSQLServer()
        {
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

                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "InsertarGasto", parametros);

            }
            catch (InvalidOperationException e)
            {
                _gasto.Codigo = -1;
            }
            catch (SqlException)
            {
                _gasto.Codigo = -2;
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

                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "InsertarGastoPropuesta", parametros);

            }
            catch (InvalidOperationException)
            {
                _gasto.Codigo = -1;
            }
            catch (SqlException)
            {
                _gasto.Codigo = -2;
            }


            return _gasto;
        }

       /// <summary>
       /// Metodo encargado de la busqueda de los gastos asociados a una seleccion del usuario
       /// </summary>
       /// <param name="Opcion">El id de la propuesta en caso de seleccion de propuesta 
       /// o -1 en caso de ser por busqueda de cliente</param>
       /// <param name="Parametro"></param>
       /// <returns> retorna una lista de los gastos asociados a la consulta</returns>
        public IList<Gasto> ConsultarGasto( int Opcion , string Parametro )
        {
           

            try
            {
                SqlParameter[] parametroconsulta = new SqlParameter[1];
                
                DbDataReader reader = null;

                if ( Parametro.Equals("Propuesta") ) // Id Propuesta
                {
                    parametroconsulta[0] = new SqlParameter("@Parametro", SqlDbType.Int);
                    parametroconsulta[0].Value = Opcion;
                    reader = SqlHelper.ExecuteReader
                        ( _conexion.GetConnection(), "ConsultarGastoPorPropuesta", parametroconsulta );
                }
                if ( Opcion == -1 ) // Nombre Cliente
                {
                    parametroconsulta[0]       = new SqlParameter("@Parametro", SqlDbType.VarChar);
                    parametroconsulta[0].Value = Parametro;
                    reader = SqlHelper.ExecuteReader
                        ( _conexion.GetConnection(), "ConsultarGastoNomCli", parametroconsulta );
                }
               
      

                while ( reader.Read() )
                {
                    Gasto gastocons        = new Gasto();
                    gastocons.Codigo       = (int)reader["IdGasto"];
                    gastocons.Estado       = (string)reader["Estado"];
                    gastocons.Monto        = float.Parse(reader["Monto"].ToString());
                    gastocons.FechaGasto   = (DateTime)reader["Fecha"];
                    gastocons.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    gastocons.Tipo         = (string)reader["Tipo"];
                    gastocons.Descripcion  = (string)reader["Descripcion"];
                    gastocons.IdVersion    = (int)reader["IdVersion"];

                    _ListaGastos.Add(gastocons);
                }

                return _ListaGastos;
            }

            catch (SqlException e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            catch (Exception e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            
        }

        public IList<Gasto> ConsultarGastoPorTipo()
        {
            IList<Core.LogicaNegocio.Entidades.Gasto> gastos = new List<Core.LogicaNegocio.Entidades.Gasto>();

            try
            {
                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarGastoPorTipo");

                while (reader.Read())
                {
                    Gasto _gasto = new Gasto();

                    _gasto.Codigo = (int)reader["IdGasto"];
                    _gasto.Estado = (string)reader["Estado"];
                    _gasto.Monto = float.Parse(reader["Monto"].ToString());
                    _gasto.FechaGasto = (DateTime)reader["Fecha"];
                    _gasto.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    _gasto.Tipo = (string)reader["Tipo"];
                    _gasto.Descripcion = (string)reader["Descripcion"];

                    gastos.Add(_gasto);
                }
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }


            return gastos;
        }

        public IList<Gasto> ConsultarGastoPorPropuesta(Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            IList<Core.LogicaNegocio.Entidades.Gasto> gastos = new List<Core.LogicaNegocio.Entidades.Gasto>();
 
            try
            {
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);
                parametro[0].Value = propuesta.Titulo;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarGastoPorPropuesta", parametro);

                while (reader.Read())
                {
                    Gasto _gasto = new Gasto();

                    _gasto.Codigo = (int)reader["IdGasto"];
                    _gasto.Estado = (string)reader["Estado"];
                    _gasto.Monto = float.Parse(reader["Monto"].ToString());
                    _gasto.FechaGasto = (DateTime)reader["Fecha"];
                    _gasto.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    _gasto.Tipo = (string)reader["Tipo"];
                    _gasto.Descripcion = (string)reader["Descripcion"];

                    gastos.Add(_gasto);
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            catch (Exception e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }


            return gastos;

        }

        /// <summary>
        /// Metodo encargado de realizar la busqueda de los gastos
        /// de acuerdo a la fecha ingresada por el usuario
        /// </summary>
        /// <param name="gasto">recibe entidad gasto con la fecha ingresada por el usuario</param>
        /// <returns>retorna una lista de los gastos</returns>
        public IList<Gasto> ConsultarGastoPorFecha( Core.LogicaNegocio.Entidades.Gasto gasto )
        {
            IList<Core.LogicaNegocio.Entidades.Gasto> gastos
                = new List<Core.LogicaNegocio.Entidades.Gasto>();
            
            try
            {
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter("@Fecha", SqlDbType.DateTime);
                parametro[0].Value = gasto.FechaGasto;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarGastoPorFecha", parametro);

                while (reader.Read())
                {
                    Gasto _gasto = new Gasto();

                    _gasto.Codigo       = (int)reader["IdGasto"];
                    _gasto.Estado       = (string)reader["Estado"];
                    _gasto.Monto        = float.Parse(reader["Monto"].ToString());
                    _gasto.FechaGasto   = (DateTime)reader["Fecha"];
                    _gasto.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    _gasto.Tipo         = (string)reader["Tipo"];
                    _gasto.Descripcion  = (string)reader["Descripcion"];
                    _gasto.IdVersion    = (int)reader["IdVersion"];

                    gastos.Add(_gasto);
                }
            }
            catch ( SqlException e )
            {
                throw new ConsultarGastoBDExceptions
                ( "Error de Consulta en Base de DAtos" , e );
            }

            catch ( Exception e )
            {
                throw new ConsultarGastoBDExceptions
                ( "Error de Consulta en Base de DAtos" , e );
            }


            return gastos;
        }

        public IList<Gasto> ConsultarGastoPorEstado(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            IList<Core.LogicaNegocio.Entidades.Gasto> gastos = new List<Core.LogicaNegocio.Entidades.Gasto>();

            try
            {
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter("@Estado", SqlDbType.VarChar);
                parametro[0].Value = gasto.Estado;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarGastoPorEstado", parametro);

                while (reader.Read())
                {
                    Gasto _gasto = new Gasto();

                    _gasto.Codigo = (int)reader["IdGasto"];
                    _gasto.Estado = (string)reader["Estado"];
                    _gasto.Monto = float.Parse(reader["Monto"].ToString());
                    _gasto.FechaGasto = (DateTime)reader["Fecha"];
                    _gasto.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    _gasto.Tipo = (string)reader["Tipo"];
                    _gasto.Descripcion = (string)reader["Descripcion"];

                    gastos.Add(_gasto);
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            catch (Exception e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }


            return gastos;
        }

        public Gasto EliminarGasto(Gasto gasto)
        {

            try
            {
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter("@IdGasto", SqlDbType.Int);
                parametro[0].Value = gasto.Codigo;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "EliminarGasto", parametro);

            }
            catch (SqlException e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            catch (Exception e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }


            return gasto;
        }

        public Gasto ModificarGasto(Gasto gasto)
        {
            Gasto _gasto = new Gasto();
            try
            {
                SqlParameter[] parametros = new SqlParameter[8];

                parametros[0] = new SqlParameter("@IdGasto", SqlDbType.VarChar);
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

                parametros[7] = new SqlParameter("@IdVersion", SqlDbType.Int);
                parametros[7].Value = gasto.IdVersion;

                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarGastoPorCodigo", parametros);

            }
            catch (SqlException e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            catch (Exception e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            return _gasto;
        }

        public IList<Gasto> ConsultarGastoaModificar(int IdGasto)
        {
            IList<Core.LogicaNegocio.Entidades.Gasto> gastos = new List<Core.LogicaNegocio.Entidades.Gasto>();

            try
            {
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter("@IdGasto", SqlDbType.Int);
                parametro[0].Value = IdGasto;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarGModificar", parametro);

                while (reader.Read())
                {
                    Gasto _gasto = new Gasto();

                    _gasto.Codigo = (int)reader["IdGasto"];
                    _gasto.Estado = (string)reader["Estado"];
                    _gasto.Monto = float.Parse(reader["Monto"].ToString());
                    _gasto.FechaGasto = (DateTime)reader["Fecha"];
                    _gasto.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    _gasto.Tipo = (string)reader["Tipo"];
                    _gasto.Descripcion = (string)reader["Descripcion"];
                    _gasto.IdVersion = (int)reader["IdVersion"];
                   

                    gastos.Add(_gasto);
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }

            catch (Exception e)
            {
                throw new ConsultarGastoBDExceptions
                ("Error de Consulta en Base de DAtos", e);
            }


            return gastos;
        }




        #endregion
    }
}
