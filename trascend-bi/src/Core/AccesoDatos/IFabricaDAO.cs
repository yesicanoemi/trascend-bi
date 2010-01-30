using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Interfaces;

namespace Core.AccesoDatos
{
    public interface IFabricaDAO
    {
        IDAOUsuario AgregarUsuario();
    }
}
