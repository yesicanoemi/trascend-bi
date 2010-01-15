using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Entidades
{
    public class Factura
    {
        private int numero;
        private string titulo;
        private string descripcion;
        private float porcentajepagado;
        private DateTime fechapago;
        private DateTime fechaingreso;
        private string estado;
        private Propuesta propuesta;


        public virtual Propuesta Prop
        {
            get
            {
                return propuesta;
            }

            set
            {
                propuesta = value;
            }
        }

        public virtual int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }


        public virtual string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
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


        public virtual float Procentajepagado
        {
            get
            {
                return porcentajepagado;
            }

            set
            {
                porcentajepagado = value;
            }
        }


        public virtual DateTime Fechapago
        {
            get
            {
                return fechapago;
            }

            set
            {
                fechapago = value;
            }
        }



        public virtual DateTime Fechaingreso
        {
            get
            {
                return fechaingreso;
            }

            set
            {
                fechaingreso = value;
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
    }
}
