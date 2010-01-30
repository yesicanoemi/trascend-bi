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

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    /// <summary>
    /// Clase pública 'ConsultarxFacturaID'.
    /// Implementa el comando 'ConsultarxFacturaID' de la entidad 'Factura'.
    /// </summary>
    public class ConsultarxFacturaID : Comando<Factura>
    {
        private Factura _factura;
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'ConsultarxFacturaID'.</summary>
        public ConsultarxFacturaID()
        { }

        /// <summary>Constructor de la clase 'ConsultarxFacturaID'.</summary>
        /// <param name="Factura">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarxFacturaID(Factura factura)
        {
            this._factura = factura;
        }


        #endregion


        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'ConsultarxFacturaID'.</summary>
        public Factura Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            Factura factura = new Factura();

            IDAOFactura bdfactura = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();

            try
            {
                if (_factura == null) { throw new ConsultarFacturaLNException(); }
                factura = bdfactura.ConsultarFacturaID(factura);
            }
            catch (ConsultarFacturaADException e) { }
            catch (ConsultarFacturaLNException e) { throw new ConsultarFacturaLNException("Se recibio una factura vacia", e); }
            catch (Exception e) { throw new ConsultarFacturaLNException("Error al Consultar", e); }
            return factura;
        }
        #endregion
    }
}