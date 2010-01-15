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
            Propuesta _propuesta = new Propuesta();

            SqlParameter[] arparms = new SqlParameter[9];

            //Se definen los parametros
            arparms[0] = new SqlParameter("@Titulo", SqlDbType.VarChar);
            arparms[0].Value = propuesta.Titulo;
            arparms[1] = new SqlParameter("@Version", SqlDbType.Int);
            arparms[1].Value = _propuesta.Version;
            arparms[2] = new SqlParameter("@FechaFirma", SqlDbType.SmallDateTime);
            arparms[2].Value = _propuesta.FechaFirma;
            arparms[3] = new SqlParameter("@NombreReceptor", SqlDbType.VarChar);
            arparms[3].Value = _propuesta.NombreReceptor;
            arparms[4] = new SqlParameter("@ApellidoReceptor", SqlDbType.VarChar);
            arparms[4].Value = _propuesta.ApellidoReceptor;
            arparms[5] = new SqlParameter("@CargoReceptor", SqlDbType.VarChar);
            arparms[5].Value = _propuesta.CargoReceptor;
            arparms[6] = new SqlParameter("@FechaInicio", SqlDbType.SmallDateTime);
            arparms[6].Value = _propuesta.FechaInicio;
            arparms[7] = new SqlParameter("@FechaFin", SqlDbType.SmallDateTime);
            arparms[7].Value = _propuesta.FechaFin;
            // arparms[8] = new SqlParameter("@TotalHoras", SqlDbType.VarChar);
            // arparms[8].Value = _propuesta.Titulo;
            arparms[8] = new SqlParameter("@MontoTotal", SqlDbType.Int);
            arparms[8].Value = _propuesta.MontoTotal;
            int result = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarPropuesta", arparms);
            return _propuesta;
        }
        
        /// <summary>
        /// Metodo para consultar las propuestas
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public IList<Propuesta> ConsultarPropuesta()
        {
            
           DbDataReader conexion = SqlHelper.ExecuteReader( GetConnection(), "ConsultarPropuesta" );
           int i = 0;

           while ( conexion.Read())
            {
                
                 Propuesta _Propuesta  = new Propuesta();
                _Propuesta.Titulo      = (string)conexion["Titulo"];
                _Propuesta.Version     = (string) conexion["NumeroVersion"].ToString();
                _Propuesta.FechaFirma  = (DateTime)conexion["FechaFirma"];
                _Propuesta.FechaInicio = (DateTime)conexion["FechaInicio"];
                _Propuesta.FechaFin    = (DateTime)conexion["FechaFin"];
                _Propuesta.MontoTotal  = (int)conexion["Monto"];

                ListaPropuesta.Insert( i, _Propuesta );
                i++;
                
            }

            return ListaPropuesta;
        }
#endregion
    }
}
