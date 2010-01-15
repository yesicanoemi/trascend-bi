using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Usuario.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos.ComandoUsuario;
using System.Net;


namespace Presentador.Usuario.Vistas
{
    public class EliminarUsuarioPresenter
    {
        private IEliminarUsuario _vista;


        public EliminarUsuarioPresenter(IEliminarUsuario vista)
        {
            _vista = vista;

        }

        public void OnBotonEliminar()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.UsuarioEliminar.Text;

            user = ConsultarUsuario(user);

            if ((user != null) && (user.Status == "activo"))
            {
                user.Status = "inactivo";
                user = EliminarUsuario(user);
               
            }

            else
            {
                //Mensaje de error el usuario no existe en el sistema
            }


         }

        public Core.LogicaNegocio.Entidades.Usuario ConsultarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

        public Core.LogicaNegocio.Entidades.Usuario EliminarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.EliminarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoEliminarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }


    }
}