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
	public static class VeiculoEndpoints
	{
        public const string API_URL_PREFIX = Program.URL_API;

        public static async Task Listar(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync($"{API_URL_PREFIX}/Veiculo/listar");
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

        public static async Task Cadastrar(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var body = new Veiculo()
            {
                Marca = "honda",
                Modelo = "civic",
                Cor = "preto",
                Placa = "12345",
                Tipo = "Carro",
            };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync($"{API_URL_PREFIX}/Veiculo/cadastrar", data);
            Console.WriteLine(response.StatusCode);
        }

        public static async Task Editar(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var body = new Veiculo()
            {
                ID = 1,
                Marca = "honda",
                Modelo = "civic",
                Cor = "preto",
                Placa = "12345",
                Tipo = "Carro",
            };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync($"{API_URL_PREFIX}/Veiculo/editar", data);
            Console.WriteLine(response.StatusCode);
        }

        public static async Task Remover(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var idVeiculo = 1;

            var response = await apiClient.DeleteAsync($"{API_URL_PREFIX}/Veiculo/remover?id={idVeiculo}");
            Console.WriteLine(response.StatusCode);
        }

    }
}
