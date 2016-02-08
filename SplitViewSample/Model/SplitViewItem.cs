namespace SplitViewSample.Model
{
    /// <summary>
    /// Модель элемента бокового меню.
    /// </summary>
    public class SplitViewItem
    {
        /// <summary>
        /// Иконка.
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Надпись.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Ключ представления.
        /// </summary>
        public string Key { get; set; }
    }
}
