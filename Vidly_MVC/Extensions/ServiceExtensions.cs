using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Vidly_MVC.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureJsonOptions(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.IncludeFields = true;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }

    public static void ConfigureCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }
}