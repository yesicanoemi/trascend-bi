namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;
    
    
    public class Usuario : Empleado
    {

        private int idUsuario;
        
        private string login;
        
        private string password;

        private string status;

        public virtual int IdUsuario
        {
            get
            {
                return this.idUsuario;
            }
            set
            {
                this.idUsuario = value;
            }
        }
        
        public virtual string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }
        
        public virtual string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public virtual string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
    }
}
