using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio;
using Core.LogicaNegocio.Excepciones;
namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class ConsultarPropuestas : Comando<Propuesta>
    {

        #region Constructor
        public ConsultarPropuestas()
        {
        }

        #endregion

        #region Metodos

        public IList<Propuesta> Ejecutar()
        {
            IList<Propuesta> _propuestas = null;
            FacturaSQLServer bdpropuestas = new FacturaSQLServer();
            try
            {
                _propuestas = bdpropuestas.ConsultarPropuesta();
            }
            catch (ConsultarFacturaADException e) { }
            catch (ConsultarFacturaLNException e) { throw new ConsultarFacturaLNException("Error en la Consulta", e); }
            catch (Exception e) { throw new ConsultarFacturaLNException("Error en la Consulta", e); }
            return _propuestas;
        }

        #endregion
    }
}