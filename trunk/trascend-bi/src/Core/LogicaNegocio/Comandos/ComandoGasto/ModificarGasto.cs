using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ModificarGasto : Comando<Gasto>
    {
        private Gasto gasto;

        #region Constructor

        /// <summary> Conructor de la Clase 'ModificarGasto' </summary>
        public ModificarGasto()
        { }

        /// <summary>Constructor de la clase 'Modificar'.</summary>
        public ModificarGasto(Gasto gasto)
        {
            this.gasto = gasto;
        }

        #endregion

        #region Metodos
        public Gasto Ejecutar()
        {
            Gasto _gasto = null;
            DAOGastoSQLServer bd = new DAOGastoSQLServer();
            _gasto = bd.ModificarGasto(gasto);
            return _gasto;
        }
        #endregion
    }
}
