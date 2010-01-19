using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class Eliminar : Comando<Propuesta>
    {
        private Propuesta _propuesta;

        #region Constructor
        public Eliminar()
        {
        }
        public Eliminar(Propuesta entidad)
        {
            _propuesta = entidad;
        }
        #endregion
    }
}
