﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoContacto
{
    public class Modificar : Comando<Contacto>
    {
        private Contacto contacto;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Modificar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Modificar(Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion

        #region Metodos
        public void Ejecutar()
        {
            int _resultado = 0;
            //Contacto _contacto;
            ContactoSQLServer bd = new ContactoSQLServer();
            _resultado = bd.Modificar(contacto);
        }
        #endregion
    }
}
