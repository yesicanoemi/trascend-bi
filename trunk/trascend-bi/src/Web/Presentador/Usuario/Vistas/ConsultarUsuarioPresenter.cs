using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Usuario.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos.ComandoUsuario;
using System.Net;
using System.Collections;


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

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            if (listado != null)
            {

                _vista.GetObjectContainerConsultaEmpleado.DataSource = listado;

            }

            else
            {
                //Mensaje de error al usuario
            }


        }

        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

        public void uxObjectConsultaEmpleadoSelecting(string id)
        {
            //CargarDatos(_controlador.ConsultarAgenciaCobro(id));
            //CambiarVista(1);

        }
    }
}
