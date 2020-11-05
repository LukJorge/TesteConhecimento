using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TesteFCamara.Client.Model;

namespace TesteFCamara.Client.Endpoints
{
	public static class ControleDeVeiculosEndpoints
	{

        public const string API_URL_PREFIX = Program.URL_API;

        public static async Task BuscarVeiculo(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var idVeiculo = 1;

            var response = await apiClient.GetAsync($"{API_URL_PREFIX}/ControleDeVeiculos/buscarVeiculo?id={idVeiculo}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }

        public static async Task Entrada(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var body = new ControleDeVeiculo()
            {
                Veiculo = 1,
                Estabelecimento = 1,
                DataEntrada = DateTime.Now
        };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync($"{API_URL_PREFIX}/ControleDeVeiculos/entrada", data);
            Console.WriteLine(response.StatusCode);
        }

        public static async Task Saida(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var body = new ControleDeVeiculo()
            {
                ID = 1,
                Veiculo = new Veiculo() {ID = 1 },
                Estabelecimento = new Estabelecimento() { ID = 1 },
                DataSaida = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync($"{API_URL_PREFIX}/ControleDeVeiculos/saida", data);
            Console.WriteLine(response.StatusCode);
        }
    }
}
