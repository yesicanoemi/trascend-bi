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
    public class ConsultarContactoXTelefono : Comando<Core.LogicaNegocio.Entidades.Contacto>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Contacto contacto;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarContactoXTelefono'.</summary>

        public ConsultarContactoXTelefono()
        { }

        public ConsultarContactoXTelefono(Core.LogicaNegocio.Entidades.Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarContactoXTelefono'.
        /// </summary>

        public Core.LogicaNegocio.Entidades.Contacto Ejecutar()
        {
            
            Core.LogicaNegocio.Entidades.Contacto contacto2 =
                                            new Core.LogicaNegocio.Entidades.Contacto();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bdcontacto = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            contacto2 = bdcontacto.ConsultarContactoXTelefono(contacto);
            
            return contacto2;
        
        }

        #endregion
    }
}
