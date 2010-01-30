using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{

    /// <summary>
    /// Interface 'IDAOFactura'.
    /// Define los comportamientos o acciones del objeto DAO para la entidad 'Factura'.
    /// </summary>
    public interface IDAOFactura
    {

        /// <summary>
        /// Firma del método ConsultarFacturasNomPro, consulta las facturas por nombre
        /// de propuesta
        /// </summary>
        /// <param name="propuesta">Entidad con los datos de la propuesta</param>
        /// <returns>Lista génerica con las entidades facturas consultadas</returns>
        IList<Factura> ConsultarFacturasNomPro( Propuesta propuesta );

        /// <summary>
        /// Firma del método ConsultarFacturasIDPro, consulta las facturas por id de la
        /// propuesta
        /// </summary>
        /// <param name="propuesta">Entidad con los datos de la propuesta</param>
        /// <returns>Lista génerica con las entidades facturas consultadas</returns>
        IList<Factura> ConsultarFacturasIDPro( Propuesta propuesta );

        /// <summary>
        /// Firma del método ConsultarPropuesta, consulta todas las propuestas
        /// </summary>
        /// <returns>Lista génerica con las entidades propuesta consultadas</returns>
        IList<Propuesta> ConsultarPropuesta();

        /// <summary>
        /// Firma del método ConsultarFacturaID, consulta una factura por su id 
        /// </summary>
        /// <param name="factura">Entidad con los datos de la factura</param>
        /// <returns>Entidad factura con los datos consultados</returns>
        Factura ConsultarFacturaID( Factura factura );

        /// <summary>
        /// Firma del método ConsultarFacturasPorEstado, consulta las facturas por estado
        /// </summary>
        /// <param name="desde">Fecha inicial de busqueda</param>
        /// <param name="hasta">Fecha final de busqueda</param>
        /// <param name="cobradas">Si la factura es de tipo "cobrada" true;
        /// Si es de tipo "por cobrar" false</param>
        /// <returns>Lista génerica con las entidades facturas consultadas</returns>
        IList<Factura> ConsultarFacturasPorEstado( DateTime desde, DateTime hasta, Boolean cobradas );

        /// <summary>
        /// Firma del método IngresarFactura, ingresa una factura
        /// </summary>
        /// <param name="factura">Entidad con los datos de la factura</param>
        /// <returns>Entidad factura con los datos modificados</returns>
        Factura IngresarFactura( Factura factura );

        /// <summary>
        /// Firma del método ConsultarFacturas, consulta todas las factura
        /// </summary>
        /// <returns>Lista génerica con las entidades facturas consultadas</returns>
        IList<Factura> ConsultarFacturas();

        /// <summary>
        /// Firma del método UpadateFactura, modifica una factura
        /// </summary>
        /// <param name="factura">Entidad con los datos de la factura</param>
        /// <returns>Entidad factura con los datos modificados</returns>
        Factura UpdateFactura( Factura factura );

        void ModificarEstadoFactura(int idFactura, string estado);
    }
}
