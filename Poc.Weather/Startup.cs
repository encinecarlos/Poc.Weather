using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Poc.Weather.Infrastructure.Services;

[assembly: FunctionsStartup(typeof(Poc.Weather.Startup))]

namespace Poc.Weather
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<HttpClientService>();
        }
    }
}
