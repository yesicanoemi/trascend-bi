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

           
            public Consultar()
            { }

           

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
                /*Fabrica.EnumFabrica = EnumFabrica.SqlServer;

                IFabrica iFabrica = Fabrica.getFabrica();

                IUsuarioDao daoUsuario = iFabrica.getUsuarioDao();

                daoUsuario.save(usuario);*/

                FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

                IFabricaDAO iFabrica = FabricaDAO.ObtenerFabricaDAO();

                IDAOCliente iDAOCliente = iFabrica.ConsultarNombre();

                _cliente2=iDAOCliente.ConsultarNombre();


//                IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO("SQLServer").ObtenerDAOCliente();

                //_cliente2 = acceso.ConsultarNombre();
                
                return _cliente2;
            }
        #endregion
    }
}