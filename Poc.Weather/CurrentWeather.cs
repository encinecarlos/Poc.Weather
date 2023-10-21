using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Poc.Weather.Domain.Entities;
using Poc.Weather.Infrastructure.Services;

namespace Poc.Weather
{
    public class CurrentWeather
    {
        private readonly HttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public CurrentWeather(HttpClientService http, IConfiguration configuration)
        {
            _httpClientService = http;
            _configuration = configuration;
        }
        [FunctionName("CurrentWeather")]
        public async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var url = $"{_configuration.GetSection("baseUrl").Value}?q={_configuration.GetSection("location").Value}&key={_configuration.GetSection("apiKey").Value}";
            var result = await _httpClientService.Get<WeatherReponse>(url);
            var response = new StringBuilder();
            
            response.AppendLine("Current Weather");
            response.AppendLine($"location {result.Location.name}");
            response.AppendLine($"temperature: {result.Current.temp_c}");
            response.AppendLine($"condittion: {result.Current.condition.text}");
            
            log.LogInformation($"{response.ToString()}");
        }
    }
}
