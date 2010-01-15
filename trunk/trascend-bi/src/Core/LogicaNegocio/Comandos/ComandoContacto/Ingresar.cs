using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoContacto
{
    public class Ingresar : Comando<Contacto>
    {
        private Contacto contacto;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Ingresar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Ingresar(Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion

        #region Metodos
        public Contacto Ejecutar()
        {
            Contacto _contacto = null;
            /*UsuarioSQLServer bd = new UsuarioSQLServer();
            _contacto = bd.Ingresar(contacto);*/

            return _contacto;
        }
        #endregion
    }
}
