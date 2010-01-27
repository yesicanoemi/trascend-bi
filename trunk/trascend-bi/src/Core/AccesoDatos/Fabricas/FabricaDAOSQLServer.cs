using System;
using System.Collections.Generic;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.SqlServer;

namespace Core.AccesoDatos.Fabricas
{

    public class FabricaDAOSQLServer: FabricaDAO
    {
        public IDAOCliente ObtenerDAOClienteSQLServer()  //devuelvo el DTA en forma de interfaz para cumplir el contrato
        {
            return new DAOClienteSQLServer();
        }
    }
}

