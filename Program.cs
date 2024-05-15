using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace hukukk;

public class Program
{
    public static string bcumle = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kayıt;Integrated Security=True";

    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(delegate (IWebHostBuilder webBuilder)
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
