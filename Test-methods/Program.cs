// See https://aka.ms/new-console-template for more information


using HttpRequest;

Login login = new Login();
/*string username="ikersanmartinbarreiro@gmail.com";
string password = "Josejudit0905";*/
string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
string accuntNumber = Environment.GetEnvironmentVariable("TASTYTRADE_ACCOUNT_NUMBER");
string sessionToken= await login.GetSessionToken(username,password);
string details = await login.GetDetails(sessionToken, accuntNumber);
Console.WriteLine(details);
Console.WriteLine("Hello, World!"); 