using SplitViewSample.Model;
using SplitViewSample.Pages;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SplitViewSample
{
    /// <summary>
    /// Корневая страница.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        /// <summary>
        /// Список элементов бокового меню.
        /// </summary>
        private List<SplitViewItem> SplitViewItems = new List<SplitViewItem>(
            new[]
            {
                new SplitViewItem()
                {
                    Icon = "\uE80F",
                    Label = "Home"
                },
                new SplitViewItem()
                {
                    Icon = "\uE77B",
                    Label = "About me"
                }
            });

        /// <summary>
        /// Корневой Frame.
        /// </summary>
        public Frame AppFrame { get { return frame; } }

        /// <summary>
        /// Текущее содержимое.
        /// </summary>
        public static AppShell Current = null;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            // Заполняет боковое меню содержимым.
            listView.ItemsSource = SplitViewItems;
            // Задаёт навигацию к домашней странице.
            listView.SelectedIndex = 0;
            // Устанавливает навигацию назад.
            SystemNavigationManager.GetForCurrentView().BackRequested += AppShell_BackRequested;
        }

        /// <summary>
        /// Переход на предыдущую страницу в AppFrame.
        /// </summary>
        private void AppShell_BackRequested(object sender, BackRequestedEventArgs e)
        {
            bool handled = e.Handled;
            BackRequested(ref handled);
            e.Handled = handled;
        }

        /// <summary>
        /// Обработка навигации назад.
        /// </summary>
        /// <param name="handled">Используется для перехвата.</param>
        private void BackRequested(ref bool handled)
        {
            if (AppFrame == null)
                return;
            if (AppFrame.CanGoBack && !handled)
            {
                handled = true;
                AppFrame.GoBack();
            }
        }

        /// <summary>
        /// Событие, происходящее при нажатии на кнопку гамбургера.
        /// </summary>
        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
            if (!splitView.IsPaneOpen)
                ToolTipService.SetToolTip(hamburgerButton, "Maximize navigation pane");
            else
                ToolTipService.SetToolTip(hamburgerButton, "Minimize navigation pane");
        }

        /// <summary>
        /// Событие, происходящее при выборе элемента в боковом меню.
        /// </summary>
        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            hamburgerButton_Click(null, null);
        }

        /// <summary>
        /// Событие, происходящее при выборе иного элемента в боковом меню.
        /// </summary>
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (listView.SelectedIndex)
                {
                    case 0: AppFrame.Navigate(typeof(HomePage)); break;
                    case 1: AppFrame.Navigate(typeof(AboutMePage)); break;
                }
            }
            catch { }
        }

        /// <summary>
        /// Событие, происходящее при нажатии на кнопку настроек.
        /// </summary>
        private void settings_Click(object sender, RoutedEventArgs e)
        {
            listView.SelectedIndex = -1;
            AppFrame.Navigate(typeof(SettingsPage));
            hamburgerButton_Click(null, null);
        }

        /// <summary>
        /// Событие навигации AppFrame.
        /// </summary>
        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            // Показывает или скрывает кнопку Back.
            if (AppFrame.BackStack.Count > 0)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            // Выделяет предыдущий элемент в боковом меню.
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (e.SourcePageType == typeof(HomePage))
                    listView.SelectedIndex = 0;
                else if (e.SourcePageType == typeof(AboutMePage))
                    listView.SelectedIndex = 1;
                else if (e.SourcePageType == typeof(SettingsPage))
                    listView.SelectedIndex = -1;
            }
        }
    }
}
