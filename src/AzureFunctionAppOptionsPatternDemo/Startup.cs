using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

[assembly: FunctionsStartup(typeof(AzureFunctionAppOptionsPatternDemo.Startup))]
namespace AzureFunctionAppOptionsPatternDemo
{
    public class Startup : FunctionsStartup
    {

        public override void ConfigureAppConfiguration(
            IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);
            var context = builder.GetContext();
            builder.ConfigurationBuilder
                .AddEnvironmentVariables()
                .AddJsonFile(
                    Path.Combine(
                            context.ApplicationRootPath,
                            "appsettings.json"),
                    optional: false,
                    reloadOnChange: false)
                .AddJsonFile(
                    Path.Combine(
                            context.ApplicationRootPath,
                            "local.settings.json"),
                    optional: true,
                    reloadOnChange: false);
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddSingleton<IMyService>((serviceProvider) =>
                {
                    var options = serviceProvider.GetRequiredService<IOptions<AppSettings>>();
                    return new MyStringService()
                    {
                        Value = options.Value.MySettings.StringValue
                    };
                })
                .AddOptions<AppSettings>()
                .Configure<IConfiguration>(
                    (settings, config) => config.Bind(settings));
        }

    }
}
