﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class Consultar : Comando<Cliente>
    {
        private Cliente _cliente;
        private IList<Cliente> _cliente2;

        #region Constructor

            /// <summary>Constructor por defecto de la clase 'Consultar'.</summary>
            public Consultar()
            { }


            /// <summary>Constructor de la clase 'Consultar'.</summary>
            public Consultar(Cliente cliente)
            {
                _cliente = cliente;
            }
            
            public Consultar(IList<Cliente> cliente)
            {
                _cliente2 = cliente;
            }

        
        #endregion


        #region Metodos

            public IList<Cliente> ejecutar()
            {

                FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

                IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();
              
                _cliente2 = acceso.ConsultarNombre();
                
                return _cliente2;
            }
        #endregion
    }
}