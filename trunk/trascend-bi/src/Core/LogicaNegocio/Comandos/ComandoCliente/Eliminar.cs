using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class Eliminar : Comando<Cliente>
    {
        private IList<string> _lista;

        #region Constructor
        public Eliminar()
        {
        }
        public Eliminar(IList<string> lista)
        {
            _lista = lista;
        }
        #endregion

        #region Metodos

        public IList<string> Ejecutar(List<string> ListaRecibida)
        {
            DAOClienteSQLServer acceso = new DAOClienteSQLServer();
            _lista = acceso.ListaEliminar(ListaRecibida);
            return _lista;
        }

        #endregion
    }
}
