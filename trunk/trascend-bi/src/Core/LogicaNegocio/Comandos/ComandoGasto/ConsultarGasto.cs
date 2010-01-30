using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
    public class ConsultarGasto : Comando<Gasto>
    {
        //private Gasto gasto;
        private string _Parametro;
        private int _Opcion;
        private IList<Gasto> listagastos = null;

        #region Constructor

        /// <summary> Conructor de la Clase 'ConsultarGasto' </summary>
        public ConsultarGasto()
        { }

        /// <summary>Constructor de la clase 'Consultar'.</summary>
        public ConsultarGasto( int Opcion, string Parametro )
        {

            _Opcion = Opcion;
            _Parametro = Parametro;
   
        }

        #endregion

        #region Metodos
        public IList<Gasto> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOGasto bdgastos = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOGasto();
            listagastos = bdgastos.ConsultarGasto( _Opcion, _Parametro);

            return listagastos;
        }
        #endregion
    }
}
