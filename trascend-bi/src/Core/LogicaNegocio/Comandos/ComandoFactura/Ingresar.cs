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

            factura = bdfactura.IngresarFactura(_factura);

            return factura;
        }
        #endregion
    }
}