using SFUListParser.Pages;
using SFUListParser.ViewModel;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SFUListParser
{
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel CompetitionListDataVM;

        public MainPage()
        {
            InitializeComponent();

            var dataPackage = new DataPackage();
            dataPackage.SetText(Path.Combine(ApplicationData.Current.LocalFolder.Path, "config.json"));

            Clipboard.SetContent(dataPackage);

            CompetitionListDataVM = MainPageViewModel.Init();
        }

        private void MainGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(ExtendedListDataPage),
                   e.ClickedItem,
                   new SlideNavigationTransitionInfo()
                   { Effect = SlideNavigationTransitionEffect.FromBottom });
        }

        private void AddButtonClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e) =>
            Frame.Navigate(typeof(CompetitionListDataEditPage));

        private void DeleteButtonClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e) =>
            CompetitionListDataVM.CompetitionLists.Remove(CompetitionListDataVM.CompetitionLists.Last());
    }
}