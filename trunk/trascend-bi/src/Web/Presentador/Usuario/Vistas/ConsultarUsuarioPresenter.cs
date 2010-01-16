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

        #region Métodos

        /// <summary>
        /// Metodo para cambiar la vista 
        /// </summary>
        /// <param name="index">Numero de vista</param>

        public void CambiarVista(int index)
        {

            _vista.MultiViewConsultar.ActiveViewIndex = index;
        }

        /// <summary>
        /// Metodo para cargar los datos por pantalla una vez seleccionado el usuario
        /// </summary>
        /// <param name="usuario">Entidad Usuario con sus datos</param>
        
         private void CargarDatos(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            _vista.NombreUsu.Text = usuario.Login;

            _vista.NombreEmp.Text = usuario.Nombre;

            _vista.ApellidoEmp.Text = usuario.Apellido;

            _vista.UsuarioU.Text = usuario.Status;
        }
  

        /// <summary>
        /// Acción del Botón Buscar (Por nombre de usuario)
        /// </summary>
         
        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.NombreUsuario.Text;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            try
            {
               if (listado != null)
                {

                    _vista.GetObjectContainerConsultaUsuario.DataSource = listado;

                }
           }

            catch (WebException e)
            {
                //Mensaje de error al usuario
            }
        }


        /// <summary>
        /// Método de Consulta una vez seleccionado el usuario 
        /// </summary>
        /// <param name="login">Nombre de Usuario</param>
        
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

        #region Comando

        /// <summary>
        /// Método para el comando ConsultarUsuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario a consultar (por nombre de usuario)</param>
        /// <returns>Lista de usuarios que cumplan con el parámetro de búsqueda</returns>
        
        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuario
                                                (Core.LogicaNegocio.Entidades.Usuario entidad)
        
        {
            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

        #endregion
    }
}
