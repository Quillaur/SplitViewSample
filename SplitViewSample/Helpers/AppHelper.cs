using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SplitViewSample.Helpers
{
    /// <summary>
    /// Класс-помощник для работы с приложением.
    /// </summary>
    public class AppHelper
    {
        /// <summary>
        /// Статусная строка.
        /// </summary>
        private StatusBar status;

        public AppHelper()
        {
            SetColors();
        }

        /// <summary>
        /// Устанавливает цвета для заголовка окна и статусной строки.
        /// </summary>
        public void SetColors()
        {
            if (!ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                if (Application.Current.RequestedTheme == ApplicationTheme.Light)
                {
                    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                    titleBar.BackgroundColor = titleBar.ButtonBackgroundColor = titleBar.InactiveBackgroundColor = titleBar.ButtonInactiveBackgroundColor =
                        Color.FromArgb(255, 230, 230, 230);
                    titleBar.ButtonHoverForegroundColor = titleBar.ButtonPressedForegroundColor = Colors.Black;
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 207, 207, 207);
                    titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 184, 184, 184);
                }
                else
                {
                    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                    titleBar.BackgroundColor = titleBar.ButtonBackgroundColor = titleBar.InactiveBackgroundColor = titleBar.ButtonInactiveBackgroundColor =
                        Color.FromArgb(255, 31, 31, 31);
                    titleBar.ButtonHoverForegroundColor = titleBar.ButtonPressedForegroundColor = Colors.White;
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 53, 53, 53);
                    titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 76, 76, 76);
                }
            else if (Application.Current.RequestedTheme == ApplicationTheme.Light)
            {
                status = StatusBar.GetForCurrentView();
                status.BackgroundColor = Color.FromArgb(255, 230, 230, 230);
                status.ForegroundColor = Color.FromArgb(255, 102, 102, 102);
                status.BackgroundOpacity = 1;
            }
            else if (Application.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                status = StatusBar.GetForCurrentView();
                status.BackgroundColor = Color.FromArgb(255, 31, 31, 31);
                status.ForegroundColor = Color.FromArgb(255, 191, 191, 191);
                status.BackgroundOpacity = 1;
            }
        }
    }
}
