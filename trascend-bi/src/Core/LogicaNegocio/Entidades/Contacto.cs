using System;
using System.Collections.Generic;

namespace Core.LogicaNegocio.Entidades
{
    public class Contacto : Persona
    {
        #region Propiedades

        private int _id;
        
        private int cedula;
        
        private string cargo;
        
        private string areaDeNegocio;
        
        private TelefonoCelular _telefonoCelular;
        
        private TelefonoTrabajo _telefonoTrabajo;

        private TelefonoFax _telefonoFax;
        
        private Cliente _cliente;


        public Contacto()
        {
            _telefonoCelular = new TelefonoCelular();
            
            _telefonoTrabajo = new TelefonoTrabajo();

            _telefonoFax = new TelefonoFax();
        }

        public virtual int IdContacto
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

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

        public virtual string AreaDeNegocio
        {
            get
            {
                return areaDeNegocio;
            }

            set
            {
                areaDeNegocio = value;
            }
        }

        public virtual TelefonoTrabajo TelefonoDeTrabajo
        {
            get { return _telefonoTrabajo; }
            
            set { _telefonoTrabajo = value; }
        }

        public virtual TelefonoCelular TelefonoDeCelular
        {
            get { return _telefonoCelular; }
            
            set { _telefonoCelular = value; }
        }

        public virtual TelefonoFax TelefonoDeFax
        {
            get { return _telefonoFax; }

            set { _telefonoFax = value; }
        }

        public virtual Cliente ClienteContac
        {
            get
            {
                return _cliente;
            }

            set
            {
                _cliente = value;
            }
        }

        #endregion  

    }
}