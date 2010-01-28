using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ConsultarGastoPorEstado
    {
        private Gasto gasto;
        private IList<Gasto> listaGasto;

        #region Constructor

        public ConsultarGastoPorEstado(Gasto _gasto)
        {
            gasto = _gasto;
        }

        public ConsultarGastoPorEstado(IList<Gasto> _listaGasto)
        {
            listaGasto = _listaGasto;
        }

        #endregion

        #region Metodo

        public IList<Gasto> Ejecutar()
        {
            DAOGastoSQLServer bd = new DAOGastoSQLServer();
            listaGasto = bd.ConsultarGastoPorEstado(gasto);

            return listaGasto;
        }
        #endregion
    }
}