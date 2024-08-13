using System.Runtime.InteropServices.ComTypes;
using InvestmentPlatform.DBAcces;
using InvestmentPlatform.DBAcces.Class;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the DbContext
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add hosted services
builder.Services.AddHostedService<WaitForDb<Context>>();
builder.Services.AddScoped<IUserDbAcces, UserDbAcces>();
// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
