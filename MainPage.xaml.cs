using SFUListParser.ViewModel;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SFUListParser
{
    public sealed partial class MainPage : Page
    {
        private MainWindowViewModel mainWindowViewModel;

        public MainPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            mainWindowViewModel = new MainWindowViewModel();
        }

        private void MainGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(ExtendedListDataPage),
                   e.ClickedItem,
                   new SlideNavigationTransitionInfo()
                   { Effect = SlideNavigationTransitionEffect.FromBottom });
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            mainWindowViewModel.CompetitionListDatas.Remove(mainWindowViewModel.CompetitionListDatas.Last());
        }
    }
}
