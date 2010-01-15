﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoFactura;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosFactura
    {
        public static Ingresar CrearComandoIngresar(Factura factura)
        {
            return new Ingresar(factura);
        }

        public static ConsultarxFacturaID CrearComandoConsultarxFacturaID(Factura factura)
        {
            return new ConsultarxFacturaID(factura);
        }

        public static ConsultarxIDPro CrearComandoConsultarxIDPro(Propuesta propuesta)
        {
            return new ConsultarxIDPro(propuesta);
        }

        public static ConsultarxNomPro CrearComandoConsultarxNomPro(Propuesta propuesta)
        {
            return new ConsultarxNomPro(propuesta);
        }

    }
}