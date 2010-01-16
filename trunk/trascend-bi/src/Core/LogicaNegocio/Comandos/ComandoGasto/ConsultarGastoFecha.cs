using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoGasto
{
   public class ConsultarGastoFecha : Comando<Gasto>
    {
       private DateTime _fechainicio;

       private DateTime _fechafin;

       private IList<Gasto> _listagasto;


       public ConsultarGastoFecha(DateTime fechaini,DateTime fechafin)
       {
       _fechainicio = fechaini;
       _fechafin = fechafin;
       }

       public IList<Gasto> Ejecutar()
       {

           GastoSQLServer acceso = new GastoSQLServer();
          _listagasto = acceso.ConsultarGastoFecha(_fechainicio,_fechafin);

           return _listagasto;
       }
    }
}

