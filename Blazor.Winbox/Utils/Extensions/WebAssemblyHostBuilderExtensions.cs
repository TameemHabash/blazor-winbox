using Microsoft.Extensions.DependencyInjection;

namespace BlazorWinbox;

public static class WebAssemblyHostBuilderExtensions
{
    public static IServiceCollection AddBlazorWinbox(this IServiceCollection services)
    {
        return services.AddScoped<IWindowManager, WinBoxWindowManager>();
    }
}
