using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Reportes.Vistas
{
    public class PropuestasIntervaloPresenter
    {
        public IList<Core.LogicaNegocio.Entidades.Propuesta> GetPropuestasIntervalo(DateTime inicio, DateTime fin)
        {
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

            return PropuestasBuenas;
        }
    }
}
