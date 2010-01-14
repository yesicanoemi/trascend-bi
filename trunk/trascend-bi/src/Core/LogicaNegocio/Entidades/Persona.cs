

namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Persona
    {
        private int cedula;

        private string nombre;

        private string apellido;

        public virtual int Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
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
