using Algebra.WebShop.Extensions;

namespace Algebra.WebShop;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureServices(builder.Configuration);
               
        var app = builder.Build();

        app.Configure();

        app.Run();
    }
}