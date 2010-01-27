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

        public override IDAOUsuario ObtenerDAOUsuario()
        {
            return new DAOUsuarioSQLServer();
        }

        /// <summary>
        /// Método que génera la fábrica para el DAO de la entidad Factura
        /// </summary>
        /// <returns>Interface del DAO de la entidad Factura</returns>
        public override IDAOFactura ObtenerDAOFactura()
        {
            return new DAOFacturaSQLServer();
        }
    }

}

