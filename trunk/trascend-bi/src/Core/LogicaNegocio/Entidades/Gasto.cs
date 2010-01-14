namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Gasto
    {
        private int codigo;
        private int estado;
        private float monto;
        private DateTime fechaGasto;
        private DateTime fechaIngreso;
        private string tipo;
        private string descripcion;

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public virtual int Estado
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

        public virtual float Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public virtual DateTime FechaGasto
        {
            get
            {
                return fechaGasto;
            }

            set
            {
                fechaGasto = value;
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

        public virtual string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public virtual string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

    }
}
