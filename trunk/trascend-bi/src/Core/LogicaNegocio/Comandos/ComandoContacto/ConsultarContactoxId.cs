using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoContacto
{
    public class ConsultarContactoxId : Comando<Core.LogicaNegocio.Entidades.Contacto>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Contacto contacto;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarContactoxId'.</summary>

        public ConsultarContactoxId()
        { }

        public ConsultarContactoxId(Core.LogicaNegocio.Entidades.Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarContactoxId'.
        /// </summary>

        public Core.LogicaNegocio.Entidades.Contacto Ejecutar()
        {
            Core.AccesoDatos.SqlServer.DAOContactoSQLServer acceso = 
                                                new Core.AccesoDatos.SqlServer.DAOContactoSQLServer();

            Core.LogicaNegocio.Entidades.Contacto Cont =
                                            new Core.LogicaNegocio.Entidades.Contacto();

            Cont = acceso.ConsultarContactoxId(contacto);

            return Cont;
        }

        #endregion    
    }
}
