using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using NUnit.Framework;
using Core.LogicaNegocio.Excepciones;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.Pruebas
{
    [TestFixture]
    public class PruebasEmpleado
    {
        [SetUp()]
        public void Init()
        {
        }

        [TearDown()]
        public void Clean()
        {
        }

            [Test]
                public void PruebaAIngresarEmpleado()
                {
                IList<Empleado> lista = new List<Empleado>();
                Empleado empleado = new Empleado();
                Empleado empleComp = new Empleado();
                empleado.Nombre = "Probador BD";
                empleado.Apellido = "Probador";
                empleado.FechaNacimiento = DateTime.Now;
                empleado.Cargo = "1";
                empleado.Cedula = 1111111;
                empleado.Cuenta = "123123";
                empleado.Estado = 1;
                empleado.SueldoBase = 198765;
                empleado.Direccion = new Direccion();
                empleado.Direccion.Avenida = "prueba";
                empleado.Direccion.Calle = " c prueba";
                empleado.Direccion.Ciudad = "ciu prueba";
                empleado.Direccion.Edif_Casa = "edif prueba";
                empleado.Direccion.Piso_apto = "p prueba";
                empleado.Direccion.Urbanizacion = "u prueba";

                FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;
                IDAOEmpleado bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

                bd.Ingresar(empleado);
                empleComp = bd.ConsultarPorTipoCedula(empleado);

                Assert.AreEqual(empleComp.Nombre, "Probador BD");
                Assert.AreEqual(empleComp.Apellido, "Probador");
                Assert.AreEqual(empleComp.Direccion.Edif_Casa, "edif prueba");
            }

        [Test]
        public void PruebaConsultarEmpleadoCedula()
        {
            Empleado empleado = new Empleado();

            empleado.Cedula = 17499612;

            Empleado Resultado = new Empleado();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            Resultado = bd.ConsultarPorTipoCedula(empleado);

            Assert.AreEqual(Resultado.Cedula,empleado.Cedula);

            
        }

        [Test]
        public void PruebaConsultarEmpleadoNombre()
        {
            Empleado empleado = new Empleado();

            string Nombre = "harold";                  
            
            empleado.Nombre = "har";

            List<Empleado> Resultado = new List<Empleado>();            

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            Resultado = bd.ConsultarPorTipoNombre(empleado);

            for (int i = 0; i < Resultado.Count; i++)
            {
                if ((Resultado[i].Nombre == Nombre))
                {
                    empleado.Nombre = Resultado[i].Nombre;
                    i = Resultado.Count;
                }
                else
                {
                    empleado.Nombre = "null";
                    empleado.Apellido = "null";
                }
            }

            Assert.AreEqual(Nombre, empleado.Nombre);                       


        }

        [Test]
        public void PruebaConsultarEmpleadoArea()
        {
            Empleado empleado = new Empleado();

            Cargo cargo = new Cargo();

            cargo.Id = 1;

            empleado.CargoEmpleado = cargo;


            IList<Empleado> Resultado = new List<Empleado>();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            Resultado = bd.ConsultarPorTipoCargo(empleado);

                   
            bool comprobar=false;

            if (Resultado.Count > 0)

                comprobar = true;
            

            Assert.AreEqual(comprobar,true);


        }

         

        
        [Test]
        public void PruebaAModificarEmpleado()
        {
            IList<Empleado> _lista = new List<Empleado>();
            IList<Empleado> lista = new List<Empleado>();
            Empleado empleado = new Empleado();
            empleado.Nombre = "jose";
            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorNombre comandoBusqueda = FabricaComandosEmpleado.CrearComandoConsultarPorNombre(empleado);
            _lista = comandoBusqueda.Ejecutar();
            empleado.Id = 6;
            empleado.Nombre = "Probador BD";
            empleado.Apellido = "Probador";
            empleado.FechaNacimiento = DateTime.Now;
            empleado.Cargo = "1";
            empleado.Cedula = 1111111;
            empleado.Cuenta = "123123";
            empleado.Estado = 1;
            empleado.SueldoBase = float.MinValue;
            empleado.Direccion = new Direccion();
            empleado.Direccion.Avenida = "prueba";
            empleado.Direccion.Calle = " c prueba";
            empleado.Direccion.Ciudad = "ciu prueba";
            empleado.Direccion.Edif_Casa = "edif prueba";
            empleado.Direccion.Piso_apto = "p prueba";
            empleado.Direccion.Urbanizacion = "u prueba";
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Modificar comandoModificar;
            comandoModificar = FabricaComandosEmpleado.CrearComandoModificar(empleado);
            comandoModificar.Ejecutar();
            comandoBusqueda = FabricaComandosEmpleado.CrearComandoConsultarPorNombre(empleado);
            lista = comandoBusqueda.Ejecutar();
            Assert.AreNotEqual(lista[0].Nombre, _lista[0].Nombre);
            Assert.AreEqual(lista[0].Nombre, "Probador BD");
            Assert.AreNotEqual(lista[0].Direccion.Avenida, _lista[0].Direccion.Avenida);
            Assert.AreEqual(lista[0].Direccion.Avenida, "prueba");
        }
    }
}
