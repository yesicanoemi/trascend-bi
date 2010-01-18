using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.Vistas;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Presentador.Cliente.ClienteInterface;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;


namespace Presentador.Cliente.Vistas
{
    public class ModificarClientePresentador
 {
        #region Propiedades
        private IModificarCliente _vista;
        private string campoVacio = "";
        #endregion
        #region Constructor
        public ModificarClientePresentador(IModificarCliente vista)
        {
            _vista = vista;
        }
        #endregion

        #region Manejo de Eventos
        public void ModificarCliente()
        {
            int resultado = 0;
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
            try
            {

                cliente.Rif = _vista.rifCliente.Text;
                cliente.Nombre = _vista.NombreCliente.Text;
                cliente.CalleAvenidad = _vista.CalleAvenidadCliente.Text;
                
                cliente.Urbanizacion = _vista.UrbanizacionCliente.Text;
                cliente.EdificioCasa = _vista.EdificioCasaCliente.Text;
                cliente.PisoApartamento = _vista.PisoApartamentoCliente.Text;
                cliente.Ciudad = _vista.CiudadCliente.Text;
                cliente.AreaNegocio = _vista.AreaNegocioCliente.Text;
                Modificar(cliente);
                //LimpiarRegistros();
            }
            catch (WebException e)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        #endregion

        #region Comando
        public void Modificar(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Modificar modificar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            modificar = Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoModificar(cliente);

            //try
            //{    
            //ejecuta el comando.
            modificar.Ejecutar();
        }
        #endregion
    }

}

