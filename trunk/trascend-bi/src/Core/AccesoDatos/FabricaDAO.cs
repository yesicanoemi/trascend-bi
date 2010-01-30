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
               case EnumFabrica.MySQL:
                    break;
               default:
                    break;
            }

            return null;
        }

        #region metodos abstractos DTA

        /// <summary>
        /// Metodo para devolvier el DTA de cliente
        /// </summary>
        /// <returns></returns>
        public abstract IDAOCliente ObtenerDAOCliente();

        /// <summary>
        /// Metodo para devolvier el DTA de usuario
        /// </summary>
        /// <returns></returns>
        public abstract IDAOUsuario ObtenerDAOUsuario();


        public abstract IDAOFactura ObtenerDAOFactura();

        /// <summary>
        /// Metodo que devuelve el DTA de Contacto
        /// </summary>
        /// <returns></returns>
        public abstract IDAOContacto ObtenerDAOContacto();

        /// <summary>
        /// Metodo que devuelve el DTA de Gasto
        /// </summary>
        /// <returns></returns>
        public abstract IDAOGasto ObtenerDAOGasto();

        /// <summary>
        /// Metodo que devuelve el DTA de Propuesta
        /// </summary>
        /// <returns></returns>
        public abstract IDAOPropuesta ObtenerDAOPropuesta();

        /// <summary>
        /// Metodo que devuelve el DTA de Empleado
        /// </summary>
        /// <returns></returns>
        public abstract IDAOEmpleado ObtenerDAOEmpleado();

        #endregion

       
    }
}
