using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoReporte;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosReporte
    {
        public static FacturasEmitidas CrearComandoFacturasEmitidas(Factura entidad)
        {
            return new FacturasEmitidas(entidad);
        }
    }
}
