using AzureFunction_EFCore_Demo.DataContext;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly:FunctionsStartup(typeof(AzureFunction_EFCore_Demo.Startup))]
namespace AzureFunction_EFCore_Demo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionstring = Environment.GetEnvironmentVariable("ConnectionStrings");
            builder.Services.AddDbContext<ShareDataContext>(options => options.UseSqlServer(connectionstring));
        }
    }
}
