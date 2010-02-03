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
using Core.LogicaNegocio.Excepciones.Cliente.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;


namespace Core.AccesoDatos.SqlServer
{
    public class DAOClienteSQLServer : IDAOCliente
    {

        #region Propiedades

        IConexion _conexion = new FabricaConexion().getConexionSQLServer();

        List<Cliente> listaCliente = new List<Cliente>();

        #endregion

        #region Constructor
        public DAOClienteSQLServer()
        {
        }
        #endregion

        #region Conexion a Base de Datos (obsoleto)
        [Obsolete("Este metodo ya no se usa")]
        private SqlConnection GetConnection()
        {
            try
            {

                XmlDocument xDoc = new XmlDocument();

                //La ruta del documento XML permite rutas relativas 
                //respecto del ejecutable!

                xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

                XmlNodeList conexiones = xDoc.GetElementsByTagName("connectionSQLServer");

                string lista = conexiones[0].InnerText;
                SqlConnection connection = new SqlConnection(lista);
                connection.Open();
                return connection;
            }
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones("No se pudo conectar con la base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones("No se pudo encontrar el XML", e);
            }


        }
        #endregion

        #region Metodos

        public Cliente Ingresar(Cliente cliente)
        {
            Cliente _cliente = new Cliente();
            try
            {

                SqlParameter[] arParms = new SqlParameter[8];

                // Parametros 

                #region Cliente

                arParms[0] = new SqlParameter("@rif", SqlDbType.VarChar);
                arParms[0].Value = cliente.Rif;

                arParms[1] = new SqlParameter("@nombre", SqlDbType.VarChar);
                arParms[1].Value = cliente.Nombre;

                arParms[3] = new SqlParameter("@urb", SqlDbType.VarChar);
                arParms[3].Value = cliente.Direccion.Urbanizacion;

                arParms[2] = new SqlParameter("@calleAv", SqlDbType.VarChar);
                arParms[2].Value = cliente.Direccion.Avenida;

                arParms[4] = new SqlParameter("@EdiCas", SqlDbType.VarChar);
                arParms[4].Value = cliente.Direccion.Edif_Casa;

                arParms[5] = new SqlParameter("@PisoApto", SqlDbType.VarChar);
                arParms[5].Value = cliente.Direccion.Oficina;

                arParms[6] = new SqlParameter("@Ciudad", SqlDbType.VarChar);
                arParms[6].Value = cliente.Direccion.Ciudad;

                arParms[7] = new SqlParameter("@AreaNeg", SqlDbType.VarChar);
                arParms[7].Value = cliente.AreaNegocio;

                DbDataReader conexion = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "InsertarCliente", arParms);

                if (conexion.Read())
                    cliente.IdCliente = (int)conexion["IdCliente"];

                #endregion

                #region Telefonos

                for (int i = 0; i < 3; i++)
                {
                    if (cliente.Telefono[i] != null)
                    {
                        arParms = new SqlParameter[4];

                        arParms[0] = new SqlParameter("@Tlf", SqlDbType.VarChar);
                        arParms[0].Value = cliente.Telefono[i].Numero.ToString();

                        arParms[1] = new SqlParameter("@codTlf", SqlDbType.VarChar);
                        arParms[1].Value = cliente.Telefono[i].Codigoarea.ToString();

                        int tipotelf = 0;

                        if (cliente.Telefono[i].Tipo.Equals("Trabajo"))
                        {
                            tipotelf = 1;
                        }
                        else if (cliente.Telefono[i].Tipo.Equals("Celular"))
                        {
                            tipotelf = 2;
                        }
                        else if (cliente.Telefono[i].Tipo.Equals("Fax"))
                        {
                            tipotelf = 3;
                        }

                        arParms[2] = new SqlParameter("@tipoTelf", SqlDbType.Int);
                        arParms[2].Value = tipotelf;

                        arParms[3] = new SqlParameter("@idCliente", SqlDbType.Int);
                        arParms[3].Value = cliente.IdCliente;

                        int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "InsertarTelefono", arParms);
                    }
                }

                #endregion



                return _cliente;

            }
            catch (SqlException e)
            {
                throw new IngresarClienteBDExepciones
                    ("Error de SQL en ingresando el cliente en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new IngresarClienteBDExepciones
                    ("Error ingresando cliente en la base de datos", e);
            }



        }

