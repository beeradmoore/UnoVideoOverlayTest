namespace UnoVideoOverlayNativeTest;

public sealed partial class MainPage : Page
{
    public MainPageModel ViewModel { get; init; }

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
