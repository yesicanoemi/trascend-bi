using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class Ingresar : Comando<Propuesta>
    {
        private Propuesta propuesta;
        private IList<string[]> equitra;

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
        public Ingresar(Propuesta entidad,IList<string[]> equipo)
        {
            propuesta = entidad;
            equitra = equipo;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que implementa la ejecución del comando Ingresar
        /// </summary>
        public Propuesta Ejecutar()
        {
            Propuesta _propuesta;
            PropuestaSQLServer conex = new PropuestaSQLServer();
            _propuesta = conex.IngresarPropuesta(propuesta,equitra);
            return _propuesta;
        }
        #endregion
    }
}