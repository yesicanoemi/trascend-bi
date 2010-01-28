using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ConsultarGastoPorPropuesta
    {
        private Propuesta propuesta;
        private IList<Propuesta> listaPropuesta = null;
        private IList<Gasto> listagastos;

        #region Constructor

        /// <summary> Conructor de la Clase 'ConsultarGasto' </summary>
        public ConsultarGastoPorPropuesta(Propuesta _propuesta)
        {
            propuesta = _propuesta;
        }

        /// <summary> Contructor de la Clase 'ConsultarGasto' </summary>
        public ConsultarGastoPorPropuesta(IList<Propuesta> _listaPropuesta)
        {
            listaPropuesta = _listaPropuesta;
        }

        #endregion

        #region Metodo

        public IList<Gasto> Ejecutar()
        {
            DAOGastoSQLServer bd = new DAOGastoSQLServer();
            listagastos = bd.ConsultarGastoPorPropuesta(propuesta);

            return listagastos;
        }

        #endregion
    }

}
