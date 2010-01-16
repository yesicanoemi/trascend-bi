using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class ConsultarPropuestas : Comando<Propuesta>
    {

        #region Constructor
        public ConsultarPropuestas()
        {
        }

        #endregion

        #region Metodos

        public IList<Propuesta> Ejecutar()
        {
            IList<Propuesta> _propuestas = null;
            FacturaSQLServer bdpropuestas = new FacturaSQLServer();
            _propuestas = bdpropuestas.ConsultarPropuesta();
            return _propuestas;
        }

        #endregion
    }
}