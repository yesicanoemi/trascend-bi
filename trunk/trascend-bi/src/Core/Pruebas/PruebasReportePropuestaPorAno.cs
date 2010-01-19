﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using NUnit.Framework;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebasReportePropuestasPorAno
    {
        [Test]
        public void GetPropuestasPorAno()
        {
            Object[] propuestasPorAno = new Object[2];
            IList<Object> ListaPropuestasPorAno = new List<Object>();
            IList<Object[]> ListaCompletaPropuestas = new List<Object[]>();
            Core.LogicaNegocio.Comandos.ComandoPropuesta.ConsultarPropuestasxEmision comandoConsulta =
                Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoConsultarPropuestasxEmision();
            IList<Core.LogicaNegocio.Entidades.Propuesta> propuestas = comandoConsulta.Ejecutar();

            int ano = 0;
            foreach (Core.LogicaNegocio.Entidades.Propuesta propuesta in propuestas)
            {
                if (ano == propuesta.FechaInicio.Year)
                {
                    ListaPropuestasPorAno.Add(propuesta);
                }
                else
                {
                    ano = propuesta.FechaInicio.Year;
                    ListaPropuestasPorAno = new List<Object>();
                    ListaPropuestasPorAno.Add(propuesta);
                    propuestasPorAno = new Object[2];
                    propuestasPorAno[0] = ano;
                    propuestasPorAno[1] = ListaPropuestasPorAno;
                    ListaCompletaPropuestas.Add(propuestasPorAno);
                }
            }
            Assert.AreEqual((int)ListaCompletaPropuestas[0][0], 2009);
            ListaPropuestasPorAno = (IList<Object>)ListaCompletaPropuestas[0][1];
            Propuesta asserta = (Propuesta)ListaPropuestasPorAno[0];
            Assert.AreEqual(asserta.FechaInicio.Year, 2009);
        }
    }
}

