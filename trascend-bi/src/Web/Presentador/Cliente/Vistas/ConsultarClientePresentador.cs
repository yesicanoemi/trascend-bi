using System;
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
        private IConsultarCliente _vista;

        private IList<Core.LogicaNegocio.Entidades.Cliente> cliente;

        #region constructor
        
        public ConsultarClientePresentador()
        { }
       
        #endregion

        public ConsultarClientePresentador(IConsultarCliente vista)
        {
            _vista = vista;
        }
        
        public void BotonSeleccionTipo()
        {

            if (_vista.opcion.SelectedIndex == 0)// nombre de cliente
            {
                Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

                cliente.Nombre = _vista.Valor.Text;


              //  IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);

                IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);
                _vista.GetObjectContainerConsultaCliente.DataSource = listaCliente;
                _vista.GetObjectContainerConsultaDireccion.DataSource = listaCliente[0].Direccion;
                CambiarVista(1);
            
            }

            if (_vista.opcion.SelectedIndex==1)//nombre de area de negocio
            {
                Core.LogicaNegocio.Entidades.Cliente cliente = 
                    new Core.LogicaNegocio.Entidades.Cliente();
                
                cliente.AreaNegocio = _vista.Valor.Text;

                IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = 
                    ConsultarClienteAreaNegocio(cliente);
                
                _vista.GetObjectContainerConsultaCliente.DataSource = listaCliente;

                CambiarVista(1);
            }                                   

        }
        
        public IList<Core.LogicaNegocio.Entidades.Cliente> BuscarNombre()
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

       
        public IList<Core.LogicaNegocio.Entidades.Cliente> 
            ConsultarClienteNombre(Core.LogicaNegocio.Entidades.Cliente entidad)
       
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre comando; //tengo q crear una nueva consulta

            comando = FabricaComandosCliente.CrearComandoConsultarNombre(entidad);

            listaCliente = comando.ejecutar();

            return listaCliente;
        }


        public IList<Core.LogicaNegocio.Entidades.Cliente>
          ConsultarClienteAreaNegocio(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarParametroAreaNegocio comando; //tengo q crear una nueva consulta

            comando = FabricaComandosCliente.CrearComandoConsultarParametroAreaNegocio(entidad);

            listaCliente = comando.ejecutar(entidad);

            return listaCliente;
        }

        /*public void metodoEnPresendator(int Id)
         {
         * 
         * CambiarVista(2);
         * }
         */
        public void CambiarVista(int index)
        {
            _vista.MultiViewConsulta.ActiveViewIndex = index;


        }
    }
}
