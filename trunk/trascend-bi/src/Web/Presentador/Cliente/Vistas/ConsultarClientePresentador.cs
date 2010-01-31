﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoCliente;

namespace Presentador.Cliente.Vistas
{
    public class ConsultarClientePresentador
    {

        #region Propiedades
        private IConsultarCliente _vista;

        private const string campoVacio = "";
        #endregion



        #region constructor

        public ConsultarClientePresentador()
        {
        }

        public ConsultarClientePresentador(IConsultarCliente vista)
        {
            _vista = vista;
        }

        #endregion


        private IList<Core.LogicaNegocio.Entidades.Cliente> cliente;

        #region Métodos


        public void CambiarVista(int index)
        {
            _vista.MultiViewConsulta.ActiveViewIndex = index;


        }

        private void LimpiarFormulario()
        {
            _vista.ConsultaRif.Text = campoVacio;

            _vista.Valor.Text = campoVacio;

        }


        #region Radio Buttons

        /// <summary>
        /// Acción al seleccionar el radiobutton
        /// </summary>
        /// 
        public void CampoBusqueda_Selected()
        {
            LimpiarFormulario();

            if (_vista.RbCampoBusqueda.SelectedValue == "1")
            {
                _vista.BotonBuscar.Visible = true;
                _vista.Valor.Visible = true;
                _vista.NombreCliente.Visible = true;
                _vista.ConsultaRif.Visible = false;
                _vista.RifCliente.Visible = false;
                _vista.GetObjectContainerConsultaCliente.DataSource = "";
                _vista.GetObjectContainerConsultaDireccion.DataSource = "";
                _vista.GetObjectContainerConsultaTelefono.DataSource = "";
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")
            {
                _vista.BotonBuscar.Visible = true;
                _vista.Valor.Visible = false;
                _vista.NombreCliente.Visible = false;
                _vista.ConsultaRif.Visible = true;
                _vista.RifCliente.Visible = true;
                _vista.GetObjectContainerConsultaCliente.DataSource = "";
                _vista.GetObjectContainerConsultaDireccion.DataSource = "";
                _vista.GetObjectContainerConsultaTelefono.DataSource = "";
            }
        }

        #endregion












        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

            if (_vista.RbCampoBusqueda.SelectedValue == "1")// nombre de cliente
            {
                cliente.Nombre = _vista.Valor.Text;

                IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);
                _vista.GetObjectContainerConsultaCliente.DataSource = listaCliente;
                _vista.GetObjectContainerConsultaDireccion.DataSource = listaCliente[0].Direccion;
                _vista.GetObjectContainerConsultaTelefono.DataSource = listaCliente[0].Telefono[0];

                CambiarVista(1);

            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")// rif del cliente
            {

                cliente.Rif = _vista.ConsultaRif.Text;

                Core.LogicaNegocio.Entidades.Cliente seleccionCliente = ConsultarClienteRif(cliente);

                _vista.GetObjectContainerConsultaCliente.DataSource = seleccionCliente;
                _vista.GetObjectContainerConsultaDireccion.DataSource = seleccionCliente.Direccion;
                _vista.GetObjectContainerConsultaTelefono.DataSource = seleccionCliente.Telefono[0];

                CambiarVista(1);
            }

        }




        /*   public IList<Core.LogicaNegocio.Entidades.Cliente> BuscarNombre()
           {
               Core.LogicaNegocio.Comandos.ComandoCliente.Consultar consultar;

               consultar = FabricaComandosCliente.CrearComandoConsultar(cliente);

               cliente = consultar.ejecutar();

               _vista.GetObjectContainerConsultaCliente.DataSource = cliente;
               //_vista.GetObjectContainerConsultaUsuario.DataSource = listado;

               CambiarVista(1);

               return cliente;

           }
    
       
           public IList<Core.LogicaNegocio.Entidades.Cliente> BuscarPorAreaNegocio()
           {
               #region logica

               Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarAreaNegocio consultar;

               consultar = FabricaComandosCliente.CrearComandoConsultarAreaNegocio(cliente);

               //cliente = consultar.Ejecutar();

               _vista.GetObjectContainerConsultaCliente.DataSource = cliente;

               CambiarVista(1);

               return cliente;

               #endregion
           }
             */

        public IList<Core.LogicaNegocio.Entidades.Cliente>
            ConsultarClienteNombre(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre comando; //tengo q crear una nueva consulta

            comando = FabricaComandosCliente.CrearComandoConsultarNombre(entidad);

            listaCliente = comando.ejecutar();

            return listaCliente;
        }


        public Core.LogicaNegocio.Entidades.Cliente ConsultarClienteRif(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            Core.LogicaNegocio.Entidades.Cliente seleccioncliente = new Core.LogicaNegocio.Entidades.Cliente();

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarRif comando; //tengo q crear una nueva consulta

            comando = FabricaComandosCliente.CrearComandoConsultarRif(entidad);

            seleccioncliente = comando.ejecutar();

            return seleccioncliente;
        }



        #endregion
    }
}
