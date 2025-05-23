using UIKit;
using Uno.UI.Hosting;
using UnoVideoOverlaySkiaTest;

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseAppleUIKit()
    .Build();

host.Run();