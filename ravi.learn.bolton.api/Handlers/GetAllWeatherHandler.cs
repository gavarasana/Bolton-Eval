using BoltOn.Mediator.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ravi.learn.bolton.api.Handlers
{
    public class GetAllWeatherHandler : IHandler<WeatherForecastRequest, IEnumerable<WeatherForecastResponse>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private ILogger<GetAllWeatherHandler> _logger;
        public GetAllWeatherHandler(ILogger<GetAllWeatherHandler> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<WeatherForecastResponse>> HandleAsync(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("In HandleAsync");
            if (cancellationToken.IsCancellationRequested)
            {
                await Task.FromResult(new List<WeatherForecastResponse>());
            }

            var rng = new Random();
            return await Task.FromResult(
             Enumerable.Range(1, 5).Select(index => new WeatherForecastResponse
             {
                 Date = DateTime.Now.AddDays(index),
                 TemperatureC = rng.Next(-20, 55),
                 Summary = Summaries[rng.Next(Summaries.Length)]
             }));            
        }
    }
}
