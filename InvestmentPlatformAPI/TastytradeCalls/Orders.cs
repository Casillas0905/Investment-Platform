using System.Text;
using InvestmentPlatform.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpRequest;

public class Orders
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly TastytradeSessionToken _tastytradeSessionToken = new TastytradeSessionToken();
    private static readonly User _user = new User();
    
    public async Task<string> BuyStock(OrderModel orderModel, string sessiontoken, string accountNumber)
    {
        // Set Authorization header directly with the session token
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Add("Authorization", sessiontoken);

        var content = new StringContent(JsonConvert.SerializeObject(orderModel), Encoding.UTF8, "application/json");
        var accountsResponse = await client.PostAsync($"https://api.cert.tastyworks.com/accounts/{accountNumber}/orders", content);

        if (!accountsResponse.IsSuccessStatusCode)
        {
            var errorMessage = await accountsResponse.Content.ReadAsStringAsync();
            throw new Exception($"Failed to buy stock: {errorMessage}");
        }
        var response = await accountsResponse.Content.ReadAsStringAsync();
        return response;
    }



}