using Windows.UI.Xaml.Controls;

namespace SplitViewSample.Pages
{
    /// <summary>
    /// Базовая страница.
    /// </summary>
    public class View : Page, IView
    {
        /// <summary>
        /// Ключ представления.
        /// </summary>
        public string Key
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
