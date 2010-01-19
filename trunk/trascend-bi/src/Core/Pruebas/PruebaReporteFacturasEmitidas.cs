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

    class PruebaReporteFacturasEmitidas
    {
        #region Métodos de Prueba

        [Test]

        //Método que prueba el funcionamiento del Reporte Facturas emitidas en un rango de fecha
    
        public void PruebaConsultaFacturaEmitida()
        {

            string FechaInicio = "01/01/2000";

            string FechaFin = "01/01/2015";

            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();

            Core.LogicaNegocio.Comandos.ComandoReporte.FacturasEmitidas comando;

            IList<Core.LogicaNegocio.Entidades.Factura> listaFactura = null;

            IList<Core.LogicaNegocio.Entidades.Factura> listaFacturaEmitida = null;

            factura.Fechaingreso = Convert.ToDateTime(FechaInicio);

            factura.Fechapago = Convert.ToDateTime(FechaFin);

            comando = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoFacturasEmitidas                         (factura);

            listaFactura = comando.Ejecutar();

            foreach (Core.LogicaNegocio.Entidades.Factura facturaTest in listaFactura)
            {
                if (facturaTest.Fechaingreso.CompareTo(FechaInicio) >= 0)
                {
                    if (facturaTest.Fechapago.CompareTo(FechaFin) <= 0)
                        
                       listaFacturaEmitida.Add(facturaTest);
                }
            }

            Assert.AreNotEqual(listaFacturaEmitida.Count, 0);
        }

        #endregion
    }
}
