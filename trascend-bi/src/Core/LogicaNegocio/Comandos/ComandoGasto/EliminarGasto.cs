using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

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
        /// <summary>
        /// Ejecuta el comando para eliminar el registro en la base de datos
        /// </summary>
        public Gasto Ejecutar()
        {

            Gasto _gasto = null;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOGasto bdGasto = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOGasto();

            _gasto = bdGasto.EliminarGasto(gasto);

            return _gasto;

        }
        #endregion
    }
}
