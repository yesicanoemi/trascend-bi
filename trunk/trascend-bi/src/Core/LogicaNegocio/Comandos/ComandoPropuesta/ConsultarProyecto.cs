﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class ConsultarProyecto : Comando<Propuesta>
    {
        private Propuesta _propuesta;
        private IList<Propuesta> _propuesta2;
        private string _estado;

        #region Constructor
        public ConsultarProyecto()
        {
        }
        public ConsultarProyecto(Propuesta entidad)
        {
            _propuesta = entidad;
        }
        public ConsultarProyecto(IList<Propuesta> arreglo)
        {
            _propuesta2 = arreglo;
        }
        public ConsultarProyecto(string estado)
        {
            _estado = estado;
        }
        #endregion

        #region Metodos

        public IList<Propuesta> Ejecutar()
        {

            PropuestaSQLServer acceso = new PropuestaSQLServer();
            _propuesta2 = acceso.ConsultarPropuesta(_estado);

            return _propuesta2;
        }

        #endregion
    }
}