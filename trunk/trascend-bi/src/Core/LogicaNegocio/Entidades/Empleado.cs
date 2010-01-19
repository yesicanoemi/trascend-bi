

namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Empleado : Persona
    {
        private int cedula;
        private string cuenta;
        private float sueldoBase;
        private DateTime fechaNacimiento;
        private DateTime fechaIngreso;
        private DateTime fechaEgreso;
        private string estado;
        private Direccion direccion;
        private string cargo;

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
        public virtual string Cuenta
        {
            get
            {
                return cuenta;
            }

            set
            {
                cuenta = value;
            }
        }

        public virtual float SueldoBase
        {
            get
            {
                return sueldoBase;
            }

            set
            {
                sueldoBase = value;
            }
        }

        public virtual DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public virtual DateTime FechaIngreso
        {
            get
            {
                return fechaIngreso;
            }

            set
            {
                fechaIngreso = value;
            }
        }

        public virtual DateTime FechaEgreso
        {
            get
            {
                return fechaEgreso;
            }

            set
            {
                fechaEgreso = value;
            }
        }

        public virtual string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public virtual Direccion Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public virtual string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }
    }
}
