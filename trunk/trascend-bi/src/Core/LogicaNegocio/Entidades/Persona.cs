

namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Persona
    {
       
        private string nombre;

        private string apellido;

        private IList<Empleado> Empleados;

        public virtual IList<Empleado> Empleado
        {
            get
            {
                return Empleados;
            }
            set
            {
                Empleados = value;
            }
        }

        public virtual string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public virtual string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }
    }
}
