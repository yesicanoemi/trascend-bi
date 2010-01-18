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

namespace Core.AccesoDatos.SqlServer
{
    class ReporteSQLServer
    {
        List<Gasto> ListaGasto = new List<Gasto>();

        #region Propiedades

        List<string> ListaRoles = new List<string>();

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

        #region Reporte de Facturas por Fecha

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

                    _factura.Prop = new Propuesta();

                    _factura.Numero = (int)reader.GetValue(0);

                    _factura.Titulo = (string)reader.GetValue(1);

                    _factura.Descripcion = (string)reader.GetValue(2);

                    _factura.Fechaingreso = (DateTime)reader.GetValue(3);

                    _factura.Estado = (string)reader.GetValue(4);

                    _propuesta.Titulo = (string)reader.GetValue(5);

                    _factura.Prop.Titulo = _propuesta.Titulo;

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

        /// <summary>
        /// Metodo que se encarga de Consultar todos los gastos comprendidos entre dos fechas
        /// </summary>
        /// <param name="fechai">Fecha de Inicio</param>
        /// <param name="fechaf">Fecha Final</param>
        /// <returns></returns>
        
        
        public IList<Gasto> ConsultarGastoFecha(DateTime fechai, DateTime fechaf)
        {
            //Se declaran los parametros

            SqlParameter[] Parametros = new SqlParameter[2];

            Parametros[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);

            Parametros[0].Value = fechai;

            Parametros[1] = new SqlParameter("@FechaFin", SqlDbType.DateTime);

            Parametros[1].Value = fechaf;


            DbDataReader conexion = SqlHelper.ExecuteReader(GetConnection(),
            "ConsultarGastoxFecha", Parametros);

            int i = 0;

            while (conexion.Read())
            {

                Gasto _gasto = new Gasto();

                _gasto.Tipo = (string)conexion["Tipo"];

                _gasto.Descripcion = (string)conexion["Descripcion"];

                _gasto.FechaGasto = (DateTime)conexion["Fecha"];

                _gasto.Monto = (float)conexion["Monto"];

                ListaGasto.Insert(i, _gasto);
                i++;

            }

            return ListaGasto;
        }

        /// <summary>
        /// Metodo que se comunica con la base de datos y realiza la consulta
        /// solicitada
        /// </summary>
        /// <returns>Retorna una Lista de string q contiene el rol</returns>
        public IList<string> ObtenerRol()
        {
            try
            {
                DbDataReader conexion = SqlHelper.ExecuteReader( GetConnection(), "ConsultarRol" );
                int i = 0;

                while ( conexion.Read() )
                {

                    string Rol;
                    string HorasParticipadas;
                    Rol = ( string )conexion["Rol"];
                    ListaRoles.Add( Rol );
                    i++;

                }

                return ListaRoles;
            }
            catch ( SqlException e )
            {
                throw new Exception( e.ToString() );
            }
        }
        /// <summary>
        /// Metodo que consulta las Horas del Rol Seleccionado
        /// </summary>
        /// <returns>Retorna Entero que representa la suma de las horas del rol</returns>
        public int SumaHora( string rol )
        {
            int HorasParticipadas = 0;
            try
            {
                SqlParameter ParametroRol = new SqlParameter();
                ParametroRol = new SqlParameter("@Rol", SqlDbType.VarChar);

                ParametroRol.Value = rol; ;

                DbDataReader conexion = 
                    SqlHelper.ExecuteReader( GetConnection(), "ConsultarHorasRol", ParametroRol );

                int i = 0;

                while ( conexion.Read() )
                    {
                        HorasParticipadas = ( int )conexion["TotalHoras"];
                    }

                return HorasParticipadas;
            }
            catch ( SqlException e )
            {
                throw new Exception( e.ToString() );
            }
        }


        #region ReporteFacturasEmitidasAnuales
        /// <summary>
        /// Metodo para el reporte de facturas emitidas en un año especifico
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// <returns>Objeto Factura</returns>
        /// 
        public IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasEmitidas(Factura factura)
        {
            IList<Core.LogicaNegocio.Entidades.Factura> facturas =
                                                new List<Core.LogicaNegocio.Entidades.Factura>();

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@yearFecha", SqlDbType.DateTime);

            parametro[0].Value = factura.Fechapago;

            DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "FacturasEmitidasAnuales",parametro);
          
            int i = 0;

            while (reader.Read())
            {

                Factura _factura = new Factura();

                Propuesta _propuesta = new Propuesta();

                _factura.Numero = (int)reader["IdFactura"];

                _factura.Titulo = (string)reader["Titulo"];

                _factura.Descripcion = (string)reader["Descripcion"];

                _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                _factura.Estado = (string)reader["Estado"];

                _factura.Fechapago = (DateTime)reader["Fecha"];

                //_propuesta.Titulo = (string)reader["Titulo"];

                //_factura.Prop.Titulo = _propuesta.Titulo;

                facturas.Add(_factura);
            }

            return facturas;
        }
        #endregion
        #region ReporteFacturasCobradasAnuales
        /// <summary>
        /// Metodo para el reporte de facturas cobradas en un año especifico
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// <returns>Objeto Factura</returns>
        /// 
        public IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasCobradas()
        {
            IList<Core.LogicaNegocio.Entidades.Factura> factura =
                                                new List<Core.LogicaNegocio.Entidades.Factura>();
            DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "FacturasCobradasAnuales");

            int i = 0;

            while (reader.Read())
            {

                Factura _factura = new Factura();

                Propuesta _propuesta = new Propuesta();

                _factura.Numero = (int)reader["NumeroFactura"];

                _factura.Titulo = (string)reader["Titulo"];

                _factura.Descripcion = (string)reader["Descripcion"];

                _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                _factura.Estado = (string)reader["Estado"];

                _factura.Fechapago = (DateTime)reader["FechaPago"];

                //_propuesta.Titulo = (string)reader["Titulo"];

                //_factura.Prop.Titulo = _propuesta.Titulo;

                factura.Add(_factura);
            }

            return factura;
        }
        #endregion

        #region ReporteFacturasPorCobrarAnuales
        /// <summary>
        /// Metodo para el reporte de facturas por cobrar en un año especifico
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// <returns>Objeto Factura</returns>
        /// 
        public IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasPorCobrar()
        {
            IList<Core.LogicaNegocio.Entidades.Factura> factura =
                                                new List<Core.LogicaNegocio.Entidades.Factura>();
            DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "FacturasPorCobrarAnuales");

            int i = 0;

            while (reader.Read())
            {

                Factura _factura = new Factura();

                Propuesta _propuesta = new Propuesta();

                _factura.Numero = (int)reader["NumeroFactura"];

                _factura.Titulo = (string)reader["Titulo"];

                _factura.Descripcion = (string)reader["Descripcion"];

                _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                _factura.Estado = (string)reader["Estado"];

                _factura.Fechapago = (DateTime)reader["FechaPago"];

                //_propuesta.Titulo = (string)reader["Titulo"];

                //_factura.Prop.Titulo = _propuesta.Titulo;

                factura.Add(_factura);
            }

            return factura;
        }
        #endregion

        #endregion

    }
}