using HttpRequest;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPlatform.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Login")]
    public async Task<string> Login()
    {
        Login login = new Login();
        string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
        string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
        string sessionToken= await login.GetSessionToken(username,password);
        return sessionToken;
    }
    
    [HttpPost(Name = "DeleteSession")]
    public async Task<Task<HttpResponseMessage>> DeleteSession([FromQuery]string sessionToken)
    {
        Login login = new Login();
        Task<HttpResponseMessage> response = login.DestroySession(sessionToken);
        return response;
    }
}