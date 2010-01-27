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
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOFactura bdpropuestas = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();

            IList<Propuesta> _propuestas = new List<Propuesta>();

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