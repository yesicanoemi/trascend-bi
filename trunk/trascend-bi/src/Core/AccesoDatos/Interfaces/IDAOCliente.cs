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
        Cliente Ingresar(Cliente cliente);

        int Modificar(Cliente cliente);

        IList<Cliente> ConsultarNombre();

        Direccion buscarDireccion(int idCliente);

        List<Contacto> BuscarContacto(int IdCliente);

        List<Cliente> ConsultarParamtroNombre(Cliente entidad);

        IList<Cliente> ConsultarParamtroAreaNegocio(Cliente cliente);

        IList<Cliente> ConsultarAreaNegocio();

        IList<string> ListaEliminar(List<string> ListaRecibida);
    }
}
