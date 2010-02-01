using System;
using System.Collections.Generic;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.SqlServer;

namespace Core.AccesoDatos.Fabricas
{

    public class FabricaDAOSQLServer: FabricaDAO
    {
        // Hay que poner un metodo para crear la conexion... Por definir
        /*public static Connection createConnection()
        {
           
        } */

        public override IDAOCliente ObtenerDAOCliente()  //devuelvo el DTA en forma de interfaz para cumplir el contrato
        {
            return new DAOClienteSQLServer();
        }
        /// <summary>
        /// M�todo que g�nera la f�brica para el DAO de la entidad Usuario
        /// </summary>
        /// <returns>Interface del DAO de la entidad Usuario</returns>

        public override IDAOUsuario ObtenerDAOUsuario()
        {
            return new DAOUsuarioSQLServer();
        }

        /// <summary>
        /// M�todo que g�nera la f�brica para el DAO de la entidad Factura
        /// </summary>
        /// <returns>Interface del DAO de la entidad Factura</returns>
        public override IDAOFactura ObtenerDAOFactura()
        {
            return new DAOFacturaSQLServer();
        }


        public override IDAOGasto ObtenerDAOGasto()
        {
            return new DAOGastoSQLServer();
        }


        public override IDAOPropuesta ObtenerDAOPropuesta()
        {
            return new DAOPropuestaSQLServer();
        }

        public override IDAOContacto ObtenerDAOContacto()
        {
            return new DAOContactoSQLServer();
        }

        public override IDAOEmpleado ObtenerDAOEmpleado()
        {
            return new DAOEmpleadoSQLServer();
        }

        public override IDAOCargo ObtenerDAOCargo()
        {
            return new DAOCargoSQLServer();
        }
    }

}

