using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOReporte
    {
        IList<Core.LogicaNegocio.Entidades.Factura>
                                                FacturasEmitidas(Factura entidad);
        IList<Gasto> ConsultarGastoFecha(DateTime fechai, DateTime fechaf);

        IList<string> ObtenerRol(DateTime FechaI, DateTime FechaF);

        int SumaHora(string rol);

        IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasEmitidas(Factura factura);

        IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasCobradas(Factura facturas);

        IList<Core.LogicaNegocio.Entidades.Factura> ObtenerFacturasPorCobrar(Factura facturas);

        IList<Core.LogicaNegocio.Entidades.Gasto>
                                                GastosAnuales(string anio);

        float TotalGastosAnuales(string anio);

        Cargo ConsultarEmpleadoCargoAnual(string metodo);

        IList<string> ObtenerCargo();

        Empleado ReporteAnualPorPaquetesEmpleadoId(Empleado entidad);
    }
}
