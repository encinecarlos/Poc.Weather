namespace Poc.Weather.Domain.Entities
{
    internal class WeatherReponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }
}