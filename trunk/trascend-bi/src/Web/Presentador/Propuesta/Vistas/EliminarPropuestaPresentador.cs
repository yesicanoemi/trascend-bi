using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Fabricas;
using System.Net;

namespace Presentador.Propuesta.Vistas
{
   public class EliminarPropuestaPresentador
   {
       IEliminarPropuesta _vista;
       IList<string> ListaPropuesta;

       #region Constructor
       public EliminarPropuestaPresentador()
       { 
       }
       public EliminarPropuestaPresentador(IEliminarPropuesta vista)
       { 
            _vista = vista;
       }
       
       #endregion

       #region Metodos

       public void LlenarLista( bool o )
       {
           List<string> ListaRecibida = new List<string>();
           if ( o == true )
           // SE SELECCIONO PROPUESTA SE PROCEDE A ELIMINAR
           {
               try
               {
                   ListaRecibida.Add(_vista.ListaPropuesta.SelectedItem.Text);
                   Core.LogicaNegocio.Comandos.ComandoPropuesta.Eliminar comando;
                   comando = FabricaComandosPropuesta.CrearComandoEliminar(ListaPropuesta);
                   ListaPropuesta = comando.Ejecutar(ListaRecibida);

                   int i = 0;
                   for (i = 0; i < ListaPropuesta.Count; i++)
                   {
                       _vista.ListaPropuesta.Items.Add(ListaPropuesta.ElementAt(i));
                   }
                   _vista.ListaPropuesta.DataBind();
                   _vista.ListaPropuesta.Visible = false;
                   _vista.LabelEliminarCompletado.Text = _vista.ListaPropuesta.SelectedItem.Text + " ELIMINADO";
                   _vista.LabelEliminarCompletado.Visible = true;
               }
               catch (WebException e)
               {
                   //Excepcipon WEB
               }
               catch (NullReferenceException e)
               { 
               
               }
           }
           else
           {
               try
               {
                   Core.LogicaNegocio.Comandos.ComandoPropuesta.Eliminar comando;
                   comando = FabricaComandosPropuesta.CrearComandoEliminar( ListaPropuesta );
                   ListaPropuesta = comando.Ejecutar( ListaRecibida );

                   int i = 0;
                   for ( i = 0; i < ListaPropuesta.Count; i++ )
                   {
                       _vista.ListaPropuesta.Items.Add( ListaPropuesta.ElementAt(i) );
                   }
                   _vista.ListaPropuesta.DataBind();
                   _vista.ListaPropuesta.Visible = true;
               }
               catch 
               {
               
               }
           }

       }

       #endregion
   }
}
