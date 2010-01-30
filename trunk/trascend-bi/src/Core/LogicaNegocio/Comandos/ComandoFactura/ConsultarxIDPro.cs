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


namespace Core.LogicaNegocio.Comandos.ComandosFactura
{
    /// <summary>
    /// Clase pública 'Consultar'.
    /// Implementa el comando 'ConsultarxIDPro' de la entidad 'Factura'.
    /// </summary>
    public class ConsultarxIDPro : Comando<Factura>
    {
        private Propuesta _propuesta;
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'ConsultarxIDPro'.</summary>
        public ConsultarxIDPro()
        { }

        /// <summary>Constructor de la clase 'ConsultarxIDPro'.</summary>
        /// <param name="Factura">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarxIDPro(Propuesta propuesta)
        {
            this._propuesta = propuesta;
        }


        #endregion


        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'ConsultarxIDPro'.</summary>
        public IList<Factura> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IList<Factura> _facturas = new List<Factura>();

            IDAOFactura bdfactura = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();

            try
            {
                if (_propuesta == null) { throw new ConsultarFacturaLNException(); }
                _facturas = bdfactura.ConsultarFacturasIDPro(_propuesta);

            }
            catch (ConsultarFacturaADException e) { }
            catch (ConsultarFacturaLNException e) { throw new ConsultarFacturaLNException("Se recibio una propuesta vacia", e); }
            catch (Exception e) { throw new ConsultarFacturaLNException("Error al Consultar", e); }
            return _facturas;
        }
        #endregion
    }
}
