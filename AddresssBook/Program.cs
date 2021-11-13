using AddresssBook.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AddresssBook
{
    public static class Program
    {
        public static async void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var dbConnext = host.Services
                                .CreateScope()
                                .ServiceProvider
                                .GetRequiredService<AddressBookContext>();

            await dbConnext.Database.MigrateAsync();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
