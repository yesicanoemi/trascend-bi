using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.LogicaNegocio.Excepciones;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class Anular : Comando<Factura>
    {

        #region Atributos

        private int _idFactura;
        private string _estado;

        #endregion

        #region Constructores

        public Anular()
        {
        }

        public Anular(int idFactura)
        {
            _idFactura = idFactura;
        }

        public Anular(int idFactura, string estado)
        {
            _idFactura = idFactura;
            _estado = estado;
        }

        #endregion

        #region Metodos

        public void Ejecutar()
        {
            Core.AccesoDatos.FabricaDAO.EnumFabrica = Core.AccesoDatos.EnumFabrica.SqlServer;

            IDAOFactura bdpropuestas = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();

            Factura facturaBuscar = new Factura();
            facturaBuscar.Numero = _idFactura;

            Factura factura = bdpropuestas.ConsultarFacturaID(facturaBuscar);

            if (factura.Estado.Equals("Por Cobrar"))
                bdpropuestas.ModificarEstadoFactura(_idFactura, "Anulada");
            else
                throw new EliminarException("No se puede anular una factura que ya haya sido cobrada");
        }

        #endregion
    }
}
