using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

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
            PropuestaSQLServer acceso = new PropuestaSQLServer();
            _lista = acceso.ListaEliminar(ListaRecibida);
            return _lista;
        }

        #endregion
    }
}
