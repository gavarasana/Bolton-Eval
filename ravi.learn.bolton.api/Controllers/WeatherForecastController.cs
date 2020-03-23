using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BoltOn.Mediator.Pipeline;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ravi.learn.bolton.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastResponse>> GetAllAsync(CancellationToken token)
        {
            _logger.LogDebug("Retrieving data");
            return await _mediator.ProcessAsync(new WeatherForecastRequest(), token);
        }
    }
}
