using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Fabricas;

namespace Core.AccesoDatos.Fabricas
{
    public abstract class FabricaDAO
    {
        public static FabricaDAO ObtenerFabricaDAO(String tipo)
        {
            if (tipo.Equals("DAOSQLServer"))
                return new FabricaDAOSQLServer();
            //else if (tipo.Equals("DAOOracle"))  //->ejemplo con otro manejador de BD
            //return new FabricaDAOOracle();   
            else return null;
        }
    }
}
