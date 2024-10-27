using Delivery.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Delivery.Core;

internal class ViewModelLocator
{
    private static ServiceProvider _provider;

    public static void Init()
    {
        var services = new ServiceCollection();

        services.AddScoped<MainViewModel>();
        services.AddScoped<SortOrderVM>();
        services.AddScoped<SortOrderResultVM>();


        services.AddSingleton<NavigateService>();
        services.AddSingleton<DatabaseController>();
        services.AddSingleton<CommandController>();
        services.AddSingleton<LogWriter>();

        _provider = services.BuildServiceProvider();

        foreach (var item in services)
            _provider.GetRequiredService(item.ServiceType);
    }

    public SortOrderResultVM SortOrderResultVM => _provider.GetRequiredService<SortOrderResultVM>();
    public SortOrderVM SortOrderVM => _provider.GetRequiredService<SortOrderVM>();
    public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
}
