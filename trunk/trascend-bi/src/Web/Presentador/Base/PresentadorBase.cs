using System.Resources;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace Presentador.Base
{
    public abstract class PresentadorBase
    {
        private ResourceManager _managerRecursos;

        protected PresentadorBase()
        {
            _managerRecursos = new ResourceManager("Presentador.RecursosPresentadores",
                                                    GetType().Assembly);

        }

        public ResourceManager ManagerRecursos
        {
            get { return _managerRecursos; }
        }

    }
}
