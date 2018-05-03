using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAccess.Dao.Daos;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.Autofac.Configuration
{
    public class CommonBuilder : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType(typeof(AlumnoDao))
                .As(typeof(IRead))
                .As(typeof(IDelete))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
