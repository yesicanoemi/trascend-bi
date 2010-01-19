using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

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
            PropuestaSQLServer bdpropuestas = new PropuestaSQLServer();
            _propuestas = bdpropuestas.ConsultarPropuestaOrdenadoPorEmision();
            return _propuestas;
        }

        #endregion
    }
}