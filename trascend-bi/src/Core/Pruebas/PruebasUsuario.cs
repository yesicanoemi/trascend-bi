using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;
using NUnit.Framework;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebasUsuario
    {
        #region Prueba Para Eliminar Usuario

        [Test]

        public void TestEliminarusuario()
        {
            Usuario usuario = new Usuario();

            IList<Usuario> listadoUsuarios = new List<Usuario>();

            string Login = "usuario";

            usuario.Login = Login;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            iDAOUsuario.EliminarUsuario(usuario);

            listadoUsuarios = iDAOUsuario.ConsultarUsuario(usuario);

            Assert.AreEqual("Inactivo", listadoUsuarios[0].Status);

        }

        #endregion

        #region Prueba Para Consultar Usuario

        [Test]

        public void TestConsultarUsuario()
        {
            Usuario usuario = new Usuario();

            string Login = "usuario";

            usuario.Login = Login;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            //UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Usuario> listadoUsuarios = new List<Usuario>();

            listadoUsuarios = iDAOUsuario.ConsultarUsuario(usuario);

            //listadoUsuarios = bd.ConsultarUsuario(usuario);

            for (int i = 0; i < listadoUsuarios.Count; i++)
            {
                if (listadoUsuarios[i].Login == "usuario")
                {
                    usuario.Login = listadoUsuarios[i].Login;
                    i = listadoUsuarios.Count;
                }
                else
                {
                    usuario.Login = "null";

                }
            }

            Assert.AreEqual(Login, usuario.Login);
        }

        #endregion

        #region Prueba Para Agregar Usuario

        [Test]

        public void TestAgregarUsuario()
        {
            Usuario usuario = new Usuario();

            usuario.Login = "UsuarioPrueba12";

            usuario.Password = "123456";

            usuario.Status = "Activo";

            usuario.Cedula = 13776256;

            IList<Permiso> listado = new List<Permiso>();

            Permiso permiso = new Permiso();

            permiso.IdPermiso = 1;

            listado.Add(permiso);

            usuario.PermisoUsu = listado;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            IDAOUsuario iDAOUsuario1 = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            iDAOUsuario.AgregarUsuario(usuario);

            //   UsuarioSQLServer bd = new UsuarioSQLServer();

            //   bd.AgregarUsuario(usuario);

            IList<Usuario> listadoUsu = new List<Usuario>();

            listadoUsu = iDAOUsuario1.ConsultarUsuario(usuario);

            Assert.AreEqual(listadoUsu[0].Login, usuario.Login);
        }

        #endregion

        #region Prueba Para Modificar Usuario

        [Test]

        public void TestModificarUsuario()
        {
            Usuario usuario = new Usuario();

            Usuario usuarioTest = new Usuario();

            Permiso permiso = new Permiso();

            //UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Usuario> listadoUsuarios = new List<Usuario>();

            IList<Permiso> listadoPermisos = new List<Permiso>();

            IList<Permiso> listadoPermisosTest = new List<Permiso>();

            //consulta de usuario y sus permisos

            //listadoUsuarios = bd.ConsultarUsuario(usuario);

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            listadoUsuarios = iDAOUsuario.ConsultarUsuario(usuario);

            usuario = listadoUsuarios[0];

            listadoPermisos = iDAOUsuario.ConsultarPermisos(listadoUsuarios[0]);

            //listadoPermisos = bd.ConsultarPermisos(listadoUsuarios[0]);

            if (usuario.Status.CompareTo("Inactivo") >= 0)
            {
                usuario.Status = "Activo";
            }

            permiso.IdPermiso = 6;

            listadoPermisosTest.Add(permiso);

            usuario.PermisoUsu = listadoPermisosTest;

            iDAOUsuario.ModificarUsuario(usuario);

            //bd.ModificarUsuario(usuario);

            //consulta de permisos y de usuario nuevamente

            listadoUsuarios = iDAOUsuario.ConsultarUsuario(usuario);

            //listadoUsuarios = bd.ConsultarUsuario(usuario);

            listadoPermisos = iDAOUsuario.ConsultarPermisos(listadoUsuarios[0]);

            //listadoPermisos = bd.ConsultarPermisos(listadoUsuarios[0]);

            usuarioTest = listadoUsuarios[0];

            Assert.AreEqual(6, listadoPermisos[0].IdPermiso);

            Assert.AreEqual(usuario.Status, usuarioTest.Status);
        }

        #endregion

        [Test]
        public void IsNul()
        {
            object nada = null;

            // Classic syntax
            Assert.IsNull(nada);

            // Helper syntax
            Assert.That(nada, Is.Null);


        }
    }
}
