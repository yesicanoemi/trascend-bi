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
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

            if (_vista.opcion.SelectedIndex == 0)// nombre de cliente
            {
                cliente.Nombre = _vista.Valor.Text;

                IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);

                _vista.GetObjectContainerConsultaCliente.DataSource = listaCliente;
                _vista.GetObjectContainerConsultaDireccion.DataSource = listaCliente[0].Direccion;
                _vista.GetObjectContainerConsultaTelefono.DataSource = listaCliente[0].Telefono[0];
 
                CambiarVista(1);
            
            }

            if (_vista.opcion.SelectedIndex==1)//nombre de area de negocio
            {
                
                cliente.Rif = _vista.Valor.Text;

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

        public void CambiarVista(int index)
        {
            _vista.MultiViewConsulta.ActiveViewIndex = index;


        }
    }
}