        public Cliente Modificar(Cliente cliente)
        {
            try
            {

                SqlParameter[] arParms = new SqlParameter[9];

                // Parametros 

                #region Cliente

                arParms[0] = new SqlParameter("@rif", SqlDbType.VarChar);
                arParms[0].Value = cliente.Rif;

                arParms[1] = new SqlParameter("@nombre", SqlDbType.VarChar);
                arParms[1].Value = cliente.Nombre;

                arParms[3] = new SqlParameter("@urb", SqlDbType.VarChar);
                arParms[3].Value = cliente.Direccion.Urbanizacion;

                arParms[2] = new SqlParameter("@calleAv", SqlDbType.VarChar);
                arParms[2].Value = cliente.Direccion.Avenida;

                arParms[4] = new SqlParameter("@EdiCas", SqlDbType.VarChar);
                arParms[4].Value = cliente.Direccion.Edif_Casa;

                arParms[5] = new SqlParameter("@PisoApto", SqlDbType.VarChar);
                arParms[5].Value = cliente.Direccion.Oficina;

                arParms[6] = new SqlParameter("@Ciudad", SqlDbType.VarChar);
                arParms[6].Value = cliente.Direccion.Ciudad;

                arParms[7] = new SqlParameter("@AreaNeg", SqlDbType.VarChar);
                arParms[7].Value = cliente.AreaNegocio;

                arParms[8] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[8].Value = cliente.IdCliente;


                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarCliente", arParms);

                #endregion

                #region Telefonos

                for (int i = 0; i < 3; i++)
                {
                    if (cliente.Telefono[i] != null)
                    {
                        arParms = new SqlParameter[4];

                        arParms[0] = new SqlParameter("@Tlf", SqlDbType.Int);
                        arParms[0].Value = cliente.Telefono[i].Numero;

                        arParms[1] = new SqlParameter("@codTlf", SqlDbType.Int);
                        arParms[1].Value = cliente.Telefono[i].Codigoarea;

                        int tipotelf = 0;

                        if (cliente.Telefono[i].Tipo.Equals("Trabajo"))
                        {
                            tipotelf = 1;
                        }
                        else if (cliente.Telefono[i].Tipo.Equals("Celular"))
                        {
                            tipotelf = 2;
                        }
                        else if (cliente.Telefono[i].Tipo.Equals("Fax"))
                        {
                            tipotelf = 3;
                        }

                        Console.WriteLine(tipotelf);

                        arParms[2] = new SqlParameter("@tipoTelf", SqlDbType.Int);
                        arParms[2].Value = tipotelf;

                        arParms[3] = new SqlParameter("@idCliente", SqlDbType.Int);
                        arParms[3].Value = cliente.IdCliente;

                        result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarTelefono", arParms);
                    }
                }

                #endregion



                return cliente;

            }
            catch (SqlException e)
            {
                throw new IngresarClienteBDExepciones
                    ("Error de SQL en ingresando el cliente en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new IngresarClienteBDExepciones
                    ("Error ingresando cliente en la base de datos", e);
            }
        }

        public IList<Cliente> ConsultarTodos()
        {
            try
            {
                IList<Cliente> listaCliente = new List<Cliente>();

                DbDataReader conexion = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarClientes");

                int i = 0;

                while (conexion.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.Direccion = new Direccion();

                    cliente.IdCliente = (int)conexion["IdCliente"];

                    cliente.Nombre = (string)conexion["Nombre"];

                    cliente.Rif = (string)conexion["RifCliente"];

                    /*cliente.Direccion.Urbanizacion = (string)conexion["Urbanizacion"];

                    cliente.Direccion.Avenida = (string)conexion["CalleAvenidad"];

                    cliente.Direccion.Edif_Casa = (string)conexion["EdificioCasa"];

                    cliente.Direccion.Oficina = (string)conexion["PisoApartamento"];

                    cliente.Direccion.Ciudad = (string)conexion["Ciudad"];

                    cliente.AreaNegocio = (string)conexion["AreaNegocio"];

                    cliente.Telefono = new TelefonoTrabajo[3];
                    
                    cliente.Telefono = BuscarTelefonos(cliente.IdCliente);*/

                    //Console.WriteLine(cliente.Telefono[1].Tipo);

                    //IList<Contacto> _listaContacto = new List<Contacto>();

                    //_listaContacto = BuscarContacto(cliente.IdCliente);

                    listaCliente.Add(cliente);

                    i++;
                }


                //if (listaCliente.Count == 0)

                //    throw new ConsultarClienteBDExcepciones();

                return listaCliente;

            }

            #region Execepciones
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error en el SQL al consultar el cliente en la base de daot", e);
            }
            catch (ConsultarClienteBDExcepciones e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ninguna informacion del cliente en la base de dato", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ninguna informacion del cliente en la base de dato", e);
            }
            #endregion
        }

        /// <summary>
        /// Buscar los telefonos de un cliente
        /// </summary>
        /// <param name="?">telefonos</param>
        /// <returns></returns>
        private TelefonoTrabajo[] BuscarTelefonos(int IdCliente)
        {
            TelefonoTrabajo[] telefonosA = new TelefonoTrabajo[3];

            try
            {

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@IdCLiente", SqlDbType.Int);
                arParms[0].Value = IdCliente;

                DbDataReader conexion = SqlHelper.ExecuteReader
                        (_conexion.GetConnection(), "ConsultarTelefonosCliente", arParms);

                int i = 0;

                while (conexion.Read())
                {
                    //Console.WriteLine(i);

                    telefonosA[i] = new TelefonoTrabajo();

                    telefonosA[i].Codigoarea = (int)conexion["CodigoArea"];

                    telefonosA[i].Numero = (int)conexion["Numero"];

                    telefonosA[i].Tipo = (string)conexion["Nombre"];

                    //Console.WriteLine(telefonos[i].Tipo);

                    //Console.WriteLine("------");

                    i++;
                }
            }
            catch (Exception e)
            {                
                throw new ConsultarClienteBDExcepciones
                    ("Error en el SQL al consultar el cliente en la base de daot", e);
                return telefonosA;
            }

            return telefonosA;
        }

        public IList<Cliente> ConsultarNombre(Cliente cliente)
        {
            IList<Cliente> listaCliente = new List<Cliente>();

            try
            {
                

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@nombre", SqlDbType.VarChar);
                arParms[0].Value = cliente.Nombre;

                DbDataReader conexion = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarClienteNombre", arParms);


                int i = 0;



                while (conexion.Read())
                {
                    cliente = new Cliente();

                    cliente.Direccion = new Direccion();

                    cliente.IdCliente = (int)conexion["IdCliente"];

                    cliente.Nombre = (string)conexion["Nombre"];

                    cliente.Rif = (string)conexion["RifCliente"];

                    cliente.Direccion.Urbanizacion = (string)conexion["Urbanizacion"];

                    cliente.Direccion.Avenida = (string)conexion["CalleAvenidad"];

                    cliente.Direccion.Edif_Casa = (string)conexion["EdificioCasa"];

                    cliente.Direccion.Oficina = (string)conexion["PisoApartamento"];

                    cliente.Direccion.Ciudad = (string)conexion["Ciudad"];

                    cliente.AreaNegocio = (string)conexion["AreaNegocio"];

                    cliente.Telefono = new TelefonoTrabajo[3];

                    cliente.Telefono = BuscarTelefonos(cliente.IdCliente);

                    //Console.WriteLine(cliente.Telefono[1].Tipo);

                    //IList<Contacto> _listaContacto = new List<Contacto>();

                    //_listaContacto = BuscarContacto(cliente.IdCliente);

                    listaCliente.Add(cliente);

                    i++;
                }


                return listaCliente;

            }

            #region Execepciones
            catch (SqlException e)
            {                
                throw new ConsultarClienteBDExcepciones
                    ("Error en el SQL al consultar el cliente en la base de daot", e);

            }
            catch (ConsultarClienteBDExcepciones e)
            {                
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ninguna informacion del cliente en la base de dato", e);

            }
            catch (Exception e)
            {                
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ninguna informacion del cliente en la base de dato", e);
                
            }
            #endregion

            return listaCliente;


        }


        public Direccion buscarDireccion(int idCliente)
        {
            SqlParameter arParms = new SqlParameter();

            arParms = new SqlParameter("@idCliente", SqlDbType.Int);

            arParms.Value = idCliente;

            SqlDataReader reader = SqlHelper.ExecuteReader
                        (GetConnection(), "ConsultarDireccionCliente", arParms);

            Direccion direcccion = new Direccion();

            if (reader.Read())
            {
                direcccion.Avenida = (string)reader["Avenida"];

                direcccion.Calle = (string)reader["Calle"];

                direcccion.Ciudad = (string)reader["Ciudad"];

                direcccion.Edif_Casa = (string)reader["EdifCasa"];

                direcccion.Piso_apto = (string)reader["PisoApto"];

                direcccion.Urbanizacion = (string)reader["Urbanizacion"];
            }

            return direcccion;
        }

        public List<Contacto> BuscarContacto(int IdCliente)
        {
            List<Contacto> ListaContacto = new List<Contacto>();

            try
            {

                SqlParameter parametros = new SqlParameter();

                parametros = new SqlParameter("@IdCliente", SqlDbType.Int);

                parametros.Value = IdCliente;

                DbDataReader conexion =
                SqlHelper.ExecuteReader(GetConnection(), "ConsultarListaContacto", parametros);

                int i = 0;


                while (conexion.Read())
                {

                    Contacto _Contacto = new Contacto();

                    _Contacto.Nombre = (string)conexion["Nombre"];
                    _Contacto.Apellido = (string)conexion["Apellido"];
                    ListaContacto.Insert(i, _Contacto);
                    i++;

                }

                return ListaContacto;
            }
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error en SQL consultando la lista de contacto del cliente", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error consultado el la lista de contacto en la base de dato", e);
            }
        }

        public List<Cliente> ConsultarParamtroNombre(Cliente entidad)
        {
            List<Cliente> ListaCliente = new List<Cliente>();

            try
            {

                SqlParameter parametros = new SqlParameter();

                parametros = new SqlParameter("@Nombre", SqlDbType.VarChar);

                parametros.Value = entidad.Nombre;

                DbDataReader conexion =
                SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarClienteParametroNombre", parametros);

                int i = 0;


                while (conexion.Read())
                {

                    Cliente _Cliente = new Cliente();

                    _Cliente.IdCliente = (int)conexion["IdCliente"];

                    _Cliente.Nombre = (string)conexion["Nombre"];

                    _Cliente.Rif = (string)conexion["RifCliente"];

                    _Cliente.AreaNegocio = (string)conexion["AreaNegocio"];

                    Direccion _Direccion = new Direccion();

                    _Cliente.Direccion = buscarDireccion(_Cliente.IdCliente);

                    IList<Contacto> _listaContacto = new List<Contacto>();

                    _listaContacto = BuscarContacto(_Cliente.IdCliente);

                    _Cliente.Contacto = _listaContacto;

                    ListaCliente.Insert(i, _Cliente);

                    i++;

                }

                if (ListaCliente.Count == 0)

                    throw new ConsultarClienteBDExcepciones();


                return ListaCliente;
            }
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error en SQL consultando la lista de contacto del cliente", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error consultado el la lista de contacto en la base de dato", e);
            }
        }

        public IList<Cliente> ConsultarParamtroAreaNegocio(Cliente cliente)
        {
            List<Cliente> ListaCliente = new List<Cliente>();

            try
            {

                SqlParameter parametros = new SqlParameter();

                parametros = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);

                parametros.Value = cliente.AreaNegocio;

                DbDataReader conexion =
                SqlHelper.ExecuteReader(GetConnection(), "ConsultarClienteParametroAreaNegocio", parametros);

                int i = 0;


                while (conexion.Read())
                {

                    Cliente _Cliente = new Cliente();

                    _Cliente.IdCliente = (int)conexion["ClienteId"];

                    _Cliente.Nombre = (string)conexion["Nombre"];

                    _Cliente.Rif = (string)conexion["RifCliente"];

                    _Cliente.AreaNegocio = (string)conexion["AreaNegocio"];

                    Direccion _Direccion = new Direccion();

                    _Cliente.Direccion = buscarDireccion(_Cliente.IdCliente);

                    IList<Contacto> _listaContacto = new List<Contacto>();

                    _listaContacto = BuscarContacto(_Cliente.IdCliente);

                    _Cliente.Contacto = _listaContacto;

                    ListaCliente.Insert(i, _Cliente);

                    i++;

                }

                return ListaCliente;
            }
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error en SQL consultando la lista de contacto del cliente", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error consultado el la lista de contacto en la base de dato", e);
            }
        }

        public IList<Cliente> ConsultarAreaNegocio()
        {
            #region ConsultarAreaNegocio

            try
            {
                DbDataReader conexion = SqlHelper.ExecuteReader
                    (GetConnection(), "ConsultarClienteAreaNegocio");

                int i = 0;

                while (conexion.Read())
                {
                    #region guarda Datos

                    Cliente _Cliente = new Cliente();

                    _Cliente.AreaNegocio = (String)conexion["AreaNegocio"];

                    listaCliente.Insert(i, _Cliente);

                    i++;
                    #endregion
                }

                return listaCliente;
            }
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error de sql consultando area de negocio del cliente", e);
            }
            catch (ConsultarClienteBDExcepciones e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ningun area de negocio en la base de dato", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error al consultar las areas de negocios que existen en la base de dato", e);
            }

            #endregion
        }

        public IList<string> ListaEliminar(List<string> ListaRecibida)
        {
            if (ListaRecibida.Count == 0)
            {
                try
                {
                    DbDataReader conexion = SqlHelper.ExecuteReader
                            (GetConnection(), "ConsultarClienteEliminar");
                    List<string> lista = new List<string>();


                    while (conexion.Read())
                    {
                        lista.Add((string)conexion["Nombre"]);
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
                    string NombreParametro = ListaRecibida.ElementAt(0);

                    SqlParameter nombre = new SqlParameter();

                    nombre = new SqlParameter("@Nombre", SqlDbType.VarChar);

                    nombre.Value = NombreParametro;

                    int result = SqlHelper.ExecuteNonQuery(GetConnection(), "EliminarCliente", nombre);

                    return ListaRecibida;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.ToString());
                }
            }
        }

        public Cliente EliminarCliente(Cliente cliente)
        {
            try
            {

                SqlParameter[] arParms = new SqlParameter[1];

                // Parametros 

                #region Cliente

                arParms[0] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[0].Value = cliente.IdCliente;

                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "EliminarCliente", arParms);

                #endregion

                return cliente;

            }
            catch (SqlException e)
            {
                throw new IngresarClienteBDExepciones
                    ("Error de SQL en ingresando el cliente en la Base de Datos", e);
            }
            catch (Exception e)
            {
                throw new IngresarClienteBDExepciones
                    ("Error ingresando cliente en la base de datos", e);
            }
        }

        public IList<Cliente> ConsultarRif(Cliente cliente)
        {
            try
            {
                IList<Cliente> listaCliente = new List<Cliente>();

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@rif", SqlDbType.VarChar);
                arParms[0].Value = cliente.Rif;

                DbDataReader conexion = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarClienteRif", arParms);


                int i = 0;


                while (conexion.Read())
                {
                    cliente = new Cliente();

                    cliente.Direccion = new Direccion();

                    cliente.IdCliente = (int)conexion["IdCliente"];

                    cliente.Nombre = (string)conexion["Nombre"];

                    cliente.Rif = (string)conexion["RifCliente"];

                    cliente.Direccion.Urbanizacion = (string)conexion["Urbanizacion"];

                    cliente.Direccion.Avenida = (string)conexion["CalleAvenidad"];

                    cliente.Direccion.Edif_Casa = (string)conexion["EdificioCasa"];

                    cliente.Direccion.Oficina = (string)conexion["PisoApartamento"];

                    cliente.Direccion.Ciudad = (string)conexion["Ciudad"];

                    cliente.AreaNegocio = (string)conexion["AreaNegocio"];

                    cliente.Telefono = new TelefonoTrabajo[3];

                    cliente.Telefono = BuscarTelefonos(cliente.IdCliente);

                    //Console.WriteLine(cliente.Telefono[1].Tipo);

                    //IList<Contacto> _listaContacto = new List<Contacto>();

                    //_listaContacto = BuscarContacto(cliente.IdCliente);

                    listaCliente.Add(cliente);
                }


                return listaCliente;

            }

            #region Execepciones
            catch (SqlException e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("Error en el SQL al consultar el cliente en la base de daot", e);
            }
            catch (ConsultarClienteBDExcepciones e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ninguna informacion del cliente en la base de dato", e);
            }
            catch (Exception e)
            {
                throw new ConsultarClienteBDExcepciones
                    ("No se encontro ninguna informacion del cliente en la base de dato", e);
            }
            #endregion
        }

        #endregion
    }
}
