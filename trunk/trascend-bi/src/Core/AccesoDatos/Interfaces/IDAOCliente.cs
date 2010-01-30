using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Excepciones.Cliente.AccesoDatos;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOCliente
    {
        /// <summary>
        /// Ingresa un cliente con su direccion y telefono
        /// </summary>
        /// <param name="cliente">Cliente a ingresar</param>
        /// <returns>Cliente ingresado</returns>
        Cliente Ingresar(Cliente cliente);

        /// <summary>
        /// Modifica un valor de un cliente
        /// </summary>
        /// <param name="cliente">Cliente a modificar</param>
        /// <returns>Cliente modificado</returns>
        Cliente Modificar(Cliente cliente);

        /// <summary>
        /// Consulta los clientes por el nombre
        /// </summary>
        /// <param name="cliente">Cliente con el Nombre a consultar</param>
        /// <returns>Lista con los clientes encontrados</returns>
        IList<Cliente> ConsultarNombre(Cliente cliente);

        /// <summary>
        /// Consulta un cliente por su RIF
        /// </summary>
        /// <param name="cliente">El Cliente a Consultar</param>
        /// <returns>El cliente resultante</returns>
        Cliente ConsultarRif(Cliente cliente);

        /// <summary>
        /// Consulta todos los clientes
        /// </summary>
        /// <returns>Lista con los clientes</returns>
        IList<Cliente> ConsultarTodos();

        /// <summary>
        /// Elimina un cliente logicamente, mas no lo borra de la BD
        /// </summary>
        /// <param name="cliente">Cliente a eliminar</param>
        /// <returns>Cliente Eliminado</returns>
        Cliente EliminarCliente(Cliente cliente);

    }
}
