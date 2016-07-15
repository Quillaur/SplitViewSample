using SplitViewSample.Common;
using SplitViewSample.Model;
using SplitViewSample.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace SplitViewSample.ViewModel
{
    /// <summary>
    /// Представляет модель представления корневой страницы.
    /// </summary>
    public class ShellViewModel : ModelBase
    {
        private ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();
        private MenuItem selectedMenuItem;
        private ObservableCollection<MenuItem> bottomMenuItems = new ObservableCollection<MenuItem>();
        private MenuItem selectedBottomMenuItem;
        private bool isSplitViewPaneOpen;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ShellViewModel()
        {
            ToggleSplitViewPaneCommand = new Command(() => IsSplitViewPaneOpen = !IsSplitViewPaneOpen);

            MenuItems.Add(new MenuItem { Icon = "\uE10F", Title = "Домашняя страница", PageType = typeof(HomeView) });
            MenuItems.Add(new MenuItem { Icon = "\uE129", Title = "Ссылка 1", PageType = typeof(EmptyView) });
            MenuItems.Add(new MenuItem { Icon = "\uE14D", Title = "Ссылка 2", PageType = typeof(EmptyView2) });

            BottomMenuItems.Add(new MenuItem { Icon = "\uE115", Title = "Настройки", PageType = typeof(EmptyView3) });

            SelectedMenuItem = MenuItems.First();
        }

        /// <summary>
        /// Команда открытия гамбургер-меню.
        /// </summary>
        public ICommand ToggleSplitViewPaneCommand { get; private set; }

        /// <summary>
        /// Свойство открытости/закрытости гамбургер-меню.
        /// </summary>
        public bool IsSplitViewPaneOpen
        {
            get { return isSplitViewPaneOpen; }
            set { Set(ref isSplitViewPaneOpen, value); }
        }

        /// <summary>
        /// Текущий выбранный элемент в гамбургер-меню.
        /// </summary>
        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if (Set(ref selectedMenuItem, value) && value != null)
                    OnSelectedMenuItemChanged(true);
            }
        }

        /// <summary>
        /// Текущий выбранный элемент в нижней части гамбургер-меню.
        /// </summary>
        public MenuItem SelectedBottomMenuItem
        {
            get { return selectedBottomMenuItem; }
            set
            {
                if (Set(ref selectedBottomMenuItem, value) && value != null)
                    OnSelectedMenuItemChanged(false);
            }
        }

        /// <summary>
        /// Выбранная страница гамбургер-меню.
        /// </summary>
        public Type SelectedPageType
        {
            get { return (selectedMenuItem ?? selectedBottomMenuItem)?.PageType; }
            set
            {
                SelectedMenuItem = menuItems.FirstOrDefault(m => m.PageType == value);
                SelectedBottomMenuItem = bottomMenuItems.FirstOrDefault(m => m.PageType == value);
            }
        }

        /// <summary>
        /// Коллекция навигационных элементов.
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems => menuItems;

        /// <summary>
        /// Коллекция нижних навигационных элементов.
        /// </summary>
        public ObservableCollection<MenuItem> BottomMenuItems => bottomMenuItems;

        /// <summary>
        /// Срабатывает при изменении выделенного элемента.
        /// </summary>
        /// <param name="top">Основной или нижний список.</param>
        private void OnSelectedMenuItemChanged(bool top)
        {
            if (top)
                SelectedBottomMenuItem = null;
            else
                SelectedMenuItem = null;
            OnPropertyChanged(nameof(SelectedPageType));

            if (!IsWideState())
                IsSplitViewPaneOpen = false;
        }

        /// <summary>
        /// Растянутое ли окно или нет.
        /// </summary>
        /// <returns><see cref="true"/> или <see cref="false"/>.</returns>
        private bool IsWideState()
        {
            return Window.Current.Bounds.Width >= 1024;
        }
    }
}
