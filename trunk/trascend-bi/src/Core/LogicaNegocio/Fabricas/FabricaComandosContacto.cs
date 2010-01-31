using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoContacto;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosContacto
    {
        #region Métodos

        /// <summary>
        /// Metodo que fabrica el comando 'ConsultarContactoxId' de la entidad Contacto
        /// </summary>
        /// <param name="entidad">Entidad contacto con los datos</param>
        /// <returns>Comando ConsultarContactoxId de la entidad Contacto</returns>

        public static ConsultarContactoxId
                                        CrearComandoConsultarContactoxId(Contacto entidad)
        {
            return new ConsultarContactoxId(entidad);
        }

        /// <summary>
        /// Metodo que fabrica el comando 'ConsultarContactoNombreApellido' de la entidad Contacto
        /// </summary>
        /// <param name="entidad">Entidad contacto con los datos</param>
        /// <returns>Comando ConsultarContactoNombreApellido de la entidad Contacto</returns>

        public static ConsultarContactoNombreApellido 
                                        CrearComandoConsultarContactoNombreApellido(Contacto entidad)
        {
            return new ConsultarContactoNombreApellido(entidad);
        }


        /// <summary>
        /// Metodo que fabrica el comando 'ConsultarContactoXTelefono' de la entidad Contacto
        /// </summary>
        /// <param name="entidad">Entidad contacto con los datos</param>
        /// <returns>Comando ConsultarContactoXTelefono de la entidad Contacto</returns>

        public static ConsultarContactoXTelefono
                                        CrearComandoConsultarContactoXTelefono(Contacto entidad)
        {
            return new ConsultarContactoXTelefono(entidad);
        }

        
        /// <summary>
        /// Metodo que fabrica el comando 'ConsultarContactoXCliente' de la entidad Contacto
        /// </summary>
        /// <param name="entidad">Entidad contacto con los datos</param>
        /// <returns>Comando ConsultarContactoXCliente de la entidad Contacto</returns>

        public static ConsultarContactoXCliente
                                        CrearComandoConsultarContactoXCliente(Contacto entidad)
        {
            return new ConsultarContactoXCliente(entidad);
        }

        public static Ingresar CrearComandoIngresar(Contacto contacto, int idCliente)
        {
            return new Ingresar(contacto, idCliente);
        }
       
        public static Eliminar CrearComandoEliminar(Contacto contacto)
        {
            return new Eliminar(contacto);
        }

        /// <summary>
        /// Metodo que fabrica el comando 'ModificarContacto' de la entidad Contacto
        /// </summary>
        /// <param name="entidad">Entidad contacto con los datos</param>
        
        public static ModificarContacto CrearComandoModificarContacto(Contacto entidad)
        {
            return new ModificarContacto(entidad);
        }
        #endregion
    }
}
