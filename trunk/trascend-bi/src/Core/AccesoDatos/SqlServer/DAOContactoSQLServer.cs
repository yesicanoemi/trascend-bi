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
                
                
                SqlParameter[] arParms = new SqlParameter[11];
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
                arParms[4].Value = contacto.TelefonoDeTrabajo.Numero;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto.TelefonoDeCelular.Numero;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                arParms[8].Value = contacto.TelefonoDeTrabajo.Tipo;
                arParms[9] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[9].Value = 1;
                arParms[10] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[10].Value = 0;
                int result = SqlHelper.ExecuteNonQuery(GetConnection(),"InsertarContacto", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _contacto;

        }


    /*    public IList<Contacto> Consultar()
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
        } */


        #region ConsultarContacto

        /// <summary>
        /// Metodo para consultar el Contacto
        /// </summary>
        /// <param name="usuario">Criterio de busqueda</param>
        /// <returns>Usuario(s) que coincidan con el criterio</returns>


        public IList<Contacto> Consultar(string Nombre,string Apellido,int Area,int Numero, int Zero)
        {
            IList<Contacto> contacto = new List<Contacto>();

            try
            {
                //Parametros de busqueda


                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@nombre", SqlDbType.VarChar);

                arParms[0].Value = Nombre;

                arParms[1] = new SqlParameter("@apellido", SqlDbType.VarChar);

                arParms[1].Value = Apellido;

                arParms[2] = new SqlParameter("@codigoArea", SqlDbType.Int);

                arParms[2].Value = Area;

                arParms[3] = new SqlParameter("@Numero", SqlDbType.Int);

                arParms[3].Value = Numero;

                DbDataReader reader = null;

                switch (Zero)
                {
                    case 0:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoVacio", arParms);

                        break;
                    case 1:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoTelefono", arParms);
                        break;
                    case 10:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoApellido", arParms);
                        break;
                    case 11:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoApellidoTelefono", arParms);
                        break;
                    case 100:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoNombre", arParms);
                        break;
                    case 101:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoNombreTelefono", arParms);

                        break;
                    case 110:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoNombreApellido", arParms);
                        break;
                    case 111:

                        reader = SqlHelper.ExecuteReader
                                                (GetConnection(), "ConsultarContactoNombreApellidoTelefono", arParms);
                        break;
                }


                Contacto _contacto = new Contacto();

                while (reader.Read())
                {

                    _contacto.Nombre = (string)reader["NOMBRE"];

                    _contacto.Apellido = (string)reader["APELLIDO"];

                    _contacto.AreaDeNegocio = (string)reader["AREA"];

                    _contacto.Cargo = (string)reader["CARGO"];

                    if ((string)reader["TIPO"] == "Celular")
                    {
                        _contacto.TelefonoDeCelular.Codigocel = (int)reader["CODIGOAREA"];

                        _contacto.TelefonoDeCelular.Numero = (int)reader["NUMERO"];
                    }

                    if ((string)reader["TIPO"] == "Trabajo")
                    {
                        _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader["CODIGOAREA"];

                        _contacto.TelefonoDeTrabajo.Numero = (int)reader["NUMERO"];

                        _contacto.TelefonoDeTrabajo.Tipo = (string)reader["TIPO"];
                    }

                    if ((string)reader["TIPO"] == "Fax")
                    {
                        _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader["CODIGOAREA"];

                        _contacto.TelefonoDeTrabajo.Numero = (int)reader["NUMERO"];

                        _contacto.TelefonoDeTrabajo.Tipo = (string)reader["TIPO"];
                    }
                    if (contacto.Count == 0)
                    {
                        contacto.Add(_contacto);
                        _contacto = new Contacto();
                    }
                    if (contacto.Last().Nombre!=_contacto.Nombre ||
                        contacto.Last().Apellido!=_contacto.Apellido ||
                        contacto.Last().AreaDeNegocio!=_contacto.AreaDeNegocio ||
                        contacto.Last().Cargo!=_contacto.Cargo)
                    {
                        contacto.Add(_contacto);
                        _contacto = new Contacto();
                    }
                }

                return contacto;

            }

            catch (SqlException e)
            {

            }

            return contacto;

        }

        #endregion


         public Contacto Eliminar(Contacto contacto)
        {
            Contacto _contacto = new Contacto();
            try
            {


                SqlParameter[] arParms = new SqlParameter[11];
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
                arParms[4].Value = contacto.TelefonoDeTrabajo.Numero;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto.TelefonoDeCelular.Numero;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                arParms[8].Value = contacto.TelefonoDeTrabajo.Tipo;
                arParms[9] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[9].Value = 1;
                arParms[10] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[10].Value = 0;
                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "EliminarContacto", arParms);
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

