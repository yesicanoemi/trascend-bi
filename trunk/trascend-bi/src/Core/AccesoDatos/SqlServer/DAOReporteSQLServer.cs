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
using Core.LogicaNegocio.Excepciones;
using Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;

namespace Core.AccesoDatos.SqlServer
{
    class DAOReporteSQLServer: IDAOReporte
    {
       #region Propiedades

        List<string> ListaRoles = new List<string>();

        List<Gasto> ListaGasto = new List<Gasto>();

        List<string> ListaCargos = new List<string>();

        IConexion _conexion = new FabricaConexion().getConexionSQLServer();

        #endregion

        #region Constructor

        public ReporteSQLServer()
        {
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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
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

        #region ReporteGastoxFecha

        /// <summary>
        /// Metodo que se encarga de Consultar todos los gastos comprendidos entre dos fechas
        /// </summary>
        /// <param name="fechai">Fecha de Inicio</param>
        /// <param name="fechaf">Fecha Final</param>
        /// <returns></returns>

        public IList<Gasto> ConsultarGastoFecha(DateTime fechai, DateTime fechaf)
        {
            try
            {

                //Se declaran los parametros

                SqlParameter[] Parametros = new SqlParameter[2];

                Parametros[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);

                Parametros[0].Value = fechai;

                Parametros[1] = new SqlParameter("@FechaFin", SqlDbType.DateTime);

                Parametros[1].Value = fechaf;

                //Se realiza la conexion con los Parametros definidos anteriormente

                DbDataReader conexion = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                "ConsultarGastoxFecha", Parametros);

                int i = 0;

                while (conexion.Read())
                {

                    Gasto _gasto = new Gasto();

                    _gasto.Tipo = (string)conexion["Tipo"];

                    _gasto.Descripcion = (string)conexion["Descripcion"];

                    _gasto.FechaGasto = (DateTime)conexion["Fecha"];

                    _gasto.Monto = float.Parse(conexion["Monto"].ToString());

                    ListaGasto.Insert(i, _gasto);
                    i++;

                }
            }
            catch (SqlException e)
            {
                throw new ReportePropuestaBdException("Conexión a la BD Fallida", e);
            }
            catch (Exception e)
            {
                throw new ReportePropuestaBdException("No se pudieron Consultar los gastos", e);
            }

            return ListaGasto;
        }

        #endregion

        #region Reporte#1 Grupo 2
        /// <summary>
        /// Metodo que se comunica con la base de datos y realiza la consulta
        /// solicitada
        /// </summary>
        /// <returns>Retorna una Lista de string q contiene el rol</returns>
        public IList<string> ObtenerRol(DateTime FechaI, DateTime FechaF)
        {
            try
            {
                SqlParameter[] Parametros = new SqlParameter[2];

                Parametros[0] = new SqlParameter("@FechaI", SqlDbType.DateTime);

                Parametros[0].Value = FechaI;

                Parametros[1] = new SqlParameter("@FechaF", SqlDbType.DateTime);

                Parametros[1].Value = FechaF;
                DbDataReader conexion = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarHorasRolFecha", Parametros);
                int i = 0;

                while (conexion.Read())
                {

                    string Rol;
                    string HorasParticipadas;
                    Rol = (string)conexion["Rol"];
                    ListaRoles.Add(Rol);
                    i++;

                }

                return ListaRoles;
            }
            catch (SqlException e)
            {
                throw new Exception("Error en Acceso a BD",e);
            }
        }
        /// <summary>
        /// Metodo que consulta las Horas del Rol Seleccionado
        /// </summary>
        /// <returns>Retorna Entero que representa la suma de las horas del rol</returns>
        public int SumaHora(string rol)
        {
            int HorasParticipadas = 0;
            try
            {
                SqlParameter ParametroRol = new SqlParameter();
                ParametroRol = new SqlParameter("@Rol", SqlDbType.VarChar);

                ParametroRol.Value = rol; ;

                DbDataReader conexion =
                    SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarHorasRol", ParametroRol);

                int i = 0;

                while (conexion.Read())
                {
                    HorasParticipadas = (int)conexion["TotalHoras"];
                }

                return HorasParticipadas;
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }
        #endregion


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

            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "FacturasEmitidasAnuales", parametro);

            int i = 0;

