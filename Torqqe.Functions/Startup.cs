using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Torqqe.Data;
using Torqqe.Functions;
using Torqqe.Functions.Helper;
using Torqqe.ShopmonkeyApi;

[assembly: WebJobsStartup(typeof(Startup))]
namespace Torqqe.Functions
{
    class Startup : IWebJobsStartup
    {
        public IConfiguration Configuration { get; }
        public void Configure(IWebJobsBuilder builder)
        {
            var cnnStr = Configuration.GetConnectionString("AzureDB");
            string connection = Environment.GetEnvironmentVariable("ConnectionStrings", EnvironmentVariableTarget.Process);

            var publicKey = Environment.GetEnvironmentVariable("Shopmonkey_PublicKey");
            var privateKey = Environment.GetEnvironmentVariable("Shopmonkey_PrivateKey");
            // Configure services
            builder.Services.AddOptions();
            builder.Services.AddScoped<ShopmonkeyClient>(x => new ShopmonkeyClient("https://api.shopmonkey.io/v1", publicKey, privateKey));
            builder.Services.AddDbContext<TorqqeContext>(options => options.UseSqlServer(connection));
            builder.Services.AddScoped<DbContext, TorqqeContext>();
            builder.Services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
