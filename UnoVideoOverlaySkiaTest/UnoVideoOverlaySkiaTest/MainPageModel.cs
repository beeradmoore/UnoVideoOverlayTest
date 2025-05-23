using System.Diagnostics;
using Windows.Media.Playback;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Uno.UI.Extensions;
using Timer = System.Timers.Timer;

namespace UnoVideoOverlaySkiaTest;

public partial class MainPageModel : ObservableObject
{
    private WeakReference<MainPage> _weakPage;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PlayPauseButtonGlyph))]
    [NotifyPropertyChangedFor(nameof(PlayPauseButtonText))]
    public partial bool IsPlaying { get; set; } = false;

    public string PlayPauseButtonGlyph => IsPlaying ? "&#xE768;" : "&#xE769;";
    public string PlayPauseButtonText => IsPlaying ? "Pause" : "Play";

    [ObservableProperty]
    public partial double Duration { get; set; }
    
    [ObservableProperty]
    public partial string PositionString { get; set; }
    
    [ObservableProperty]
    public partial double Position { get; set; }
    
    public MainPageModel(MainPage page)
    {
        _weakPage = new WeakReference<MainPage>(page);
        
        var mediaPlayerElement = page.GetMainMediaPlayerElement();
        
        /*
        var timer = new System.Timers.Timer(TimeSpan.FromSeconds(1.0 / 24.0));
        timer.Elapsed += (sender, e) =>
        {
            if (mediaPlayerElement.MediaPlayer is not null)
            {
                Position = mediaPlayerElement.MediaPlayer.Position.TotalSeconds;
                PositionString = mediaPlayerElement.MediaPlayer.Position.TotalSeconds.ToString("0.00");
            }
        };
        timer.Start();
        */
        mediaPlayerElement.Loaded += (_, _) =>
        {
            mediaPlayerElement.MediaPlayer.PlaybackSession.NaturalDurationChanged += (sender, args) =>
            {
                if (args is TimeSpan naturalDuration)
                {
                    Duration = naturalDuration.TotalSeconds;
                }
            };
            mediaPlayerElement.MediaPlayer.PlaybackSession.PositionChanged += (sender, args) =>
            {
                if (args is TimeSpan position)
                {
                    Position = position.TotalSeconds;
                    PositionString = position.TotalSeconds.ToString("0.00");
                }
            };
            
            
            mediaPlayerElement.MediaPlayer.BufferingEnded += (sender, args) =>
            {
                Console.WriteLine("BufferingEnded");
            };
            mediaPlayerElement.MediaPlayer.BufferingStarted += (sender, args) =>
            {
                Console.WriteLine("BufferingStarted");
            };
            mediaPlayerElement.MediaPlayer.CurrentStateChanged += (sender, args) =>
            {
                Console.WriteLine("CurrentStateChanged");
            };
            mediaPlayerElement.MediaPlayer.MediaEnded += (sender, args) =>
            {
                Console.WriteLine("MediaEnded");
            };
            mediaPlayerElement.MediaPlayer.MediaFailed += (sender, args) =>
            {
                Console.WriteLine("MediaFailed");
            };
            mediaPlayerElement.MediaPlayer.MediaOpened += (sender, args) =>
            {
                Console.WriteLine("MediaOpened");
            };
            mediaPlayerElement.MediaPlayer.MediaPlayerRateChanged += (sender, args) =>
            {
                Console.WriteLine("MediaPlayerRateChanged");
            };
            mediaPlayerElement.MediaPlayer.PlaybackMediaMarkerReached += (sender, args) =>
            {
                Console.WriteLine("PlaybackMediaMarkerReached");
            };
            mediaPlayerElement.MediaPlayer.SeekCompleted += (sender, args) =>
            {
                Console.WriteLine("SeekCompleted");
            };
            mediaPlayerElement.MediaPlayer.VolumeChanged += (sender, args) =>
            {
                Console.WriteLine("VolumeChanged");
            };
        };
    }

    [RelayCommand]
    public void PlayPause()
    {
        if (_weakPage.TryGetTarget(out var page))
        {
            var mediaPlayerElement = page.GetMainMediaPlayerElement();
            if (IsPlaying)
            {
                mediaPlayerElement.MediaPlayer.Pause();
                IsPlaying = false;
            }
            else
            {
                mediaPlayerElement.MediaPlayer.Play();
                IsPlaying = true;
            }
        }
    }
}

