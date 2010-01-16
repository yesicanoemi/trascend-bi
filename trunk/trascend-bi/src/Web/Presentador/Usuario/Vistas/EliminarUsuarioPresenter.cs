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

            user = VerificarUsuario(user);

            if ((user != null) && (user.Status == "activo"))
            {
                user.Status = "inactivo";
                user = EliminarUsuario(user);
                _vista.Volver();
               
            }

            else
            {
                //Mensaje de error el usuario no existe en el sistema
            }


         }



        public void CargarUsuarios()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();
            IList<Core.LogicaNegocio.Entidades.Usuario> listaUsuarios;

            listaUsuarios = ListarUsuarios(user);
            
            _vista.UsuarioEliminar.Items.Clear();
            _vista.UsuarioEliminar.Items.Add(" -- ");
            _vista.UsuarioEliminar.Items[0].Value = "0";
            _vista.UsuarioEliminar.DataSource = listaUsuarios;
            _vista.UsuarioEliminar.DataValueField = "Login";
            _vista.UsuarioEliminar.DataTextField = "login";
            _vista.UsuarioEliminar.DataBind();

        }



        public IList<Core.LogicaNegocio.Entidades.Usuario> 
            ListarUsuarios(Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ListaUsuarios comando;

            comando = FabricaComandosUsuario.CrearComandoListaUsuarios(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }


     
        public Core.LogicaNegocio.Entidades.Usuario VerificarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.VerificarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoVerificarUsuario(entidad);

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