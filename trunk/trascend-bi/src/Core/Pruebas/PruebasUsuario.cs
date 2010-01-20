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
        public void ReporteFactura()
        {
            Factura factura = new Factura();

            factura.Fechaingreso = Convert.ToDateTime("01/01/2010");

            factura.Fechapago = Convert.ToDateTime("29/01/2010");

            ReporteSQLServer bd = new ReporteSQLServer();

            IList<Factura> listadoFactura = new List<Factura>();

            listadoFactura = bd.FacturasEmitidas(factura);

            int j= 0;

            for (int i = 0; i < listadoFactura.Count; i++)
            {
                if (listadoFactura[i].Titulo == "PruebaUnitario")
                {
                    j = i;
                    i = listadoFactura.Count;

                }
                
            }

            Assert.AreEqual("PruebaUnitaria", listadoFactura[j].Titulo);


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
