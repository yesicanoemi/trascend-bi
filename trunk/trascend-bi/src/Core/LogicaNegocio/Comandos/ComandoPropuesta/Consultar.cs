using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class Consultar : Comando<Propuesta>
    {
        private Propuesta _propuesta;
        private IList<Propuesta> _propuesta2;

        #region Constructor
        public Consultar()
        {
        }
        public Consultar(Propuesta entidad)
        {
            _propuesta = entidad;
        }
        public Consultar(IList<Propuesta> arreglo)
        {
            _propuesta2 = arreglo;
        }
        #endregion

        #region Metodos

        public IList<Propuesta> Ejecutar()
        {

            PropuestaSQLServer acceso = new PropuestaSQLServer();
            _propuesta2 = acceso.ConsultarPropuesta();
            
            return _propuesta2;
        }

        #endregion
    }
}