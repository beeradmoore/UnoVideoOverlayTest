using System.Diagnostics;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

namespace UnoVideoOverlaySkiaTest;

public sealed partial class MainPage : Page
{
    public MainPageModel ViewModel { get; private set; }

    public MainPage()
    {
        this.InitializeComponent();
        ViewModel = new MainPageModel(this);
        DataContext = ViewModel;
    }
    
    public MediaPlayerElement GetMainMediaPlayerElement()
    {
        return MainMediaPlayerElement;
    }
}
