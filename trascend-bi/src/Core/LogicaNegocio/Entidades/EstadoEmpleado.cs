namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    class EstadoEmpleado
    {
        private int idEstadoEmpleado;
        private string   nombre;

        public virtual int IdEstadoEmpleado
        {
            get { return idEstadoEmpleado; }
            set { idEstadoEmpleado = value; }
        }

        public virtual string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
