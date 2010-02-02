using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Core.AccesoDatos.Interfaces;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio;
using Core.LogicaNegocio.Excepciones;

namespace Presentador.Factura.Vistas
{
    public class ModificarFacturaPresenter
    {

        #region Atributos

        IModificarFactura _vista;

        #endregion

        #region Constructor

        public ModificarFacturaPresenter(IModificarFactura vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos

        public void ConsultarFactura()
        {
            try
            {
                Core.LogicaNegocio.Entidades.Factura factura =
                    new Core.LogicaNegocio.Entidades.Factura();

                factura.Numero = int.Parse(_vista.NumeroFactura.Text);

                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxFacturaID comandoConsultar =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxFacturaID(factura);

                factura = comandoConsultar.Ejecutar();

                List<Core.LogicaNegocio.Entidades.Factura> lista = new List<Core.LogicaNegocio.Entidades.Factura>();
                lista.Add(factura);

                _vista.DetalleFactura.DataSource = lista;
                _vista.DetalleFactura.DataBind();

            }
            catch (ConsultarException e)
            {
                _vista.Pintar(e.Message);
            }
            catch (Exception e)
            {
                _vista.Pintar(e.Message);
            }
        }


        public void SaldarFactura()
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoFactura.Saldar comandoSaldar =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoSaldar(
                    int.Parse(_vista.NumeroFactura.Text), _vista.Estado.SelectedItem.Text);

                comandoSaldar.Ejecutar();
                _vista.Pintar("Cambio ejecutado con éxito");
                _vista.MensajeVisible = true;
            }
            catch (ConsultarException e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
            catch (Exception e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
        }

        public void LLenarDDLEstados()
        {
            try
            {
                IDAOFactura facturabd = FabricaDAOSQLServer.ObtenerFabricaDAO().ObtenerDAOFactura();

                IList<String> estados = facturabd.ConsultarEstados();

                for (int i = estados.Count-1; i >= 0; i--)
                {
                    _vista.Estado.Items.Add(estados[i].ToString());
                }
            }
            catch (ConsultarException e) 
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
            catch (Exception e) 
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }

        }

        #endregion
    }
}







