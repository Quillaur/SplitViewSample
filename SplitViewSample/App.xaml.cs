using SplitViewSample.Pages;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SplitViewSample
{
    /// <summary>
    /// Корневой класс приложения.
    /// </summary>
    sealed partial class App : Application
    {
        private StatusBar status;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запуск приложения.
        /// </summary>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            AppShell shell = Window.Current.Content as AppShell;
            // Инициализация AppShell.
            shell = new AppShell();
            // AppShell становится текущим содержимым окна.
            Window.Current.Content = shell;
            // Определяет цветовую гамму заголовка окна или статусной панели.
            if (!ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                if (Current.RequestedTheme == ApplicationTheme.Light)
                {
                    var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                    titleBar.BackgroundColor = titleBar.ButtonBackgroundColor = titleBar.InactiveBackgroundColor = titleBar.ButtonInactiveBackgroundColor =
                        Color.FromArgb(255, 242, 242, 242);
                    titleBar.ButtonHoverForegroundColor = titleBar.ButtonPressedForegroundColor = Colors.Black;
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 230, 230, 230);
                    titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 204, 204, 204);
                }
                else
                {
                    var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                    titleBar.BackgroundColor = titleBar.ButtonBackgroundColor = titleBar.InactiveBackgroundColor = titleBar.ButtonInactiveBackgroundColor =
                        Colors.Black;
                    titleBar.ButtonHoverForegroundColor = titleBar.ButtonPressedForegroundColor = Colors.White;
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 25, 25, 25);
                    titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 51, 51, 51);
                }
            else if (Current.RequestedTheme == ApplicationTheme.Light)
            {
                status = StatusBar.GetForCurrentView();
                status.BackgroundColor = Color.FromArgb(255, 242, 242, 242);
                status.ForegroundColor = Color.FromArgb(255, 102, 102, 102);
                status.BackgroundOpacity = 1;
            }
            else if (Current.RequestedTheme == ApplicationTheme.Dark)
            {
                status = StatusBar.GetForCurrentView();
                status.BackgroundColor = Colors.Black;
                status.BackgroundOpacity = 1;
            }
            // Выполняет навигацию к домашней странице.
            shell.AppFrame.Navigate(typeof(HomePage));
            // Активация Window.
            Window.Current.Activate();
        }
    }
}
