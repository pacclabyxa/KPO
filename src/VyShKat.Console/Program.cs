using Microsoft.Extensions.DependencyInjection;
using VyShKat.Application;
using VyShKat.Presentation;

var services = new ServiceCollection();

services.AddSingleton<IInspectionService, ServiceCenter>();
services.AddSingleton<FleetService>();
services.AddSingleton<App>();

var provider = services.BuildServiceProvider();
provider.GetRequiredService<App>().Run();
