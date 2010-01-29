using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class Consultar : Comando<Propuesta>
    {
        private Propuesta _propuesta;
        private IList<Propuesta> _propuesta2;
        private string _Parametro;
        private int _Opcion;

        #region Constructor
        public Consultar()
        {
        }
        public Consultar(Propuesta entidad)
        {
            _propuesta = entidad;
        }
        public Consultar(IList<Propuesta> arreglo)
        {
            _propuesta2 = arreglo;
        }
        public Consultar(int Opcion , string Parametro)
        {
            _Opcion = Opcion;
            _Parametro = Parametro;
        }
        #endregion

        #region Metodos

        public IList<Propuesta> Ejecutar()
        {

            //DAOPropuestaSQLServer acceso = new DAOPropuestaSQLServer();
            //_propuesta2 = acceso.ConsultarPropuestaNueva(_Opcion,_Parametro);

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOPropuesta iDAOPropuesta = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOPropuesta();

            _propuesta2 = iDAOPropuesta.ConsultarPropuestaNueva(_Opcion, _Parametro);
            
            
            return _propuesta2;
        }

        #endregion
    }
}