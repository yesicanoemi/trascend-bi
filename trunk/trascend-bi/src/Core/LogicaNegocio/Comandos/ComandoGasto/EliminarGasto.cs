using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class EliminarGasto : Comando<Gasto>
    {
        private Gasto gasto;

        #region Constructor

        /// <summary> Conructor de la Clase 'EliminarGasto' </summary>
        public EliminarGasto()
        { }

        /// <summary>Constructor de la clase 'Eliminar'.</summary>
        public EliminarGasto(Gasto gasto)
        {
            this.gasto = gasto;
        }

        #endregion

        #region Metodos
        public void Ejecutar()
        {
            //Gasto _gasto = null;
            //GastoSQLServer bd = new GastoSQLServer();
            //_gasto = bd.EliminarGasto(gasto);
        }
        #endregion
    }
}
