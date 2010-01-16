using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoContacto
{
    public class Consultar : Comando<Contacto>
    {

        #region Constructor
        public Consultar()
        {
        }

        #endregion

        #region Metodos

        public IList<Contacto> Ejecutar()
        {
            IList<Contacto> _contactos = null;
            ContactoSQLServer bd = new ContactoSQLServer();
            _contactos = bd.Consultar();
            return _contactos;
        }

        #endregion
    }
}