using System;

namespace SplitViewSample.Model
{
    /// <summary>
    /// Модель элемента меню.
    /// </summary>
    public class MenuItem : ModelBase
    {
        private string _icon, _title;
        private Type _pageType;

        /// <summary>
        /// Строковый глиф иконки.
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { Set(ref _icon, value); }
        }

        /// <summary>
        /// Надпись.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        /// <summary>
        /// Страница, на которую ведет элемент.
        /// </summary>
        public Type PageType
        {
            get { return _pageType; }
            set { Set(ref _pageType, value); }
        }
    }
}