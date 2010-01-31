using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class Saldar : Comando<Factura>
    {

        #region Atributos

        private int _factura;
        private string _estado;

        #endregion

        #region Constructores

        public Saldar()
        {
        }

        public Saldar(int idFactura, string estado)
        {
            _factura = idFactura;
            _estado = estado;
        }

        #endregion

        #region Metodos

        public void Ejecutar()
        {
            Core.AccesoDatos.FabricaDAO.EnumFabrica = Core.AccesoDatos.EnumFabrica.SqlServer;

            IDAOFactura dao = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOFactura();

            dao.ModificarEstadoFactura(_factura, _estado);
        }

        #endregion
    }
}
