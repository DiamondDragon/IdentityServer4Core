using System.Collections.Generic;
using Autofac;
using IntelliFlo.AppStartup;
using IntelliFlo.AppStartup.Initializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IdentityServer4PoC
{
    internal class Startup : MicroserviceStartup
    {
        public Startup(ILoggerFactory loggerFactory, IConfiguration configuration)
            : base(loggerFactory, configuration)
        {
        }

        protected override IEnumerable<IMicroserviceInitializer> CreateInitializers()
        {
            foreach (var initializer in base.CreateInitializers())
            {
                yield return initializer;
            }

            yield return new DatabaseInitializer(Configuration);
            yield return new NHibernateInitializer(Configuration);
            //yield return new EntityFrameworkInitializer<PlatformerDbContext>(Configuration);
            yield return new BusInitializer(Configuration);
            yield return new IdentityServerInitializer();
        }

        protected override IEnumerable<Module> CreateAutofacModules()
        {
            foreach (var module in base.CreateAutofacModules())
            {
                yield return module;
            }

            //yield return new BulkApiAutofacModule();
            //yield return new BulkAutofacModule();
            //yield return new BulkBusAutofacModule();
        }
    }
}
