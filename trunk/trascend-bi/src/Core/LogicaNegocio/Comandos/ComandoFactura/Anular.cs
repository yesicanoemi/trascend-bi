using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.LogicaNegocio.Comandos.ComandosFactura
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

        public Anular(int idFactura, string estado)
        {
            _idFactura = idFactura;
            _estado = estado;
        }

        #endregion

        public void Ejecutar()
        {
            Core.AccesoDatos.FabricaDAO.EnumFabrica = Core.AccesoDatos.EnumFabrica.SqlServer;

            IDAOFactura bdpropuestas = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();


            bdpropuestas.ModificarEstadoFactura( _idFactura );
        }
    }
}
