using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoPropuesta;

namespace Presentador.Reportes.Vistas
{
    class PropuestasPorAnoPresenter
    {
        private IList<Object[]> GetPropuestasPorAno()
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

            return ListaCompletaPropuestas;
        }
    }
}
