using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ConsultarGastoPorTipo
    {
        private Gasto gasto;
        private IList<Gasto> listagastos = null;

        #region Constructor

        /// <summary> Conructor de la Clase 'ConsultarGasto' </summary>
        public ConsultarGastoPorTipo(Gasto _gasto)
        {
            gasto = _gasto;
        }

        /// <summary> Contructor de la Clase 'ConsultarGasto' </summary>
        public ConsultarGastoPorTipo(IList<Gasto> _listagasto)
        {
            listagastos = _listagasto;
        }

        #endregion

        #region Metodo

        public IList<Gasto> Ejecutar()
        {

            DAOGastoSQLServer bd = new DAOGastoSQLServer();
            listagastos = bd.ConsultarGastoPorTipo();

            return listagastos;
        }
        #endregion
    }
}