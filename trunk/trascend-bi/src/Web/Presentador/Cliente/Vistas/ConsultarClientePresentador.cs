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

                IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);


                _vista.GetObjectContainerConsultaCliente.DataSource = listaCliente;

                CambiarVista(1);
            
            }

            if (_vista.opcion.SelectedIndex==1)//nombre de area de negocio
            {
            
            }
            
                
            #region comentado     
           //_vista.opcion.Visible = false;

            
            /*_vista.TipoConsulta.Visible = false;
            _vista.Seleccion.Visible = true;
            _vista.SeleccionOpcion.Visible= true;
            _vista.SeleccionAreaCliente.Visible = false;
            _vista.SeleccionArea.Visible = false;*/
#endregion

            #region SolicitudServicios

            /*if (_vista.opcion.SelectedIndex == 0) // Nombre de cliente
            {
                #region buscar por nombre
                int i = 0;

                  cliente = BuscarNombre(); //busco todo los nombres de cliente

                 for (i = 0; i < cliente.Count; i++)
                 {

                     _vista.SeleccionOpcion.Items.Add(cliente.ElementAt(i).Nombre);

                 }

                 _vista.SeleccionOpcion.DataBind();
                #endregion
            }



            if (_vista.opcion.SelectedIndex == 1) // Area de Negcocio
            {
                #region area de negocio

                int i = 0;

                cliente = BuscarPorAreaNegocio();

                 for (i = 0; i < cliente.Count; i++)
                 {                                
                     _vista.SeleccionOpcion.Items.Add(cliente.ElementAt(i).AreaNegocio);

                 }
                            
                 _vista.SeleccionOpcion.DataBind();

                #endregion
            }*/


            #endregion



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

            cliente = consultar.Ejecutar();

            _vista.GetObjectContainerConsultaCliente.DataSource = cliente;

            CambiarVista(1);

            return cliente;

            #endregion
        }

        public IList<Core.LogicaNegocio.Entidades.Cliente> 
            ConsultarClienteNombre(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarParametroNombre comando; //tengo q crear una nueva consulta

            comando = FabricaComandosCliente.CrearComandoConsultarParametroNombre (entidad);

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
