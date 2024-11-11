using CalculatorApp;
using CalculatorApp.Helpers;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = ConfigureServices();
var app = serviceProvider.GetService<CalculatorAppRunner>();
app?.Run();

ServiceProvider ConfigureServices()
{
    return new ServiceCollection()
        .AddSingleton<Parser>()
        .AddSingleton<Calculator>()
        .AddSingleton<CalculatorAppRunner>()
        .BuildServiceProvider();
}