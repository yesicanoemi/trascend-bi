using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using NUnit.Framework;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebasReportePropuestasIntervalo
    {
        [Test]
        public void PruebaConsultaConsigue()
        {
            DateTime inicio = DateTime.Parse("1/4/2009");
            DateTime fin = DateTime.Parse("1/5/2009");

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas comandoConsulta =
                Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = comandoConsulta.Ejecutar();

            IList<Core.LogicaNegocio.Entidades.Propuesta> PropuestasBuenas = new List<Core.LogicaNegocio.Entidades.Propuesta>();

            foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
            {
                if (PropuestaAux.FechaInicio.CompareTo(inicio) >= 0)
                {
                    if (PropuestaAux.FechaInicio.CompareTo(fin) <= 0)
                        PropuestasBuenas.Add(PropuestaAux);
                }
            }
            Assert.AreNotEqual(PropuestasBuenas.Count, 0);
        }

        [Test]
        public void PruebaConsultaMala1()
        {
            DateTime inicio = DateTime.Parse("1/5/2009");
            DateTime fin = DateTime.Parse("1/5/2009");

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas comandoConsulta =
                Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = comandoConsulta.Ejecutar();

            IList<Core.LogicaNegocio.Entidades.Propuesta> PropuestasBuenas = new List<Core.LogicaNegocio.Entidades.Propuesta>();

            foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
            {
                if (PropuestaAux.FechaInicio.CompareTo(inicio) >= 0)
                {
                    if (PropuestaAux.FechaInicio.CompareTo(fin) <= 0)
                        PropuestasBuenas.Add(PropuestaAux);
                }
            }
            Assert.AreEqual(PropuestasBuenas.Count, 0);
        }

        [Test]
        public void PruebaConsultaMala2()
        {
            DateTime inicio = DateTime.Parse("1/4/2009");
            DateTime fin = DateTime.Parse("1/4/2009");

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas comandoConsulta =
                Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = comandoConsulta.Ejecutar();

            IList<Core.LogicaNegocio.Entidades.Propuesta> PropuestasBuenas = new List<Core.LogicaNegocio.Entidades.Propuesta>();

            foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
            {
                if (PropuestaAux.FechaInicio.CompareTo(inicio) >= 0)
                {
                    if (PropuestaAux.FechaInicio.CompareTo(fin) <= 0)
                        PropuestasBuenas.Add(PropuestaAux);
                }
            }
            Assert.AreEqual(PropuestasBuenas.Count, 0);
        }
    }
}
