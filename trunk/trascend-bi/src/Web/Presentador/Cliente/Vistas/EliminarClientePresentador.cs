using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Fabricas;
using System.Net;

namespace Presentador.Cliente.Vistas
{
    public class EliminarClientePresentador
    {
        IEliminarCliente _vista;
        IList<string> ListaCliente;

        #region Constructor
        public EliminarClientePresentador()
        {
        }
        public EliminarClientePresentador(IEliminarCliente vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos

        public void LlenarLista(bool o)
        {
        //    List<string> ListaRecibida = new List<string>();
        //    if (o == true)
        //    // SE SELECCIONO EL CLIENTE SE PROCEDE A ELIMINAR
        //    {
        //        try
        //        {
        //            ListaRecibida.Add(_vista.ListaCliente.SelectedItem.Text);
        //            Core.LogicaNegocio.Comandos.ComandoCliente.Eliminar comando;
        //            comando = FabricaComandosCliente.CrearComandoEliminar(new Cliente());
        //            ListaCliente = comando.Ejecutar();

        //            int i = 0;
        //            for (i = 0; i < ListaCliente.Count; i++)
        //            {
        //                _vista.ListaCliente.Items.Add(ListaCliente.ElementAt(i));
        //            }
        //            _vista.ListaCliente.DataBind();
        //            _vista.ListaCliente.Visible = false;
        //            _vista.LabelEliminarCompletado.Text = _vista.ListaCliente.SelectedItem.Text + " fue eliminado de la base de datos";
        //            _vista.LabelEliminarCompletado.Visible = true;
        //        }
        //        catch (WebException e)
        //        {
        //            //Excepcipon WEB
        //        }
        //        catch (NullReferenceException e)
        //        {

        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Core.LogicaNegocio.Comandos.ComandoCliente.Eliminar comando;
        //            //-------------------FALTA ARREGLARLO---------------------------------//
        //            comando = FabricaComandosCliente.CrearComandoEliminar(new Cliente());
        //            ListaCliente = comando.Ejecutar(ListaRecibida);

        //            int i = 0;
        //            for (i = 0; i < ListaCliente.Count; i++)
        //            {
        //                _vista.ListaCliente.Items.Add(ListaCliente.ElementAt(i));
        //            }
        //            _vista.ListaCliente.DataBind();
        //            _vista.ListaCliente.Visible = true;
        //        }
        //        catch
        //        {

        //        }
        //    }

        }

        #endregion
    }

}
