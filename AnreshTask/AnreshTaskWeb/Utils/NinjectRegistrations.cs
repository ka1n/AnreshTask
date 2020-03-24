using DataAccess.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnreshTaskWeb.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonRepository>().To<PersonRepository>();
            Unbind<ModelValidatorProvider>();
        }
    }
}