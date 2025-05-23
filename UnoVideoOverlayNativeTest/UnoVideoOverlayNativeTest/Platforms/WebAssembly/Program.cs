using Uno.UI.Hosting;
using UnoVideoOverlayNativeTest;

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseWebAssembly()
    .Build();

await host.RunAsync();