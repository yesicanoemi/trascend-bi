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

        #region Constructor

        public ConsultarUsuarioPresenter(IConsultarUsuario vista)
        {
            _vista = vista;

        }

        #endregion

        #region Metodos

        public void CambiarVista(int index)
        {

            _vista.MultiViewConsultar.ActiveViewIndex = index;
        }


         private void CargarDatos(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            _vista.NombreUsu.Text = usuario.Login;

            _vista.NombreEmp.Text = usuario.Nombre;

            _vista.ApellidoEmp.Text = usuario.Apellido;

            _vista.UsuarioU.Text = usuario.Status;
        }
  
        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.NombreUsuario.Text;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            if (listado != null)
            {

                _vista.GetObjectContainerConsultaUsuario.DataSource = listado;

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

        public void uxObjectConsultaUsuarioSelecting(string login)
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = login;
            
            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            user = null;

            user = listado[0];

            CargarDatos(user);
            
            CambiarVista(1);

        }

        #endregion
    }
}
