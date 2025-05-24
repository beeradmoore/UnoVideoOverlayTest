namespace UnoVideoOverlayNativeTest;

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
