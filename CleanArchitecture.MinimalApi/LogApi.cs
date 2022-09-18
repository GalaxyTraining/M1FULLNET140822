using CleanArchitecture.Domain.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CleanArchitecture.MinimalApi
{
    public class LogApi
    {
        protected readonly IConfiguration _configuration;
        public LogApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async void GuardarLog(string mensaje, Error error)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["LOGGER_URL_BASE"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            error.Mensaje = $"Error al procesar transaccion o consulta:  {mensaje}";
            var json = JsonConvert.SerializeObject(error);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("Logs/ObtenerError", stringContent);
        }
    }
}
