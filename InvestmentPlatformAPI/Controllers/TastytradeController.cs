using HttpRequest;
using InvestmentPlatform.DBAcces;
using InvestmentPlatform.DBAcces.Class;
using InvestmentPlatform.Domain;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPlatform.Controllers;

[ApiController]
[Route("[controller]")]
public class TastytradeController : ControllerBase
{
    private readonly IUserDbAcces userDbAcces;

    private readonly ILogger<TastytradeController> _logger;

    public TastytradeController(IUserDbAcces userDbAcces, ILogger<TastytradeController> logger)
    {
        this.userDbAcces = userDbAcces;
        _logger = logger;
    }

    [HttpGet,Route("login")]
    public async Task<string> Login()
    {
        Login login = new Login();
        string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
        string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
        string sessionToken= await login.GetSessionToken(username,password);
        TastytradeSessionToken tastytradeSessionToken = new TastytradeSessionToken();
        tastytradeSessionToken.Token = sessionToken;
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
    
    [HttpPost,Route("buyStock")]
    public async Task<string> BuyStock(OrderModel orderModel,string sessiontoken, string accountNumber)
    {
        Orders orders = new Orders();
        string response = await orders.BuyStock(orderModel, sessiontoken,  accountNumber);
        return response;
    }
}