using SplitViewSample.Model;
using SplitViewSample.Pages;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

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
            ((CollectionViewSource)Resources["Items"]).Source = SplitViewItems;
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
            AppFrame.BackStack.Clear();
            AppFrame.Navigate(typeof(SettingsPage));
            hamburgerButton_Click(null, null);
        }
    }
}