            while (reader.Read())
            {

                Factura _factura = new Factura();

                Propuesta _propuesta = new Propuesta();

                _factura.Numero = (int)reader["IdFactura"];

                _factura.Titulo = (string)reader["Titulo"];

                _factura.Descripcion = (string)reader["Descripcion"];

                _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

 //               _factura.Estado = (int)reader["Estado"];

                _factura.Fechapago = (DateTime)reader["Fecha"];

                _factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

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
        public IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasCobradas(Factura facturas)
        {
            IList<Core.LogicaNegocio.Entidades.Factura> factura =
                                                new List<Core.LogicaNegocio.Entidades.Factura>();
            try
            {
            

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@yearFecha", SqlDbType.DateTime);

            parametro[0].Value = facturas.Fechapago;


            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "FacturasCobradasAnuales", parametro);

            int i = 0;

            while (reader.Read())
            {

                Factura _factura = new Factura();

                Propuesta _propuesta = new Propuesta();

                _factura.Numero = (int)reader["IdFactura"];

                _factura.Titulo = (string)reader["Titulo"];

                _factura.Descripcion = (string)reader["Descripcion"];

                _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                _factura.Estado = (string)reader["Nombre"];

                _factura.Fechapago = (DateTime)reader["Fecha"];

                _factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

                factura.Add(_factura);
            }
            }
            catch (ConsultarException e)
            {
                throw new ConsultarException("Error al consultar",e);
            }
            catch (Exception e)
            {
                throw new ConsultarException("error",e);
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
        public IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasPorCobrar(Factura facturas)
        {
            IList<Core.LogicaNegocio.Entidades.Factura> factura =
                                                new List<Core.LogicaNegocio.Entidades.Factura>();
            try
            {
            

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@yearFecha", SqlDbType.DateTime);

            parametro[0].Value = facturas.Fechapago;

            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "FacturasPorCobrarAnuales", parametro);

            int i = 0;

            while (reader.Read())
            {

                Factura _factura = new Factura();

                Propuesta _propuesta = new Propuesta();

                _factura.Numero = (int)reader["IdFactura"];

                _factura.Titulo = (string)reader["Titulo"];

                _factura.Descripcion = (string)reader["Descripcion"];

                _factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                _factura.Estado = (string)reader["Nombre"];

                _factura.Fechapago = (DateTime)reader["Fecha"];

                _factura.Procentajepagado = float.Parse(reader["Porcentaje"].ToString());

                factura.Add(_factura);
            }
            }
            catch (ConsultarException e)
            {
                throw new ConsultarException("Error al consultar",e);
            }
            catch (Exception e)
            {
                throw new ConsultarException("error", e);
            }
            return factura;
        }
        #endregion


        #region ReporteGastosAnuales

        /// <summary>
        /// Metodo para el reporte de Gastos en un anio (consulta de datos)
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>Lista de Gastos</returns>

        public IList<Core.LogicaNegocio.Entidades.Gasto>
                                                GastosAnuales(string anio)
        {

            IList<Core.LogicaNegocio.Entidades.Gasto> gasto =
                                                new List<Core.LogicaNegocio.Entidades.Gasto>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Anio", SqlDbType.VarChar);

                arParms[0].Value = anio;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarDatosGastoAnual", arParms);

                while (reader.Read())
                {
                    Gasto _gasto = new Gasto();

                    _gasto.Codigo = (int)reader["IdGasto"];

                    _gasto.FechaGasto = (DateTime)reader["Fecha"];

                    _gasto.Tipo = (string)reader["Tipo"];

                    string prueba = (String)reader["Monto"].ToString();

                    _gasto.Monto = float.Parse(prueba);

                    gasto.Add(_gasto);
                }

                return gasto;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return gasto;

        }



        /// <summary>
        /// Metodo para el reporte de Gastos en un anio (total gastos)
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns>Total de Gastos</returns>

        public float TotalGastosAnuales(string anio)
        {
            float total = 0;


            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Anio", SqlDbType.VarChar);

                arParms[0].Value = anio;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "GastoAnual", arParms);

                while (reader.Read())
                {
                    string prueba = (String)reader["Monto"].ToString();

                    if (prueba != "")
                    {
                        total = float.Parse(prueba);
                        return total;
                    }
                    else
                    {//  mensaje de aviso que la base no contiene datos
                        return total;
                    }

                }
            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return total;

        }



