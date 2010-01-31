using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ConsultarGastoPorFecha
    {
        private Gasto gasto;
        private IList<Gasto> listaGasto;

        #region Constructor

        public ConsultarGastoPorFecha(Gasto _gasto)
        {
            gasto = _gasto;
        }

        public ConsultarGastoPorFecha(IList<Gasto> _listaGasto)
        {
            listaGasto = _listaGasto;
        }

        #endregion

        #region Metodo

        public IList<Gasto> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOGasto bdgastos = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOGasto();
            
            listaGasto = bdgastos.ConsultarGastoPorFecha(gasto);

            return listaGasto;
        }
        #endregion
    }
}