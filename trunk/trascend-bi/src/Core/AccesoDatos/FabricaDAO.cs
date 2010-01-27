using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;

namespace Core.AccesoDatos
{
    public abstract class FabricaDAO : IFabricaDAO
    {
        private static EnumFabrica enumFabrica;

        public static EnumFabrica EnumFabrica
        {
            get { return enumFabrica; }
            set { enumFabrica = value; }
        }

        public abstract IDAOCliente ObtenerDAOCliente();

        public static FabricaDAO ObtenerFabricaDAO()
        {
            switch (enumFabrica)
            {
               case EnumFabrica.SqlServer:
                    return new FabricaDAOSQLServer();
               case EnumFabrica.Oracle:
                    break;
               default:
                    break;
            }

            return null;
        }
        
        #region IFabrica Miembros

            public abstract Core.AccesoDatos.Interfaces.IDAOUsuario AgregarUsuario();
           
            public abstract Core.AccesoDatos.Interfaces.IDAOCliente ConsultarNombre();

        //    public abstract Core.AccesoDatos.Interfaces.IDAOUsuario EliminarUsuario();

        #endregion

       /* public static FabricaDAO ObtenerFabricaDAO(String tipo)
        {
            if (tipo.Equals("DAOSQLServer"))
            if (tipo.Equals("SQLServer"))
                return new FabricaDAOSQLServer();
            //else if (tipo.Equals("Oracle"))  //->ejemplo con otro manejador de BD
            //return new FabricaDAOOracle();   
            else return null;
        }*/
    }
}
