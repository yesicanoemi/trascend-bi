using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebaReporteGastoAnual
    {
        [Test]
        public void TestReporteGastoAnual()
        {
            string anio = "2008";

            Core.LogicaNegocio.Entidades.Gasto gastoA = new Core.LogicaNegocio.Entidades.Gasto();

            IList<Core.LogicaNegocio.Entidades.Gasto> gasto = null;

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarGastoAnual comando;

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarGastoTotal comando2;

            float total = 0;

            comando = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoGastosAnuales(gastoA);

            gasto = comando.Ejecutar(anio);

            if (gasto.Count > 0)
            {

                comando2 = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoGastoTotal(gastoA);
                total = comando2.Ejecutar(anio);
            }

            Assert.AreNotEqual(total, 0);
        }
    }
}

