﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Propuesta.Contrato
{
    public interface IConsultarPropuesta
    {
        RadioButtonList ListOpcion { get; set; }
        //DropDownList SeleccionOpcion { get; set; }
        Label LabelTipoC { get; set; }
        Label LabelT { get; set; }
        Label LabelTP { get; set; }
        Label LabelV { get; set; }
        Label LabelVP { get; set; }
        Label LabelFFirm { get; set; }
        Label LabelFFirmP { get; set; }
        Label LabelRecep { get; set; }
        Label LabelRecepP { get; set; }
        Label LabelCarg { get; set; }
        Label LabelCargP { get; set; }
        Label LabelFechaI { get; set; }
        Label LabelFechaIP { get; set; }
        Label LabelFechaFi { get; set; }
        Label LabelFechaFiP { get; set; }
        Label LabelTotalHoras { get; set; }
        Label LabelTotalHorasP { get; set; }
        Label LabelMont { get; set; }
        Label LabelMontP { get; set; }
        Label LabelEquip { get; set; }
        //Label LabelParam { get; set; }
        ListBox ListaEmpleados { get; set; }
        TextBox TextParametro { get; set; }
        GridView GridPropuesta { get; set; }
        ObjectContainerDataSource ObtenerValorDataSource { get; set; }
        GridView GridPropuestaMuest { get; set; }
        ObjectContainerDataSource ObtenerValorMuestra { get; set; }
        MultiView MultiViewPropuestaC { get; set; }
        Label LabelVacioC { get; set; }



    }
}
