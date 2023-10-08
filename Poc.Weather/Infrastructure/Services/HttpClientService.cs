using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Poc.Weather.Infrastructure.Services
{
    public class HttpClientService
    {
        public IHttpClientFactory ClientFactory { get; set; }

        public HttpClientService(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async Task<T> Get<T>(string url)
        {
            var client = await ClientFactory.CreateClient().GetAsync(url);
            return await client.Content.ReadAsAsync<T>();
        }
    }
}
