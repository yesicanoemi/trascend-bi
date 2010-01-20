using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Entidades
{
    public class Propuesta
    {
        private string titulo;
        private string version;
        private DateTime fechaFirma;
        private string nombreReceptor;
        private string apellidoReceptor;
        private string cargoReceptor;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private IList<Empleado> equipoTrabajo;
        private int totalHoras;
        private float montoTotal;
        private int ID;
        private string Nombreequipo1;
        private string Nombreequipo2;
        private string Nombreequipo3;
        private string Apellidoequipo1;
        private string Apellidoequipo2;
        private string Apellidoequipo3;
        private string rol1;
        private string rol2;
        private string rol3;
        private string equipo;

        public virtual string Equipo
        {
            get
            {
                return equipo;
            }
            set
            {
                equipo = value;
            }
        }
        
        public virtual int Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
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

        public virtual string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        public virtual DateTime FechaFirma
        {
            get
            {
                return fechaFirma;
            }
            set
            {
                fechaFirma = value;
            }
        }

        public virtual string NombreReceptor
        {
            get
            {
                return nombreReceptor;
            }
            set
            {
                nombreReceptor = value;
            }
        }

        public virtual string ApellidoReceptor
        {
            get
            {
                return apellidoReceptor;
            }
            set
            {
                apellidoReceptor = value;
            }
        }

        public virtual string CargoReceptor
        {
            get
            {
                return cargoReceptor;
            }
            set
            {
                cargoReceptor = value;
            }
        }

        public virtual DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }
            set
            {
                fechaInicio = value;
            }
        }

        public virtual DateTime FechaFin
        {
            get
            {
                return fechaFin;
            }
            set
            {
                fechaFin = value;
            }
        }

        public virtual IList<Empleado> EquipoTrabajo
        {
            get
            {
                return equipoTrabajo;
            }
            set
            {
                equipoTrabajo = value;
            }
        }

        public virtual int TotalHoras
        {
            get
            {
                return totalHoras;
            }
            set
            {
                totalHoras = value;
            }
        }

        public virtual float MontoTotal
        {
            get
            {
                return montoTotal;
            }
            set
            {
                montoTotal = value;
            }
        }

       

      

    

      


      

        public virtual string Rol1
        {
            get
            {
                return rol1;
            }
            set
            {
                rol1 = value;
            }
        }


      

    }
}
