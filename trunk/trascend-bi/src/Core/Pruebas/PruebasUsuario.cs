using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;
using NUnit.Framework;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebasUsuario
    {
        [Test]
        public void TestConsultarUsuario()
        {
            Usuario usuario = new Usuario();

            string Login = "usuario";

            usuario.Login = Login;

            UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Usuario> listadoUsuarios = new List<Usuario>();

            listadoUsuarios = bd.ConsultarUsuario(usuario);

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

            Assert.AreEqual(Login,usuario.Login);
        }

        [Test]
        public void TestAgregarUsuario()
        {
            Usuario usuario = new Usuario();

            usuario.Login = "UsuarioPrueba";
            usuario.Password = "123456";
            usuario.Status = "Activo";
            usuario.Cedula = 13776256;

            IList<Permiso> listado = new List<Permiso>();
            Permiso permiso = new Permiso();
            permiso.IdPermiso = 1;
            listado.Add(permiso);

            UsuarioSQLServer bd = new UsuarioSQLServer();
                bd.AgregarUsuario(usuario);
            IList<Usuario> listadoUsu = new List<Usuario>();
                listadoUsu = bd.ConsultarUsuario(usuario);

            Assert.AreEqual(listadoUsu[0].Login, usuario.Login);
        }

        [Test]
        public void TestModificarUsuario()
        {
            Usuario usuario = new Usuario();

            Usuario usuarioTest = new Usuario();

            UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Usuario> listadoUsuarios = new List<Usuario>();

            IList<Permiso> listadoPermisos = new List<Permiso>();

            //consulta de usuario y sus permisos
            listadoUsuarios = bd.ConsultarUsuario(usuario);

            usuario = listadoUsuarios[0];

            listadoPermisos = bd.ConsultarPermisos(listadoUsuarios[0]);

           /* if (listadoPermisos[0] != null)
            {
                //asignacion del permiso al usuario
                usuario.PermisoUsu[0].IdPermiso = listadoPermisos[0].IdPermiso;

                //modificacion del permiso
                usuario.PermisoUsu[0].IdPermiso = 5;

            }

            else
            {
                //modificacion del permiso
                usuario.PermisoUsu[0].IdPermiso = 5;
            
            }
*/
            if (usuario.Status.CompareTo("Inactivo") > 0)
            {
                usuario.Status = "Activo";
            }

            bd.ModificarUsuario(usuario);

            //consulta de permisos y de usuario nuevamente
            listadoPermisos = bd.ConsultarPermisos(listadoUsuarios[0]);
            listadoUsuarios = bd.ConsultarUsuario(usuario);

            usuarioTest = listadoUsuarios[0];
         
            Assert.AreEqual(5,listadoPermisos[0].IdPermiso);
            Assert.AreEqual(usuario.Status, usuarioTest.Status);
        }

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
