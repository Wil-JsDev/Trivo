using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trivo.Application.Interfaces.Services;
using Trivo.Domain.Configurations;
using Trivo.Infrastructure.Shared.Services;

namespace Trivo.Infrastructure.Shared;

public static class DependencyInjection
{
    public static void AddInfrastructureShared(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        services.AddConfiguration(configuration);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
    }

    private static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
        services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySetting"));
    }
}