using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class IngresarGasto : Comando<Gasto>
    {
        private Gasto gasto;

        #region Constructor

        /// <summary> Conructor de la Clase 'IngresarGasto' </summary>
        public IngresarGasto()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        public IngresarGasto(Gasto gasto)
        {
            this.gasto = gasto;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Ejecuta el comando para:
        ///     Ingresar el gasto sin asociacion.
        ///     Ingresar el gasto asociado a, un proyecto o propuesta aprovada.
        /// </summary>
        public Gasto Ejecutar()
        {
            Gasto _gasto = null;

            DAOGastoSQLServer bdGasto = new DAOGastoSQLServer();

            if (gasto.IdVersion > 0)
                // Ingresa el gasto asociado a un proyecto
                _gasto = bdGasto.IngresarGastoPropuesta(gasto);

            else
                //Ingresa el gasto sin asociacion
                _gasto = bdGasto.IngresarGasto(gasto);

            return _gasto;
        }
        #endregion
    }
}
