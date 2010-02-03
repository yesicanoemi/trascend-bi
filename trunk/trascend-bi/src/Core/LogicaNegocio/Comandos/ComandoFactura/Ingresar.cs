using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio;
using Core.LogicaNegocio.Excepciones;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using System.Collections;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class Ingresar : Comando<Factura>
    {
        private Factura _factura;


        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Ingresar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="factura">Entidad sobre la cual se aplicará el comando.</param>
        public Ingresar(Factura factura)
        {
            this._factura = factura;
        }

        #endregion

        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'Ingresar'.</summary>
        public Factura Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            Factura factura = new Factura();

            IDAOFactura bdfactura = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();

            IDAOPropuesta bdpropuesta = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOPropuesta();

            IList<Factura> facturas = bdfactura.ConsultarFacturasNomPro(_factura.Prop);

            IList<Propuesta> propuestas = bdpropuesta.ConsultarPropuestaNueva(1, _factura.Prop.Titulo);

            #region Validar porcentaje a pagar

            float porcentaje = 0;

            foreach (Factura f in facturas)
            {
                porcentaje += f.Procentajepagado;
            }

            porcentaje += _factura.Procentajepagado;

            #endregion

            if (porcentaje > 100)
                throw new IngresarException("El porcentaje ingresado supera el monto restante de la propuesta");
            else
            {
                foreach (Propuesta p in propuestas)
                {
                    if (p.Version != "Activa")
                        throw new IngresarException("No se puede facturar una propuesta que no este activa ");
                    
                }

                factura = bdfactura.IngresarFactura(_factura);
            }

            return factura;
        }
        #endregion
    }
}