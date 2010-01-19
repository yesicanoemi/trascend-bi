using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Entidades
{
    public class Cargo : Entidad
    {
        #region Atributos
        private int id;
        private String nombre;
        private String descripcion;
        private float sueldo_minimo;
        private float sueldo_maximo;
        private DateTime vigencia;
        private float sueldo_minimo_inf;
        private float sueldo_maximo_inf;
        #endregion

        #region Encapsulamiento
        public virtual int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

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

        public virtual float SueldoMaximoConInflacion
        {
            get
            {
                return sueldo_maximo_inf;
            }
            set
            {
                sueldo_maximo_inf = value;
            }
        }

        public virtual float SueldoMinimoConInflacion
        {
            get
            {
                return sueldo_minimo_inf;
            }
            set
            {
                sueldo_minimo_inf = value;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que calcula el sueldo minimo por inflacion
        /// </summary>
        /// <param name="inflacion">la inflacion</param>
        /// <returns>sueldo minimo con inflacion</returns>
        public float getSueldoMinimoConInflacion(float inflacion)
        {
            return sueldo_minimo * (1 + inflacion);
        }

        /// <summary>
        /// Metodo que calcula el sueldo maximo por inflacion
        /// </summary>
        /// <param name="inflacion">la inflacion</param>
        /// <returns>sueldo maximo con inflacion</returns>
        public float getSueldoMaximoConInflacion(float inflacion)
        {
            return sueldo_maximo * (1 + inflacion);
        }
        #endregion

    }
}
