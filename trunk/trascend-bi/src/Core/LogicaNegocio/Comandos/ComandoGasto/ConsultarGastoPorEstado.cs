using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ConsultarGastoPorEstado
    {
        private Gasto gasto;
        private IList<Gasto> listaGasto;
        private int _Opcion;
        private string _Parametro;

        #region Constructor

        public ConsultarGastoPorEstado(Gasto _gasto)
        {
            gasto = _gasto;
        }

        public ConsultarGastoPorEstado(IList<Gasto> _listaGasto)
        {
            listaGasto = _listaGasto;
        }
        public ConsultarGastoPorEstado(int Opcion , string Parametro)
        {
            _Opcion = Opcion;
            _Parametro = Parametro;
        }


        #endregion

        #region Metodo

        public IList<Gasto> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOGasto bdgastos = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOGasto();
            listaGasto = bdgastos.ConsultarGastoPorEstado(gasto);

            return listaGasto;
        }
        #endregion
    }
}