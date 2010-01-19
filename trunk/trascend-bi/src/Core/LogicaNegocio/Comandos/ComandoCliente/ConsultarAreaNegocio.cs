using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class ConsultarAreaNegocio : Comando<Cliente>
    {
        private Cliente _cliente;
        private IList<Cliente> _cliente2;

        #region constructor

            public ConsultarAreaNegocio()
            { }
            
            public ConsultarAreaNegocio(Cliente cliente)
            {
                _cliente = cliente;
            }

            public ConsultarAreaNegocio(IList<Cliente> cliente)
            {
                _cliente2 = cliente;
            }

        #endregion

        #region metodos
            public IList<Cliente> Ejecutar()
            {
                #region Llamamos a DAOClientesqlserver y accedemos a los datos

                    DAOClienteSQLServer acceso = new DAOClienteSQLServer();

                    _cliente2 = acceso.ConsultarAreaNegocio();

                    return _cliente2;

                #endregion

            }

        #endregion
    }
}
