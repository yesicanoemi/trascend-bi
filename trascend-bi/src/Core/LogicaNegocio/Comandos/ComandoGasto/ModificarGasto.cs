using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;


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
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;
            IDAOGasto modificarbd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOGasto();
          //  DAOGastoSQLServer bd = new DAOGastoSQLServer();
            _gasto = modificarbd.ModificarGasto(gasto);
            return _gasto;
        }
        #endregion
    }
}
