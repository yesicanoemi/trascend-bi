using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class Ingresar : Comando<Propuesta>
    {
        private Propuesta _propuesta;

        #region Constructor

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public Ingresar()
        {
        }

        /// <summary>
        /// Constructor de la clase que recibe la entidad propuesta como parametro 
        /// </summary>
        /// <param name="entidad">Endtidad de tipoPropuesta</param>
        public Ingresar(Propuesta entidad)
        {
            _propuesta = entidad;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que implementa la ejecución del comando Ingresar
        /// </summary>
        public void Ejecutar()
        {

        }
        #endregion
    }
}