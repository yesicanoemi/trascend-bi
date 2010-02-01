using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentador.Usuario.Contrato
{
    public interface IDefaultUsuario
    {
        #region Dialogo

        //  bool DialogoVisible { get; set; }

        //    void Pintar(string codigo, string mensaje, string actor, string detalles);

        //bool InformacionVisible { get; set; }

        bool InformacionVisibleBotonAceptar { get; set; }

        //void PintarInformacion(string mensaje, string estilo);

        void PintarInformacionBotonAceptar(string mensaje, string estilo);


        #endregion
    }
}
