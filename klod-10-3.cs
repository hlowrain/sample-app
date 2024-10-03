using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        Application.Current.Resuming += Current_Resuming;
    }

    private async void Current_Resuming(object sender, object e)
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            // Force activation of the window
            CoreWindow.GetForCurrentThread().Activate();

            // Trigger a small layout change to refresh the UI
            var margin = this.Margin;
            this.Margin = new Thickness(margin.Left + 1, margin.Top, margin.Right, margin.Bottom);
            this.Margin = margin;  // Set it back to the original value
        });
    }
}
