using InvestmentPlatform.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InvestmentPlatform.DBAcces.Class;

public class UserDbAcces : IUserDbAcces
{
    private readonly Context context;

    public UserDbAcces(Context context)
    {
        this.context = context;
    }

    public async Task register(string name, string password)
    {
        User user = new User();
        user.Id = 2;
        user.AppName = name;
        user.AppPassword = password;
        EntityEntry<User> added = await context.User.AddAsync(user);
        await context.SaveChangesAsync();
    }
}