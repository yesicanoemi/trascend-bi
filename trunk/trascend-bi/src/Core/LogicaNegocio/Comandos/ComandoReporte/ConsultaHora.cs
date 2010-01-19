using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultaHora
    {
        private string _rol;
        #region Constructor
        public ConsultaHora(string rol)
        {
            _rol = rol;
        }
        #endregion

        #region Metodos
        public int Ejecutar()
        {
            int hora;
            ReporteSQLServer acceso = new ReporteSQLServer();
            hora = acceso.SumaHora(_rol);
            return hora;
        }
        #endregion
    }
}
