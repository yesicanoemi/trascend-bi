﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Entidades
{
    public class Cargo
    {
        private String nombre;
        private String descripcion;
        private float sueldo_minimo;
        private float sueldo_maximo;
        private DateTime vigencia;

        public virtual String Nombre
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
        public virtual String Descripcion
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
        public virtual float SueldoMinimo
        {
            get
            {
                return sueldo_minimo;
            }
            set
            {
                sueldo_minimo = value;
            }
        }
        public virtual float SueldoMaximo
        {
            get
            {
                return sueldo_maximo;
            }
            set
            {
                sueldo_maximo = value;
            }
        }
        public virtual DateTime Vigencia
        {
            get
            {
                return vigencia;
            }
            set
            {
                vigencia = value;
            }
        }
    }
}