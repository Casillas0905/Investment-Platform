// See https://aka.ms/new-console-template for more information


using HttpRequest;

Login login = new Login();
string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
Task<string> token = login.GetSessionToken(username, password);
Console.WriteLine(token);
Console.WriteLine("Hello, World!");