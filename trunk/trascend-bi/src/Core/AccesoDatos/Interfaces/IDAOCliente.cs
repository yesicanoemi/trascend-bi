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

        int Modificar(Cliente cliente);

        /// <summary>
        /// Consulta los clientes por el nombre
        /// </summary>
        /// <param name="cliente">Cliente con el Nombre a consultar</param>
        /// <returns>Lista con los clientes encontrados</returns>
        IList<Cliente> ConsultarNombre(Cliente cliente);

        Direccion buscarDireccion(int idCliente);

        List<Contacto> BuscarContacto(int IdCliente);

        List<Cliente> ConsultarParamtroNombre(Cliente entidad);

        IList<Cliente> ConsultarParamtroAreaNegocio(Cliente cliente);

        IList<Cliente> ConsultarAreaNegocio();

        IList<string> ListaEliminar(List<string> ListaRecibida);
    }
}
