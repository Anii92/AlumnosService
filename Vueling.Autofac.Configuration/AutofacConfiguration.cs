using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;

namespace Vueling.Autofac.Configuration
{
    public class AutofacConfiguration
    {
        public static IContainer Build(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(assembly);

            builder.RegisterModule(new AlumnoDaoModule());
            builder.RegisterModule(new AlumnoBusinessModule());

            return builder.Build();
        }
    }
}
