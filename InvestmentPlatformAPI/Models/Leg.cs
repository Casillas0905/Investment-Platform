using Newtonsoft.Json;

namespace InvestmentPlatform.Domain;

public class Leg
{
    [JsonProperty("instrument-type")]
    public string InstrumentType { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("action")]
    public string Action { get; set; }

    public Leg(string instrumentType, string symbol, int quantity, string action)
    {
        InstrumentType = instrumentType;
        Symbol = symbol;
        Quantity = quantity;
        Action = action;
    }
}