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
    public class ConsultarPropuestasxEmision : Comando<Propuesta>
    {

        #region Constructor
        public ConsultarPropuestasxEmision()
        {
        }

        #endregion

        #region Metodos

        public IList<Propuesta> Ejecutar()
        {
            IList<Propuesta> _propuestas = null;
            //DAOPropuestaSQLServer bdpropuestas = new DAOPropuestaSQLServer();
            //_propuestas = bdpropuestas.ConsultarPropuestaOrdenadoPorEmision();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOPropuesta iDAOPropuesta = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOPropuesta();

            _propuestas = iDAOPropuesta.ConsultarPropuestaOrdenadoPorEmision();

            return _propuestas;
        }

        #endregion
    }
}