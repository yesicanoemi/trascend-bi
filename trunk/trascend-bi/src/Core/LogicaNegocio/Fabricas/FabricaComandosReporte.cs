﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoReporte;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosReporte
    {
        #region Metodos

        /// <summary>
        /// Metodo que fabrica el comando 'FacturasEmitidas' de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad Factura con los datos</param>
        /// <returns>Comando FacturasEmitidas de la entidad Factura</returns>
        
        public static FacturasEmitidas CrearComandoFacturasEmitidas(Factura entidad)
        {
            return new FacturasEmitidas(entidad);
        }

        public static ConsultaRol CrearComandoConsultarRol(IList<string> entidad)
        {
            return new ConsultaRol(entidad);
        }

        #endregion

    }
}
