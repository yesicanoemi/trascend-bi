using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Fabricas;


namespace Presentador.Reportes.Vistas
{
    public class ReporteGastoFechaPresenter
    {
        private IReporteGastoFecha _vista;

        private IList<Core.LogicaNegocio.Entidades.Gasto> Gastos;

        public ReporteGastoFechaPresenter(IReporteGastoFecha vista)
        {
            _vista = vista;
        }

        public void ConsultarGastoFecha(DateTime FechaIni, DateTime FechaFin)
        {
            FechaIni = Convert.ToDateTime(_vista.FechaInicio.Text);

            FechaFin = Convert.ToDateTime(_vista.FechaFin.Text);

            Gastos = Consultar(FechaIni, FechaFin);


        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> Consultar(DateTime FechaIni, DateTime FechaFin)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoFecha busqueda;

            busqueda = FabricaComandoGasto.CrearComandoConsultarFecha(FechaIni, FechaFin);

            Gastos = busqueda.Ejecutar();

            return Gastos;
        }

    }
}
