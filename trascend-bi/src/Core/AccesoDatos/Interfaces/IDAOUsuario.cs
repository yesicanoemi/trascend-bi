using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOUsuario
    {
        void AgregarUsuario(Usuario usuario);

        void ModificarUsuario(Usuario usuario);
        
        Usuario ConsultarCredenciales(Usuario usuario);

        IList<Usuario> ConsultarUsuario(Usuario usuario);

        IList<Permiso> ConsultarPermisos(Usuario usuario);

        IList<Empleado> ConsultarEmpleadoConUsuario(Empleado empleado);

        IList<Usuario> ListaUsuarios();

        Usuario VerificarUsuario(Usuario usuario);

        Usuario EliminarUsuario(Usuario usuario);


        
    }
}
