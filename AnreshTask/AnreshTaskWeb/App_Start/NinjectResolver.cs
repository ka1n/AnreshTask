using DataAdapter.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnreshTaskWeb.App_Start
{
    public class NinjectResolver
    {

        private readonly IKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this._kernel.Bind<IPersonRepository>().To<PersonRepository>(); // Registering Types   
        }
    }
}