using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class ConsultarParametroAreaNegocio : Comando<Cliente>
    {
        private Cliente _cliente;
        private IList<Cliente> _cliente2;

        #region Constructor


        public ConsultarParametroAreaNegocio()
        { }



        public ConsultarParametroAreaNegocio(Cliente cliente)
        {
            _cliente = cliente;
        }

        public ConsultarParametroAreaNegocio(IList<Cliente> cliente)
        {
            _cliente2 = cliente;
        }


        #endregion


        #region Metodos

        public IList<Cliente> ejecutar(Cliente entidad)
        {
            Core.AccesoDatos.SqlServer.DAOClienteSQLServer acceso =
                new Core.AccesoDatos.SqlServer.DAOClienteSQLServer();

            _cliente2 = acceso.ConsultarParamtroAreaNegocio(entidad);

            return _cliente2;


        }
        #endregion
    }
}
