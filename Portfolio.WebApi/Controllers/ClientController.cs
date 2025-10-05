using Microsoft.AspNetCore.Mvc;
using Portfolio.EntityModels;
namespace Portfolio.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IClient _client;

    public ClientController(IClient client, ILogger<WeatherForecastController> logger)
    {
        _client = client;
        _logger = logger;
    }

    [HttpGet(Name = "GetClients")]
    public Task<IEnumerable<WpClient>> Get()
    {
        return _client.GetWpClientsAsync();
    }
}