using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoReporte;
using Core.LogicaNegocio.Fabricas;
using Presentador.Reportes.Contrato;
using System.Net;

namespace Presentador.Reportes
{
    public class ReporteEmpleadoPaquetePresenter
    {
        #region Propiedades

        private IReportePaqueteCargoAnual _vista;
        private IList<string> cargo;
        private Core.LogicaNegocio.Entidades.Cargo _resultado;
        


        #endregion

        public ReporteEmpleadoPaquetePresenter(IReportePaqueteCargoAnual vista)
        {
            _vista = vista;

        }



        public void BuscaCargo()
        {
            try
            {
                cargo = BuscarCargos();
                int i = 0;

                for (i = 0; i < cargo.Count; i++)
                {
                    _vista.SeleccionCargo.Items.Add(cargo.ElementAt(i));
                    
                }

                _vista.SeleccionCargo.DataBind();
                _vista.SeleccionCargo.Visible = true;
            }
            catch (WebException e)
            {
                //EXCECION WEB
            }
        }


        public IList<string> BuscarCargos()
        {
            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultaCargo consultar;
            consultar = FabricaComandosReporte.CrearComandoConsultarCargo(cargo);
            cargo = consultar.Ejecutar();
            return cargo;
        }

        public Core.LogicaNegocio.Entidades.Cargo BuscarReultado()
        {
            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarEmpleadoCargoAnual consultar;
            consultar = FabricaComandosReporte.CrearConsultarEmpleadoCargoAnual(_vista.SeleccionCargo.Text);
            _resultado = consultar.Ejecutar();
       
        
        
                    
            //_vista.TablaResultados.Rows.Add(r);
                    TableRow r = new TableRow();
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl("NOMBRE"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("ANUALMIN"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("ANUALMINIMO"));
                    r.Cells.Add(c);
                    _vista.TablaSolucion.Rows.Add(r);
                    r = new TableRow();
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl(_resultado.Nombre));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl(_resultado.SueldoMinimo.ToString()));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl(_resultado.SueldoMaximo.ToString()));
                    r.Cells.Add(c);
                    _vista.TablaSolucion.Rows.Add(r);


                    return _resultado;
        }

    }



}
