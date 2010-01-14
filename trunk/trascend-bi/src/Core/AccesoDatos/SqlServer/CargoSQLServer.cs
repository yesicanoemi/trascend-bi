using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using Core.LogicaNegocio.Entidades;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Xml;

namespace Core.AccesoDatos.SqlServer
{
    public class CargoSQLServer
    {
        public CargoSQLServer()
        {
        }

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
        /// Metodo para ingresar un cargo
        /// </summary>
        /// <param name="cargo">cargo que se va a ingresar</param>
        /// <returns></returns>
        public Boolean IngresarCargo( Cargo cargo )
        {
            Cargo _cargo = new Cargo();
            try
            {
                SqlParameter[] arParms = new SqlParameter[5];
                //Parametros
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = _cargo.Nombre;
                arParms[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                arParms[1].Value = _cargo.Descripcion;
                arParms[2] = new SqlParameter("@SueldoMinimo", SqlDbType.Float);
                arParms[2].Value = _cargo.SueldoMinimo;
                arParms[3] = new SqlParameter("@SueldoMaximo", SqlDbType.Float);
                arParms[3].Value = _cargo.SueldoMaximo;
                arParms[4] = new SqlParameter("@VigenciaAnual", SqlDbType.SmallDateTime);
                arParms[4].Value = _cargo.Vigencia.ToShortDateString;
                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarCargo", arParms);
            }
            catch (SqlException e)
            {
                return false;
                //System.Console.Write(e);
            }
            return true;
        }

        /// <summary>
        /// Metodo para consultar un cargo por su nombre
        /// </summary>
        /// <param name="cargo">Criterio de la busqueda</param>
        /// <returns>La informacion del cargo asociado al criterio</returns>
        public Cargo ConsultarCargo( Cargo cargo )
        {
            Cargo _cargo = new Cargo();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = cargo.Nombre;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                                "ConsultarCargo", arParms);

                if (reader.Read())
                {
                    _cargo.Nombre = (string)reader["Nombre"];
                    _cargo.Descripcion = (string)reader["Descripcion"];
                    _cargo.SueldoMinimo = (float)reader["SueldoMinimo"];
                    _cargo.SueldoMaximo = (float)reader["SueldoMaximo"];
                    _cargo.Vigencia = (smalldatetime)reader["VigenciaAnual"];
                }

                return _cargo;
            }
            catch (SqlException e)
            {
                System.Console.Write( e );
            }
            return _cargo;

        }
        #endregion
    }
}
