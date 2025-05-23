using Uno.UI.Hosting;
using UnoVideoOverlaySkiaTest;

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseWebAssembly()
    .Build();

await host.RunAsync();