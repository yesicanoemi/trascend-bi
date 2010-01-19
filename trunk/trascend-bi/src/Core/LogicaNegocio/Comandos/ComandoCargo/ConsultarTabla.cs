using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class ConsultarTabla : Comando<Cargo>
    {
        public ConsultarTabla()
        { 
        }

        public List<Cargo> Ejecutar()
        {
            CargoSQLServer bd = new CargoSQLServer();
            List<Cargo> ListaCargos = new List<Cargo>();
            IList<Entidad> ListaEntidades = bd.ConsultarCargos();
            
            for (int i = 0; i < ListaEntidades.Count; i++)
            {
                ListaCargos.Add((Cargo)ListaEntidades[i]);
            }
            return ListaCargos;
        }
    }
}
