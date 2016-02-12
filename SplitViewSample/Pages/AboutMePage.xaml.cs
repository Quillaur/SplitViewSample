using System;
using Windows.System;
using Windows.UI.Xaml;

namespace SplitViewSample.Pages
{
    /// <summary>
    /// Страница сведений обо мне.
    /// </summary>
    public sealed partial class AboutMePage : View
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public AboutMePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие нажатия на ссылку.
        /// </summary>
        /// <param name="sender">Отправитель (ссылка)</param>
        /// <param name="e">Данные.</param>
        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:publisher?name=Oleg%20Samoylov"));
        }
    }
}
