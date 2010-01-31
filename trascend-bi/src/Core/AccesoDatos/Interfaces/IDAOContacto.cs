using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOContacto
    {


        IList<Contacto> ConsultarContactoNombreApellido(Contacto entidad);

        Contacto ConsultarContactoXTelefono(Contacto entidad);

        IList<Contacto> ConsultarContactoXCliente(Contacto entidad);

        Contacto ConsultarContactoxId(Contacto entidad);

        void Eliminar(Contacto contacto);

    }
}
