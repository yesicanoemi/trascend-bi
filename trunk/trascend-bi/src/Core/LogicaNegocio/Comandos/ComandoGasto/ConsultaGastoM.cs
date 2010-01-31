using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
   public class ConsultaGastoM : Comando<Gasto>
    {
       private int _IdGasto;
       private IList<Gasto> listagastos = null;

        #region Constructor

        /// <summary> Conructor de la Clase 'ModificarGasto' </summary>
        public ConsultaGastoM()
        { }

        /// <summary>Constructor de la clase 'Modificar'.</summary>
        public ConsultaGastoM( int IdGasto )
        {

            _IdGasto = IdGasto;
          
   
        }

        #endregion

        #region Metodos
        public IList<Gasto> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOGasto bdgastos = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOGasto();
            listagastos = bdgastos.ConsultarGastoaModificar(_IdGasto);

            return listagastos;
        }
        #endregion
    }
}
