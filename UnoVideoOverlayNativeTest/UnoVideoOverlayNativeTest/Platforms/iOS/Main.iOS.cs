using UIKit;
using Uno.UI.Hosting;
using UnoVideoOverlayNativeTest;

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseAppleUIKit()
    .Build();

host.Run();