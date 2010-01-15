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
    public class ConsultarUsuarioPresenter
    {
        private IConsultarUsuario _vista;

        public ConsultarUsuarioPresenter(IConsultarUsuario vista)
        {
            _vista = vista;

        }

        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.NombreUsuario.Text;

            user = ConsultarUsuario(user);

            if (user != null)
            {

                _vista.NombreU.Text = user.Login;

                _vista.NombreEmpleado.Text = user.Nombre;

                _vista.ApellidoEmpleado.Text = user.Apellido;

                _vista.StatusUsuario.Text = user.Status;

            }

            else
            {
                //Mensaje de error al usuario
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
    }
}
