using System;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace IdentityServer4PoC.ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DoDemoAsync().Wait();

        }

        private static async Task DoDemoAsync()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:8888");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }


            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
        }
    }
}
