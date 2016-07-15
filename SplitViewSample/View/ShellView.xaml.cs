using SplitViewSample.Common;
using SplitViewSample.Helpers;
using SplitViewSample.ViewModel;
using Windows.UI.Xaml.Controls;

namespace SplitViewSample.View
{
    /// <summary>
    /// Представляет корневую страницу.
    /// </summary>
    public sealed partial class ShellView : Page, IBindableView<ShellViewModel>, INavigationHelper
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ShellView()
        {
            InitializeComponent();
            Locator.InitializeNavigationHelper(this);
        }

        /// <summary>
        /// Модель представления.
        /// </summary>
        public ShellViewModel ViewModel { get; set; } = new ShellViewModel();

        /// <summary>
        /// <see cref="Frame"/>, находящийся внутри обертки.
        /// </summary>
        public Frame CurrentFrame => frame;
    }
}