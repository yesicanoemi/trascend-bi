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
    public class ConsultarContactoXCliente : Comando<Core.LogicaNegocio.Entidades.Contacto>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Contacto contacto;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarContactoXCliente'.</summary>

        public ConsultarContactoXCliente()
        { }

        public ConsultarContactoXCliente(Core.LogicaNegocio.Entidades.Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarContactoXCliente'.
        /// </summary>

        public IList<Core.LogicaNegocio.Entidades.Contacto> Ejecutar()
        {

            IList<Core.LogicaNegocio.Entidades.Contacto> listaCont =
                                            new List<Core.LogicaNegocio.Entidades.Contacto>();
     
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bdcontacto = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            listaCont = bdcontacto.ConsultarContactoXCliente(contacto);

            return listaCont;

        }

        #endregion
    }
}
