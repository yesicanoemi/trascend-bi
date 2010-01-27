using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;

namespace Core.AccesoDatos
{
    public abstract class FabricaDAO
    {
        public abstract IDAOCliente ObtenerDAOCliente();

        public static FabricaDAO ObtenerFabricaDAO(String tipo)
        {
            if (tipo.Equals("SQLServer"))
                return new FabricaDAOSQLServer();
            //else if (tipo.Equals("Oracle"))  //->ejemplo con otro manejador de BD
            //return new FabricaDAOOracle();   
            else return null;
        }
    }
}
