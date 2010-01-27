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

        // Se utiliza el enum tipo String para saber con que Fabrica
        // concreta vamos a trabajar
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

        //    public abstract Core.AccesoDatos.Interfaces.IDAOUsuario EliminarUsuario();

        #endregion

        #region metodos abstractos DTA

        /// <summary>
        /// Metodo para devolvier el DTA de cliente de SQL Server
        /// </summary>
        /// <returns></returns>
        public abstract IDAOCliente ObtenerDAOCliente();

        #endregion

        public static FabricaDAO ObtenerFabricaDAO(String tipo)
        {
            if (tipo.Equals("SQLServer"))
                return new FabricaDAOSQLServer();
            //else if (tipo.Equals("Oracle"))  //->ejemplo con otro manejador de BD
            //    return new FabricaDAOOracle();   
            else return null;
        }
    }
}
