using Windows.UI.Xaml.Controls;

namespace SplitViewSample.View
{
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public string Label => "Model - View - ViewModel";
    }
}