using System.Collections.Generic;
using System.Linq;
using Autofac;
using IdentityServer4.Models;
using IntelliFlo.AppStartup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4PoC
{
    public class IdentityServerInitializer : IMicroserviceInitializer
    {
        public IEnumerable<Module> Modules => Enumerable.Empty<Module>();

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            app.UseIdentityServer();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Enumerable.Empty<ApiResource>())
                .AddInMemoryClients(Enumerable.Empty<Client>());
        }
    }
}
