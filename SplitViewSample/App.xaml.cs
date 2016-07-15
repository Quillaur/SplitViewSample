using SplitViewSample.Helpers;
using SplitViewSample.View;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SplitViewSample
{
    /// <summary>
    /// Корневой класс приложения.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Конструктор приложения.
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Срабатывает при прямом запуске приложения.
        /// </summary>
        /// <param name="e">Передаваемые данные.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
                rootFrame.Navigate(typeof(ShellView));

                Locator.NavigationHelper.CurrentFrame.Navigated += OnNavigated;

                SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

                if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                    HardwareButtons.BackPressed += OnBackPressed;

                UpdateBackButtonVisibility();

                if (!e.PrelaunchActivated)
                    Window.Current.Activate();

                new AppHelper();

                UpdateBackButtonVisibility();
            }
        }

        /// <summary>
        /// Обрабатывает событие аппаратной и экранной кнопок "Назад" внутри <see cref="ShellView"/>.
        /// </summary>
        /// <param name="sender">Объект-отправитель.</param>
        /// <param name="e">Передаваемые данные.</param>
        void OnBackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        /// <summary>
        /// Обрабатывает событие программной кнопки "Назад" внутри <see cref="ShellView"/>.
        /// </summary>
        /// <param name="sender">Объект-отправитель.</param>
        /// <param name="e">Передаваемые данные.</param>
        void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }

        }

        /// <summary>
        /// Обрабатывает событие навигации внутри <see cref="ShellView"/>.
        /// </summary>
        /// <param name="sender">Объект-отправитель.</param>
        /// <param name="e">Передаваемые данные.</param>
        void OnNavigated(object sender, NavigationEventArgs e)
        {
            UpdateBackButtonVisibility();
        }

        /// <summary>
        /// Управляет видимостью кнопки Back в панели заголовка окна.
        /// </summary>
        private void UpdateBackButtonVisibility()
        {
            AppViewBackButtonVisibility visibility = AppViewBackButtonVisibility.Collapsed;
            if (Frame.CanGoBack)
                visibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = visibility;
        }

        /// <summary>
        /// Текущая страница, отображая внутри <see cref="ShellView"/>.
        /// </summary>
        private Frame Frame => Locator.NavigationHelper.CurrentFrame;
    }
}