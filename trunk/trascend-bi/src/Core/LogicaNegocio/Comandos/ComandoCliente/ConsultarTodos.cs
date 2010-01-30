using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class ConsultarTodos : Comando<Cliente>
    {
        
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Consultar'.</summary>
        public ConsultarTodos()
        { }

        #endregion


        #region Metodos

        public IList<Core.LogicaNegocio.Entidades.Cliente> Ejecutar()
        {
            Core.AccesoDatos.SqlServer.DAOClienteSQLServer acceso =
                                      new Core.AccesoDatos.SqlServer.DAOClienteSQLServer();

            IList<Core.LogicaNegocio.Entidades.Contacto> listaCont =
                                            new List<Core.LogicaNegocio.Entidades.Contacto>();            

            return acceso.ConsultarTodos();
        }
        #endregion
    }
}