        #endregion

        #region ReporteTransacciones
        public Cargo ConsultarEmpleadoCargoAnual(string metodo)
        {
            Cargo cargo = new Cargo();

            Cargo _cargo = new Cargo();

            try
            {
                //Parametros de busqueda


                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@cargo", SqlDbType.VarChar);

                arParms[0].Value = metodo;


                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ReporteAnualPorCargo", arParms);



                while (reader.Read())
                {

                    _cargo.Nombre = (string)reader["NOMBRE"];

                    _cargo.SueldoMaximo = (int)reader["ANUALMAX"];

                    _cargo.SueldoMinimo = (int)reader["ANUALMINIMO"];

                }

                return _cargo;

            }

            catch (SqlException e)
            {

            }

            return _cargo;

        }
        #region Reporte 1a

        public IList<Empleado> ConsultaEmpleadosNombreEmp(string data)
        {
            Empleado empleado;
            IList<Empleado> Empleados;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);

                arParms[0].Value = data;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ReporteAnualPorEmpleadoPaquetesNombre", arParms);

                Empleados = new List<Empleado>();
                while (reader.Read())
                {
                    empleado = new Empleado();

                    empleado.Nombre = (string)reader["NOMBRE"];
                    empleado.Apellido = (string)reader["APELLIDO"];
                    empleado.Estado = (int)reader["ESTADO"];

                    Empleados.Add(empleado);
                }
                return Empleados;
            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            catch (Exception e)
            {
                System.Console.Write(e);
            }
            return null;

        }

        public IList<Cargo> ConsultaEmpleadosNombreCar(string data)
        {
            Cargo cargo;
            IList<Cargo> Cargos;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);

                arParms[0].Value = data;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ReporteAnualPorEmpleadoPaquetesNombre", arParms);

                Cargos = new List<Cargo>();
                cargo = new Cargo();

                while (reader.Read())
                {
                    cargo.Nombre = (string)reader["CARGO"];
                    cargo.SueldoMaximo = (float)reader["ANUALTOTAL"];
                    cargo.SueldoMinimo = (float)reader["ANUALMINIMO"];

                    Cargos.Add(cargo);
                }
                return Cargos;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            catch (Exception e)
            {
                System.Console.Write(e);
            }
            return null;
        }

        public IList<Empleado> ConsultaEmpleadosCIEmp(string data)
        {
            Empleado empleado;
            IList<Empleado> Empleados;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@CIEmpleado", SqlDbType.VarChar);

                arParms[0].Value = data;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ReporteAnualPorEmpleadoPaquetes", arParms);

                Empleados = new List<Empleado>();
                while (reader.Read())
                {
                    empleado = new Empleado();

                    empleado.Nombre = (string)reader["NOMBRE"];
                    empleado.Apellido = (string)reader["APELLIDO"];
                    empleado.Estado = (int)reader["ESTADO"];

                    Empleados.Add(empleado);
                }
                return Empleados;
            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            catch (Exception e)
            {
                System.Console.Write(e);
            }
            return null;

        }

        public IList<Cargo> ConsultaEmpleadosCICar(string data)
        {
            Cargo cargo;
            IList<Cargo> Cargos;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@CIEmpleado", SqlDbType.VarChar);

                arParms[0].Value = data;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ReporteAnualPorEmpleadoPaquetes", arParms);

                Cargos = new List<Cargo>();
                cargo = new Cargo();

                while (reader.Read())
                {
                    cargo.Nombre = (string)reader["CARGO"];
                    cargo.SueldoMaximo = (float)reader["ANUALTOTAL"];
                    cargo.SueldoMinimo = (float)reader["ANUALMINIMO"];

                    Cargos.Add(cargo);
                }
                return Cargos;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            catch (Exception e)
            {
                System.Console.Write(e);
            }
            return null;
        }

        #endregion

        public IList<string> ObtenerCargo()
        {
            try
            {
                DbDataReader conexion = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarCargo1");
                int i = 0;

                while (conexion.Read())
                {

                    string Cargo;

                    Cargo = (string)conexion["NOMBRE"];
                    ListaCargos.Add(Cargo);
                    i++;

                }

                return ListaCargos;
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }

        }

        #endregion

        #endregion
    }
}
