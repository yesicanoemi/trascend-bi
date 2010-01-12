using System;
using System.Collections.Generic;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.SqlServer;

namespace Core.AccesoDatos.Fabricas
{

    public class FabricaDAOSQLServer
    {

        public static IDAOEmpleado ObtenerDAOEmpleado()
        {
            return new DAOEmpleadoSQLServer();
        }
        public static IDAOPropuesta ObtenerDAOPropuesta()
        {
            return new DAOPropuestaSQLServer();
        }

        public static IDAOFactura ObtenerDAOFactura()
        {
            return new DAOFacturaSQLServer();
        }

    }
}

