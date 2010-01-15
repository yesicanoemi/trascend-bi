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
       private Contacto contacto;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Consultar'.</summary>
        public Consultar()
        { }

        /// <summary>Constructor de la clase 'Consultar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Consultar(Contacto contacto)
        {
            this.contacto = contacto;
        }

        #endregion


        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'CosultarContactos'.</summary>
        /*
                public Contacto Ejecutar()
                {
                    Contacto _contacto;

                     ContactoSQLServer bd = new ContactoSQLServer();

                    _contacto = bd.ConsultarContactos(contacto);

                    return _contacto; 

                }
                */

        #endregion
    }
}