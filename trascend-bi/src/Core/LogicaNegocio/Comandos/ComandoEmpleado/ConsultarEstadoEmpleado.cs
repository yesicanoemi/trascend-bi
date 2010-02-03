using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarEstadoEmpleado:Comando<EstadoEmpleado>
    {
            private EstadoEmpleado estadoempleado;
            private IList<EstadoEmpleado> listempleado;

            #region Constructor

            /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
            public ConsultarEstadoEmpleado()
            { }

            /// <summary>Constructor de la clase 'Ingresar'.</summary>
            /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
            public ConsultarEstadoEmpleado(EstadoEmpleado estadoempleados)
            {
                this.estadoempleado = estadoempleados;
            }

            #endregion

            #region Metodos
            public IList<EstadoEmpleado> Ejecutar()
            {
                listempleado = new List<EstadoEmpleado>(); 
                FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

                IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

                listempleado = acceso.ConsultarTodosEstadosEmpleado();

                return listempleado;


            }
            #endregion
        }

    }

