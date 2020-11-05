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
	public static class EstabelecimentoEndpoints
	{
        public const string API_URL_PREFIX = Program.URL_API;

        public static async Task Listar(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync($"{API_URL_PREFIX}/Estabelecimento/listar");
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

            var body = new Estabelecimento()
            {
                Nome = "Loja do centro",
                CNPJ = "123",
                Endereco = "Rua das couves",
                Telefone = "12345",
                QtVagasMotos = 10,
                QtVagasCarros = 20
            };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync($"{API_URL_PREFIX}/Estabelecimento/cadastrar", data);
            Console.WriteLine(response.StatusCode);
        }

        public static async Task Editar(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var body = new Estabelecimento()
            {
                ID  = 1,
                Nome = "Loja do centro - edit",
                CNPJ = "1234",
                Endereco = "Rua das couves2",
                Telefone = "123456",
                QtVagasMotos = 11,
                QtVagasCarros = 21
            };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync($"{API_URL_PREFIX}/Estabelecimento/editar", data);
            Console.WriteLine(response.StatusCode);
        }

        public static async Task Remover(TokenResponse tokenResponse)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var idEstabelecimento = 1;

            var response = await apiClient.DeleteAsync($"{API_URL_PREFIX}/Estabelecimento/cadastrar?id={idEstabelecimento}");
            Console.WriteLine(response.StatusCode);
        }
    }
}
