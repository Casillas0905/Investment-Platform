using Newtonsoft.Json;

namespace InvestmentPlatform.Domain;

public class OrderModel
{
    [JsonProperty("order-type")]
    public string OrderType { get; set; }

    [JsonProperty("price")]
    public int Price { get; set; }

    [JsonProperty("price-effect")]
    public string PriceEffect { get; set; }

    [JsonProperty("time-in-force")]
    public string TimeInForce { get; set; }

    [JsonProperty("legs")]
    public Leg[] Legs { get; set; }

    public OrderModel(string orderType, int price, string priceEffect, string timeInForce, Leg[] legs)
    {
        OrderType = orderType;
        Price = price;
        PriceEffect = priceEffect;
        TimeInForce = timeInForce;
        Legs = legs;
    }
}