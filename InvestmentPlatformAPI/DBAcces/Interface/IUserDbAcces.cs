namespace InvestmentPlatform.DBAcces;

public interface IUserDbAcces
{
    public Task register(string name, string password);
}