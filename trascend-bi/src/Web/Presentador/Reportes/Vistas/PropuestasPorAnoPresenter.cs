﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoPropuesta;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Reportes.Vistas
{
    public class PropuestasPorAnoPresenter
    {
        private IPropuestaPorAnoPresenter _vista;

        public PropuestasPorAnoPresenter(IPropuestaPorAnoPresenter vista)
        {
            _vista = vista;
        }

        public void CargarGrid()
        {
            _vista.Grid.DataSource = null;

            _vista.Grid.DataBind();

            IList<Object[]> lista = GetPropuestasPorAno();

            int i = 0;

            foreach (Object[] recorrido in lista)
            {
                if ((int)recorrido[i] == int.Parse(_vista.List.SelectedItem.ToString()))
                {
                    IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestasPorAno = (IList<Core.LogicaNegocio.Entidades.Propuesta>)lista[i][1];

                    _vista.Grid.DataSource = ListaPropuestasPorAno;

                    _vista.Grid.DataBind();
                }
                
                i++;
            }
        }
        private IList<Object[]> GetPropuestasPorAno()
        {
            Object[] propuestasPorAno = new Object[2];
            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestasPorAno = new List<Core.LogicaNegocio.Entidades.Propuesta>();
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
                    ListaPropuestasPorAno = new List<Core.LogicaNegocio.Entidades.Propuesta>();
                    ListaPropuestasPorAno.Add(propuesta);
                    propuestasPorAno = new Object[2];
                    propuestasPorAno[0] = ano;
                    propuestasPorAno[1] = ListaPropuestasPorAno;
                    ListaCompletaPropuestas.Add(propuestasPorAno);
                }
            }

            return ListaCompletaPropuestas;
        }
    }
}