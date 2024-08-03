using HttpRequest;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPlatform.Controllers;

[ApiController]
[Route("[controller]")]
public class TastytradeController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TastytradeController> _logger;

    public TastytradeController(ILogger<TastytradeController> logger)
    {
        _logger = logger;
    }

    [HttpGet,Route("login")]
    public async Task<string> Login()
    {
        Login login = new Login();
        string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
        string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
        string sessionToken= await login.GetSessionToken(username,password);
        return sessionToken;
    }
    
    [HttpDelete,Route("delete")]
    public async Task<string> DeleteSession([FromQuery]string sessionToken)
    {
        Login login = new Login();
        string response = login.DestroySession(sessionToken).ToString();
        return response;
    }
    
    [HttpGet,Route("getAccountDetails")]
    public async Task<string> LoginPost([FromQuery]string sessionToken)
    {
        Login login = new Login();
        string accountNumber = Environment.GetEnvironmentVariable("TASTYTRADE_ACCOUNT_NUMBER");
        string details = await login.GetDetails(sessionToken, accountNumber);
        return details;
    }
}