using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;


namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class ConsultarTabla : Comando<Cargo>
    {
        #region Constructor
        public ConsultarTabla()
        {
        }
        #endregion

        /// <summary>
        /// Metodo de ejecucion de busqueda de todos los cargos
        /// </summary>
        /// <returns>List de cargos con todos los cargos</returns>
        public List<Cargo> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCargo bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCargo();

            List<Cargo> ListaCargos = new List<Cargo>();
            IList<Entidad> ListaEntidades = bd.ConsultarCargos();
            
            for (int i = 0; i < ListaEntidades.Count; i++)
            {
                ListaCargos.Add((Cargo)ListaEntidades[i]);
            }
            return ListaCargos;
        }
    }
}
