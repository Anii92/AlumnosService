using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;

namespace Vueling.Autofac.Configuration
{
    public class AlumnoBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AlumnoBusiness>()
                .As<IAlumnoBusiness>();

            base.Load(builder);
        }
    }
}
