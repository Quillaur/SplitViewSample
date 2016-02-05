using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SplitViewSample.Pages
{
    /// <summary>
    /// Второстепенная страница.
    /// </summary>
    public sealed partial class AboutMePage : Page
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public AboutMePage()
        {
            InitializeComponent();
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:publisher?name=Oleg%20Samoylov"));
        }
    }
}
