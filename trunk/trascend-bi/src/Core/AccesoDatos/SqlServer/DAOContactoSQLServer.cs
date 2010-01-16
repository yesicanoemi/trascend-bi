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
    public class ContactoSQLServer
    {
        #region Propiedades

        #endregion
        #region Constructor
        public ContactoSQLServer()
        {
        }
        #endregion

        private SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            string lista = conexiones[0].InnerText;
            SqlConnection connection = new SqlConnection(lista);
            connection.Open();

            return connection;
        }

        #region Metodos
        public Contacto Ingresar(Contacto contacto)
        {
            Contacto _contacto = new Contacto();
            try
            {

                SqlParameter[] arParms = new SqlParameter[9];
                // Parametros 
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = contacto.Nombre;
                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[1].Value = contacto.Apellido;
                arParms[2] = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);
                arParms[2].Value = contacto.AreaDeNegocio;
                arParms[3] = new SqlParameter("@Cargo", SqlDbType.VarChar);
                arParms[3].Value = contacto.Cargo;
                arParms[4] = new SqlParameter("@TelefonoTrabajo", SqlDbType.Int);
                arParms[4].Value = contacto.TelefonoDeTrabajo;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto.TelefonoDeCelular;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.Int);
                arParms[8].Value = contacto.TelefonoDeTrabajo.Tipo;



                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "InsertarContacto", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _contacto;

        }


        public IList<Contacto> Consultar()
        {
            IList<Contacto> contacto = null;
            DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarContacto");
            while (reader.Read())
            {
                Contacto _contacto = new Contacto();
                _contacto.Nombre = (string)reader["nombre"];
                _contacto.Apellido = (string)reader["apellido"];
                _contacto.AreaDeNegocio = (string)reader["areanegocio"];
                _contacto.Cargo = (string)reader["cargo"];
            //    _contacto.TelefonoDeTrabajo = (Int32)reader["telefonotrabajo"];
            //    _contacto.TelefonoDeCelular = (Int32)reader["telefonocelular"];

                contacto.Add(_contacto);
            }
            return contacto;
        }


        public Contacto Eliminar(Contacto contacto)
        {
            Contacto _contacto = new Contacto();
            try
            {

                SqlParameter[] arParms = new SqlParameter[2];
                // Parametros 
        
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = contacto.Nombre;
                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[1].Value = contacto.Apellido;



                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                     "EliminarContacto", arParms);
                /*
                                if (reader.Read())
                                {
                                    _usuario.Login = (string)reader["LoginUsuario"];

                                    _usuario.Status = (string)reader["Status"];
                                }
                                */
                return _contacto;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _contacto;

        }

         public int Modificar(Contacto contacto)
        {
            int resultado = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[9];
                // Parametros 
                
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = contacto.Nombre;
                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[1].Value = contacto.Apellido;
                arParms[2] = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);
                arParms[2].Value = contacto.AreaDeNegocio;
                arParms[3] = new SqlParameter("@Cargo", SqlDbType.VarChar);
                arParms[3].Value = contacto.Cargo;
                arParms[4] = new SqlParameter("@TelefonoTrabajo", SqlDbType.Int);
                arParms[4].Value = contacto.TelefonoDeTrabajo;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto.TelefonoDeCelular;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.Int);
                arParms[8].Value = contacto.TelefonoDeTrabajo.Tipo;
                resultado = SqlHelper.ExecuteNonQuery(GetConnection(), "ModificarContacto", arParms);
                return resultado;
            }
            catch (SqlException )
            {
            }
            return resultado;
        }
        #endregion

        
    }
}

