using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoContacto
{
    public class Eliminar : Comando<Contacto>
    {
        private Contacto contacto;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Eliminar()
        { }

        /// <summary>Constructor de la clase 'Eliminar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Eliminar(Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion

        #region Metodos
        public void Ejecutar()
        {
            //int _resultado = 0;
            Contacto _contacto = null;
            DAOContactoSQLServer bd = new DAOContactoSQLServer();
            bd.Eliminar(contacto);
        }
        #endregion
    }
}