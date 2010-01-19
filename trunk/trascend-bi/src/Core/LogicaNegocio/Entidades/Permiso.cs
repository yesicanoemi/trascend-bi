using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Entidades
{
    public class Permiso
    {

        private int idPermiso;

        private string permiso;

        public virtual int IdPermiso
        {
            get
            {
                return this.idPermiso;
            }
            set
            {
                this.idPermiso = value;
            }
        }

        public virtual string Permisos
        {
            get
            {
                return this.permiso;
            }
            set
            {
                this.permiso = value;
            }
        }
    }
}
