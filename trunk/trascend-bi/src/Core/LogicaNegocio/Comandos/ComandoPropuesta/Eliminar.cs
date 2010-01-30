using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class Eliminar : Comando<Propuesta>
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
            //DAOPropuestaSQLServer acceso = new DAOPropuestaSQLServer();
            //_lista = acceso.ListaEliminar(ListaRecibida);

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOPropuesta iDAOPropuesta = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOPropuesta();

            _lista = iDAOPropuesta.ListaEliminar(ListaRecibida);

            return _lista;
        }

        #endregion
    }
}
