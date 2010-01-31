using System;
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

        public static Consultar CrearComandoConsultar()
        {
            return new Consultar();
        }

        public static Modificar CrearComandoModificar(Factura factura)
        {
            return new Modificar(factura);
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

        public static ConsultarPropuestas CrearComandoConsultarPropuestas()
        {
            return new ConsultarPropuestas();
        }

    
        public static Anular CrearComandoAnular(int idFactura)
        {
            return new Anular(idFactura);
        }

        public static Saldar CrearComandoSaldar(int idFactura, string estado)
        {
            return new Saldar(idFactura, estado);
        }
    }
}
