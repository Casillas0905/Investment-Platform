// See https://aka.ms/new-console-template for more information


/*using HttpRequest;

Login login = new Login();
string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
string accuntNumber = Environment.GetEnvironmentVariable("TASTYTRADE_ACCOUNT_NUMBER");
string sessionToken= await login.GetSessionToken(username,password);
string details = await login.GetDetails(sessionToken, accuntNumber);
Console.WriteLine(details);
Console.WriteLine("Hello, World!"); */

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();