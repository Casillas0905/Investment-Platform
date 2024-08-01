// See https://aka.ms/new-console-template for more information


using HttpRequest;

Login login = new Login();
/*string username="ikersanmartinbarreiro@gmail.com";
string password = "Josejudit0905";*/
string username = Environment.GetEnvironmentVariable("TASTYTRADE_USERNAME");
string password = Environment.GetEnvironmentVariable("TASTYTRADE_PASSWORD");
string result= await login.GetSessionToken(username,password);
Console.WriteLine(result);
Console.WriteLine("Hello, World!"); 