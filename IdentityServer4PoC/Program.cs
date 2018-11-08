using IntelliFlo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace IdentityServer4PoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            if (MicroserviceHost.ShouldRunAsService(args))
                host.RunAsService();
            else
                host.Run();
        }

        /// <summary>
        /// It's important to have this methods defined as follows in order to prevent issues with EF
        /// migrations https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
        /// </summary>
        public static IWebHost BuildWebHost(string[] args) => MicroserviceHost
            .Build<Startup>(args);
    }
}
