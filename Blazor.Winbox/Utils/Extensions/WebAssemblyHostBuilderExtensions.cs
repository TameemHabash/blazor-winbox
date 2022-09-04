using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Winbox;

public static class WebAssemblyHostBuilderExtensions
{
    public static IServiceCollection AddBlazorWinbox(this IServiceCollection services)
    {
        return services.AddScoped<IWindowManager, WinBoxWindowManager>();
    }
}
