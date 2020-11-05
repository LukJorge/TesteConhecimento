using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TesteFCamara.Client.Endpoints;

namespace TesteFCamara.Client
{
    public class Program
    {
        public const string URL_API = "https://localhost:6001";

        private static async Task Main()
        {
            var client = new HttpClient();

            var identityDiscovery = await client.GetDiscoveryDocumentAsync(URL_API);
            if (identityDiscovery.IsError)
            {
                Console.WriteLine(identityDiscovery.Error);
                return;
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = identityDiscovery.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "TestFCamara"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);

            await EstabelecimentoEndpoints.Editar(tokenResponse);
        }
    }
}
